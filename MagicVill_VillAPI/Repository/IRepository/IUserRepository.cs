using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
