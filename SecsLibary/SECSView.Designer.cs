
namespace SecsLibary
{
    partial class SECSView
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richSECSILog = new System.Windows.Forms.RichTextBox();
            this.richSECSIILog = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveSECSII = new System.Windows.Forms.Button();
            this.btnClearLog2 = new System.Windows.Forms.Button();
            this.btnActiveSend = new System.Windows.Forms.Button();
            this.btnSaveSECSI = new System.Windows.Forms.Button();
            this.btnClearLog1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radRemote = new System.Windows.Forms.RadioButton();
            this.radOffline = new System.Windows.Forms.RadioButton();
            this.radLocal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.chkAutoEnable = new System.Windows.Forms.CheckBox();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFile = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.context.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richSECSILog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richSECSIILog);
            this.splitContainer1.Size = new System.Drawing.Size(985, 535);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // richSECSILog
            // 
            this.richSECSILog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richSECSILog.Location = new System.Drawing.Point(0, 0);
            this.richSECSILog.Name = "richSECSILog";
            this.richSECSILog.Size = new System.Drawing.Size(985, 264);
            this.richSECSILog.TabIndex = 0;
            this.richSECSILog.Text = "";
            // 
            // richSECSIILog
            // 
            this.richSECSIILog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richSECSIILog.Location = new System.Drawing.Point(0, 0);
            this.richSECSIILog.Name = "richSECSIILog";
            this.richSECSIILog.Size = new System.Drawing.Size(985, 266);
            this.richSECSIILog.TabIndex = 0;
            this.richSECSIILog.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(985, 661);
            this.splitContainer2.SplitterDistance = 121;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSaveSECSII);
            this.panel1.Controls.Add(this.btnClearLog2);
            this.panel1.Controls.Add(this.btnActiveSend);
            this.panel1.Controls.Add(this.btnSaveSECSI);
            this.panel1.Controls.Add(this.btnClearLog1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 121);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(867, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveSECSII
            // 
            this.btnSaveSECSII.Location = new System.Drawing.Point(712, 76);
            this.btnSaveSECSII.Name = "btnSaveSECSII";
            this.btnSaveSECSII.Size = new System.Drawing.Size(138, 29);
            this.btnSaveSECSII.TabIndex = 2;
            this.btnSaveSECSII.Text = "Save SECS II Log";
            this.btnSaveSECSII.UseVisualStyleBackColor = true;
            this.btnSaveSECSII.Click += new System.EventHandler(this.btnSaveSECSII_Click);
            // 
            // btnClearLog2
            // 
            this.btnClearLog2.Location = new System.Drawing.Point(568, 76);
            this.btnClearLog2.Name = "btnClearLog2";
            this.btnClearLog2.Size = new System.Drawing.Size(138, 29);
            this.btnClearLog2.TabIndex = 2;
            this.btnClearLog2.Text = "Clear SECS II Log";
            this.btnClearLog2.UseVisualStyleBackColor = true;
            this.btnClearLog2.Click += new System.EventHandler(this.btnClearLog2_Click);
            // 
            // btnActiveSend
            // 
            this.btnActiveSend.Location = new System.Drawing.Point(856, 30);
            this.btnActiveSend.Name = "btnActiveSend";
            this.btnActiveSend.Size = new System.Drawing.Size(117, 29);
            this.btnActiveSend.TabIndex = 2;
            this.btnActiveSend.Text = "Active Send";
            this.btnActiveSend.UseVisualStyleBackColor = true;
            this.btnActiveSend.Click += new System.EventHandler(this.btnActiveSend_Click);
            // 
            // btnSaveSECSI
            // 
            this.btnSaveSECSI.Location = new System.Drawing.Point(712, 30);
            this.btnSaveSECSI.Name = "btnSaveSECSI";
            this.btnSaveSECSI.Size = new System.Drawing.Size(138, 29);
            this.btnSaveSECSI.TabIndex = 2;
            this.btnSaveSECSI.Text = "Save SECS I Log";
            this.btnSaveSECSI.UseVisualStyleBackColor = true;
            this.btnSaveSECSI.Click += new System.EventHandler(this.btnSaveSECSI_Click);
            // 
            // btnClearLog1
            // 
            this.btnClearLog1.Location = new System.Drawing.Point(568, 30);
            this.btnClearLog1.Name = "btnClearLog1";
            this.btnClearLog1.Size = new System.Drawing.Size(138, 29);
            this.btnClearLog1.TabIndex = 2;
            this.btnClearLog1.Text = "Clear SECS I Log";
            this.btnClearLog1.UseVisualStyleBackColor = true;
            this.btnClearLog1.Click += new System.EventHandler(this.btnClearLog1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radRemote);
            this.groupBox2.Controls.Add(this.radOffline);
            this.groupBox2.Controls.Add(this.radLocal);
            this.groupBox2.Location = new System.Drawing.Point(352, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local/Remote";
            // 
            // radRemote
            // 
            this.radRemote.AutoSize = true;
            this.radRemote.Location = new System.Drawing.Point(117, 62);
            this.radRemote.Name = "radRemote";
            this.radRemote.Size = new System.Drawing.Size(67, 18);
            this.radRemote.TabIndex = 0;
            this.radRemote.TabStop = true;
            this.radRemote.Text = "Remote";
            this.radRemote.UseVisualStyleBackColor = true;
            this.radRemote.CheckedChanged += new System.EventHandler(this.radRemote_CheckedChanged);
            // 
            // radOffline
            // 
            this.radOffline.AutoSize = true;
            this.radOffline.Location = new System.Drawing.Point(56, 26);
            this.radOffline.Name = "radOffline";
            this.radOffline.Size = new System.Drawing.Size(74, 18);
            this.radOffline.TabIndex = 0;
            this.radOffline.TabStop = true;
            this.radOffline.Text = "Offline";
            this.radOffline.UseVisualStyleBackColor = true;
            this.radOffline.CheckedChanged += new System.EventHandler(this.radOffline_CheckedChanged);
            // 
            // radLocal
            // 
            this.radLocal.AutoSize = true;
            this.radLocal.Location = new System.Drawing.Point(16, 62);
            this.radLocal.Name = "radLocal";
            this.radLocal.Size = new System.Drawing.Size(60, 18);
            this.radLocal.TabIndex = 0;
            this.radLocal.TabStop = true;
            this.radLocal.Text = "Local";
            this.radLocal.UseVisualStyleBackColor = true;
            this.radLocal.CheckedChanged += new System.EventHandler(this.radLocal_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.chkAutoEnable);
            this.groupBox1.Controls.Add(this.btnDisable);
            this.groupBox1.Controls.Add(this.btnEnable);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SECS Config";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(229, 62);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(99, 26);
            this.btnSaveConfig.TabIndex = 4;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // chkAutoEnable
            // 
            this.chkAutoEnable.AutoSize = true;
            this.chkAutoEnable.Location = new System.Drawing.Point(127, 68);
            this.chkAutoEnable.Name = "chkAutoEnable";
            this.chkAutoEnable.Size = new System.Drawing.Size(96, 18);
            this.chkAutoEnable.TabIndex = 3;
            this.chkAutoEnable.Text = "AutoEnable";
            this.chkAutoEnable.UseVisualStyleBackColor = true;
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(242, 22);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(75, 27);
            this.btnDisable.TabIndex = 2;
            this.btnDisable.Text = "Disable";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Visible = false;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(161, 22);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 27);
            this.btnEnable.TabIndex = 2;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(49, 64);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 22);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(49, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(93, 22);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "10.99.59.50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // context
            // 
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToFile,
            this.loadFromFile});
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(163, 48);
            // 
            // saveToFile
            // 
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(162, 22);
            this.saveToFile.Text = "Save To File";
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // loadFromFile
            // 
            this.loadFromFile.Name = "loadFromFile";
            this.loadFromFile.Size = new System.Drawing.Size(162, 22);
            this.loadFromFile.Text = "Load From File";
            this.loadFromFile.Click += new System.EventHandler(this.loadFromFile_Click);
            // 
            // SECSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 661);
            this.ContextMenuStrip = this.context;
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SECSView";
            this.Text = "SECSView(1.07)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.context.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richSECSILog;
        private System.Windows.Forms.RichTextBox richSECSIILog;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoEnable;
        private System.Windows.Forms.Button btnClearLog2;
        private System.Windows.Forms.Button btnClearLog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radRemote;
        private System.Windows.Forms.RadioButton radLocal;
        private System.Windows.Forms.Button btnSaveSECSII;
        private System.Windows.Forms.Button btnSaveSECSI;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnActiveSend;
        private System.Windows.Forms.ContextMenuStrip context;
        private System.Windows.Forms.ToolStripMenuItem saveToFile;
        private System.Windows.Forms.ToolStripMenuItem loadFromFile;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radOffline;
    }
}