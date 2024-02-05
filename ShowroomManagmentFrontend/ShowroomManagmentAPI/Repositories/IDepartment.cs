using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartment();

        public Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO);

        public Task<ResponseDTO> DeleteDepartment(int id);

        public Task<ResponseDTO> GetDepartmentById(int id);
        public Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO);
    }
}
