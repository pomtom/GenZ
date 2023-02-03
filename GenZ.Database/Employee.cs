using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenZ.Database
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [DisplayName("Emloyee Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee city is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Employee phone is required.")]
        [DisplayName("Phone")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Employee BirthDate is required.")]
        [Column("BirthDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime BirthDate { get; set; } = DateTime.Now.Date;
    }
}
