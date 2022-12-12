using System.Security.Claims;
using AutoMapper;
using C__RPG_Backend.Data;
using C__RPG_Backend.DTOs.Character;
using Microsoft.EntityFrameworkCore;


namespace C__RPG_Backend.services.CharacterService
{
    public class CharacterService : ICharacterService
    
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        
        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {   
            
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var skillPoints = newCharacter.Intelligence + newCharacter.Strength + newCharacter.Defense;
            if( skillPoints >= 31 ){
                serviceResponse.Success = false;
                serviceResponse.Message = "Only 30 skill points available";
                return serviceResponse;
            }
            
            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            
            serviceResponse.Data = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDTO>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacters = await _context.Characters
                .Include(c => c.Skills)
                .Include(c => c.Weapon)
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbCharacter = await _context.Characters
                .Include(c => c.Skills)
                .Include(c => c.Weapon)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

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
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
                   
                if(character.User.Id == GetUserId())
                {
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

        public async Task<ServiceResponse<GetCharacterDTO>> AddCharacterSkill(AddCharacterSkillDTO newCharacterSkill)
        {
            var response = new ServiceResponse<GetCharacterDTO>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId &&
                    c.User.Id == GetUserId());

                if(character == null){
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
                if(skill == null){
                    response.Success = false;
                    response.Message = "Skill not found.";
                    return response;
                }

                character.Skills.Add(skill);
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