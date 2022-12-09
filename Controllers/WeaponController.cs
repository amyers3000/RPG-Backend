using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Weapon;
using C__RPG_Backend.services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace C__RPG_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddWeapon(AddWeaponDTO newWeapon)
        {
            return Ok(await _weaponService.AddWeapon(newWeapon));
        }
    }
}