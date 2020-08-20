using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public enum MSFJurisdiction
    {
        [Display(Name = "Select...")]
        None = 0,
        Global = 1,
        City = 2,
        Cosmic = 3
    }
}
