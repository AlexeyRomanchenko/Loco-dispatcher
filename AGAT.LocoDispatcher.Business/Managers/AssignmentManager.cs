using AGAT.LocoDispatcher.AsusDb.Repositories;
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

                var _assignments = await repository.GetActiveByStationCodeAsync(code);
                IEnumerable<Assignment> assignments =
                    Mapper.GetMapperInstance().Map<IEnumerable<Assignment>>(_assignments);
                return assignments;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
