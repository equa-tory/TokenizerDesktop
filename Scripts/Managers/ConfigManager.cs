using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TicketApp
{
    public class ConfigManager
    {
        private static string configFile = Path.Combine(Application.StartupPath, "config.json");
        public string serverIP = "171.22.30.82";
        public int updateTimer = 3000;
        public string selectedPrinter = "Your Printer";

        //--------------------------------------------------------------------------------------------

        public static ConfigManager Load()
        {
            if (!File.Exists(configFile))
                return new ConfigManager();
            string json = File.ReadAllText(configFile);
            return JsonConvert.DeserializeObject<ConfigManager>(json);
        }

        public void Save()
        {
            File.WriteAllText(configFile, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}