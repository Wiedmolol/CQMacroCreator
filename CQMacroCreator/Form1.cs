using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;

namespace CQMacroCreator
{
    public partial class Form1 : Form
    {
        static AppSettings appSettings = new AppSettings();
        public const string SettingsFilename = "Settings.json";
        static string output;
        static bool wrongHeroAmountAlreadyAsked = false;
        static DateTime previousDQTime;
        static string calcOut;
        List<NumericUpDown> heroCounts;
        List<NumericUpDown> heroCountsServerOrder;
        List<CheckBox> questBoxes;
        List<Button> questButtons;
        List<CheckBox> heroBoxes;
        double lowerFollowerPerc = 0.0;
        double upperFollowerPerc = 0.0;
        ToolTip tp = new ToolTip();
        PFStuff pf;
        Dictionary<string, string> aliases = new Dictionary<string, string>
        {
            {"LADY", "ladyoftwilight"},
            {"LOT", "ladyoftwilight"},
            {"KAIRY", "k41ry"},
            {"TRONIX", "tr0n1x"},
            {"GAIA", "gaiabyte"},
            {"BRYN", "brynhildr"},
            {"TAURUS","t4urus"},
            {"HALL", "hallinskidi"},
            {"PYRO", "pyromancer"},
            {"DRUID", "forestdruid"},
            {"ODELITH", "ladyodelith"},
            {"KIRK", "lordkirk"},
            {"NEP", "neptunius"},
            {"DULLA", "dullahan"},
            {"DULL", "dullahan"},
            {"JACK", "jackoknight"},
            {"SHIT", "geum"},
            {"WATERBOOM", "zeth"},
            {"EARTHBOOM", "koth"},
            {"WOLF", "werewolf"},
            {"OGREFART", "ourea"},
            {"COOORRRRRAAAAALLL!", "carl"},
            {"URSULA", "ladyodelith"},
            {"SHYGUY", "shygu"},
            {"ALF", "alvitr"},
            {"FREUD", "sigrun"},
            {"FOREIGNER", "koldis"},
            {"VOWELCHICK", "aoyuki"},
            {"SANTA", "santaclaus"},
            {"MARY", "sexysanta"},
            {"MARYCHRISTMAS", "sexysanta"},
            {"DEER", "reindeer"},
            {"RUDOLPH", "reindeer"},
            {"ELF", "christmaself"},
            {"FBOSS", "lordofchaos"},
            {"ATRONIX", "atr0n1x"},
            {"ASHIT", "ageum"},
            {"SEXY", "sexysanta"},
            {"EBOSS", "moak"},
            {"MOTHEROFALLKODAMAS", "moak"},
            {"LEPR", "leprechaun"},
            {"ABOSS", "kryton"},
            {"DICE", "dicemaster" },
            {"POKER", "pokerface" },
            {"LUX", "luxurious" }

        };
        string token;
        string KongregateId;
        int defaultActionOnOpen = 0;

        static string[] names = {"james", "hunter", "shaman", "alpha", "carl", "nimue", "athos", "jet", "geron", "rei", "ailen", "faefyr", "auri", "k41ry", "t4urus", "tr0n1x",
                                "aquortis", "aeris", "geum", "rudean", "aural", "geror", "ourea", "erebus", "pontus", "oymos", "xarth", "atzar", "ladyoftwilight", "tiny", "nebra",
                              "veildur", "brynhildr", "groth", "zeth", "koth", "gurth", "spyke", "aoyuki", "gaiabyte", "valor", "rokka", "pyromancer", "bewat", "nicte", "forestdruid",
                              "ignitor", "undine", "chroma", "petry", "zaytus", "werewolf", "jackoknight", "dullahan", "ladyodelith", "shygu", "thert", "lordkirk", "neptunius",
                                "sigrun", "koldis", "alvitr", "hama", "hallinskidi", "rigr", "aalpha", "aathos", "arei", "aauri", "atr0n1x", "ageum", "ageror", "lordofchaos",
                                "christmaself", "reindeer", "santaclaus", "sexysanta", "toth", "ganah", "dagda", "bubbles", "apontus", "aatzar", "arshen", "rua", "dorth", "arigr",
                                "moak", "hosokawa", "takeda", "hirate", "hattori", "adagda", "bylar", "boor", "bavah", "leprechaun", "sparks", "leaf", "flynn", "abavah",
                                "drhawking", "masterlee", "kumusan", "liucheng", "hidoka", "kryton", "dicemaster", "luxurious", "pokerface", "taint", "putrid", "defile", "neil",
                                "mahatma", "jade", "edana", "dybbuk"
                                };

        static string[] servernames = { "dybbuk","edana","jade", "mahatma", "neil", "defile", "putrid", "taint", "pokerface", "luxurious", "dicemaster", "kryton", "hidoka", "liucheng", "kumusan", "masterlee", "drhawking", "abavah" ,"flynn", "leaf", "sparks", "leprechaun", "bavah", "boor", "bylar", "adagda", "hattori", "hirate", "takeda", "hosokawa", "moak", "arigr", "dorth", "rua", "arshen", "aatzar", "apontus",  "bubbles",  "dagda",  "ganah", "toth",  "sexysanta", "santaclaus", "reindeer", "christmaself", "lordofchaos", "ageror", "ageum", "atr0n1x", "aauri", "arei", "aathos", "aalpha",
                                   "rigr", "hallinskidi", "hama", "alvitr", "koldis", "sigrun", "neptunius", "lordkirk", "thert", "shygu", "ladyodelith", "dullahan", "jackoknight", "werewolf",
                               "gurth", "koth", "zeth", "atzar", "xarth", "oymos", "gaiabyte", "aoyuki", "spyke", "zaytus", "petry", "chroma", "pontus", "erebus", "ourea",
                               "groth", "brynhildr", "veildur", "geror", "aural", "rudean", "undine", "ignitor", "forestdruid", "geum", "aeris", "aquortis", "tronix", "taurus", "kairy",
                               "james", "nicte", "auri", "faefyr", "ailen", "rei", "geron", "jet", "athos", "nimue", "carl", "alpha", "shaman", "hunter", "bewat", "pyromancer", "rokka",
                               "valor", "nebra", "tiny", "ladyoftwilight", "", "A1", "E1", "F1", "W1", "A2", "E2", "F2", "W2", "A3", "E3", "F3", "W3", "A4", "E4", "F4", "W4",
                               "A5", "E5", "F5", "W5", "A6", "E6", "F6", "W6", "A7", "E7", "F7", "W7", "A8", "E8", "F8", "W8", "A9", "E9", "F9", "W9", "A10", "E10", "F10", "W10",
                               "A11", "E11", "F11", "W11", "A12", "E12", "F12", "W12", "A13", "E13", "F13", "W13", "A14", "E14", "F14", "W14", "A15", "E15", "F15", "W15",
                               "A16","E16","F16","W16","A17","E17","F17","W17","A18","E18","F18","W18","A19","E19","F19","W19","A20","E20","F20","W20","A21","E21","F21","W21",
                               "A22","E22","F22","W22","A23","E23","F23","W23","A24","E24","F24","W24","A25","E25","F25","W25","A26","E26","F26","W26","A27","E27","F27","W27",
                               "A28","E28","F28","W28","A29","E29","F29","W29","A30","E30","F30","W30",};

        static int[] monstersCosts = {1000, 1300, 1000, 1400, 3900, 2700, 3900, 3900, 8000, 7500, 8000, 8000, 15000, 18000, 23000, 18000, 41000, 54000, 31000,
                                        52000, 96000, 71000, 94000, 84000, 144000, 115000, 115000, 159000, 257000, 215000, 321000, 241000, 495000, 436000,
                                        454000, 418000, 785000, 689000, 787000, 675000, 1403000, 1130000, 1229000, 1315000, 1733000, 1903000, 1718000, 1775000,
                                        2772000, 3971000, 3169000, 2398000, 4785000, 6044000, 4741000, 4159000, 8897000, 7173000, 5676000, 7758000, 12855000,
                                        12534000, 13001000, 13475000, 16765000, 16531000, 18090000, 17573000, 21951000, 22567000, 21951000, 20909000, 27288000,
                                        27107000, 25170000, 25079000, 32242000, 32025000, 33155600, 34182000, 42826000, 42252000, 42798000, 41901000, 55373000,
                                        55671000, 55582000, 55877000, 72580000, 73483000, 72480000, 72243000, 94312000, 96071000, 95772000, 95903000, 124549000,
                                        123096000, 125443000, 127256000, 155097000, 157055000, 160026000, 157140000, 202295000, 206317000, 201426000, 199344000,
                                        265846000, 268117000, 264250000, 261023000, 368230000, 363805000, 358119000, 370761000, 505055000, 497082000, 514040000,
                                        515849000,
                                    };


        int heroesInGame = Array.IndexOf(servernames, "ladyoftwilight") + 2;


        public Form1()
        {

            InitializeComponent();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += currentDomain_UnhandledException;
            heroCounts = new List<NumericUpDown>() {JamesCount,
                                               HunterCount, ShamanCount, AlphaCount,
                                               CarlCount, NimueCount, AthosCount,
                                               JetCount, GeronCount, ReiCount,
                                               AilenCount, FaefyrCount, AuriCount,
                                               KairyCount, TaurusCount, TronixCount,
                                               AquortisCount, AerisCount, GeumCount,
                                               RudeanCount, AuralCount, GerorCount,
                                               OureaCount, ErebusCount, PontusCount,
                                               OymosCount, XarthCount, AtzarCount,
                                               LadyCount, TinyCount, NebraCount,
                                               VeildurCount, BrynCount, GrothCount,
                                               ZethCount, KothCount, GurthCount,
                                               SpykeCount, AoyukiCount, GaiaCount,
                                               ValorCount, RokkaCount, PyroCount, BewatCount,
                                               NicteCount, DruidCount, IgnitorCount, UndineCount,
                                               ChromaCount, PetryCount, ZaytusCount,
                                               WerewolfCount, JackCount, DullahanCount,
                                               OdelithCount, ShyguCount, ThertCount, KirkCount, NeptuniusCount,
                                               SigrunCount, KoldisCount, AlvitrCount,
                                               HamaCount, HallinskidiCount, RigrCount,
                                               AAlphaCount, AAthosCount, AReiCount, AAuriCount, ATronixCount, AGeumCount, AGerorCount,
                                               null,
                                               elfCount, deerCount, santaCount, maryCount,
                                               TothCount, GanahCount, DagdaCount, BubblesCount, APontusCount, AAtzarCount,
                                               ArshenCount, RuaCount, DorthCount,
                                               aRigrCount, null,
                                               HosokawaCount, TakedaCount, HirateCount, HattoriCount,
                                               aDagdaCount, BylarCount, BoorCount, BavahCount, LeprCount,
                                               SparksCount, LeafCount, FlynnCount,
                                               aBavahCount, HawkingCount, LeeCount, KumuCount, ChengCount, HidokaCount,
                                               null,
                                               DicemasterCount, LuxCount, PokerCount,
                                               TaintCount, PutridCount, DefileCount,
                                               NeilCount,
                                               MahatmaCount, JadeCount, EdanaCount, DybbukCount

            };

            heroCountsServerOrder = new List<NumericUpDown>() {
                                               LadyCount, TinyCount, NebraCount,
                                               ValorCount, RokkaCount, PyroCount, BewatCount,
                                               HunterCount, ShamanCount, AlphaCount,
                                               CarlCount, NimueCount, AthosCount,
                                               JetCount, GeronCount, ReiCount,
                                               AilenCount, FaefyrCount, AuriCount,
                                               NicteCount,
                                               JamesCount,
                                               KairyCount, TaurusCount, TronixCount,
                                               AquortisCount, AerisCount, GeumCount,
                                               DruidCount, IgnitorCount, UndineCount,
                                               RudeanCount, AuralCount, GerorCount,
                                               VeildurCount, BrynCount, GrothCount,
                                               OureaCount, ErebusCount, PontusCount,
                                               ChromaCount, PetryCount, ZaytusCount,
                                               SpykeCount, AoyukiCount, GaiaCount,
                                               OymosCount, XarthCount, AtzarCount,
                                               ZethCount, KothCount, GurthCount,
                                               WerewolfCount, JackCount, DullahanCount,
                                               OdelithCount, ShyguCount, ThertCount, KirkCount, NeptuniusCount,
                                               SigrunCount, KoldisCount, AlvitrCount,
                                               HamaCount, HallinskidiCount, RigrCount,
                                               AAlphaCount, AAthosCount, AReiCount, AAuriCount, ATronixCount, AGeumCount, AGerorCount,
                                               null,
                                               elfCount, deerCount, santaCount, maryCount,
                                               TothCount, GanahCount, DagdaCount, BubblesCount, APontusCount, AAtzarCount,
                                               ArshenCount, RuaCount, DorthCount,
                                               aRigrCount, null,
                                               HosokawaCount, TakedaCount, HirateCount, HattoriCount,
                                               aDagdaCount, BylarCount, BoorCount, BavahCount, LeprCount,
                                               SparksCount, LeafCount, FlynnCount,
                                               aBavahCount, HawkingCount, LeeCount, KumuCount, ChengCount, HidokaCount,
                                               null,
                                               DicemasterCount, LuxCount, PokerCount,
                                               TaintCount, PutridCount, DefileCount,
                                               NeilCount,
                                               MahatmaCount, JadeCount, EdanaCount, DybbukCount

            };
            heroBoxes = new List<CheckBox>() { JamesBox,
                                               HunterBox, ShamanBox, AlphaBox,
                                               CarlBox, NimueBox, AthosBox,
                                               JetBox, GeronBox, ReiBox,
                                               AilenBox, FaefyrBox, AuriBox,
                                               KairyBox, TaurusBox, TronixBox,
                                               AquortisBox, AerisBox, GeumBox,
                                               RudeanBox, AuralBox, GerorBox,
                                               OureaBox, ErebusBox, PontusBox,
                                               OymosBox, XarthBox, AtzarBox,
                                               LadyBox, TinyBox, NebraBox,
                                               VeildurBox, BrynBox, GrothBox,
                                               ZethBox, KothBox, GurthBox,
                                               SpykeBox, AoyukiBox, GaiaBox,
                                               ValorBox, RokkaBox, PyroBox, BewatBox,
                                               NicteBox, DruidBox, IgnitorBox, UndineBox,
                                               ChromaBox, PetryBox, ZaytusBox,
                                               WerewolfBox, JackBox, DullahanBox,
                                               OdelithBox, ShyguBox, ThertBox, KirkBox, NeptuniusBox,
                                               SigrunBox, KoldisBox, AlvitrBox,
                                               HamaBox, HallinskidiBox, RigrBox,
                                               AAlphaBox, AAthosBox, AReiBox, AAuriBox, ATronixBox, AGeumBox, AGerorBox,
                                               null,
                                               elfBox, deerBox, santaBox, maryBox,
                                               TothBox, GanahBox, DagdaBox, BubblesBox, APontusBox, AAtzarBox,
                                               ArshenBox, RuaBox, DorthBox,
                                               aRigrBox, null,
                                               HosokawaBox, TakedaBox, HirateBox, HattoriBox,
                                               aDagdaBox, BylarBox, BoorBox, BavahBox, LeprBox,
                                               SparksBox, LeafBox, FlynnBox,
                                               aBavahBox, HawkingBox, LeeBox, KumuBox, ChengBox, HidokaBox,
                                               null,
                                               DicemasterBox, LuxBox, PokerBox,
                                               TaintBox, PutridBox, DefileBox,
                                               NeilBox,
                                               MahatmaBox, JadeBox, EdanaBox, DybbukBox

            };

            questBoxes = new List<CheckBox>() {
                checkBox1, checkBox2, checkBox3,
                checkBox6, checkBox5, checkBox4,
                checkBox9, checkBox8, checkBox7,
                checkBox12, checkBox11, checkBox10,
                checkBox15, checkBox14, checkBox13,

                checkBox30, checkBox29, checkBox28,
                checkBox27, checkBox26, checkBox25,
                checkBox24, checkBox23, checkBox22,
                checkBox21, checkBox20, checkBox19,
                checkBox18, checkBox17, checkBox16,

                checkBox45, checkBox44, checkBox43,
                checkBox42, checkBox41, checkBox40,
                checkBox39, checkBox38, checkBox37,
                checkBox36, checkBox35, checkBox34,
                checkBox33, checkBox32, checkBox31,

                checkBox60, checkBox59, checkBox58,
                checkBox57, checkBox56, checkBox55,
                checkBox54, checkBox53, checkBox52,
                checkBox51, checkBox50, checkBox49,
                checkBox48, checkBox47, checkBox46,

                checkBox75, checkBox74, checkBox73,
                checkBox72, checkBox71, checkBox70,
                checkBox69, checkBox68, checkBox67,
                checkBox66, checkBox65, checkBox64,
                checkBox63, checkBox62, checkBox61,

                checkBox105, checkBox104, checkBox103,
                checkBox102, checkBox101, checkBox100,
                checkBox99, checkBox98, checkBox97,
                checkBox96, checkBox95, checkBox94,
                checkBox93, checkBox92, checkBox91,

                checkBox90, checkBox89, checkBox88,
                checkBox87, checkBox86, checkBox85,
                checkBox84, checkBox83, checkBox82,
                checkBox81, checkBox80, checkBox79,
                checkBox78, checkBox77, checkBox76,

                checkBox120, checkBox119, checkBox118,
                checkBox117, checkBox116, checkBox115,
                checkBox114, checkBox113, checkBox112,
                checkBox111, checkBox110, checkBox109,
                checkBox108, checkBox107, checkBox106,

                checkBox150, checkBox149, checkBox148,
                checkBox147, checkBox146, checkBox145,
                checkBox144, checkBox143, checkBox142,
                checkBox141, checkBox140, checkBox139,
                checkBox138, checkBox137, checkBox136,

                checkBox135, checkBox134, checkBox133,
                checkBox132, checkBox131, checkBox130,
                checkBox129, checkBox128, checkBox127,
                checkBox126, checkBox125, checkBox124,
                checkBox123, checkBox122, checkBox121,

                checkBox165, checkBox164, checkBox163,
                checkBox162, checkBox161, checkBox160,
                checkBox159, checkBox158, checkBox157,
                checkBox156, checkBox155, checkBox154,
                checkBox153, checkBox152, checkBox151,

                checkBox195, checkBox194, checkBox193,
                checkBox192, checkBox191, checkBox190,
                checkBox189, checkBox188, checkBox187,
                checkBox186, checkBox185, checkBox184,
                checkBox183, checkBox182, checkBox181,

                checkBox180, checkBox179, checkBox178,
                checkBox177, checkBox176, checkBox175,
                checkBox174, checkBox173, checkBox172,
                checkBox171, checkBox170, checkBox169,
                checkBox168, checkBox167, checkBox166,

                checkBox225, checkBox224, checkBox223,
                checkBox222, checkBox221, checkBox220,
                checkBox219, checkBox218, checkBox217,
                checkBox216, checkBox215, checkBox214,
                checkBox213, checkBox212, checkBox211,

                checkBox210, checkBox209, checkBox208,
                checkBox207, checkBox206, checkBox205,
                checkBox204, checkBox203, checkBox202,
                checkBox201, checkBox200, checkBox199,
                checkBox198, checkBox197, checkBox196,

                checkBox240, checkBox239, checkBox238,
                checkBox237, checkBox236, checkBox235,
                checkBox234, checkBox233, checkBox232,
                checkBox231, checkBox230, checkBox229,
                checkBox228, checkBox227, checkBox226,

                checkBox255, checkBox254, checkBox253,
                checkBox252, checkBox251, checkBox250,
                checkBox249, checkBox248, checkBox247,
                checkBox246, checkBox245, checkBox244,
                checkBox243, checkBox242, checkBox241,

                checkBox300, checkBox299, checkBox298,
                checkBox297, checkBox296, checkBox295,
                checkBox294, checkBox293, checkBox292,
                checkBox291, checkBox290, checkBox289,
                checkBox288, checkBox287, checkBox286,

                checkBox285, checkBox284, checkBox283,
                checkBox282, checkBox281, checkBox280,
                checkBox279, checkBox278, checkBox277,
                checkBox276, checkBox275, checkBox274,
                checkBox273, checkBox272, checkBox271,

                checkBox270, checkBox269, checkBox268,
                checkBox267, checkBox266, checkBox265,
                checkBox264, checkBox263, checkBox262,
                checkBox261, checkBox260, checkBox259,
                checkBox258, checkBox257, checkBox256,



            };
            questButtons = new List<Button>() {
                button11, button12, button13, button14, button15,
                button20, button19, button18, button17, button16,
                button25, button24, button23, button22, button21,
                button30, button29, button28, button27, button26,
                button35, button34, button33, button32, button31,
                button45, button44, button43, button42, button41,
                button40, button39, button38, button37, button36,
                button50, button49, button48, button47, button46,
                button60, button59, button58, button57, button56,
                button55, button54, button53, button52, button51,
                button65, button64, button63, button62, button61,
                button75, button74, button73, button72, button71,
                button70, button69, button68, button67, button66,
                button85, button84, button83, button82, button81,
                button80, button79, button78, button77, button76,
                button90, button89, button88, button87, button86,
                button95, button94, button92, button10, button3,
                button110, button109, button108, button107, button106,
                button105, button104, button103, button102, button101,
                button100, button99, button98, button97, button96
            };

            init();
            String[] cmdArguments = Environment.GetCommandLineArgs();
            if (cmdArguments.Length > 1)
            {
                if (token != null && KongregateId != null && cmdArguments[1] == "quick")
                {
                    this.Hide();

                    sendTillNoSolveButton_Click(this, EventArgs.Empty);
                    Console.Write(output);
                    Environment.Exit(0);
                    //Application.Exit();
                }
                if (token != null && KongregateId != null && cmdArguments[1] == "quickdung")
                {
                    this.Hide();
                    getDungeonButton_Click(this, EventArgs.Empty);
                    sendTillNoSolveButton_Click(this, EventArgs.Empty);
                    Console.Write(output);
                    Environment.Exit(0);
                    //Application.Exit();
                }
            }
        }
        void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ue = (Exception)e.ExceptionObject;
            using (StreamWriter sw = new StreamWriter("ExceptionLog.txt", true))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(ue);
            }
        }
        private void hideButtons()
        {
            getDQButton.Enabled = false;
            button9.Enabled = false;
            autoSend.Enabled = false;
            guiLog.Enabled = false;
            getQuestsButton.Enabled = false;
            upper100.Enabled = false;
            upper110.Enabled = false;
            lower30.Enabled = false;
            lower60.Enabled = false;
            refreshFollowersButton.Enabled = false;


        }


        private string getSetting(string s)
        {
            if (s == null || s == String.Empty)
                return null;
            else
            {
                s = s.TrimStart(" ".ToArray());
                int index = s.IndexOfAny("/ \t\n".ToArray());
                if (index > 0)
                {
                    s = s.Substring(0, index);
                }
                return s.Trim();
            }
        }

        private void init()
        {
            string lower = null, upper = null;
            if (!File.Exists("Newtonsoft.Json.dll"))
            {
                MessageBox.Show("Newtonsoft file not found. Please download it from this project's github");
            }
            previousDQTime = DateTime.UtcNow;
            if (File.Exists(SettingsFilename))
            {
                appSettings = AppSettings.loadSettings();
                token = appSettings.token;
                KongregateId = appSettings.KongregateId;
                defaultActionOnOpen = appSettings.actionOnStart ?? 0;
                lower = appSettings.defaultLowerLimit;
                upper = appSettings.defaultUpperLimit;

            }
            else if (File.Exists("MacroSettings.txt"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("MacroSettings.txt");
                appSettings.actionOnStart = defaultActionOnOpen = int.Parse(getSetting(sr.ReadLine()));
                token = appSettings.token = getSetting(sr.ReadLine());
                KongregateId = appSettings.KongregateId = getSetting(sr.ReadLine());

                lower = appSettings.defaultLowerLimit = getSetting(sr.ReadLine());
                upper = appSettings.defaultUpperLimit = getSetting(sr.ReadLine());
                appSettings.saveSettings();
                sr.Close();
            }
            else
            {
                token = null;
                KongregateId = null;
                DialogResult dr = MessageBox.Show("Settings file not found. Do you want help with creating one?", "Settings Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    button111_Click(this, EventArgs.Empty);
                }

            }
            if (token == "1111111111111111111111111111111111111111111111111111111111111111" || KongregateId == "000000")
            {
                token = KongregateId = null;
            }
            if (token != null && KongregateId != null)
            {
                pf = new PFStuff(token, KongregateId);
            }
            else
            {
                hideButtons();
            }
            if (lower != null)
            {
                if (lower.Contains("%"))
                {
                    lowerFollowerPerc = Int64.Parse(lower.Split('%')[0]) / 100.0;
                }
                else
                {
                    lowerCount.Value = Int64.Parse(lower);
                }
            }

            if (upper != null)
            {
                if (upper.Contains("%"))
                {
                    upperFollowerPerc = Int64.Parse(upper.Split('%')[0]) / 100.0;
                }
                else
                {
                    upperCount.Value = Int64.Parse(upper);
                }
            }
            switch (defaultActionOnOpen)
            {
                case (0):
                    break;
                case (1):
                    if (File.Exists("defaultHeroes"))
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader("defaultHeroes");
                        ReadLevels(sr.ReadLine());
                        string s;
                        if ((s = sr.ReadLine()) != null)
                        {
                            setBoxes(s);
                        }
                        sr.Close();
                    }
                    else
                    {
                        MessageBox.Show("No default file found. Make sure its name is \"defaultHeroes\"");
                    }
                    break;
                case (2):
                    if (token != null)
                    {
                        getData(true, true, false, false);
                        button5_Click(this, EventArgs.Empty);
                    }
                    break;
                case (3):
                    if (token != null)
                    {
                        getData(true, true, true, false);
                        button5_Click(this, EventArgs.Empty);
                    }
                    break;
                case (4):
                    if (token != null)
                    {
                        getData(true, true, true, true);
                        button5_Click(this, EventArgs.Empty);
                    }
                    break;
                case (5):
                    if (token != null)
                    {
                        getData(true, true, true, true);
                        for (int i = 0; i < appSettings.calcEnabledHeroes.Count; i++)
                        {
                            int index = Array.FindIndex(names, w => w == appSettings.calcEnabledHeroes[i]);
                            heroBoxes[index].Checked = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        List<Hero> heroList = new List<Hero>(new Hero[] {
            new Hero(50,12,6,1,1.2),
            new Hero(22,14,1,0,0), new Hero(40,20,2,0,0), new Hero(82,22,6,0,10000),            //hunter, shaman, alpha
            new Hero(28,12,1,0,0), new Hero(38,22,2,0,0), new Hero(70,26,6,0,2000),             //carl, nimue, athos
            new Hero(24,16,1,0,0), new Hero(36,24,2,0,0), new Hero(46,40,6,0,2500),             //jet, geron, rei
            new Hero(19,22,1,0,0), new Hero(50,18,2,0,0), new Hero(60,32,6,0,1500),             //ailen, faefyr, auri
            new Hero(28,16,1,0,0), new Hero(46,20,2,0,1000), new Hero(100,20,6,0,50000),        //kairy, taurus, tronix
            new Hero(58,8,1,0,0), new Hero(30,32,2,0,0), new Hero(75,2,6,0,0),                  //aquortis, aeris, geum
            new Hero(38,12,1,0,0), new Hero(18,50,2,0,0), new Hero(46,46,6,1,1.3),              //rudean, aural, geror
            new Hero(30,16,1,0,0), new Hero(48,20,2,0,0), new Hero(62,36,6,1,1.15),             //ourea, erebus, pontus
            new Hero(36,14,1,0,0), new Hero(32,32,2,0,0), new Hero(76,32,6,1,1.15),             //oymos, xarth, atzar
            new Hero(45,20,1,0,0), new Hero(70,30,2,0,0), new Hero(90,40,6,0,10000),            //lady, tiny, nebra
            new Hero(66,44,6,0,20000), new Hero(72,48,6,0,30000), new Hero(78,52,6,0,40000),    //veildur, bryn, groth
            new Hero(70,42,6,1,1.05), new Hero(76,46,6,1,1.08), new Hero(82,50,6,1,1.10),       //zeth, koth, gurth
            new Hero(75,45,6,0,20000), new Hero(70,55,6,0,15000), new Hero(50,100,6,0,0),       //spyke, aoyuki, gaia
            new Hero(20,10,1,0,0), new Hero(30,8,1,0,0), new Hero(24,12,1,0,0), new Hero(50,6,1,0,0),
            new Hero(22,32,2,0,0), new Hero(46,16,2,0,0), new Hero(32,24,2,0,0), new Hero(58,14,2,0,0),
            new Hero(52,20,2,0,0), new Hero(26,44,2,0,0), new Hero(58,22,2,0,0),
            new Hero(35,25,1,0,0), new Hero(55,35,2,0,0), new Hero(75,45,6,0,0),
            new Hero(36,36,2,0,0), new Hero(34,54,6,0,0), new Hero(72,28,6,0,0), new Hero(32,64,6,0,0), new Hero(30,70,6,0,0),
            new Hero(65,12,6,0,0), new Hero(70,14,6,0,0), new Hero(75,16,6,0,0),               // Sigrun, Koldis, Alvitr
            new Hero(30,18,1,0,0), new Hero(34,34,2,0,0), new Hero(60,42,6,0,0),                //Hama, Halli, Rigr
            new Hero(174,46,12,0,0), new Hero(162,60,12,0,0), new Hero(120,104,12,0,0), new Hero(148,78,12,0,0),new Hero(190,38,12,0,0),new Hero(222,8,12,0,0),new Hero(116,116,12,0,0),
            null,
            new Hero(38,24,1,0,0), new Hero(54,36,2,0,0), new Hero(72,48,6,0,0), new Hero(44,44,2,0,0), //xmas
            new Hero(24,24,1,0,0), new Hero(40,30,2,0,0), new Hero(58,46,6,1,1.15),             //toth, ganah, dagda
            new Hero(174,46,12,0,0),                                                            //bubbles
            new Hero(150,86,12,0,0),new Hero(162,81,12,0,0),
            new Hero(74,36,6,0,0), new Hero(78,40,6,0,0), new Hero(82,44,6,0,0),
            new Hero(141,99,12,0,0), null,
            new Hero(42,50,6,0,0), new Hero(32,66,6,0,0), new Hero(38,56,6,0,0), new Hero(44,48,6,0,0),
            new Hero(135,107,12,0,0), //adagda
            new Hero(30,20,1,0,0), new Hero(36,36,2,0,0), new Hero(52,52,6,0,0), //bavah, boor
            new Hero(25,75,6,0,0),
            new Hero(30,30,2,0,0), new Hero(48,42,4,0,0), new Hero(70,48,12,0,0), //sparks, leaf, flynn
            new Hero(122,122,12,0,0),new Hero(60,66,6,0,0), //bavah , hawking
            new Hero(150,90,12,0,0), new Hero(70,38,6,0,0), new Hero(78,42,6,0,0), new Hero(86,44,6,0,0),
            null,
            new Hero(25,26,1,0,0), new Hero(28,60,2,0,0), new Hero(70,70,6,0,0),
            new Hero(25,25,1,0,0), new Hero(48,50,2,0,0), new Hero(52,48,6,0,0),
            new Hero(150,15,6,0,0)
        });

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                ReadLevels(sr.ReadLine());
                string s;
                if ((s = sr.ReadLine()) != null)
                {
                    setBoxes(s);
                }
                sr.Close();
            }
        }


        private void ReadLevels(string s)
        {
            try
            {
                int[] levels = s.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                for (int i = 0; i < levels.Length; i++)
                {
                    if (heroCounts[i] != null)
                        heroCounts[i].Value = levels[i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wrong input file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setBoxes(string s)
        {
            int[] bools = s.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            for (int i = 0; i < bools.Length; i++)
            {
                if (heroBoxes[i] != null)
                    heroBoxes[i].Checked = bools[i] == 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(save.OpenFile());
                List<int> levels = new List<int>();
                foreach (NumericUpDown n in heroCounts)
                {
                    if (n != null)
                    {
                        levels.Add((int)n.Value);
                    }
                    else
                    {
                        levels.Add(0);
                    }
                }
                string s = string.Join(",", levels.ToArray());
                sw.WriteLine(s);
                List<int> bools = new List<int>();
                foreach (CheckBox cb in heroBoxes)
                {
                    if (cb != null)
                        bools.Add(cb.Checked ? 1 : 0);
                    else
                        bools.Add(0);
                }
                s = string.Join(",", bools.ToArray());
                sw.Write(s);

                sw.Close();
            }
        }

        private void runCalcButton_Click(object sender, EventArgs e)
        {
            int heroChecked = 0;
            DialogResult dr = DialogResult.Yes;
            foreach (CheckBox cb in heroBoxes)
            {
                if (cb != null && cb.Checked)
                {
                    heroChecked++;
                }
            }
            if (!wrongHeroAmountAlreadyAsked)
            {
                if (heroChecked == 0)
                {
                    dr = MessageBox.Show("You haven't enabled any heroes. Are you sure you want to run the calculator without using any heroes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
                else if (heroChecked > 20)
                {
                    dr = MessageBox.Show("You are using more than 20 heroes, that might considerably slow down the calculations. Are you sure you want to run the calc with so many heroes enabled?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
                if (lowerCount.Value != -1 && monstersCosts.Count(x => x > lowerCount.Value && x < upperCount.Value) > 50)
                {
                    dr = MessageBox.Show("Your limits will make the calc use more than 50 monsters, that might considerably slow down the calculations. Are you sure you want to run the calc with so many monsters enabled?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dr = DialogResult.Yes;
            }
            if (dr == DialogResult.Yes)
            {
                wrongHeroAmountAlreadyAsked = true;
                try
                {
                    if (autoSend.Checked)
                    {
                        List<string> lineups = lineupBox.Text.Split(' ').ToList();
                        foreach (string lp in lineups)
                        {
                            if (lp.Contains("DUNG"))
                            {
                                createMacroFile(lp.Substring(5));
                            }
                            else
                            {
                                createMacroFile(lp);
                            }
                            RunWithRedirect("CosmosQuest.exe");
                            //calcOut = calcOut.Substring(0, calcOut.Length - 24);
                            JObject solution = JObject.Parse(calcOut);
                            if (solution["validSolution"]["solution"].ToString() != String.Empty)
                            {
                                var mon = solution["validSolution"]["solution"]["monsters"];
                                if (mon.Count() > 0)
                                {
                                    output = calcOut;
                                    List<int> solutionLineupIDs = new List<int>();
                                    foreach (JToken jt in mon)
                                    {
                                        solutionLineupIDs.Add(Convert.ToInt32(jt["id"]));
                                    }
                                    while (solutionLineupIDs.Count < 6)
                                    {
                                        solutionLineupIDs.Add(-1);
                                    }
                                    PFStuff.lineup = solutionLineupIDs.ToArray();
                                    System.Threading.Thread.Sleep(Math.Max(0, (previousDQTime.AddSeconds(5.1) - DateTime.UtcNow).Milliseconds));
                                    Thread mt;
                                    if (lp.Contains("quest"))
                                    {
                                        int a = lp.IndexOf("-");
                                        string s = lp.Substring(5, a - 5);
                                        Console.Write("\n" + s);
                                        PFStuff.questID = Int32.Parse(s) - 1;
                                        mt = new Thread(pf.sendQuestSolution);
                                        mt.Start();
                                        mt.Join();
                                    }
                                    else if (lp.Contains("DUNG"))
                                    {
                                        mt = new Thread(pf.sendDungSolution);
                                        mt.Start();
                                        mt.Join();
                                    }
                                    else
                                    {
                                        mt = new Thread(pf.sendDQSolution);
                                        mt.Start();
                                        mt.Join();
                                        previousDQTime = DateTime.UtcNow;
                                    }
                                    if (PFStuff.DQResult)
                                    {
                                        if (lp.Contains("quest"))
                                        {
                                            guiLog.AppendText("Quest " + (PFStuff.questID + 1) + " solution accepted by server\n");
                                        }
                                        else if (lp.Contains("DUNG"))
                                        {
                                            guiLog.AppendText("Dungeon " + PFStuff.dungeonLvl + " solution accepted by server\n");
                                            getDungeonButton_Click(this, EventArgs.Empty);
                                        }
                                        else
                                        {
                                            guiLog.AppendText("DQ solution accepted by server\n");
                                            setDQData();
                                        }
                                    }
                                    else
                                    {
                                        guiLog.AppendText("Solution rejected by server\n");
                                    }
                                }

                            }
                            else
                            {
                                guiLog.AppendText("Solution not found\n");
                                PFStuff.lineup = null;
                            }
                        }
                    }
                    else
                    {
                        createMacroFile(lineupBox.Text.Replace("DUNG,", ""));
                        Process.Start("CosmosQuest.exe", "gen.cqinput");
                    }
                    guiLog.ScrollToCaret();


                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("Something went wrong. Make sure Macro Creator is in the same folder as calc.\nError Message: " + ex.Message,
                        "Error " + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        void RunWithRedirect(string cmdPath)
        {
            calcOut = "";
            var proc = new Process();
            proc.StartInfo.FileName = cmdPath;
            proc.StartInfo.Arguments = "gen.cqinput -server";

            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.EnableRaisingEvents = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;

            proc.ErrorDataReceived += proc_DataReceived;
            proc.OutputDataReceived += proc_DataReceived;

            proc.Start();

            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            proc.WaitForExit();

        }

        void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                calcOut += e.Data + "\n";
            }
        }

        private void createMacroFile(string lineup)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("gen.cqinput");
            List<string> l = new List<string>();
            for (int i = 0; i < heroCounts.Count; i++)
            {
                if (heroBoxes[i] != null && heroCounts[i] != null)
                {
                    if (heroBoxes[i].Checked && heroCounts[i].Value > 0)
                    {
                        l.Add(names[i] + ":" + heroCounts[i].Value);
                    }
                }

            }
            for (int i = 0; i < l.Count; i++)
            {
                sw.WriteLine(l[i]);
            }
            sw.WriteLine("done");
            sw.WriteLine(lowerCount.Value);
            sw.WriteLine(upperCount.Value);

            sw.WriteLine(checkForAliases(lineup));
            sw.WriteLine("y");
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (CheckBox cb in heroBoxes)
            {
                if (cb != null && cb.Checked)
                    counter++;
            }
            if (counter > heroBoxes.Count / 2)
            {
                foreach (CheckBox cb in heroBoxes)
                    if (cb != null)
                    {
                        cb.Checked = false;
                        CSHC.Text = "0";
                    }
            }
            else
            {
                for (int i = 0; i < heroBoxes.Count; i++)
                {
                    if (heroBoxes[i] != null && heroCounts[i].Value != 0)
                    {
                        heroBoxes[i].Checked = true;
                    }
                }
                //foreach (CheckBox cb in heroBoxes)
                //    if (cb != null)
                //        cb.Checked = true;
            }
        }

        private void chooseHeroes()
        {
            foreach (CheckBox cb in heroBoxes)
                if (cb != null)
                    cb.Checked = false;
            int[] strength = new int[heroCounts.Count];
            for (int i = 0; i < heroCounts.Count; i++)
            {
                if (heroList[i] != null && heroCounts[i] != null && heroCounts[i].Enabled)
                    strength[i] = heroList[i].getStrength((int)heroCounts[i].Value);
            }
            int index;
            int[] sorted = strength.OrderByDescending(i => i).ToArray();
            int j = 0;
            while (sorted[j] > (decimal)0.33 * lowerCount.Value && (j < 8 || (j < 14 && sorted[j + 1] > sorted[j] * 0.5)))
            {
                index = Array.IndexOf(strength, sorted[j]);
                heroBoxes[index].Checked = true;
                j++;
            }
        }

        private string checkForAliases(string l)
        {
            string[] units = l.Split(',');
            List<string> result = new List<string>();
            foreach (string u in units)
            {
                if (u.Contains(':'))
                {
                    string[] hero = u.Split(':');
                    if (aliases.ContainsKey(hero[0].ToUpper()))
                    {
                        result.Add(aliases[hero[0].ToUpper()] + ":" + hero[1]);
                    }
                    else
                    {
                        result.Add(u);
                    }
                }
                else
                {
                    result.Add(u);
                }
            }
            return result.Aggregate((current, next) => current + "," + next);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            chooseHeroes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lower follower limit. It disables low tier monsters making calculations a little faster.\nDefault is 0(no limit)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Upper follower limit. Disables high tier monsters(those you can't afford) making calculations a little faster.\nDefault is -1(no limit)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Write enemy lineup here.\nUses same format as Dice's calc - units are separated by comma, heroes are Name:Level\nQuests are written like questX-Y where X is quest number and Y is 1 for 6 monsters solution, 2 for 5 monsters, 3 for 4 monsters\n\nExample lineups:\na10,f10,w10,e10,e10,nebra:40\nquest33-2", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void login()
        {
            Thread mt;
            mt = new Thread(pf.LoginKong);
            mt.Start();
            mt.Join();
            if (PFStuff.logres)
            {
                guiLog.AppendText("Successfully logged in\n");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Failed to log in. Do you want help with creating MacroSettings file?", "Settings Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    button111_Click(this, EventArgs.Empty);
                }
                hideButtons();
                throw new System.InvalidOperationException("Failed to log in");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            getData(true, false, false, false);
        }

        private void calculatePranaCosts()
        {
            int PGrare = 0;
            int PGcommon = 0;
            int maxedCommons = 0;
            int maxedRares = 0;
            int maxedLegs = 0;
            int[] chestRaresID = new int[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 63, 78, 94 };
            foreach (int i in chestRaresID)
            {
                PGrare += (99 - Math.Max(1, (int)heroCounts[i].Value)) * 3;
                PGcommon += (99 - Math.Max(1, (int)heroCounts[i - 1].Value));

                maxedCommons += heroCounts[i - 1].Value == 99 ? 0 : 1;
                maxedRares += heroCounts[i].Value == 99 ? 0 : 1;
                maxedLegs += heroCounts[i + 1].Value == 99 ? 0 : 1;
            }
            PGforMaxCommon.Text = PGcommon.ToString("# ##0");
            PGforMaxRare.Text = PGrare.ToString("# ##0");

            if (maxedCommons + maxedRares + maxedLegs == 0)
                maxedCommons = maxedRares = maxedLegs = chestRaresID.Length;
            double totalWeight = 0.6 * maxedCommons + 0.3 * maxedRares + 0.1 * maxedLegs;

            double commonChance = 0.6 * maxedCommons / totalWeight;
            double rareChance = 0.3 * maxedRares / totalWeight;
            double legChance = 0.1 * maxedLegs / totalWeight;

            normalCommonChanceLabel.Text = (commonChance / 5.0).ToString("0.##%");
            normalRareChanceLabel.Text = (rareChance / 5.0).ToString("0.##%");
            normalLegChanceLabel.Text = (legChance / 5.0).ToString("0.##%");

            heroCommonChanceLabel.Text = (commonChance).ToString("0.##%");
            heroRareChanceLabel.Text = (rareChance).ToString("0.##%");
            heroLegChanceLabel.Text = (legChance).ToString("0.##%");

            normalAvgPranaLabel.Text = (1 * commonChance / 5 + 3 * rareChance / 5 + 12 * legChance / 5).ToString("0.##");
            heroAvgPranaLabel.Text = (1 * commonChance + 3 * rareChance + 12 * legChance).ToString("0.##");


        }

        private void setDQData()
        {
            string[] enemylist = new string[5];
            for (int i = 0; i < 5; i++)
            {
                enemylist[i] = servernames[PFStuff.getResult[1][i] + heroesInGame];
                if (PFStuff.getResult[1][i] < -1)
                {
                    enemylist[i] += ":" + PFStuff.getResult[2][-PFStuff.getResult[1][i] - 2].ToString();
                }
            }
            enemylist = enemylist.Reverse().ToArray();
            lineupBox.Text = string.Join(",", enemylist);
            guiLog.AppendText("Successfully got enemy lineup for DQ" + PFStuff.DQlvl + " - " + string.Join(",", enemylist) + "\n");
        }

        private void getDQButton_Click(object sender, EventArgs e)
        {
            getData(false, false, true, false);
        }

        private void RigrBox_CheckedChanged(object sender, EventArgs e)
        {
            int temp = 0;
            foreach (CheckBox c in heroBoxes)
                if (c != null)
                    if (c.Checked)
                        temp++;
            CSHC.Text = temp.ToString();
        }


        private void questButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Predicate<Button> pre = delegate(Button a) { return a.Name == b.Name; };
            int index = questButtons.FindIndex(pre);
            lineupBox.Text += getQuestString(index);
        }

        private string getQuestString(int index)
        {
            if (questBoxes[3 * index + 2].Checked)
            {
                return null;
            }
            else
            {
                string s = " ";
                if (lineupBox.Text == "" || lineupBox.Text == null)
                {
                    s = "";
                }
                s += "quest" + (index + 1);
                s += questBoxes[3 * index + 1].Checked ? "-3" : questBoxes[3 * index].Checked ? "-2" : "-1";
                return s;
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runCalcButton_Click(this, EventArgs.Empty);
            }
        }

        private void questCheckboxChanged(object sender, EventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            Predicate<CheckBox> pre = delegate(CheckBox a) { return a.Name == b.Name; };
            setQuestBoxes(questBoxes.FindIndex(pre), b.Checked);
        }

        private void setQuestBoxes(int boxID, bool checkState)
        {
            if (boxID % 3 < 2)
            {
                if (questBoxes[boxID + 1].Checked)
                {
                    questBoxes[boxID].Checked = true;
                }
            }
            for (int i = 3 * (boxID / 3); i < 3 * (boxID / 3) + 3; i++)
            {
                if (i != boxID)
                {
                    if (i < boxID)
                    {
                        questBoxes[i].Checked = true;
                    }
                    else
                    {
                        questBoxes[i].Checked = false;
                    }
                }
            }
        }


        private void setQuestBoxesFromServer(int index, int questState)
        {
            for (int i = 0; i < 3; i++)
            {
                if (questState > 0)
                {
                    questBoxes[3 * index + i].Checked = true;
                }
                questState = questState / 2;
            }
        }

        private void deactivateButtons()
        {
            for (int i = 0; i < questButtons.Count(); i++)
            {
                if (questBoxes[3 * i + 2].Checked)
                {
                    questButtons[i].Enabled = false;
                }
                else
                {
                    questButtons[i].Enabled = true;
                }
            }
        }
        private void getQuestsButton_Click(object sender, EventArgs e)
        {
            getData(false, false, false, true);
        }

        private void setUpperFromServer(double d)
        {
            if (followerLabel.Text == "0")
            {
                upperCount.Value = -1;
            }
            else
            {
                upperCount.Value = (int)(d * Int32.Parse(followerLabel.Text.Replace(" ", "")));
            }
        }

        private void setLowerFromServer(double d)
        {
            if (followerLabel.Text == "0")
            {
                lowerCount.Value = 0;
            }
            else
            {
                lowerCount.Value = (int)(d * Int32.Parse(followerLabel.Text.Replace(" ", "")));
            }
        }


        private void button92_Click(object sender, EventArgs e)
        {
            if (followerLabel.Text == "0")
            {
                lowerCount.Value = 0;
            }
            else
            {
                lowerCount.Value = (int)(0.3 * Int32.Parse(followerLabel.Text.Replace(" ", "")));
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            int twoMonsterQuestLimit = 4;
            int oneMonsterQuestLimit = 1;
            List<string> result = new List<string>();
            lineupBox.Text = "";
            for (int i = 0; i < questButtons.Count; i++)
            {
                if (!questBoxes[3 * i + 2].Checked)
                {
                    if (questBoxes[3 * i + 1].Checked)
                    {
                        result.Add("quest" + (i + 1) + "-3");
                    }
                    else if (questBoxes[3 * i].Checked && twoMonsterQuestLimit > 0)
                    {
                        result.Add("quest" + (i + 1) + "-2");
                        twoMonsterQuestLimit--;
                    }
                    else if (!questBoxes[3 * i].Checked && oneMonsterQuestLimit > 0)
                    {
                        result.Add("quest" + (i + 1) + "-1");
                        oneMonsterQuestLimit--;
                    }
                }
            }
            lineupBox.Text = String.Join(" ", result);
        }

        private void upper100_Click(object sender, EventArgs e)
        {
            setUpperFromServer(1.0);
        }

        private void upper110_Click(object sender, EventArgs e)
        {
            setUpperFromServer(1.1);
        }

        private void lower30_Click(object sender, EventArgs e)
        {
            setLowerFromServer(0.3);
        }

        private void lower60_Click(object sender, EventArgs e)
        {
            setLowerFromServer(0.6);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            try
            {
                Thread mt;
                if (!PlayFab.PlayFabClientAPI.IsClientLoggedIn())
                {
                    login();
                }

                mt = new Thread(pf.GetGameData);
                mt.Start();
                mt.Join();
                if (PFStuff.getResult.Count > 0)
                {
                    guiLog.AppendText("Followers refreshed\n");
                    followerLabel.Text = PFStuff.followers.ToString("### ### ###");
                }
                else
                {
                    guiLog.AppendText("Failed to refresh followers\n");
                }
            }
            catch
            {
                MessageBox.Show("Failed to log in");
            }
        }

        private void clearLogButton_click(object sender, EventArgs e)
        {
            guiLog.Text = "";
        }

        private void getData(bool heroes, bool followers, bool DQ, bool quests)
        {
            try
            {
                Thread mt;
                if (!PlayFab.PlayFabClientAPI.IsClientLoggedIn())
                {
                    login();
                }

                mt = new Thread(pf.GetGameData);
                mt.Start();
                mt.Join();
                if (PFStuff.getResult.Count > 0)
                {
                    if (followers)
                    {
                        guiLog.AppendText("Followers refreshed\n");
                        followerLabel.Text = PFStuff.followers.ToString("### ### ###");
                        if (upperFollowerPerc != 0.0)
                        {
                            upperCount.Value = (decimal)(upperFollowerPerc * PFStuff.followers);
                        }
                        if (lowerFollowerPerc != 0.0)
                        {
                            lowerCount.Value = (decimal)(lowerFollowerPerc * PFStuff.followers);
                        }
                    }
                    if (heroes)
                    {
                        guiLog.AppendText("Successfully got hero levels from server\n");
                        for (int i = 0; i < heroCountsServerOrder.Count; i++)
                        {
                            if (heroCountsServerOrder[i] != null)
                                heroCountsServerOrder[i].Value = PFStuff.getResult[0][i];
                        }
                        //chooseHeroes();
                        followerLabel.Text = PFStuff.followers.ToString("### ### ###");
                        calculatePranaCosts();
                    }
                    if (DQ)
                    {
                        string[] enemylist = new string[5];
                        for (int i = 0; i < 5; i++)
                        {
                            enemylist[i] = servernames[PFStuff.getResult[1][i] + heroesInGame];
                            if (PFStuff.getResult[1][i] < -1)
                            {
                                enemylist[i] += ":" + PFStuff.getResult[2][-PFStuff.getResult[1][i] - 2].ToString();
                            }
                        }
                        enemylist = enemylist.Reverse().ToArray();
                        lineupBox.Text = string.Join(",", enemylist);
                        guiLog.AppendText("Successfully got enemy lineup for DQ" + PFStuff.DQlvl + " - " + string.Join(",", enemylist) + "\n");
                    }
                    if (quests)
                    {
                        int questMax = Math.Min(PFStuff.questList.Count(), 100);
                        for (int i = 0; i < questMax; i++)
                        {
                            setQuestBoxesFromServer(i, PFStuff.questList[i]);
                        }
                        deactivateButtons();
                        guiLog.AppendText("Successfully got quests from server\n");
                    }
                }
                else
                {
                    guiLog.AppendText("Failed to obtain game data\n");
                }
            }
            catch (InvalidOperationException)
            {
                guiLog.AppendText("Failed to log in - your Auth Ticket: " + token + ", your KongID: " + KongregateId);
            }
            catch (IndexOutOfRangeException)
            {
                guiLog.AppendText("Unknown unit");
            }
            catch (Exception dataException)
            {
                guiLog.AppendText("Error: " + dataException.Message);
            }
        }

        private void sendTillNoSolveButton_Click(object sender, EventArgs e)
        {
            wrongHeroAmountAlreadyAsked = false;
            int attempts = 0;
            string previousDQlvl = "";
            autoSend.Checked = true;
            if (lineupBox.Text.Contains("DUNG"))
            {
                while ((previousDQlvl != PFStuff.dungeonLvl.ToString() || !PFStuff.DQResult) && (PFStuff.lineup != null || attempts == 0))
                {
                    if (PFStuff.DQResult || attempts == 0)
                    {
                        attempts = 1;
                        previousDQlvl = PFStuff.dungeonLvl.ToString();
                        runCalcButton_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        if (attempts < 3)
                        {
                            attempts++;
                            guiLog.AppendText("Attempt no. " + attempts + " in 5 seconds\n");
                            System.Threading.Thread.Sleep(5000);
                            runCalcButton_Click(this, EventArgs.Empty);
                        }
                        else
                        {
                            guiLog.AppendText("Solution invalid, solving was stopped\n");
                            break;
                        }
                    }
                }
            }
            else
            {
                while ((previousDQlvl != PFStuff.DQlvl || !PFStuff.DQResult) && (PFStuff.lineup != null || attempts == 0))
                {
                    if (PFStuff.DQResult || attempts == 0)
                    {
                        attempts = 1;
                        previousDQlvl = PFStuff.DQlvl;
                        runCalcButton_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        if (attempts < 3)
                        {
                            attempts++;
                            guiLog.AppendText("Attempt no. " + attempts + " in 5 seconds\n");
                            System.Threading.Thread.Sleep(5000);
                            runCalcButton_Click(this, EventArgs.Empty);
                        }
                        else
                        {
                            guiLog.AppendText("Solution invalid, solving was stopped\n");
                            break;
                        }
                    }
                }
            }

        }

        private void button111_Click(object sender, EventArgs e)
        {
            MacroSettingsHelper msh = new MacroSettingsHelper(appSettings);
            msh.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Wiedmolol/CQAutomater");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button91_Click_1(object sender, EventArgs e)
        {
            List<string> enabled = new List<string>();
            for (int i = 0; i < heroCounts.Count; i++)
            {
                if (heroBoxes[i] != null && heroBoxes[i].Checked)
                    enabled.Add(names[i]);
            }
            appSettings = AppSettings.loadSettings();
            appSettings.calcEnabledHeroes = enabled;
            appSettings.saveSettings();
        }

        private void getDungeonButton_Click(object sender, EventArgs e)
        {
            PFStuff.getDungeonData(KongregateId);
            string[] enemylist = new string[6];
            for (int i = 0; i < 5; i++)
            {
                enemylist[i] = servernames[PFStuff.dungeonLineup[0][i] + heroesInGame];
                if (PFStuff.dungeonLineup[0][i] < -1)
                {
                    enemylist[i] += ":" + PFStuff.dungeonLineup[1][-PFStuff.dungeonLineup[0][i] - 2].ToString();
                }
            }
            enemylist[5] = "DUNG";
            enemylist = enemylist.Reverse().ToArray();
            lineupBox.Text = string.Join(",", enemylist);
            guiLog.AppendText("Successfully got enemy lineup for Dungeon" + PFStuff.dungeonLvl + " - " + string.Join(",", enemylist) + "\n");
        }

        private void ascendTargetLevel_ValueChanged(object sender, EventArgs e)
        {
            decimal sum = 0;
            for (decimal i = ascendCurrentLevel.Value; i < ascendTargetLevel.Value; i++)
            {
                sum += i;
            }
            sum += ascendCurrentLevel.Value == 0 ? 100 : 0;
            ascendCostLabel.Text = sum.ToString();
        }

        private void chestHeroLevel_ValueChanged(object sender, EventArgs e)
        {
            calculatePranaCosts();
        }
    }
}
