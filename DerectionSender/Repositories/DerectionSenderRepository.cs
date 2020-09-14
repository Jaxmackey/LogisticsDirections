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

        public IQueryable<string> GetCountriesNames()
        {
            return _context.Countries.Where(y => !y.IsIndexPresent).Select(x => x.CountryName);
        }

        public Derections GetDerectionsByName(string derectionName)
        {
            return _context.Derections.FirstOrDefault(x => x.Derection == derectionName);
        }

        public IQueryable<RequestDerections> GetRequestDerections()
        {
            return _context.RequestDerections;
        }

        public RequestDerections GetRequestDerectionsById(Guid guid)
        {
            return _context.RequestDerections.FirstOrDefault(x => x.Id == guid);
        }

        public IQueryable<RequestDerections> GetRequestDerectionsIsNotDeleted()
        {
            return _context.RequestDerections.Where(x => !x.IsDeleted);
        }

        public IQueryable<RequestDerections> GetRequestDerectionsIsNotDeletedIsNotPosted()
        {
            return _context.RequestDerections.Where(x => !x.IsDeleted && !x.IsPost);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
