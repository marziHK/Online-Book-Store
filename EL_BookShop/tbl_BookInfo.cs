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
    public class tbl_BookInfo : IEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fld_Id { get; set; }

        [DisplayName("نام کتاب")]
        [MaxLength(50)]
        [Required(ErrorMessage = "الزامیست")]
        public string fld_BookName { get; set; }

        [MaxLength(80)]
        [DisplayName("نویسنده")]
        [Required(ErrorMessage = "الزامیست")]
        public string fld_Author { get; set; }

        [MaxLength(50)]
        [DisplayName("مترجم")]
        public string fld_Translator { get; set; }

        [MaxLength(50)]
        [DisplayName("انتشارات")]
        [Required(ErrorMessage = "الزامیست")]
        public string fld_Publisher { get; set; }

        [StringLength(4)]
        [DisplayName("سال چاپ")]
        public string fld_PublishYear { get; set; }

        [MaxLength(50)]
        [DisplayName("تصویر")]
        [Required(ErrorMessage = "الزامیست")]
        public string fld_Image { get; set; }


        [StringLength(10)]
        [DisplayName("تاریخ ثبت")]
        [HiddenInput(DisplayValue = false)]
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
