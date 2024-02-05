using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagmentAPI.Data
{
    public class Empolyee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Contact_no { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }
        public Department Department { get; set; }
    }
}
