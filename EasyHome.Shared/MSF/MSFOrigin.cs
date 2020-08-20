using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public enum MSFOrigin
    {
        [Display(Name = "Select...")] 
        None = 0,
        Bio = 1,
        Mystic = 2,
        Skill = 3,
        Tech = 4,
        Mutant = 5
    }
}
