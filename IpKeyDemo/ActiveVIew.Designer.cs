
namespace IpKeyDemo
{
    partial class ActiveVIew
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
            this.btnGetIp = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnActiveMD5 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnGetIp
            // 
            this.btnGetIp.Location = new System.Drawing.Point(222, 8);
            this.btnGetIp.Name = "btnGetIp";
            this.btnGetIp.Size = new System.Drawing.Size(75, 23);
            this.btnGetIp.TabIndex = 13;
            this.btnGetIp.Text = "获取IP";
            this.btnGetIp.UseVisualStyleBackColor = true;
            this.btnGetIp.Click += new System.EventHandler(this.btnGetIp_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(320, 24);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(348, 53);
            this.txtResult.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(51, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(154, 21);
            this.txtIP.TabIndex = 10;
            // 
            // btnActiveMD5
            // 
            this.btnActiveMD5.Location = new System.Drawing.Point(222, 41);
            this.btnActiveMD5.Name = "btnActiveMD5";
            this.btnActiveMD5.Size = new System.Drawing.Size(75, 23);
            this.btnActiveMD5.TabIndex = 9;
            this.btnActiveMD5.Text = "生成";
            this.btnActiveMD5.UseVisualStyleBackColor = true;
            this.btnActiveMD5.Click += new System.EventHandler(this.btnActiveMD5_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(49, 80);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(269, 12);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "获取IP自动获取本地IP或者手动输入IP计算激活号";
            // 
            // ActiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 129);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnGetIp);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnActiveMD5);
            this.Name = "ActiveForm";
            this.Text = "ActiveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetIp;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnActiveMD5;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}