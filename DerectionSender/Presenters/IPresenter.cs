using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.Presenters
{
    public interface IPresenter
    {
        void Run();
        void Load();
        void Create();
        void SendEmails();
        void DeleteAll();
    }
}
