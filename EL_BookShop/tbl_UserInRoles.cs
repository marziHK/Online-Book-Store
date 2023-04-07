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
using System.ComponentModel.DataAnnotations.Schema;

namespace EL_BookShop
{
    public class tbl_UserInRoles
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fld_ID { get; set; }


        public int fld_UserID_fk { get; set; }


        public int fld_RoleID_fk { get; set; }

        [StringLength(10)]
        [HiddenInput(DisplayValue = false)]
        [DisplayName("تاریخ ثبت")]
        public string fld_Date { get; set; }

        [StringLength(10)]
        [HiddenInput(DisplayValue = false)]
        public string fld_LastUpdateDate { get; set; }


        [HiddenInput(DisplayValue = false)]
        public short fld_Status { get; set; }
    }
}
