﻿namespace System.Web.Mvc {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal sealed class ControllerTypeCache {

        private Dictionary<string, ILookup<string, Type>> _cache;
        private object _lockObj = new object();

        internal int Count {
            get {
                int count = 0;
                foreach (var lookup in _cache.Values) {
                    foreach (var grouping in lookup) {
                        count += grouping.Count();
                    }
                }
                return count;
            }
        }

        public void EnsureInitialized(IBuildManager buildManager) {
            if (_cache == null) {
                lock (_lockObj) {
                    if (_cache == null) {
                        List<Type> controllerTypes = GetAllControllerTypes(buildManager);
                        var groupedByName = controllerTypes.GroupBy(
                            t => t.Name.Substring(0, t.Name.Length - "Controller".Length),
                            StringComparer.OrdinalIgnoreCase);
                        _cache = groupedByName.ToDictionary(
                            g => g.Key,
                            g => g.ToLookup(t => t.Namespace ?? String.Empty, StringComparer.OrdinalIgnoreCase),
                            StringComparer.OrdinalIgnoreCase);
                    }
                }
            }
        }

        private static List<Type> GetAllControllerTypes(IBuildManager buildManager) {
            // Go through all assemblies referenced by the application and search for
            // controllers and controller factories.
            List<Type> controllerTypes = new List<Type>();
            ICollection assemblies = buildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies) {
                Type[] typesInAsm;
                try {
                    typesInAsm = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex) {
                    typesInAsm = ex.Types;
                }
                controllerTypes.AddRange(typesInAsm.Where(IsControllerType));
            }
            return controllerTypes;
        }

        public IList<Type> GetControllerTypes(string controllerName, HashSet<string> namespaces) {
            List<Type> matchingTypes = new List<Type>();

            ILookup<string, Type> nsLookup;
            if (_cache.TryGetValue(controllerName, out nsLookup)) {
                // this friendly name was located in the cache, now cycle through namespaces
                if (namespaces != null) {
                    foreach (string ns in namespaces) {
                        matchingTypes.AddRange(nsLookup[ns]);
                    }
                }
                else {
                    // if the namespaces parameter is null, search *every* namespace
                    foreach (var nsGroup in nsLookup) {
                        matchingTypes.AddRange(nsGroup);
                    }
                }
            }

            return matchingTypes;
        }

        internal static bool IsControllerType(Type t) {
            return
                t != null &&
                t.IsPublic &&
                t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) &&
                !t.IsAbstract &&
                typeof(IController).IsAssignableFrom(t);
        }
    }
}