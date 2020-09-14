using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.Presenters
{
    public interface IDerectionSenderRepository
    {
        void Create(RequestDerections requestDerections);
        IQueryable<RequestDerections> GetRequestDerections();
        IQueryable<RequestDerections> GetRequestDerectionsIsNotDeleted();
        IQueryable<RequestDerections> GetRequestDerectionsIsNotDeletedIsNotPosted();
        RequestDerections GetRequestDerectionsById(Guid guid);
        IQueryable<string> GetCountriesNames();
        Derections GetDerectionsByName(string derectionName);
        void DeleteAllDerections();
        void SaveChanges();
    }
}
