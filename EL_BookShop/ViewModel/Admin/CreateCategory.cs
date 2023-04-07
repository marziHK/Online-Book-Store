//بسم الله الرحمن الرحیم
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BookShop.ViewModel.Admin
{
   public class CreateCategory
    {
       [MaxLength(30)]
       [DisplayName("نام دسته بندی")]
       [Required(ErrorMessage = "الزامیست")]
       public string fld_CateName { get; set; }


       [StringLength(10)]
       public string fld_Date { get; set; }


       public DateTime fld_MDate { get; set; }


       [StringLength(10)]
       public string fld_LastUpdateDate { get; set; }

       public DateTime? fld_LastUpdateMDate { get; set; }


       public int? fld_LastUpdateUserID_fk { get; set; }


       public short fld_Status { get; set; }
    }
}
