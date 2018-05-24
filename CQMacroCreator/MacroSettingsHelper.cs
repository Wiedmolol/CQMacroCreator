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
            "Load heroes, DQ and quest states from server",
            "Heroes&&DQ from server, enable heroes from settings"
        };

        public MacroSettingsHelper(AppSettings a)
        {
            InitializeComponent();
            textBox1.Text = a.token ?? "";
            textBox2.Text = a.KongregateId ?? "";
            if (a.defaultLowerLimit != null)
            {
                if (a.defaultLowerLimit.Contains("%"))
                {
                    lowerPercRadio.Checked = true;
                    lowerPercCount.Value = decimal.Parse(a.defaultLowerLimit.Split('%')[0]);
                }
                else if (a.defaultLowerLimit == "-1")
                {
                    lowerNoRadio.Checked = true;
                }
                else
                {
                    lowerFlatRadio.Checked = true;
                    lowerFlatCount.Value = decimal.Parse(a.defaultLowerLimit);
                }
            }
            if (a.defaultUpperLimit != null)
            {
                if (a.defaultUpperLimit.Contains("%"))
                {

                    upperPercRadio.Checked = true;
                    upperPercCount.Value = decimal.Parse(a.defaultUpperLimit.Split('%')[0]);
                }
                else if (a.defaultUpperLimit == "-1")
                {
                    upperNoRadio.Checked = true;
                }
                else
                {
                    upperFlatRadio.Checked = true;
                    upperFlatCount.Value = decimal.Parse(a.defaultUpperLimit);
                }
            }
            defaultActionCount.Value = a.actionOnStart ?? 0;
            autoChestBox.Checked = a.autoChestEnabled ?? false;
            autoDQBox.Checked = a.autoDQEnabled ?? false;
            autoWBBox.Checked = a.autoWBEnabled ?? false;
            autoPVPBox.Checked = a.autoPvPEnabled ?? false;
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
            AppSettings a = AppSettings.loadSettings();
            a.actionOnStart = (int)defaultActionCount.Value;
            a.token = textBox1.Text;
            a.KongregateId = textBox2.Text;
            a.autoChestEnabled = autoChestBox.Checked;
            a.autoDQEnabled = autoDQBox.Checked;
            a.autoPvPEnabled = autoPVPBox.Checked;
            a.autoWBEnabled = autoWBBox.Checked;

            if (lowerFlatRadio.Checked)
            {
                a.defaultLowerLimit = lowerFlatCount.Value.ToString();
            }
            else if (lowerPercRadio.Checked)
            {
                a.defaultLowerLimit = lowerPercCount.Value.ToString() + "%";
            }
            else
            {
                a.defaultLowerLimit = "-1";
            }

            if (upperFlatRadio.Checked)
            {
                a.defaultUpperLimit = upperFlatCount.Value.ToString();
            }
            else if (upperPercRadio.Checked)
            {
                a.defaultUpperLimit = upperPercCount.Value.ToString() + "%";
            }
            else
            {
                a.defaultUpperLimit = "-1";
            }

            a.saveSettings();
            MessageBox.Show("Settings saved to file. Restart the application to use the new settings.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.kongregate.com/forums/910715-cosmos-quest/topics/965457-cq-macro-creator-for-diceycles-calc");
        }

    }
}
