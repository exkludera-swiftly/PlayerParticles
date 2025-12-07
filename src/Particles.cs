using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Natives;
using SwiftlyS2.Shared.SchemaDefinitions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class Particles
{
    private readonly ISwiftlyCore Core;
    private readonly ILogger<Particles> Logger;
    private readonly IOptionsMonitor<Config> Config;
    private readonly Utils Utils;

    public Particles(ISwiftlyCore core, ILogger<Particles> logger, IOptionsMonitor<Config> config, Utils utils)
    {
        Core = core;
        Logger = logger;
        Config = config;
        Utils = utils;

        core.Registrator.Register(this);
    }

    public Dictionary<CCSPlayerController, List<CEnvParticleGlow>> List = new();

    public void AddToPlayer(CCSPlayerController player)
    {
        var pawn = player.Pawn.Value;
        if (pawn == null) return;

        foreach (var group in Config.CurrentValue.Groups)
        {
            if (Utils.HasPermission(player, group))
            {
                foreach (var particlePath in group.Particles)
                {
                    var particle = Core.EntitySystem.CreateEntity<CEnvParticleGlow>();

                    particle.StartActive = true;
                    particle.EffectName = particlePath;
                    particle.Teleport(pawn.AbsOrigin, pawn.AbsRotation, Vector.Zero);
                    particle.DispatchSpawn();
                    particle.AcceptInput("FollowEntity", "!activator", pawn, pawn);

                    List[player].Add(particle);
                }
            }
        }
    }

    public void RemoveFromPlayer(CCSPlayerController player)
    {
        if (List.ContainsKey(player))
        {
            foreach (var particle in List[player])
            {
                if (particle != null && particle.IsValid)
                {
                    List[player].Remove(particle);
                    particle.AcceptInput("Kill", particle);
                }
            }
        }
        else List[player] = new();
    }
}