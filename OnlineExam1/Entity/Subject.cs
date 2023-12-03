using OnlineExam1.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExam1.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        public int SiteID { get; set; }

        [ForeignKey(nameof(SiteID))]
        public Site Site { get; set; }

        [Required]
        [StringLength(255)]
        public string SubjectName { get; set; }
        public ICollection<QuestionBank> QuestionBanks { get; set; }
    }


}
