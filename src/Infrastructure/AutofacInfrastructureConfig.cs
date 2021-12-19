using Autofac;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure
{
    public class AutofacInfrastructureConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeznamkaDbContext>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UnitOfWorkProvider>()
                .As<IUnitOfWorkProvider>()
                .InstancePerLifetimeScope();
           
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();
            
            builder.RegisterGeneric(typeof(QueryBase<>))
                .As(typeof(IQuery<>))
                .InstancePerDependency();

            builder.RegisterType<UserQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<MessageQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<UserChatQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<UserPhotoQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<BannedUsersQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<BanQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<ChatQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<FriendshipQuery>()
                .AsSelf()
                .InstancePerDependency();
        }
    }
}