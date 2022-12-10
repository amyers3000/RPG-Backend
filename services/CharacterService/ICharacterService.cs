using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.DTOs.Character;
// Interfaces are decarative and only show implementation in dervied class. In a way it's like a contract with classes derived from it. 
//Allows concrete classes not to be used and loose coupling
namespace C__RPG_Backend.services.CharacterService
{
    public interface ICharacterService
    {
        // Task added for async functionality. Allows thread to open up and return whent await task is complete
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id);
        Task<ServiceResponse<GetCharacterDTO>> AddCharacterSkill(AddCharacterSkillDTO newCharacterSkill);
        
    }
}