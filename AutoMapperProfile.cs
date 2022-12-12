using AutoMapper;
using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Fight;
using C__RPG_Backend.DTOs.Skill;

namespace C__RPG_Backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
            CreateMap<Weapon, GetWeaponDTO>();
            CreateMap<Skill, GetSkillDTO>();
            CreateMap<Character, HighscoreDTO>();
        }
    }
}