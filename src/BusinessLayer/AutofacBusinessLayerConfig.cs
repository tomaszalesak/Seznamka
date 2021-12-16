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
            
            builder.RegisterType<UsernameUserQueryObject>()
                .As<QueryObjectBase<User, UserDto, UsernameUserFilterDto, IQuery<User>>>()
                .InstancePerDependency();
            
            builder.RegisterType<FindUserQueryObject>()
                .As<QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>>>()
                .InstancePerDependency();
            
            builder.RegisterType<UserPhotoQueryObject>()
                .As<QueryObjectBase<UserPhoto, UserPhotoDto, UserPhotoFilterDto, IQuery<UserPhoto>>>()
                .InstancePerDependency();
            
            builder.RegisterType<BanQueryObject>()
                .As<QueryObjectBase<Ban, BanDto, BanFilterDto, IQuery<Ban>>>()
                .InstancePerDependency();
            
            builder.RegisterType<UserQuery>()
                .As<IQuery<User>>()
                .InstancePerDependency();
            
            builder.RegisterType<UserPhotoQuery>()
                .As<IQuery<UserPhoto>>()
                .InstancePerDependency();
        }
    }
}