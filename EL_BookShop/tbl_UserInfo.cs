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
    public class tbl_UserInfo : IEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fld_Id { get; set; }

        public int fld_RoleID_fk { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "الزامیست")]
        [MaxLength(30)]
        public string fld_FName { get; set; }


        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "الزامیست")]
        [MaxLength(70)]
        public string fld_LName { get; set; }


        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "الزامیست")]
        [MaxLength(20)]
        public string fld_UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "الزامیست")]
        [StringLength(100, ErrorMessage = "کلمه عبور حداقل باید 4 حرفی باشد", MinimumLength = 4)]
        public string fld_PassWord { get; set; }


        [DataType(DataType.EmailAddress)]
        [DisplayName("پست الکترونیکی")]
        [Required(ErrorMessage = "الزامیست")]
        [MaxLength(50)]
        public string fld_Email { get; set; }



        [HiddenInput(DisplayValue = false)]
        [StringLength(10)]
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
