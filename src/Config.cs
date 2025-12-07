public class Config
{
    public List<Config_Group> Groups { get; set; } =
    [
        new()
        {
            Permissions = [""],
            Team = "both",
            Particles = ["particles/therazu/other/roles/player.vpcf"]
        },
        new()
        {
            Permissions = ["vip"],
            Team = "both",
            Particles = ["particles/therazu/other/roles/vip.vpcf"]
        },
        new()
        {
            Permissions = ["admin"],
            Team = "both",
            Particles = ["particles/therazu/other/roles/admin.vpcf"]
        }
    ];
}

public class Config_Group
{
    public List<string> Permissions { get; set; } = new();
    public string Team { get; set; } = "";
    public List<string> Particles { get; set; } = new();
}