using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Brigita.Dom.Bits;

namespace Brigita.Web
{
    public static class HtmlHelpers
    {
        
        public static string Currency(this HtmlHelper html, CurrencyValue currValue) 
        {
            if(currValue == null) return "";
            
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var numberFormat = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();

            switch(currValue.Code) {
                case "EUR":
                    numberFormat.CurrencySymbol = "€";
                    break;
                case "USD":
                    numberFormat.CurrencySymbol = "$";
                    break;
                case "GBP":
                    numberFormat.CurrencySymbol = "£";
                    break;
            }

            return currValue.Amount.ToString("C", numberFormat);
        }




    }
}