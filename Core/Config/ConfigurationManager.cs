using System.Text.Json;

public static class ConfigurationManager
{
    public static Config Config { get; private set; }

    static ConfigurationManager()
    {
        var json = File.ReadAllText("config.json");

        Config = JsonSerializer.Deserialize<Config>(json);
    }
}
