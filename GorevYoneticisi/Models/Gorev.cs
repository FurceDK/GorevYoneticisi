using System;
using System.ComponentModel.DataAnnotations;

namespace GorevYoneticisi.Models
{
    public class Gorev
    {
        [Key]
        public int GorevID { get; set; }

        [Required(ErrorMessage = "Görev Adı zorunludur.")]
        [Display(Name = "Görev Adı")]
        public string GorevAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Required]
        public Durum Durum { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tahmini Bitiş Tarihi")]
        public DateTime? DueDate { get; set; }

        public bool Arsivle { get; set; }

        public DateTime? ArsivlenmeTarihi { get; set; }
    }


}