using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelInvatare.Common
{
    public static class TipCameraSelectie
    {
        public static SelectList Selectii()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Standard",
                Value = "Standard"
            });
            list.Add(new SelectListItem()
            {
                Text = "Executive",
                Value = "Executive"
            });
            return new SelectList(list, "Value", "Text");
        }
    }
}