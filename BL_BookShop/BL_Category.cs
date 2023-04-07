//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_BookShop;

namespace BL_BookShop
{
    public class BL_Category
    {
        #region Feilds

        DA_Category obj_Cate;
        ClsDate obj_Date = new ClsDate();
        string NowDate;

        #endregion


        public List<EL_BookShop.tbl_Category> GetAllCategoris()
        {
            obj_Cate = new DA_Category();
            return obj_Cate.GetAllCategoris();
        }


        public bool InsertNewCate(EL_BookShop.tbl_Category c)
        {
            obj_Cate = new DA_Category();

            NowDate = obj_Date.Today();
            c.fld_Date = NowDate;
            c.fld_LastUpdateDate = NowDate;
            c.fld_LastUpdateUserID_fk = 1;
            c.fld_LastUpdateMDate = DateTime.Now;
            c.fld_MDate = DateTime.Now;
            c.fld_Status = 0;
            bool x = obj_Cate.InsertNewCate(c);
            return x;
        }


        public EL_BookShop.tbl_Category GetCategoryByID(int id)
        {
            obj_Cate = new DA_Category();
            return obj_Cate.GetCategoryByID(id);
        }

        public bool UpdateCategoryByID(int id, string cName)
        {
            obj_Cate = new DA_Category();
            NowDate = obj_Date.Today();

            return obj_Cate.UpdateCategoryByID(id, cName, NowDate);
        }

        public bool DeleteCategory(int id)
        {
            obj_Cate = new DA_Category();
            NowDate = obj_Date.Today();
            DateTime mDate = DateTime.Now;

            return obj_Cate.DeleteCategory(id, NowDate, mDate);
        }
    }
}
