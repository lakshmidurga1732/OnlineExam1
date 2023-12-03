using OnlineExam1.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineExam1.Entity
{

    public class Site
    {
        [Key]
        public int SiteID { get; set; }

        [Required]
        public int OrgID { get; set; }

        [ForeignKey(nameof(OrgID))]
        public Organization Organization { get; set; }

        [Required]
        [StringLength(255)]
        public string SiteName { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<TestStructure> TestStructures{ get; set; }

    }




}
