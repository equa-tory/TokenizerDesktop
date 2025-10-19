using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

public static class AppConfig
{
    private static string filePath = Path.Combine(Application.StartupPath, "config.json");

    public static string ServerIP = "171.22.30.82";
    public static int UpdateTimer = 3000;
    public static string SelectedPrinter = "Your Printer";

    public static void Load()
    {
        if (!File.Exists(filePath)) return;
        try
        {
            string json = File.ReadAllText(filePath);
            AppConfigData obj = JsonConvert.DeserializeObject<AppConfigData>(json);
            if (obj != null)
            {
                ServerIP = obj.ServerIP;
                UpdateTimer = obj.UpdateTimer;
                SelectedPrinter = obj.SelectedPrinter;
            }
        }
        catch { }
    }

    public static void Save()
    {
        try
        {
            // old inline initializer causes CS1526
            AppConfigData obj = new AppConfigData(); // instantiate first
            obj.ServerIP = ServerIP;
            obj.UpdateTimer = UpdateTimer;
            obj.SelectedPrinter = SelectedPrinter;

            File.WriteAllText(filePath, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
        catch { }
    }


    private class AppConfigData
    {
        public string ServerIP;
        public int UpdateTimer;
        public string SelectedPrinter;
    }
}
