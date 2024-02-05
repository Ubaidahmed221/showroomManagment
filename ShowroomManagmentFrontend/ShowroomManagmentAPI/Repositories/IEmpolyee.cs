using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface IEmpolyee
    {
        public Task<ResponseDTO> AddEmpolyee(EmpolyeeDTO empolyeeDTO);
    }
}
