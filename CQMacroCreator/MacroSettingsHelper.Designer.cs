namespace CQMacroCreator
{
    partial class MacroSettingsHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.defaultActionCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.actionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ticketStatus = new System.Windows.Forms.Label();
            this.kongIdStatus = new System.Windows.Forms.Label();
            this.lowerFlatRadio = new System.Windows.Forms.RadioButton();
            this.lowerPercRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lowerNoRadio = new System.Windows.Forms.RadioButton();
            this.lowerFlatCount = new System.Windows.Forms.NumericUpDown();
            this.lowerPercCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.upperPercCount = new System.Windows.Forms.NumericUpDown();
            this.upperFlatCount = new System.Windows.Forms.NumericUpDown();
            this.upperNoRadio = new System.Windows.Forms.RadioButton();
            this.upperPercRadio = new System.Windows.Forms.RadioButton();
            this.upperFlatRadio = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.defaultActionCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerFlatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPercCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperPercCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperFlatCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default action on start:";
            // 
            // defaultActionCount
            // 
            this.defaultActionCount.Location = new System.Drawing.Point(149, 43);
            this.defaultActionCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.defaultActionCount.Name = "defaultActionCount";
            this.defaultActionCount.Size = new System.Drawing.Size(64, 20);
            this.defaultActionCount.TabIndex = 1;
            this.defaultActionCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Authentication Ticket:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kongregate ID:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 58);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(247, 45);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(53, 13);
            this.actionLabel.TabIndex = 11;
            this.actionLabel.Text = "No action";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(156, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "MacroSettings Creator Helper";
            // 
            // ticketStatus
            // 
            this.ticketStatus.AutoSize = true;
            this.ticketStatus.Location = new System.Drawing.Point(146, 92);
            this.ticketStatus.Name = "ticketStatus";
            this.ticketStatus.Size = new System.Drawing.Size(389, 26);
            this.ticketStatus.TabIndex = 13;
            this.ticketStatus.Text = "No ticket. Online functions like downloading heroes or sending solutions to serve" +
    "r\r\nwon\'t be available.";
            // 
            // kongIdStatus
            // 
            this.kongIdStatus.AutoSize = true;
            this.kongIdStatus.Location = new System.Drawing.Point(146, 151);
            this.kongIdStatus.Name = "kongIdStatus";
            this.kongIdStatus.Size = new System.Drawing.Size(10, 13);
            this.kongIdStatus.TabIndex = 14;
            this.kongIdStatus.Text = "-";
            // 
            // lowerFlatRadio
            // 
            this.lowerFlatRadio.AutoSize = true;
            this.lowerFlatRadio.Checked = true;
            this.lowerFlatRadio.Location = new System.Drawing.Point(12, 15);
            this.lowerFlatRadio.Name = "lowerFlatRadio";
            this.lowerFlatRadio.Size = new System.Drawing.Size(72, 17);
            this.lowerFlatRadio.TabIndex = 17;
            this.lowerFlatRadio.TabStop = true;
            this.lowerFlatRadio.Text = "Flat Value";
            this.lowerFlatRadio.UseVisualStyleBackColor = true;
            // 
            // lowerPercRadio
            // 
            this.lowerPercRadio.AutoSize = true;
            this.lowerPercRadio.Location = new System.Drawing.Point(12, 37);
            this.lowerPercRadio.Name = "lowerPercRadio";
            this.lowerPercRadio.Size = new System.Drawing.Size(80, 17);
            this.lowerPercRadio.TabIndex = 18;
            this.lowerPercRadio.Text = "Percentage";
            this.lowerPercRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lowerPercCount);
            this.groupBox1.Controls.Add(this.lowerFlatCount);
            this.groupBox1.Controls.Add(this.lowerNoRadio);
            this.groupBox1.Controls.Add(this.lowerPercRadio);
            this.groupBox1.Controls.Add(this.lowerFlatRadio);
            this.groupBox1.Location = new System.Drawing.Point(27, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 88);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default lower follower limit";
            // 
            // lowerNoRadio
            // 
            this.lowerNoRadio.AutoSize = true;
            this.lowerNoRadio.Location = new System.Drawing.Point(12, 60);
            this.lowerNoRadio.Name = "lowerNoRadio";
            this.lowerNoRadio.Size = new System.Drawing.Size(135, 17);
            this.lowerNoRadio.TabIndex = 19;
            this.lowerNoRadio.Text = "Don\'t use any monsters";
            this.lowerNoRadio.UseVisualStyleBackColor = true;
            // 
            // lowerFlatCount
            // 
            this.lowerFlatCount.Location = new System.Drawing.Point(111, 15);
            this.lowerFlatCount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.lowerFlatCount.Name = "lowerFlatCount";
            this.lowerFlatCount.Size = new System.Drawing.Size(115, 20);
            this.lowerFlatCount.TabIndex = 20;
            // 
            // lowerPercCount
            // 
            this.lowerPercCount.Location = new System.Drawing.Point(111, 37);
            this.lowerPercCount.Name = "lowerPercCount";
            this.lowerPercCount.Size = new System.Drawing.Size(73, 20);
            this.lowerPercCount.TabIndex = 21;
            this.lowerPercCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(190, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "%";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.upperPercCount);
            this.groupBox2.Controls.Add(this.upperFlatCount);
            this.groupBox2.Controls.Add(this.upperNoRadio);
            this.groupBox2.Controls.Add(this.upperPercRadio);
            this.groupBox2.Controls.Add(this.upperFlatRadio);
            this.groupBox2.Location = new System.Drawing.Point(266, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 88);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Default upper follower limit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(190, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "%";
            // 
            // upperPercCount
            // 
            this.upperPercCount.Location = new System.Drawing.Point(111, 37);
            this.upperPercCount.Name = "upperPercCount";
            this.upperPercCount.Size = new System.Drawing.Size(73, 20);
            this.upperPercCount.TabIndex = 21;
            this.upperPercCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // upperFlatCount
            // 
            this.upperFlatCount.Location = new System.Drawing.Point(111, 15);
            this.upperFlatCount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.upperFlatCount.Name = "upperFlatCount";
            this.upperFlatCount.Size = new System.Drawing.Size(115, 20);
            this.upperFlatCount.TabIndex = 20;
            // 
            // upperNoRadio
            // 
            this.upperNoRadio.AutoSize = true;
            this.upperNoRadio.Location = new System.Drawing.Point(12, 60);
            this.upperNoRadio.Name = "upperNoRadio";
            this.upperNoRadio.Size = new System.Drawing.Size(89, 17);
            this.upperNoRadio.TabIndex = 19;
            this.upperNoRadio.Text = "No upper limit";
            this.upperNoRadio.UseVisualStyleBackColor = true;
            // 
            // upperPercRadio
            // 
            this.upperPercRadio.AutoSize = true;
            this.upperPercRadio.Checked = true;
            this.upperPercRadio.Location = new System.Drawing.Point(12, 37);
            this.upperPercRadio.Name = "upperPercRadio";
            this.upperPercRadio.Size = new System.Drawing.Size(80, 17);
            this.upperPercRadio.TabIndex = 18;
            this.upperPercRadio.TabStop = true;
            this.upperPercRadio.Text = "Percentage";
            this.upperPercRadio.UseVisualStyleBackColor = true;
            // 
            // upperFlatRadio
            // 
            this.upperFlatRadio.AutoSize = true;
            this.upperFlatRadio.Location = new System.Drawing.Point(12, 15);
            this.upperFlatRadio.Name = "upperFlatRadio";
            this.upperFlatRadio.Size = new System.Drawing.Size(72, 17);
            this.upperFlatRadio.TabIndex = 17;
            this.upperFlatRadio.Text = "Flat Value";
            this.upperFlatRadio.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 58);
            this.button2.TabIndex = 23;
            this.button2.Text = "I don\'t know how to get my Auth Ticket and Kong ID(opens CQMacroCreator thread in" +
    " a browser)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MacroSettingsHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 358);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kongIdStatus);
            this.Controls.Add(this.ticketStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.defaultActionCount);
            this.Controls.Add(this.label1);
            this.Name = "MacroSettingsHelper";
            this.Text = "MacroSettingsHelper";
            ((System.ComponentModel.ISupportInitialize)(this.defaultActionCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerFlatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPercCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperPercCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperFlatCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown defaultActionCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ticketStatus;
        private System.Windows.Forms.Label kongIdStatus;
        private System.Windows.Forms.RadioButton lowerFlatRadio;
        private System.Windows.Forms.RadioButton lowerPercRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown lowerPercCount;
        private System.Windows.Forms.NumericUpDown lowerFlatCount;
        private System.Windows.Forms.RadioButton lowerNoRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown upperPercCount;
        private System.Windows.Forms.NumericUpDown upperFlatCount;
        private System.Windows.Forms.RadioButton upperNoRadio;
        private System.Windows.Forms.RadioButton upperPercRadio;
        private System.Windows.Forms.RadioButton upperFlatRadio;
        private System.Windows.Forms.Button button2;
    }
}