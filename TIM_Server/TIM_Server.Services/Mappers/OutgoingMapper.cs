using System;
using Microsoft.VisualBasic.CompilerServices;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.OutgoingBook;

namespace TIM_Server.Services.Mappers
{
    public static class OutgoingMapper
    {
        public static Leave AddLeaveMap(LeaveToAddDto leaveToAdd)
        {
            var leave = new Leave
            {
                Id = Guid.NewGuid(),
                Returned = false,
                StartDate = leaveToAdd.StartDate,
                EndDate = leaveToAdd.EndDate,
                SoldierId = leaveToAdd.SoldierId,
                Type = leaveToAdd.Type,
                Where = leaveToAdd.Where
            };
            return leave;
        }

        public static Leave UpdateLeaveMap(LeaveToUpdateDto leaveToUpdate, Leave leave)
        {
            leave.StartDate = leaveToUpdate.StartDate;
            leave.EndDate = leaveToUpdate.EndDate;
            leave.Type = leaveToUpdate.Type;
            leave.Where = leaveToUpdate.Where;
            return leave;
        }

        public static OutgoingSoldierDto OutgoingSoldierMap(Leave leave)
        {
            var outgoingSoldier = new OutgoingSoldierDto
            {
                FirstName = leave.Soldier.FirstName,
                LastName = leave.Soldier.LastName,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                MilitaryRank = leave.Soldier.MilitaryRank,
                SoldierId = (Guid) leave.SoldierId,
                Status = leave.Soldier.Status,
                LeaveId = leave.Id,
                PhoneNumber = leave.Soldier.PhoneNumber
            };
            return outgoingSoldier;
        }

        public static NotOutgoingSoldierDto NotOutgoingSoldierMap(Soldier soldier)
        {
            var notOutgoingSoldier = new NotOutgoingSoldierDto
            {
                FirstName = soldier.FirstName,
                LastName = soldier.LastName,
                MilitaryRank = soldier.MilitaryRank,
                SoldierId = soldier.Id,
                PhoneNumber = soldier.PhoneNumber
            };
            return notOutgoingSoldier;
        }
    }
}