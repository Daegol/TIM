using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Soldier;

namespace TIM_Server.Services.Mappers
{
    public static class SoldierMapper
    {
        public static SoldierToSendDto SoldierToSendMap(Soldier soldier)
        {
            return new SoldierToSendDto
            {
                SoldierId = soldier.Id,
                FirstName = soldier.FirstName,
                LastName = soldier.LastName,
                MilitaryRank = soldier.MilitaryRank,
                Status = soldier.Status
            };

        }
    }
}