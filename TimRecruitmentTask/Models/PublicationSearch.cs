using System.ComponentModel.DataAnnotations;

namespace TimRecruitmentTask.Models
{
    public class PublicationSearch
    {
        [Display(Name = "Szukana publikacja:")]
        public string? SearchedWord { get; set; }
        public string? Result { get; set; }
        public int Interator { get; set; }
    }
}
