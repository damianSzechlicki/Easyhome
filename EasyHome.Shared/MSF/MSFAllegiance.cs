using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public enum MSFAllegiance
    {
        [Display(Name = "Select...")]
        None = 0,
        Hero = 1,
        Villain = 2,
    }
}
