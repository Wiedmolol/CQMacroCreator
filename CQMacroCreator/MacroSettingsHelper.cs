using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CQMacroCreator
{
    public partial class MacroSettingsHelper : Form
    {
        string[] DefaultActions = new string[] {
            "No action",
            "Load heroes from defaultHeroes file",
            "Load heroes from server",
            "Load heroes and DQ from server",
            "Load heroes, DQ and quest states from server"
        };

        public MacroSettingsHelper()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            actionLabel.Text = DefaultActions[(int)defaultActionCount.Value];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            Regex r = new Regex(@"^[a-fA-F0-9]*$");
            if (textBox1.Text.Length == 0)
            {
                ticketStatus.Text = "No ticket. Online functions like downloading heroes or sending solutions to server\nwon't be available.";
            }
            else if (textBox1.Text.Length != 64)
            {
                ticketStatus.Text = "Incorrect ticket length. Ticket should be 64 characters long.\nYours is " + textBox1.Text.Length + " characters long.";
            }
            else if (!r.IsMatch(textBox1.Text))
            {
                ticketStatus.Text = "Your ticket contains invalid characters.\nTicket should contain only digits and letters from 'a' to 'f'";
            }
            else
            {
                ticketStatus.Text = "-";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Trim();
            if (textBox2.Text.Length == 0)
            {
                kongIdStatus.Text = "No kongID. Online functions like downloading heroes or sending solutions to server\nwon't be available.";
            }
            else if (textBox2.Text.Length >= 9)
            {
                kongIdStatus.Text = "KongID might be incorrect. Usually KongID is 7 or 8 digits.\nYours is " + textBox2.Text.Length + " characters long.";
            }
            else if (!textBox2.Text.All(char.IsDigit))
            {
                kongIdStatus.Text = "Your kongID contains invalid characters.\nKongID should contain only digits.";
            }
            else
            {
                kongIdStatus.Text = "-";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("MacroSettings.txt");
            sw.WriteLine(defaultActionCount.Value.ToString());
            if (textBox1.Text.Length == 0)
            {
                sw.WriteLine("1111111111111111111111111111111111111111111111111111111111111111");
            }
            else
            {
                sw.WriteLine(textBox1.Text);
            }

            if (textBox2.Text.Length == 0)
            {
                sw.WriteLine("0000000");
            }
            else
            {
                sw.WriteLine(textBox2.Text);
            }


            if (lowerFlatRadio.Checked)
            {
                sw.WriteLine(lowerFlatCount.Value.ToString());
            }
            else if (lowerPercRadio.Checked)
            {
                sw.WriteLine(lowerPercCount.Value.ToString() + "%");
            }
            else
            {
                sw.WriteLine("-1");
            }

            if (upperFlatRadio.Checked)
            {
                sw.WriteLine(upperFlatCount.Value.ToString());
            }
            else if (upperPercRadio.Checked)
            {
                sw.WriteLine(upperPercCount.Value.ToString() + "%");
            }
            else
            {
                sw.WriteLine("-1");
            }

            sw.Close();
            MessageBox.Show("Settings saved to file. Restart the application to use the new settings.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.kongregate.com/forums/910715-cosmos-quest/topics/965457-cq-macro-creator-for-diceycles-calc");
        }

    }
}
