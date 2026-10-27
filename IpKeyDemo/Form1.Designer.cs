
namespace IpKeyDemo
{
    partial class Form1
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
            this.btnServer = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(26, 43);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(102, 45);
            this.btnServer.TabIndex = 9;
            this.btnServer.Text = "服务器";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(173, 43);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(102, 45);
            this.btnClient.TabIndex = 9;
            this.btnClient.Text = "客户端";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(335, 43);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(102, 45);
            this.btnActive.TabIndex = 9;
            this.btnActive.Text = "激活";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(510, 43);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(102, 45);
            this.button7.TabIndex = 9;
            this.button7.Text = "其他";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 149);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnServer);
            this.Name = "Form1";
            this.Text = "测试程序";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button button7;
    }
}

