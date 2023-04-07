//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BookShop.ViewModel.Admin
{
    public class Book_Detail
    {
        public tbl_BookInfo BookInfo { get; set; }

        public tbl_StoreRoom StoreRoom { get; set; }

        public tbl_Category Category { get; set; }
    }
}
