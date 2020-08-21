using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.RailData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AGAT.LocoDispatcher.Data.Repositories.RailRepositories
{
    public class RailsRepository : IRepository<Rail>
    {
        public void Create(Rail rail)
        {
            if (rail != null)
            {
                try
                {
                    using (DataContext db = new DataContext())
                    {
                        db.Rails.Add(rail);
                        db.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                throw new ArgumentException("Model should not be null");
            }
        }
        public IEnumerable<Rail> GetById(int id)
        {
            if (id > 0)
            {
                try
                {
                    using (DataContext db = new DataContext())
                    {
                        var routes = db.Rails.Where(e => e.ParkId == id).Include(e => e.Coords).Include(e => e.Carriage).Include(e => e.RoutePlate).ToList();
                        return routes;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw ex;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Id should be more than null. Now Id is {id}");
            }
        }
    }
}
