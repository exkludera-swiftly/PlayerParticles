using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Events;
using SwiftlyS2.Shared.GameEventDefinitions;
using SwiftlyS2.Shared.Misc;
using SwiftlyS2.Shared.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[PluginMetadata(
    Id = "PlayerParticles",
    Version = "1.0.0",
    Name = "Player Particles",
    Author = "exkludera",
    Description = "No description."
)]

public class Plugin : BasePlugin
{
    private readonly Config Config;
    private readonly Utils Utils;
    private readonly Particles Particles;

    public Plugin(ISwiftlyCore core) : base(core)
    {
        Core.Configuration
          .InitializeJsonWithModel<Config>("config.jsonc", "PlayerParticles")
          .Configure(builder => builder.AddJsonFile("config.jsonc", false, true));

        ServiceCollection services = new();

        services
            .AddSwiftly(Core)
            .AddSingleton<Utils>()
            .AddSingleton<Particles>()
            .AddOptionsWithValidateOnStart<Config>().BindConfiguration("PlayerParticles");

        var provider = services.BuildServiceProvider();

        Config = provider.GetRequiredService<IOptions<Config>>().Value;
        Utils = provider.GetRequiredService<Utils>();
        Particles = provider.GetRequiredService<Particles>();
    }

    public override void ConfigureSharedInterface(IInterfaceManager interfaceManager) {}
    public override void UseSharedInterface(IInterfaceManager interfaceManager) {}

    public override void Load(bool hotReload)
    {
        Core.Event.OnPrecacheResource += OnPrecacheResource;

        Core.GameEvent.HookPre<EventRoundStart>(EventRoundStart);
        Core.GameEvent.HookPost<EventPlayerSpawn>(EventPlayerSpawn);
    }

    public override void Unload()
    {
        Core.Event.OnPrecacheResource -= OnPrecacheResource;

        Core.GameEvent.UnhookPost<EventRoundStart>();
        Core.GameEvent.UnhookPost<EventPlayerSpawn>();
    }

    private void OnPrecacheResource(IOnPrecacheResourceEvent @event)
    {
        foreach (var group in Config.Groups)
        {
            foreach (var particle in group.Particles)
            {
                @event.AddItem(particle);
            }
        }
    }

    private HookResult EventRoundStart(EventRoundStart @event)
    {
        Particles.List.Clear();

        return HookResult.Continue;
    }

    private HookResult EventPlayerSpawn(EventPlayerSpawn @event)
    {
        if (!@event.UserIdPlayer.IsValid)
            return HookResult.Continue;

        var player = @event.UserIdPlayer.RequiredController;

        Particles.RemoveFromPlayer(player);
        Particles.AddToPlayer(player);

        return HookResult.Continue;
    }
}