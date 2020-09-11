using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.Presenters
{
    public class DerectionSenderRepository : IDerectionSenderRepository
    {
        private readonly LBEntities _context = new LBEntities();

        public void Create(RequestDerections requestDerections)
        {
            _context.RequestDerections.Add(requestDerections);
            _context.SaveChanges();
        }

        public void DeleteAllDerections()
        {
            _context.RequestDerections.RemoveRange(GetRequestDerections());
            _context.SaveChanges();
        }

        public IQueryable<Countries> GetCountries()
        {
            return _context.Countries;
        }

        public IQueryable<Derections> GetDerections()
        {
            return _context.Derections;
        }

        public IQueryable<RequestDerections> GetRequestDerections()
        {
            return _context.RequestDerections;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
