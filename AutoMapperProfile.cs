using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Skill;
// need to create maps for the mapping which is done by a profile
// Could make a profile for every single mapping but not necessary
namespace C__RPG_Backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // first parameter is source and seconde is what it is being mapped to
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
            CreateMap<Weapon, GetWeaponDTO>();
            CreateMap<Skill, GetSkillDTO>();
        }
    }
}