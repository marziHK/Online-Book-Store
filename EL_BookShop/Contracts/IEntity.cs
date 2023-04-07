using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EL_BookShop.Contracts
{
    public interface IEntity
    {
        [HiddenInput(DisplayValue = false)]
         int fld_Id { get; set; }

        [HiddenInput(DisplayValue = false)]
         Int16 fld_Status { get; set; }

        [HiddenInput(DisplayValue = false)]
         string fld_Date { get; set; }

        [HiddenInput(DisplayValue = false)]
        string fld_LastUpdateDate { get; set; }

        //[HiddenInput(DisplayValue = false)]
        // int? fld_LastUpdateUserID_fk { get; set; }

        [HiddenInput(DisplayValue = false)]
         DateTime fld_MDate { get; set; }

        //[HiddenInput(DisplayValue = false)]
        // DateTime? fld_LastUpdateMDate { get; set; }

    }
}
