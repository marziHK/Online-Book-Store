//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_BookShop;

namespace BL_BookShop
{
    public class BL_Book
    {
        #region Feilds

        DA_Book obj_Book;
        DA_Category obj_cate;
        ClsDate obj_Date = new ClsDate();
        string NowDate;

        #endregion

        public bool InsertNewBook(EL_BookShop.tbl_BookInfo b, string BookCount, string BookPrice, string CateID)
        {
            DateTime mDate = DateTime.Now;
            NowDate = obj_Date.Today();
            obj_Book = new DA_Book();
            obj_cate = new DA_Category();

            b.fld_Date = NowDate;
            b.fld_LastUpdateDate = NowDate;
            b.fld_LastUpdateMDate = mDate;
            b.fld_MDate = mDate;
            b.fld_Status = 0;
            b.fld_LastUpdateUserID_fk = 1;


            //int CateID = obj_cate.GetCateIDbyName(CateName);

            return obj_Book.InsertNewBook(b, Convert.ToInt32(BookCount), BookPrice, NowDate, mDate, Convert.ToInt32(CateID));
        }


        public List<EL_BookShop.tbl_StoreRoom> Get_AllBook()
        {
            obj_Book = new DA_Book();
            return obj_Book.Get_AllBook();
        }

        public List<EL_BookShop.tbl_StoreRoom> Get_ShownBook()
        {
            obj_Book = new DA_Book();
            return obj_Book.Get_ShownBook();
        }

        public List<EL_BookShop.tbl_BookInfo> Get_ShownBookInfo()
        {
            obj_Book = new DA_Book();
            return obj_Book.Get_ShownBookInfo();
        }

        public bool SetBookShown(string StoreRoomIDs)
        {
            obj_Book = new DA_Book();
            DateTime mDate = DateTime.Now;
            NowDate = obj_Date.Today();
            return obj_Book.SetBookShown(StoreRoomIDs, NowDate, mDate);
        }


        public EL_BookShop.tbl_BookInfo GetBookInfoByID(int bID)
        {
            obj_Book = new DA_Book();
            return obj_Book.GetBookInfoByID(bID);
        }


        public EL_BookShop.tbl_StoreRoom GetStoreRoomByBookID(int bID)
        {
            obj_Book = new DA_Book();
            return obj_Book.GetStoreRoomByBookID(bID);
        }

        public EL_BookShop.ViewModel.Admin.Book_Detail GetBookDetail(int bID)
        {
            obj_cate = new DA_Category();

            var q = new EL_BookShop.ViewModel.Admin.Book_Detail();
            q.BookInfo = GetBookInfoByID(bID);
            q.StoreRoom = obj_Book.GetStoreRoomByBookID(bID);
            int CatID = q.StoreRoom.fld_CateID_fk;
            q.Category = obj_cate.GetCategoryByID(CatID);

            return q;
        }


        public bool UpdateBookInfo(EL_BookShop.ViewModel.Admin.Book_Detail m)
        {
            obj_Book = new DA_Book();
            DateTime mDate = DateTime.Now;
            NowDate = obj_Date.Today();

            m.BookInfo.fld_LastUpdateDate = NowDate;
            m.BookInfo.fld_LastUpdateMDate = mDate;
            m.BookInfo.fld_LastUpdateUserID_fk = 1;
            m.BookInfo.fld_Status = 2;

            m.StoreRoom.fld_LastUpdateDate = NowDate;
            m.StoreRoom.fld_LastUpdateMDate = mDate;
            m.StoreRoom.fld_LastUpdateUserID_fk = 1;
            m.StoreRoom.fld_Status = 2;

            m.StoreRoom.fld_Date = "test";
            m.BookInfo.fld_Date = "test";
            m.BookInfo.fld_Image = "tst";


            return obj_Book.UpdateBookInfo(m.BookInfo, m.StoreRoom);
        }

        public bool DeleteBookInfo(int _id)
        {
            obj_cate = new DA_Category();
            DateTime mDate = DateTime.Now;
            NowDate = obj_Date.Today();

            return obj_Book.DeleteBookInfo(_id, NowDate, mDate);
        }


        public EL_BookShop.ViewModel.Home.Books Top4BookInfo()
        {

            obj_Book = new DA_Book();
            obj_cate = new DA_Category();

            var q = new List<EL_BookShop.tbl_StoreRoom>();
            q = obj_Book.Last4Book();

            var b = new List<EL_BookShop.tbl_BookInfo>();
            var c = new List<EL_BookShop.tbl_Category>();

            try
            {
                if (q.Any())
                {
                    q.ForEach(adder =>
                    {
                        b.Add(obj_Book.GetBookInfoByID(Convert.ToInt32(adder.fld_BookID_fk)));
                        c.Add(obj_cate.GetCategoryByID(Convert.ToInt32(adder.fld_CateID_fk)));
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            var res = new EL_BookShop.ViewModel.Home.Books();
            res.BookInfo = b;
            res.Category = c;
            res.StoreRoom = q;
            return res;
        }



        public EL_BookShop.ViewModel.Home.Books ThisWeekBook()
        {
            NowDate = obj_Date.Today();
            string LastWeek;

            int dayy = Convert.ToInt32(NowDate.Substring(8, 2));
            if (dayy > 7)
            {
                LastWeek = NowDate.Substring(0, 8) + Convert.ToString(dayy - 7);
            }
            else
            {
                LastWeek = NowDate.Substring(0, 5) + Convert.ToString(Convert.ToInt32(NowDate.Substring(8, 2)) - 1) + "/" + Convert.ToString(30 - 4 + dayy);
            }

            obj_Book = new DA_Book();
            obj_cate = new DA_Category();

            var q = new List<EL_BookShop.tbl_StoreRoom>();
            q = obj_Book.LastWeekBooks(LastWeek, NowDate);

            var b = new List<EL_BookShop.tbl_BookInfo>();
            var c = new List<EL_BookShop.tbl_Category>();
            c = obj_cate.GetAllCategoris();
            try
            {
                if (q.Any())
                {
                    q.ForEach(adder =>
                    {
                        b.Add(obj_Book.GetBookInfoByID(Convert.ToInt32(adder.fld_BookID_fk)));
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            var res = new EL_BookShop.ViewModel.Home.Books();
            res.BookInfo = b;
            res.Category = c;
            res.StoreRoom = q;
            return res;
        }


    }
}
