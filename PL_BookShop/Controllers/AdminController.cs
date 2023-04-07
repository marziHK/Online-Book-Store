//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EL_BookShop;
using BL_BookShop;

namespace PL_BookShop.Controllers
{
    public class AdminController : Controller
    {
        #region Feilds

        BL_Category obj_Cate = new BL_Category();
        BL_Book obj_Book = new BL_Book();
        BL_BaseInfo obj_Base = new BL_BaseInfo();

        #endregion

        public ActionResult Index()
        {
            if (Request.Files.Count > 0)
            { }
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            return View();
        }



        #region دسته بندی ها

        public ActionResult Category_ManagePanel()
        {
            return View();
        }

        public ActionResult Category_ShowAll()
        {
            return View(obj_Cate.GetAllCategoris());
        }

        public ActionResult Category_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Category_Create(EL_BookShop.tbl_Category c)
        {
            if (ModelState.IsValid)
            {
                obj_Cate = new BL_Category();
                if (obj_Cate.InsertNewCate(c))
                {
                    return RedirectToAction("Category_ShowAll");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Category_Detail(int id)
        {
            obj_Cate = new BL_Category();
            return View(obj_Cate.GetCategoryByID(id));
        }

        public ActionResult Category_Edit(int id)
        {
            obj_Cate = new BL_Category();
            return View(obj_Cate.GetCategoryByID(id));
        }

        [HttpPost]
        public ActionResult Category_Edit(EL_BookShop.tbl_Category c)
        {
            int _id = c.fld_Id;
            string _cName = c.fld_CateName;
            if (ModelState.IsValid)
            {
                obj_Cate = new BL_Category();
                bool res = obj_Cate.UpdateCategoryByID(_id, _cName);
                if (res)
                {
                    return RedirectToAction("Category_ShowAll");

                }
                else
                {
                    return View(obj_Cate.GetCategoryByID(_id));
                }
            }
            else
            {
                return View(obj_Cate.GetCategoryByID(_id));
            }
        }

        public ActionResult Category_Delete(int id)
        {
            obj_Cate = new BL_Category();
            bool res = obj_Cate.DeleteCategory(id);
            if (res)
            {
                return RedirectToAction("Category_ShowAll");
            }
            else
            {
                return View(obj_Cate.GetCategoryByID(id));
            }
        }


        #endregion



        #region کتاب

        public ActionResult Book_ManagePanel()
        {
            return View();
        }

        public ActionResult Book_Create()
        {
            obj_Cate = new BL_Category();
            var li = new List<SelectListItem>();
            var list = new List<EL_BookShop.tbl_Category>();
            list = obj_Cate.GetAllCategoris();
            for (int i = 0; i < list.Count; i++)
            {
                li.Add(new SelectListItem() { Text = list[i].fld_CateName, Value = list[i].fld_Id.ToString() });
            }
            ViewData["Category"] = li;

            return View();
        }

        [HttpPost]
        public ActionResult Book_Create(EL_BookShop.tbl_BookInfo b, HttpPostedFileBase file)
        {
            //if (ModelState.IsValid)
            //{
            if (Request.Files.Count > 0)
            {
                string name = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour + DateTime.Now.Minute.ToString() + "-" + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/BookImages/" + name));
                b.fld_Image = "/Content/BookImages/" + name;

                string Cate = Request.Form["Category"].ToString();
                string BookCount = Request.Form["BookCount"].ToString();
                string BookPrice = Request.Form["BookPrice"].ToString();

                obj_Book = new BL_Book();
                obj_Book.InsertNewBook(b, BookCount, BookPrice, Cate);
            }
            //}
            //else
            //{

            //}
            obj_Cate = new BL_Category();
            var li = new List<SelectListItem>();
            var list = new List<EL_BookShop.tbl_Category>();
            list = obj_Cate.GetAllCategoris();
            for (int i = 0; i < list.Count; i++)
            {
                li.Add(new SelectListItem() { Text = list[i].fld_CateName, Value = list[i].fld_Id.ToString() });
            }
            ViewData["Category"] = li;

            //return View();
            return RedirectToAction("Book_Shown");
        }



        public ActionResult Book_Shown()
        {
            obj_Cate = new BL_Category();
            obj_Book = new BL_Book();
            var ModelShown = new EL_BookShop.ViewModel.Admin.Book_Shown();
            ModelShown.Category = obj_Cate.GetAllCategoris();
            ModelShown.StoreRoom = obj_Book.Get_ShownBook();
            ModelShown.BookInfo = obj_Book.Get_ShownBookInfo();
            return View(ModelShown);
        }

        [HttpPost]
        public ActionResult Book_Shown(FormCollection coll)
        {
            obj_Book = new BL_Book();
            string tst = Request.Form["fld_Shown"];
            if (!(string.IsNullOrEmpty(tst)))
            {
                bool pm = obj_Book.SetBookShown(tst);
                if (pm)
                    return RedirectToAction("Book_ManagePanel");
                else
                    return RedirectToAction("Book_Shown");

            }
            else
            {
                return RedirectToAction("Book_Shown");
            }
        }


        public ActionResult Book_Detail(int _id)
        {
            obj_Book = new BL_Book();
            var q = new EL_BookShop.ViewModel.Admin.Book_Detail();
            q = obj_Book.GetBookDetail(_id);
            return View(q);
        }


        public ActionResult Book_Edit(int _id)
        {
            obj_Book = new BL_Book();
            var q = new EL_BookShop.ViewModel.Admin.Book_Detail();
            q = obj_Book.GetBookDetail(_id);
            string selectedval = q.Category.fld_Id.ToString();

            #region For ddlCate
            var li = new List<SelectListItem>();
            var list = new List<EL_BookShop.tbl_Category>();
            list = obj_Cate.GetAllCategoris();
            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 == Convert.ToInt32(selectedval))
                {
                    li.Add(new SelectListItem() { Text = list[i].fld_CateName, Value = list[i].fld_Id.ToString(), Selected = true });

                }
                else
                    li.Add(new SelectListItem() { Text = list[i].fld_CateName, Value = list[i].fld_Id.ToString() });
            }


            //ViewData["Category"] = new SelectList(li, "fld_Id", "fld_CateName", selectedval);
            ViewData["Category"] = li;
            #endregion



            return View(q);
        }


        [HttpPost]
        public ActionResult Book_Edit(EL_BookShop.ViewModel.Admin.Book_Detail m/*, HttpPostedFileBase file*/)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string name = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour + DateTime.Now.Minute.ToString() + "-" + file.FileName;
            //    file.SaveAs(Server.MapPath("~/Content/BookImages/" + name));
            //    m.BookInfo.fld_Image = "/Content/BookImages/" + name;

            int bokID = Convert.ToInt32(Request.Form["BookId"].ToString());
            m.BookInfo.fld_Id = bokID;

            int sID = Convert.ToInt32(Request.Form["StoreId"].ToString());
            m.StoreRoom.fld_Id = sID;
            //}
            obj_Book = new BL_Book();
            bool pm = obj_Book.UpdateBookInfo(m);
            if (pm)
            {
                return RedirectToAction("Book_ManagePanel");
            }
            else
            {
                return View(m.BookInfo.fld_Id);
            }
        }


        public ActionResult Book_Delete(int id)
        {
            obj_Book = new BL_Book();
            bool pm = obj_Book.DeleteBookInfo(id);
            //if (pm)
            //{
                return RedirectToAction("Book_ManagePanel");
            //}
            //else
            //{
                //return View();
            //}
        }


        public ActionResult Book_Log1()
        {

            ViewData["NowDate"] = obj_Base.GetToday(); 

            obj_Cate = new BL_Category();
            var li = new List<SelectListItem>();
            var list = new List<EL_BookShop.tbl_Category>();
            list = obj_Cate.GetAllCategoris();
            for (int i = 0; i < list.Count; i++)
            {
                li.Add(new SelectListItem() { Text = list[i].fld_CateName, Value = list[i].fld_Id.ToString() });
            }
            ViewData["Category"] = li;

            return View();
        }

        //[HttpPost]
        //public ActionResult Book_Log1()
        //{ 
        
        //}


        public ActionResult Book_GetAll()
        {
            obj_Cate = new BL_Category();
            obj_Book = new BL_Book();
            var ModelShown = new EL_BookShop.ViewModel.Admin.Book_Shown();
            ModelShown.Category = obj_Cate.GetAllCategoris();
            ModelShown.StoreRoom = obj_Book.Get_AllBook();
            ModelShown.BookInfo = obj_Book.Get_ShownBookInfo();
            return View(ModelShown);
        }

        #endregion

    }
}
