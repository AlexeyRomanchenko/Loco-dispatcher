using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class TrainRepository
    {
        public object GetTrains()
        {
            try
            {
                using (AsusContext context = new AsusContext())
                {
                    return context.sostav.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
