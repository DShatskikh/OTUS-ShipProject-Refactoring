using VContainer;
using VContainer.Unity;

namespace Lessons.Lesson19_EventBus
{
    public sealed class SceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureLevel(builder);
            ConfigurePlayer(builder);
            ConfigureControllers(builder);

            builder.RegisterComponentInHierarchy<EntityInstaller>();

            ConfigureEventBus(builder);
            ConfigureTurnPipeline(builder);
            ConfigureVisualPipeline(builder);
        }

        private void ConfigureVisualPipeline(IContainerBuilder builder)
        {
            builder.Register<VisualPipeline>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MoveVisualHandler>();
            builder.RegisterEntryPoint<DestroyVisualHandler>();
        }

        private void ConfigureTurnPipeline(IContainerBuilder builder)
        {
            builder.Register<TurnPipeline>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<TurnPipelineRunner>();
        }

        private void ConfigureLevel(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<TileMap>();
            builder.Register<EntityMap>(Lifetime.Singleton);
            builder.Register<LevelMap>(Lifetime.Singleton);
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<KeyboardInput>();
            builder.RegisterComponentInHierarchy<PlayerService>();
            // builder.RegisterEntryPoint<PlayerController>();
        }

        private void ConfigureControllers(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ApplyDirectionHandler>();
            builder.RegisterEntryPoint<AttackHandler>();
            builder.RegisterEntryPoint<DealDamageHandler>();
            builder.RegisterEntryPoint<DestroyHandler>();
            builder.RegisterEntryPoint<MoveHandler>();
            builder.RegisterEntryPoint<ForceDirectionHandler>();
            
            builder.RegisterEntryPoint<ForceWeaponHandler>();
        }

        private void ConfigureEventBus(IContainerBuilder builder)
        {
            builder.Register<EventBus>(Lifetime.Singleton);
        }
    }
}