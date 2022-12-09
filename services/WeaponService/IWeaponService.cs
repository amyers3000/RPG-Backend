using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Weapon;

namespace C__RPG_Backend.services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO newWeapon);
    }
}