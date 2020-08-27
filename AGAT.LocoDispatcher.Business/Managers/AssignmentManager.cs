﻿using AGAT.LocoDispatcher.AsusDb.Repositories;
using AGAT.LocoDispatcher.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class AssignmentManager
    {
        private AssignmentRepository repository;
        public AssignmentManager()
        {
            repository = new AssignmentRepository();
        }
        public async Task<IEnumerable<Assignment>> GetAsync()
        {
            var _assignments = await repository.GetActiveAsync();
            IEnumerable<Assignment> assignments =
                Mapper.GetMapperInstance().Map<IEnumerable<Assignment>>(_assignments);
            return assignments;
        }

        public async Task<IEnumerable<Assignment>> GetByCodeAsync(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code?.Trim()))
                {
                    throw new ArgumentNullException("Код станции неопознан");
                }

                IEnumerable<AsusDb.Models.LokM_operWork> _assignments = await repository.GetActiveByStationCodeAsync(code);
                List<AsusDb.Models.Assignment> _assignmentList = new List<AsusDb.Models.Assignment>();
                foreach (var assignment in _assignments)
                {
                    AsusDb.Models.Assignment _assignment = new AsusDb.Models.Assignment
                    {
                    Id = assignment.lokM_operW_id,
                    Station  = assignment.stanc,
                    LocomotiveNumber = assignment.num_lok,
                    SerialNumber = assignment.ser_lok,
                    WorkCode = assignment.cod_work,
                    PaymentCode = assignment.cod_opL,
                    StartDate = assignment.dt_beg,
                    EndDate = assignment.dt_end,
                    InsertDate = assignment.dt_ins,
                    AppliedCode = assignment.utv
                    };
                    _assignmentList.Add(_assignment);
                }
                IEnumerable<Assignment> assignments =
                    Mapper.GetMapperInstance().Map<IEnumerable<Assignment>>(_assignmentList);
                return assignments;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}