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
    public class HomeController : Controller
    {

        #region Feilds

        BL_Category obj_Cate = new BL_Category();
        BL_Book obj_Book = new BL_Book();
        BL_BaseInfo obj_Base = new BL_BaseInfo();
        //BL_User obj_User = new BL_User();
        #endregion



        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }









        public ActionResult Home()
        {
            obj_Book = new BL_Book();
            EL_BookShop.ViewModel.Home.Books q = obj_Book.Top4BookInfo();
            return View(q);
        }



        public ActionResult NewBooks()
        {
            obj_Book = new BL_Book();
            EL_BookShop.ViewModel.Home.Books q = obj_Book.ThisWeekBook();
            return View(q);
        }

        public ActionResult BookInfo(int _id)
        {
            obj_Book = new BL_Book();
            var q = new EL_BookShop.ViewModel.Admin.Book_Detail();
            q = obj_Book.GetBookDetail(_id);
            return View(q);
        }



    }
}
