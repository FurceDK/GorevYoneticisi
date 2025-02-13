using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GorevYoneticisi.Models
{
    public enum Durum
    {
        [Display(Name = "Bekliyor")]
        Bekliyor = 0,

        [Display(Name = "Devam Ediyor")]
        DevamEdiyor = 1,

        [Display(Name = "Tamamlandı")]
        Tamamlandi = 2
    }

}