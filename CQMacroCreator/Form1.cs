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

namespace CQMacroCreator
{
    public partial class Form1 : Form
    {
        List<NumericUpDown> heroCounts;
        List<CheckBox> heroBoxes;
        ToolTip tp = new ToolTip();
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
                                               ChromaCount, PetryCount, ZaytusCount

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
                                               ChromaBox, PetryBox, ZaytusBox
            };
            int[] rarity = {6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               1,2,6,
                               6,6,6,
                               6,6,6,
                               6,6,6,
                               1,1,1,1,
                               2,2,2,2,
                               2,2,2
                           };
            
            tp.SetToolTip(lowerCount, "Lower follower limit. It disables low tier monsters making calculations a little faster. Default is 0(no limit)");
            tp.SetToolTip(upperCount, "Upper follower limit. Disables high tier monsters(those you can't afford) making calculations a little faster. Default is -1(no limit)");
            tp.SetToolTip(lineupBox, "Write enemy lineup here. Uses same format as Dice's calc - units are separated by comma, heroes are Name:Level\nQuests are written like questX-Y where X is quest number and Y is 1 for 6 monsters solutions, 2 for 5 monsters, 3 for 4 monsters");
        }

        List<Hero> heroList = new List<Hero>(new Hero[] {
            new Hero(50,12,6),
            new Hero(22,14,1), new Hero(40,20,2), new Hero(82,22,6),
            new Hero(28,12,1), new Hero(38,22,2), new Hero(70,26,6),
            new Hero(24,16,1), new Hero(36,24,2), new Hero(46,40,6),
            new Hero(19,22,1), new Hero(50,18,2), new Hero(60,32,6),
            new Hero(28,16,1), new Hero(46,20,2), new Hero(100,20,6),
            new Hero(58,8,1), new Hero(30,32,2), new Hero(75,2,6),
            new Hero(38,12,1), new Hero(18,50,2), new Hero(46,46,6),
            new Hero(30,16,1), new Hero(48,20,2), new Hero(62,36,6),
            new Hero(36,14,1), new Hero(32,32,2), new Hero(76,32,6),
            new Hero(45,20,1), new Hero(70,30,2), new Hero(90,40,6),
            new Hero(66,44,6), new Hero(72,48,6), new Hero(78,52,6),
            new Hero(70,42,6), new Hero(76,46,6), new Hero(82,50,6),
            new Hero(75,45,6), new Hero(70,55,6), new Hero(50,100,6),
            new Hero(20,10,1), new Hero(30,8,1), new Hero(24,12,1), new Hero(50,6,1),
            new Hero(22,32,2), new Hero(46,16,2), new Hero(32,24,2), new Hero(58,14,2),
            new Hero(52,20,2), new Hero(26,44,2), new Hero(58,22,2)

        });

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                ReadLevels(sr.ReadLine());
                string s;
                if((s = sr.ReadLine()) != null) {
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
                heroBoxes[i].Checked = bools[i]==1;
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
            try
            {
                createMacroFile();
                Process.Start("CosmosQuest.exe", "gen.cqinput");
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("Something went wrong. Make sure Macro Creator is in the same folder as calc.\nError Message: " + ex.Message,
                    "Error " + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createMacroFile()
        {
            Console.Write("\n" + Directory.GetCurrentDirectory());
            System.IO.StreamWriter sw = new System.IO.StreamWriter("gen.cqinput");
            sw.WriteLine("n");
            List<int> l = new List<int>();
            for (int i = 0; i < heroCounts.Count; i++)
            {
                if (heroBoxes[i].Checked)
                {
                    l.Add((int)heroCounts[i].Value);
                }
                else
                {
                    l.Add(0);
                }
            }
            for (int i = 0; i < l.Count; i++)
            {
                sw.WriteLine(l[i]);
            }
            sw.WriteLine(lowerCount.Value);
            sw.WriteLine(upperCount.Value);
            sw.WriteLine(lineupBox.Text);
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
            if (counter > heroBoxes.Count/2)
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
            int j=0;
            while((j<8 || (j<12 && sorted[j+1] > sorted[j]*0.75)) && Math.Pow(sorted[j],1.5) > (double)lowerCount.Value)
            {                
                index = Array.IndexOf(strength, sorted[j]);
                heroBoxes[index].Checked = true;
                j++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chooseHeroes();
        }

    }
}
