
namespace SecsLibary
{
    partial class ActiveSendView
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
            this.cmbStream = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbStream
            // 
            this.cmbStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStream.FormattingEnabled = true;
            this.cmbStream.Location = new System.Drawing.Point(81, 36);
            this.cmbStream.Name = "cmbStream";
            this.cmbStream.Size = new System.Drawing.Size(285, 22);
            this.cmbStream.TabIndex = 0;
            this.cmbStream.SelectedIndexChanged += new System.EventHandler(this.cmbStream_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(417, 31);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 31);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Active Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stream";
            // 
            // cmbData
            // 
            this.cmbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbData.FormattingEnabled = true;
            this.cmbData.Location = new System.Drawing.Point(81, 94);
            this.cmbData.Name = "cmbData";
            this.cmbData.Size = new System.Drawing.Size(473, 22);
            this.cmbData.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "DataItem";
            // 
            // ActiveSendView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbData);
            this.Controls.Add(this.cmbStream);
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActiveSendView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Active Send View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActiveSendView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStream;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbData;
        private System.Windows.Forms.Label label2;
    }
}