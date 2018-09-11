using System.Data.Entity;
using Autofac;
using MenhirSite.Model.Context;
using MenhirSite.Repository.Interfaces;
using MenhirSite.Repository.UnitOfWork;

namespace MenhirSite.Modules
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(DbContext)).InstancePerRequest().AsSelf();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}