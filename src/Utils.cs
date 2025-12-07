using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Players;
using SwiftlyS2.Shared.SchemaDefinitions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class Utils
{
    private readonly ISwiftlyCore Core;
    private readonly ILogger<Utils> Logger;
    private readonly IOptionsMonitor<Config> Config;

    public Utils(ISwiftlyCore core, ILogger<Utils> logger, IOptionsMonitor<Config> config)
    {
        Core = core;
        Logger = logger;
        Config = config;

        core.Registrator.Register(this);
    }

    public bool HasPermission(CCSPlayerController player, Config_Group group)
    {
        bool requireCheck = group.Permissions.Any(p => !string.IsNullOrWhiteSpace(p));
        bool hasPermission = !requireCheck;

        if (requireCheck)
            hasPermission = Core.Permission.PlayerHasPermissions(player.SteamID, group.Permissions);

        var team = group.Team.ToLower();
        bool isTeamValid =
            ((team == "t" || team == "terrorist") && player.Team == Team.T) ||
            ((team == "ct" || team == "counterterrorist") && player.Team == Team.CT) ||
            string.IsNullOrEmpty(team) || team == "both" || team == "all";

        return hasPermission && isTeamValid;
    }
}