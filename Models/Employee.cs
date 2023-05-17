using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string LastName { get; set; }

        [ForeignKey("Roles")]
        public int FK_Role { get; set; }
        public virtual Role Roles { get; set; }

        [Required]
        public string Address { get; set; }

        public string? useLessInfo1 { get; set; }

        public string? useLessInfo2 { get; set; }

        public string? useLessInfo3 { get; set; }
    }
}
