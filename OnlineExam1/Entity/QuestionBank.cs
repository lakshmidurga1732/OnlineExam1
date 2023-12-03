using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExam1.Entity
{
    public class QuestionBank
    {
        [Key]
        public int QuestionID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject Subject { get; set; }

        [Required]
        [MaxLength]
        public string QuestionText { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Answer { get; set; }
    }
}
