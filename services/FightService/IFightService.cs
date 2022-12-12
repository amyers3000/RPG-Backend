using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__RPG_Backend.DTOs.Fight;

namespace C__RPG_Backend.services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDTO>> WeaponAttack(WeaponAttackDTO request);
        Task<ServiceResponse<AttackResultDTO>> SkillAttack(SkillAttackDTO request);
        Task<ServiceResponse<FightResultDTO>> Fight(FightRequestDTO request);
        Task<ServiceResponse<List<HighscoreDTO>>>GetHighscore();
        
    }
}