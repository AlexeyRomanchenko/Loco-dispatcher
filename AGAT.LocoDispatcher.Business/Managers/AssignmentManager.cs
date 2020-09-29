using AGAT.locoDispatcher.ArchiveDB.Models;
using AGAT.locoDispatcher.ArchiveDB.Repositories;
using AGAT.LocoDispatcher.AsusDb.Repositories;
using AGAT.LocoDispatcher.Business.Helpers;
using AGAT.LocoDispatcher.Business.Models;
using AGAT.LocoDispatcher.NSI_DB.Repository;
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
        private BasicReasonRepository _reasonRepository;
        private OperationRepository _operationRepository;
        public AssignmentManager()
        {
            _reasonRepository = new BasicReasonRepository();
            repository = new AssignmentRepository();
            _operationRepository = new OperationRepository();
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
                    (string, string) startParkRoute = ("-", "-");
                    (string, string) endParkRoute = ("-", "-");
                    string reasonName = await _reasonRepository.GetReasonNameByCodeAsync(assignment.cod_opL);
                    Destination destination = await _operationRepository.GetOperationDestinationsByWorkIdAsync(assignment.lokm_workid, assignment.dt_beg);
                    if (destination != null)
                    {
                        startParkRoute = ConvertHelper.ConvertToParkAndRoute(destination.From);
                        endParkRoute = ConvertHelper.ConvertToParkAndRoute(destination.To);
                    }
                    
                    AsusDb.Models.Assignment _assignment = new AsusDb.Models.Assignment
                    {
                        Id = assignment.lokM_operW_id,
                        Station = assignment.stanc,
                        LocomotiveNumber = assignment.num_lok,
                        SerialNumber = assignment.ser_lok,
                        WorkCode = assignment.cod_work,
                        PaymentCode = assignment.cod_opL,
                        StartDate = assignment.dt_beg,
                        EndDate = assignment.dt_end,
                        InsertDate = assignment.dt_ins,
                        AppliedCode = assignment.utv,
                        Reason = reasonName,
                        StartRoute = startParkRoute.Item2,
                        StartPark = startParkRoute.Item1,
                        EndRoute = endParkRoute.Item2,
                        EndPark = endParkRoute.Item1,
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
