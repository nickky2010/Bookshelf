using BLL.Infrastructure.Exceptions.Localizations.English;
using BLL.Interfaces;
using BLL.Interfaces.Localizations.Exceptions;
using BLL.Services;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class InterfacesRegistrationsBLL : NinjectModule
    {
        public string ConnectionString { get; private set; }
        public InterfacesRegistrationsBLL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWorkService>().To<UnitOfWorkService>().WithConstructorArgument(ConnectionString);
            Bind<IUnitOfWorkExceptionMessageLocalization>().To<UnitOfWorkExceptionMessageOnEnglish>();
        }
    }
}
