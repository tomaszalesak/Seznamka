using System.Reflection;
using Autofac;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Persistence.Query;

namespace BusinessLayer
{
    public class AutofacBusinessLayerConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacInfrastructureConfig());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "BusinessLayer.QueryObjects").AsSelf()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "BusinessLayer.Services.Implementations")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .InstancePerDependency();
            
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "BusinessLayer.Facades.FacadeImplementations")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name))
                .InstancePerDependency();

            builder.RegisterGeneric(typeof(QueryObjectBase<,,,>))
                .As(typeof(IQueryObjectBase<,,>))
                .InstancePerDependency();
            
            builder.RegisterType<UserQueryObject>()
                .As<QueryObjectBase<User, UserDto, UserFilterDto, IQuery<User>>>()
                .InstancePerDependency();
            
            builder.RegisterType<UserQuery>()
                .As<IQuery<User>>()
                .InstancePerDependency();
        }
    }
}