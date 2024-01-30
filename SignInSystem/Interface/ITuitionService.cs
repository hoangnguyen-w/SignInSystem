using SignInSystem.DTO.Tuition;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ITuitionService
    {
        Task<List<Tuition>> GetAll();

        Task<List<Tuition>> GetPayTution();

        Task<List<Tuition>> GetTuitionByID(int id);

        Task<Tuition> FindIDToResult(int id);

        Task CreateTuition(TuitionDTO tuitionDTO);

        Task AddVoucherTuition(int id, AddVoucherDTO addVoucherDTO);

        Task ChangStautsTuition(int id);

        Task EditTuition(int id, UpdateTuitionDTO updateTuitionDTO);

        Task DeleteTuition(int id);
    }
}
