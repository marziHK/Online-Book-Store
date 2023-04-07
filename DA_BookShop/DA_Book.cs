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
    public class DA_Book
    {
        #region Feilds

        UsersContext db = new UsersContext();

        #endregion

        public bool InsertNewBook(EL_BookShop.tbl_BookInfo b, int BookCount, string BookPrice,
                                string NowHDate, DateTime mDAte, int CateID)
        {
            try
            {
                db = new UsersContext();

                db.tbl_BookInfo.Add(b);

                db.SaveChanges();

                int bID = b.fld_Id;

                db = new UsersContext();

                var q = new tbl_StoreRoom
                {
                    fld_BookID_fk = bID,
                    fld_CateID_fk = CateID,
                    fld_SalerUserID_fk = 1,
                    fld_Count = BookCount,
                    fld_Price = BookPrice,
                    fld_Date = NowHDate,
                    fld_MDate = mDAte,
                    fld_LastUpdateDate = NowHDate,
                    fld_LastUpdateMDate = mDAte,
                    fld_LastUpdateUserID_fk = 1,
                    fld_Status = 0,
                    fld_Shown = false
                };

                db.tbl_StoreRoom.Add(q);
                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    string nammee = eve.Entry.Entity.GetType().Name;
                    string statee = eve.Entry.State.ToString();

                    foreach (var ve in eve.ValidationErrors)
                    {
                        //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        //    ve.PropertyName, ve.ErrorMessage);
                        string prop = ve.PropertyName;
                        string err = ve.ErrorMessage;
                    }
                }
                return false;
            }
        }

        public List<EL_BookShop.tbl_StoreRoom> Get_AllBook()
        {
            db = new UsersContext();
            var q = (from x in db.tbl_StoreRoom
                     where x.fld_Status != 1 && x.fld_Shown == true
                     select x);

            return q.ToList();
        }



        public List<EL_BookShop.tbl_StoreRoom> Get_ShownBook()
        {
            db = new UsersContext();
            var q = (from x in db.tbl_StoreRoom
                     where x.fld_Status != 1 && x.fld_Shown == false
                     select x);

            return q.ToList();
        }

        public List<EL_BookShop.tbl_BookInfo> Get_ShownBookInfo()
        {
            db = new UsersContext();
            var q = (from x in db.tbl_BookInfo
                     where x.fld_Status != 1
                     select x);
            return q.ToList();

        }


        public bool SetBookShown(string StoreRoomIDs, string NowHDate, DateTime mDAte)
        {
            try
            {
                db = new UsersContext();
                foreach (string m in StoreRoomIDs.Split(','))
                {
                    int _id = Convert.ToInt32(m);
                    var q = (from x in db.tbl_StoreRoom
                             where x.fld_Id == _id
                             select x).FirstOrDefault();
                    if (q != null)
                    {
                        q.fld_LastUpdateDate = NowHDate;
                        q.fld_LastUpdateMDate = mDAte;
                        q.fld_LastUpdateUserID_fk = 1;
                        q.fld_Shown = true;
                    }
                }
                db.SaveChanges();

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    string nammee = eve.Entry.Entity.GetType().Name;
                    string statee = eve.Entry.State.ToString();

                    foreach (var ve in eve.ValidationErrors)
                    {
                        //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        //    ve.PropertyName, ve.ErrorMessage);
                        string prop = ve.PropertyName;
                        string err = ve.ErrorMessage;
                    }
                }
                return false;
            }
        }


        public EL_BookShop.tbl_BookInfo GetBookInfoByID(int bID)
        {
            db = new UsersContext();
            var q = (from x in db.tbl_BookInfo
                     where x.fld_Id == bID && x.fld_Status != 1
                     select x).FirstOrDefault();
            return q;
        }


        public EL_BookShop.tbl_StoreRoom GetStoreRoomByBookID(int bID)
        {
            var q = (from x in db.tbl_StoreRoom
                     where x.fld_Status != 1 && x.fld_BookID_fk == bID
                     select x).FirstOrDefault();

            return q;
        }


        public bool UpdateBookInfo(EL_BookShop.tbl_BookInfo b, EL_BookShop.tbl_StoreRoom s)
        {
            try
            {
                db = new UsersContext();

                int bookID = b.fld_Id;
                int StoreID = s.fld_Id;

                var q = (from x in db.tbl_BookInfo
                         where x.fld_Id == bookID
                         select x).FirstOrDefault();
                if (q != null)
                {
                    q.fld_LastUpdateDate = b.fld_LastUpdateDate;
                    q.fld_LastUpdateMDate = b.fld_LastUpdateMDate;
                    q.fld_LastUpdateUserID_fk = b.fld_LastUpdateUserID_fk;
                    q.fld_Status = 2;
                    q.fld_Author = b.fld_Author;
                    // q.fld_Image = b.fld_Image;
                    q.fld_Translator = b.fld_Translator;
                }


                var w = (from n in db.tbl_StoreRoom
                         where n.fld_Id == StoreID
                         select n).FirstOrDefault();
                if (w != null)
                {
                    w.fld_LastUpdateDate = s.fld_LastUpdateDate;
                    w.fld_LastUpdateMDate = s.fld_LastUpdateMDate;
                    w.fld_LastUpdateUserID_fk = s.fld_LastUpdateUserID_fk;
                    w.fld_Status = 2;
                    w.fld_Count = s.fld_Count;
                    w.fld_Price = s.fld_Price;
                    w.fld_Shown = s.fld_Shown;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool DeleteBookInfo(int _id, string NowHDate, DateTime mDAte)
        {
            try
            {
                db = new UsersContext();

                var q = (from x in db.tbl_StoreRoom
                         where x.fld_Status != 1 && x.fld_Id == _id
                         select x).FirstOrDefault();
                if (q != null)
                {
                    q.fld_LastUpdateDate = NowHDate;
                    q.fld_LastUpdateMDate = mDAte;
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



        public List<EL_BookShop.tbl_StoreRoom> Last4Book()
        {
            try
            {
                db = new UsersContext();

                var q = (from x in db.tbl_StoreRoom
                         where x.fld_Status != 1
                         orderby x.fld_Date descending
                         select x).Take(4);

                return q.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<EL_BookShop.tbl_StoreRoom> LastWeekBooks(string fd, string td)
        {
            try
            {
                db = new UsersContext();

                var q = (from x in db.tbl_StoreRoom
                         where x.fld_Status != 1 && x.fld_Date.CompareTo(fd) >= 0 && x.fld_Date.CompareTo(td) <= 0
                         orderby x.fld_Date descending
                         select x);

                return q.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
