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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                ReadLevels(sr.ReadLine());
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(save.OpenFile());
                string s = string.Join(",", heroCounts.Select(x => x.Value).ToArray());
                sw.WriteLine(s);
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

    }
}
