using AutoMapper;
using Dotnet_RPG.Dtos.Character;
using Dotnet_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "Sam"}
            };

        public CharacterService(IMapper mapper)
        {
            _Mapper = mapper;
        }

        private readonly IMapper _Mapper;

        public async Task<ServiceResponse<List<AddCharacterDto>>> Addcharacter(AddCharacterDto newCharacter)
        {

            Character character = _Mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;

            characters.Add(character);
            var serviceResponse = new ServiceResponse<List<AddCharacterDto>>();
            serviceResponse.Data = characters.Select(x => _Mapper.Map<AddCharacterDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _Mapper.Map<List<GetCharacterDto>>(characters);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _Mapper.Map<GetCharacterDto>(characters.FirstOrDefault(x => x.Id == id));

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto update)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(x => x.Id == update.Id);

                character.Name = update.Name;
                character.HitPoints = update.HitPoints;
                character.Strength = update.Strength;
                character.Defense = update.Defense;
                character.Intelligence = update.Intelligence;
                character.Class = update.Class;

                serviceResponse.Data = _Mapper.Map<GetCharacterDto>(character);
            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
           

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> Deletecharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data = characters.Select(x => _Mapper.Map<GetCharacterDto>(x)).ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
