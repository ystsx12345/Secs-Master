
namespace Secs_Master_Example
{
    partial class FormSocket
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnClearLog2 = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDisEnable = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radPassive = new System.Windows.Forms.RadioButton();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.richLog = new System.Windows.Forms.RichTextBox();
            this.btnS5F1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richLog2 = new System.Windows.Forms.RichTextBox();
            this.btnS1F13 = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.btnClearLog2);
            this.groupBox1.Controls.Add(this.btnClearLog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDisEnable);
            this.groupBox1.Controls.Add(this.btnEnable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radPassive);
            this.groupBox1.Controls.Add(this.radActive);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(300, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(269, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "设备端连接测试软件 Host->Active EQP->Passive";
            // 
            // btnClearLog2
            // 
            this.btnClearLog2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog2.Location = new System.Drawing.Point(734, 57);
            this.btnClearLog2.Name = "btnClearLog2";
            this.btnClearLog2.Size = new System.Drawing.Size(126, 29);
            this.btnClearLog2.TabIndex = 9;
            this.btnClearLog2.Text = "Clear SECE II Log";
            this.btnClearLog2.UseVisualStyleBackColor = true;
            this.btnClearLog2.Click += new System.EventHandler(this.btnClearLog2_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(734, 12);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(126, 29);
            this.btnClearLog.TabIndex = 9;
            this.btnClearLog.Text = "Clear SECE I Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(563, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "DisConnected";
            // 
            // btnDisEnable
            // 
            this.btnDisEnable.Location = new System.Drawing.Point(434, 44);
            this.btnDisEnable.Name = "btnDisEnable";
            this.btnDisEnable.Size = new System.Drawing.Size(84, 34);
            this.btnDisEnable.TabIndex = 4;
            this.btnDisEnable.Text = "DisEnable";
            this.btnDisEnable.UseVisualStyleBackColor = true;
            this.btnDisEnable.Click += new System.EventHandler(this.btnDisEnable_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(302, 44);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(84, 34);
            this.btnEnable.TabIndex = 3;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // radPassive
            // 
            this.radPassive.AutoSize = true;
            this.radPassive.Checked = true;
            this.radPassive.Location = new System.Drawing.Point(27, 62);
            this.radPassive.Name = "radPassive";
            this.radPassive.Size = new System.Drawing.Size(65, 16);
            this.radPassive.TabIndex = 1;
            this.radPassive.TabStop = true;
            this.radPassive.Text = "Passive";
            this.radPassive.UseVisualStyleBackColor = true;
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Enabled = false;
            this.radActive.Location = new System.Drawing.Point(27, 25);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(59, 16);
            this.radActive.TabIndex = 1;
            this.radActive.Text = "Active";
            this.radActive.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(165, 57);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "5002";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(165, 24);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // richLog
            // 
            this.richLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richLog.Location = new System.Drawing.Point(0, 0);
            this.richLog.Name = "richLog";
            this.richLog.Size = new System.Drawing.Size(893, 164);
            this.richLog.TabIndex = 1;
            this.richLog.Text = "";
            // 
            // btnS5F1
            // 
            this.btnS5F1.Location = new System.Drawing.Point(247, 107);
            this.btnS5F1.Name = "btnS5F1";
            this.btnS5F1.Size = new System.Drawing.Size(87, 34);
            this.btnS5F1.TabIndex = 8;
            this.btnS5F1.Text = "S5F1";
            this.btnS5F1.UseVisualStyleBackColor = true;
            this.btnS5F1.Click += new System.EventHandler(this.button6_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 218);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richLog2);
            this.splitContainer1.Size = new System.Drawing.Size(893, 329);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.TabIndex = 9;
            // 
            // richLog2
            // 
            this.richLog2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richLog2.Font = new System.Drawing.Font("Consolas", 9F);
            this.richLog2.Location = new System.Drawing.Point(0, 0);
            this.richLog2.Name = "richLog2";
            this.richLog2.Size = new System.Drawing.Size(893, 161);
            this.richLog2.TabIndex = 2;
            this.richLog2.Text = "";
            // 
            // btnS1F13
            // 
            this.btnS1F13.Location = new System.Drawing.Point(12, 107);
            this.btnS1F13.Name = "btnS1F13";
            this.btnS1F13.Size = new System.Drawing.Size(87, 34);
            this.btnS1F13.TabIndex = 8;
            this.btnS1F13.Text = "S1F13";
            this.btnS1F13.UseVisualStyleBackColor = true;
            this.btnS1F13.Click += new System.EventHandler(this.btnS1F13_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(734, 108);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(126, 33);
            this.btnConfig.TabIndex = 10;
            this.btnConfig.Text = "Save xml";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "S6F11";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 33);
            this.button2.TabIndex = 11;
            this.button2.Text = "S6F11 Bytes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(469, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "S1F1 1000";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 547);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnS1F13);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnS5F1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSocket";
            this.Text = "SECE HSMS DEMO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radPassive;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.RichTextBox richLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDisEnable;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnS5F1;
        private System.Windows.Forms.Button btnClearLog2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richLog2;
        private System.Windows.Forms.Button btnS1F13;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

