//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_BookShop;
using System.Data.Entity.Validation;

namespace DA_BookShop
{
    public class DA_User
    {
        #region Feilds

        Context db = new Context();

        #endregion



        public string Login(string usr, string pswrd)
        {
            string res = "";
            try
            {
                db = new Context();
                var q = (from x in db.tbl_UserInfo
                         where x.fld_Status != 1 && x.fld_PassWord == pswrd && x.fld_UserName == usr
                         select x).FirstOrDefault();

                if (q != null)
                {
                    res = q.fld_Id.ToString() + "@" + q.fld_RoleID_fk.ToString();
                }

            }
            catch (Exception ex)
            {
                res = "ct";
            }

            return res;
        }

    }
}
