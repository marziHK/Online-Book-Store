//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_BookShop;

namespace DA_BookShop
{
    public class DA_Category
    {
        #region Feilds

        UsersContext db = new UsersContext();

        #endregion


        public List<EL_BookShop.tbl_Category> GetAllCategoris()
        {
            db = new UsersContext();
            var q = (from x in db.tbl_Category
                     where x.fld_Status != 1
                     select x);

            return q.ToList();
        }

        public bool InsertNewCate(tbl_Category c)
        {
            try
            {
                db = new UsersContext();
                db.tbl_Category.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public EL_BookShop.tbl_Category GetCategoryByID(int id)
        {
            db = new UsersContext();
            var q = (from x in db.tbl_Category
                     where x.fld_Id == id && x.fld_Status != 1
                     select x).FirstOrDefault();
            return q;
        }

        public bool UpdateCategoryByID(int id, string cName,string NowDate)
        {
            try
            {
                db = new UsersContext();
                var q = (from x in db.tbl_Category
                         where x.fld_Id == id && x.fld_Status != 1
                         select x).FirstOrDefault();
                if (q!=null)
                {
                    q.fld_CateName = cName;
                    q.fld_LastUpdateDate = NowDate;
                    q.fld_LastUpdateMDate = DateTime.Now;
                    q.fld_LastUpdateUserID_fk = 1;
                    q.fld_Status = 2;
                }
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool DeleteCategory(int id,string NowDate,DateTime NowMDate)
        {
            try
            {
                db = new UsersContext();
                var q = (from x in db.tbl_Category
                         where x.fld_Id == id && x.fld_Status != 1
                         select x).FirstOrDefault();
                if (q != null)
                {
                    q.fld_LastUpdateDate = NowDate;
                    q.fld_LastUpdateMDate = NowMDate;
                    q.fld_LastUpdateUserID_fk = 1;
                    q.fld_Status = 1;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public int GetCateIDbyName(string CateName)
        {
            try
            {
                int q = db.tbl_Category.Where(x => x.fld_Status != 1 && x.fld_CateName == CateName).Select(x => x.fld_Id).FirstOrDefault();
                return q;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
