using MC.Domain;
using MC.Services.DTOs;

namespace MC.Services.Interfaces
{
    public interface IDirectorsService
    {
        Task<List<Director>> GetAllDirectorAsync();
        Task<Director> GetDirectorByIdAsync(Guid id);
        Task<Director> AddDirectorAsync(CreateDirectorDto directorDto);
        Task<Director> UpdateDirectorAsync(Guid id, EditDirectorDto directorDto);
        Task DeleteDirectorAsync(Guid id);

    }
}
