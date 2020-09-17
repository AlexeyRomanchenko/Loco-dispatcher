using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.NSI_DB.Repository
{
    public class BasicReasonRepository
    {
        private nsiEntities _context;
        public BasicReasonRepository()
        {
            _context = new nsiEntities();
        }
        public async Task<string> GetReasonNameByCodeAsync(string code)
        {
            try
            {
                if (String.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException("code is not valid");
                }
                var text =  await _context.LokM_BasicPr.Where(e=>e.cod_W == code).Select(e=>e.basic_pr).FirstOrDefaultAsync();
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
