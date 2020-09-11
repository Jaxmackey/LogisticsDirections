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
        IQueryable<Countries> GetCountries();
        IQueryable<Derections> GetDerections();
        void DeleteAllDerections();
        void SaveChanges();
    }
}
