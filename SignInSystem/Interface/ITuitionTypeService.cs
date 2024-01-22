using SignInSystem.DTO.TuitionType;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ITuitionTypeService
    {
        Task<List<TuitionType>> GetAll();

        Task<List<TuitionType>> GetTuitionTypeID(int id);

        Task<List<TuitionType>> GetTuitionTypeName(string tuitionTypeName);

        Task<TuitionType> FindIDToResult(int id);

        Task CreateTuitionType(TuitionTypeDTO tuitionTypeDTO);

        Task EditTuitionType(int id, TuitionTypeDTO tuitionTypeDTO);

        Task DeleteTuitionType(int id);
    }
}
