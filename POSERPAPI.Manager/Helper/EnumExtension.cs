//using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Helper
{
    public static class EnumExtension<T>
    {
        //usage: var lst =  Enum<myenum>.GetSelectList();
        //public static List<SelectListItem> GetSelectList()
        //{
        //    return Enum.GetValues(typeof(T))
        //            .Cast<object>()
        //            .Select(i => new SelectListItem()
        //            {
        //                Value = ((int)i).ToString()
        //                          ,
        //                Text = i.ToString()
        //            })
        //            .ToList();
        //}

    }
}
