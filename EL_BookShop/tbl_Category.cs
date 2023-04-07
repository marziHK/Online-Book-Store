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
    public class tbl_Category : IEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fld_Id { get; set; }


        [MaxLength(30)]
        [DisplayName("نام دسته بندی")]
        [Required(ErrorMessage = "الزامیست")]
        public string fld_CateName { get; set; }

        [StringLength(10)]
        [HiddenInput(DisplayValue = false)]
        [DisplayName("تاریخ ثبت")]
        public string fld_Date { get; set; }


        [HiddenInput(DisplayValue = false)]
        public DateTime fld_MDate { get; set; }


        [StringLength(10)]
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
