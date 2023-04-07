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
    public class tbl_Roles
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int fld_ID { get; set; }


        //public int fld_RoleID { get; set; }


        [MaxLength(15)]
        public string fld_Role { get; set; }
    }
}
