using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Weapon;

namespace C__RPG_Backend.services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO newWeapon);
    }
}