//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_BookShop;


namespace BL_BookShop
{
    public class BL_BaseInfo
    {
        #region Feilds

        public static string NowHdate;
        ClsDate obj_Date = new ClsDate();

        #endregion


        public string GetToday()
        {
            return obj_Date.Today();
        }


    }
}
