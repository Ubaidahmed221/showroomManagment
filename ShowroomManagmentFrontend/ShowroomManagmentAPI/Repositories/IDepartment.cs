using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartment();

        public Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO);
    }
}
