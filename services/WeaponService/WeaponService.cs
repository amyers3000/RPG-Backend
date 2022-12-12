using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using C__RPG_Backend.Data;
using C__RPG_Backend.DTOs.Character;
using C__RPG_Backend.DTOs.Weapon;
using Microsoft.EntityFrameworkCore;

namespace C__RPG_Backend.services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper  mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO newWeapon)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            try
            {
                Character character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if(character == null){
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                var damage = new Random().Next(30) + new Random().Next(character.Intelligence);
                if(character.Class == newWeapon.Type){
                    damage += new Random().Next(10);
                }

                Weapon weapon = new Weapon {
                    Name = newWeapon.Name,
                    Damage = damage,
                    Character = character,
                    Type = newWeapon.Type
                };
                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDTO>(character);
                

            }
            catch (Exception ex)
            {
                
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}