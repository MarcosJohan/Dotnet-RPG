using Dotnet_RPG.Dtos.Character;
using Dotnet_RPG.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<AddCharacterDto>>> Addcharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto update);
        Task<ServiceResponse<List<GetCharacterDto>>> Deletecharacter(int id);
    }
}
