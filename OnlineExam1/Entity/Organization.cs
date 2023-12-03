using System.ComponentModel.DataAnnotations;

namespace OnlineExam1.Entity
{

    public class Organization
    {
        [Key]
        public int OrgID { get; set; }

        [Required]
        [StringLength(255)]
        
        public string OrgName { get; set; }
        public ICollection<Site> Sites { get; set; }
    }



}