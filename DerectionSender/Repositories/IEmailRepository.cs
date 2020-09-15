using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.Repositories
{
    public interface IEmailRepository
    {
        string SendEmail(string to, string from, string password, string host, int port, string subject, string body);
    }
}
