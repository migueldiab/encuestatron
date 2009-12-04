using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
  public static class DatePickerExtension
  {
    public static string DatePicker(this HtmlHelper htmlHelper, string name, string value)
    {
      return "<script type=\"text/javascript\">" +
               "$(function() {" +
               "$(\"#" + name + "\").datepicker({ dateFormat: 'dd/mm/yy' });" +
               "});" +
               "</script>" +
               "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";
    }
  }
}

