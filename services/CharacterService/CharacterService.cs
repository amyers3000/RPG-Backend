using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using C__RPG_Backend.Data;
using C__RPG_Backend.DTOs.Character;
using Microsoft.EntityFrameworkCore;
// Service removes logic allowing controller not to become "fat". Good use to slim down controllers and hold duplicate code. Injected into controllers via dependency injection
// Task added to each method aswell as async

namespace C__RPG_Backend.services.CharacterService
{
    public class CharacterService : ICharacterService
    
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Added mapper via dependency injection; allows us to map DTO to model; will use Automapper to set the correct types to the data property of our service response
        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //controller based class provides a user object of type claims principal; can click on class and see using command button
        //The user object provides all claims we added to the JWT token from request
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {   
            // new service response object made every time a method is called passing the type
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            // This maps AddCharacterDTO to character so it can be added to characters
            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            // Changes each item in list (Linq Select) to GetCharacterDTO and then into list to be returned to client
            serviceResponse.Data = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDTO>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            // Changes each item in list (Linq Select) to GetCharacterDTO and then into list to be returned to client
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacters = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbCharacter = await _context.Characters
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
            // Brackets show what value type it should be mapped too and the parameter is the actual object that is mapped
            // Goal is to return DTO in serviceResponse to client
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
                    //only can access related objects when DBcontext is still available for example in above method; use include to have access to object after that
                if(character.User.Id == GetUserId())
                {
                    // same as when you use angle brackets( source and what type its being mapped to)
                    // Be careful with automapper; may only want to update somethings... don't want to set to default value
                    // _mapper.Map(updateCharacter, character);
                    character.Name = updateCharacter.Name;
                    character.HitPoints = updateCharacter.HitPoints;
                    character.Strength = updateCharacter.Strength;
                    character.Defense = updateCharacter.Defense;
                    character.Intelligence = updateCharacter.Intelligence;
                    character.Class = updateCharacter.Class;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetCharacterDTO>(character);
                }
                else{
                    response.Success = false;
                    response.Message = "Character not found";
                }
            }
            catch (Exception ex)
            {
                
                response.Success = false;
                response.Message = ex.Message;
                
            }
            
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
           try
            {
                Character character =  await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
                if(character != null)
                {
                     _context.Characters.Remove(character);
                     await _context.SaveChangesAsync();
                     response.Data = _context.Characters
                        .Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
                }
                else{
                    response.Success = false;
                    response.Message = "Character not found";
                }
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