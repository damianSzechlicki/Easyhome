using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public enum MSFCharacterClass
    {
        [Display(Name = "Select...")]
        None = 0,
        Protector = 1,
        Brawler = 2,
        Blaster = 3,
        Controller = 4,
        Support = 5
    }
}
