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


namespace CQMacroCreator
{
    public partial class Form1 : Form
    {
        static string calcOut;
        const int heroesInGame = 66;
        List<NumericUpDown> heroCounts;
        List<NumericUpDown> heroCountsServerOrder;
        List<CheckBox> heroBoxes;

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
            {"VOWELCHICK", "aoyuki"}
        };
        string token;
        string KongregateId;
        string defaultActionOnOpen = "0";

        string[] names = {"james", "hunter", "shaman", "alpha", "carl", "nimue", "athos", "jet", "geron", "rei", "ailen", "faefyr", "auri", "k41ry", "t4urus", "tr0n1x", 
                                "aquortis", "aeris", "geum", "rudean", "aural", "geror", "ourea", "erebus", "pontus", "oymos", "xarth", "atzar", "ladyoftwilight", "tiny", "nebra",
                              "veildur", "brynhildr", "groth", "zeth", "koth", "gurth", "spyke", "aoyuki", "gaiabyte", "valor", "rokka", "pyromancer", "bewat", "nicte", "forestdruid",
                              "ignitor", "undine", "chroma", "petry", "zaytus", "werewolf", "jackoknight", "dullahan", "ladyodelith", "shygu", "thert", "lordkirk", "neptunius",
                                "sigrun", "koldis", "alvitr", "hama", "hallinskidi", "rigr"};

        string[] servernames = {"rigr", "hallinskidi", "hama", "alvitr", "koldis", "sigrun", "neptunius", "lordkirk", "thert", "shygu", "ladyodelith", "dullahan", "jackoknight", "werewolf",
                               "gurth", "koth", "zeth", "atzar", "xarth", "oymos", "gaiabyte", "aoyuki", "spyke", "zaytus", "petry", "chroma", "pontus", "erebus", "ourea",
                               "groth", "brynhildr", "veildur", "geror", "aural", "rudean", "undine", "ignitor", "forestdruid", "geum", "aeris", "aquortis", "tronix", "taurus", "kairy",
                               "james", "nicte", "auri", "faefyr", "ailen", "rei", "geron", "jet", "athos", "nimue", "carl", "alpha", "shaman", "hunter", "bewat", "pyromancer", "rokka",
                               "valor", "nebra", "tiny", "ladyoftwilight", "", "A1", "E1", "F1", "W1", "A2", "E2", "F2", "W2", "A3", "E3", "F3", "W3", "A4", "E4", "F4", "W4",
                               "A5", "E5", "F5", "W5", "A6", "E6", "F6", "W6", "A7", "E7", "F7", "W7", "A8", "E8", "F8", "W8", "A9", "E9", "F9", "W9", "A10", "E10", "F10", "W10",
                               "A11", "E11", "F11", "W11", "A12", "E12", "F12", "W12", "A13", "E13", "F13", "W13", "A14", "E14", "F14", "W14", "A15", "E15", "F15", "W15"};

        public Form1()
        {
            InitializeComponent();
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
                                               HamaCount, HallinskidiCount, RigrCount

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
                                               HamaCount, HallinskidiCount, RigrCount

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
                                               HamaBox, HallinskidiBox, RigrBox
            };

            init();
        }
        private void hideButtons()
        {
            button10.Visible = false;
            button9.Visible = false;
            autoSend.Visible = false;
            guiLog.Visible = false;
        }

        private void init()
        {
            if (File.Exists("MacroSettings.txt"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("MacroSettings.txt");
                defaultActionOnOpen = sr.ReadLine();
                defaultActionOnOpen = defaultActionOnOpen.Substring(0, defaultActionOnOpen.IndexOfAny("/ \t".ToArray()));
                token = sr.ReadLine();
                if (token != null)
                {
                    token = token.Substring(0, token.IndexOfAny(" \t".ToArray()));
                    if (token == "1111111111111111111111111111111111111111111111111111111111111111")
                        token = null;
                }
                KongregateId = sr.ReadLine();
                if (KongregateId != null)
                    KongregateId = KongregateId.Substring(0, KongregateId.IndexOfAny(" \t".ToArray()));
            }
            else
            {
                token = null;
                KongregateId = null;
            }
            if (token != null && KongregateId != null)
            {
                pf = new PFStuff(token, KongregateId);
            }
            else
            {
                hideButtons();
            }
            switch (defaultActionOnOpen)
            {
                case ("0"):
                    break;
                case ("1"):
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
                case ("2"):
                    if (token != null)
                    {
                        button9_Click(this, EventArgs.Empty);
                        button5_Click(this, EventArgs.Empty);
                    }
                    break;
                case ("3"):
                    if (token != null)
                    {
                        button9_Click(this, EventArgs.Empty);
                        button10_Click(this, EventArgs.Empty);
                        button5_Click(this, EventArgs.Empty);
                    }
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
            new Hero(30,18,1,0,0), new Hero(34,34,2,0,0), new Hero(60,42,6,0,0)

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
                heroBoxes[i].Checked = bools[i] == 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(save.OpenFile());
                string s = string.Join(",", heroCounts.Select(x => x.Value).ToArray());
                sw.WriteLine(s);
                List<int> bools = new List<int>();
                foreach (CheckBox cb in heroBoxes)
                {
                    bools.Add(cb.Checked ? 1 : 0);
                }
                s = string.Join(",", bools.ToArray());
                sw.Write(s);

                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int heroChecked = 0;
            DialogResult dr = DialogResult.Yes;
            foreach (CheckBox cb in heroBoxes)
            {
                if (cb.Checked)
                {
                    heroChecked++;
                }
            }
            if (heroChecked == 0)
            {
                dr = MessageBox.Show("You haven't enabled any heroes. Are you sure you want to run the calculator without using any heroes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            else if (heroChecked > 20)
            {
                dr = MessageBox.Show("You are using more than 20 heroes, that might considerably slow down the calculations. Are you sure you want to run the calc with so many heroes enabled?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            if (dr == DialogResult.Yes)
            {
                try
                {
                    createMacroFile();
                    if (autoSend.Checked)
                    {
                        RunWithRedirect("CosmosQuest.exe");
                        JObject solution = JObject.Parse(calcOut);
                        Console.Write("\n" + solution["validSolution"]["solution"].ToString() + "Haha\n");
                        if (solution["validSolution"]["solution"].ToString() != String.Empty)
                        {
                            var mon = solution["validSolution"]["solution"]["monsters"];
                            if (mon.Count() > 0)
                            {
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
                                Thread mt;
                                mt = new Thread(pf.sendDQSolution);
                                mt.Start();
                                mt.Join();
                                if (PFStuff.DQResult)
                                {
                                    guiLog.AppendText("Solution accepted by server\n");
                                }
                                else
                                {
                                    guiLog.AppendText("Solution rejected by server\n");
                                }
                                button10_Click(this, EventArgs.Empty);
                            }
                        }
                        else
                        {
                            guiLog.AppendText("Solution not found\n");
                        }
                    }
                    else
                    {
                        Process.Start("CosmosQuest.exe", "gen.cqinput");
                    }
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

        private void createMacroFile()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("gen.cqinput");
            List<string> l = new List<string>();
            for (int i = 0; i < heroCounts.Count; i++)
            {
                if (heroBoxes[i].Checked && heroCounts[i].Value > 0)
                {
                    l.Add(names[i] + ":" + heroCounts[i].Value);
                }
            }
            for (int i = 0; i < l.Count; i++)
            {
                sw.WriteLine(l[i]);
            }
            sw.WriteLine("done");
            sw.WriteLine(lowerCount.Value);
            sw.WriteLine(upperCount.Value);

            sw.WriteLine(checkForAliases(lineupBox.Text));
            sw.WriteLine("y");
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (CheckBox cb in heroBoxes)
            {
                if (cb.Checked)
                    counter++;
            }
            if (counter > heroBoxes.Count / 2)
            {
                foreach (CheckBox cb in heroBoxes)
                    cb.Checked = false;
            }
            else
            {
                foreach (CheckBox cb in heroBoxes)
                    cb.Checked = true;
            }
        }

        private void chooseHeroes()
        {
            foreach (CheckBox cb in heroBoxes)
                cb.Checked = false;
            int[] strength = new int[heroCounts.Count];
            for (int i = 0; i < heroCounts.Count; i++)
            {
                strength[i] = heroList[i].getStrength((int)heroCounts[i].Value);
            }
            int index;
            int[] sorted = strength.OrderByDescending(i => i).ToArray();
            int j = 0;
            while ((j < 8 || (j < 14 && sorted[j + 1] > sorted[j] * 0.6)))
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
                hideButtons();
                throw new System.InvalidOperationException("Failed to log in");
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
                    guiLog.AppendText("Successfully got hero levels from server\n");
                    //upperCount.Value = (int)(PFStuff.followers * 1.1);
                    for (int i = 0; i < heroCountsServerOrder.Count; i++)
                    {
                        heroCountsServerOrder[i].Value = PFStuff.getResult[0][i];
                    }
                    chooseHeroes();
                }
                else
                {
                    guiLog.AppendText("Failed to get heroes from server\n");
                }
            }
            catch
            {
                MessageBox.Show("Failed to log in");
            }

        }

        private void button10_Click(object sender, EventArgs e)
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
                else
                {
                    guiLog.AppendText("Failed to get enemy lineup from server\n");
                }
            }
            catch
            {
                MessageBox.Show("Failed t o log in");
            }
        }


    }
}
