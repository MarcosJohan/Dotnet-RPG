using AutoMapper;
using Dotnet_RPG.Dtos.Character;
using Dotnet_RPG.Models;

namespace Dotnet_RPG.AutoMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>(); 
        }
    }
}
