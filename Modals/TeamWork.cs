using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class TeamWork
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamWorkId { get; set; }
        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(250)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(1024)]
        public string AboutWork { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        [StringLength(250)]
        public string Author { get; set; } = "Author";
        [StringLength(250)]
        public string LinkedIn { get; set; }
        [StringLength(250)]
        public string Instagram { get; set; }
        [StringLength(250)]
        public string Facebook { get; set; }
        [StringLength(250)]
        public string Status { get; set; }
        [Required]

        public int JobPositionId { get; set; }
        [StringLength(500)]
        public string Photo { get; set; }
        public JobPosition JobPositions { get; set; }
    }
}
