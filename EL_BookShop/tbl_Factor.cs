//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_BookShop.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using EL_BookShop;

namespace EL_BookShop
{
    public class tbl_Factor : IEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int fld_Id { get; set; }

        public string fld_Address { get; set; }

        public string fld_UserEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string fld_UserPhone { get; set; }

        public int fld_BookCount { get; set; }

        //public virtual tbl_StoreRoom fld_StoreRoomID_fk { get; set; }



        [HiddenInput(DisplayValue = false)]
        public string fld_Date { get; set; }


        [HiddenInput(DisplayValue = false)]
        public DateTime fld_MDate { get; set; }


        [HiddenInput(DisplayValue = false)]
        public string fld_LastUpdateDate { get; set; }


        [HiddenInput(DisplayValue = false)]
        public DateTime? fld_LastUpdateMDate { get; set; }


        [HiddenInput(DisplayValue = false)]
        public int? fld_LastUpdateUserID_fk { get; set; }


        [HiddenInput(DisplayValue = false)]
        public short fld_Status { get; set; }
    }
}
