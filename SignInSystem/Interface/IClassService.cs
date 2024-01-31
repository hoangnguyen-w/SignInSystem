using SignInSystem.DTO.Class;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IClassService
    {
        Task<List<Class>> GetAll();

        Task<List<Class>> GetClassByID(string id);

        Task<List<Class>> GetClassByName(string className);

        Task<Class> FindIDToResult(string id);

        Task CreateClass(ClassDTO classDTO);

        Task EditClass(string id, UpdateClassDTO classDTO);

        Task EditStatusClass(string id);

        Task DeleteClass(string id);
    }
}
