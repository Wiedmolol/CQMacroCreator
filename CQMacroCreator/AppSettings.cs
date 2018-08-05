using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
namespace CQMacroCreator
{
    public struct AuctionBids
    {
        bool biddingEnabled;
        string name;
        int maxLevel;
        int maxBid;
    }
    public class AppSettings
    {
        public string KongregateId { get; set; }
        public string token { get; set; }
        public int? actionOnStart { get; set; }
        public string defaultLowerLimit { get; set; }
        public string defaultUpperLimit { get; set; }
        public List<string> LoCLineup { get; set; }
        public List<string> MOAKLineup { get; set; }
        public List<string> KrytonLineup { get; set; }
        public List<string> defaultDQLineup { get; set; }
        public List<string> calcEnabledHeroes { get; set; }
        public bool? DQSoundEnabled { get; set; }
        public bool? autoBestDQEnabled { get; set; }
        public bool? autoDQEnabled { get; set; }
        public bool? autoPvPEnabled { get; set; }
        public bool? autoChestEnabled { get; set; }
        public int? chestsToOpen { get; set; }
        public bool? autoWBEnabled { get; set; }
        public bool? safeModeWBEnabled { get; set; }
        public int? pvpLowerLimit { get; set; }
        public int? pvpUpperLimit { get; set; }
        public List<int> WBsettings { get; set; }
        public List<AuctionBids> bids { get; set; }
        public bool? autoLevelEnabled { get; set; }
        public int[] bankedCurrencies { get; set; }
        public string[] herosToLevel { get; set; }
        public int[] levelLimits { get; set; }
        public bool? instantMaxPriceBid { get; set; }

        public static AppSettings loadSettings()
        {        
            if (File.Exists(Form1.SettingsFilename))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Form1.SettingsFilename);
                AppSettings a = JsonConvert.DeserializeObject<AppSettings>(sr.ReadToEnd());
                sr.Close();
                return a;
            }
            else
            {
                return new AppSettings();
            }
        }

        public void saveSettings()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(Form1.SettingsFilename);
            sw.Write(json);
            sw.Close();
        }
    }
}
