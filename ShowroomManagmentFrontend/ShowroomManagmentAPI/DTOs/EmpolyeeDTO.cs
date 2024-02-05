namespace ShowroomManagmentAPI.DTOs
{
    public class EmpolyeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Contact_no { get; set; }
        public int DepartmentId { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
