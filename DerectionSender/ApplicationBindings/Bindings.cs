using DerectionSender.Presenters;
using DerectionSender.Repositories;
using DerectionSender.Views;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.ApplicationBindings
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDerectionSenderRepository>().To<DerectionSenderRepository>();
            Bind<IEmailRepository>().To<EmailRepository>();
            Bind<IDerectionSenderView>().To<DerectionSenderForm>().InSingletonScope();
            Bind<CreatePresenter>().ToSelf();
        }
    }
}
