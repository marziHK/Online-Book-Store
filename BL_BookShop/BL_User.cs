//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_BookShop;


namespace BL_BookShop
{
    public class BL_User
    {
        #region Feilds

        DA_User obj_User;
        ClsDate obj_Date = new ClsDate();
        string NowDate;

        #endregion




        public bool Login(EL_BookShop.ViewModel.Home.LoginModel m)
        {
            obj_User = new DA_User();
            string[] res;

            string pm = obj_User.Login(m.UserName.ToString().Trim(), m.Password.ToString().Trim());
            if (pm != "ct" && pm !="")
            {
                res = pm.Split('@');
                if (res[0]!="0")
                {
                    //ورود
                    //res[0] == ایدی
                    //res[1] == نقش
                    return true;
                }
                else
                {
                        //اشتباه
                    return false;
                }
            }
            else
            {
                //اشتباه
                return false;
            }
        }
    }
}
