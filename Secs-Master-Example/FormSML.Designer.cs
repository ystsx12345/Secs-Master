
namespace Secs_Master_Example
{
    partial class FormSML
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editScodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChildMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(568, 588);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editScodToolStripMenuItem,
            this.deleteMessageToolStripMenuItem,
            this.addChildMessageToolStripMenuItem,
            this.addMessageToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 136);
            // 
            // editScodToolStripMenuItem
            // 
            this.editScodToolStripMenuItem.Name = "editScodToolStripMenuItem";
            this.editScodToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.editScodToolStripMenuItem.Text = "Edit Reply Message";
            this.editScodToolStripMenuItem.Click += new System.EventHandler(this.editScodToolStripMenuItem_Click);
            // 
            // deleteMessageToolStripMenuItem
            // 
            this.deleteMessageToolStripMenuItem.Name = "deleteMessageToolStripMenuItem";
            this.deleteMessageToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteMessageToolStripMenuItem.Text = "Delete Message";
            // 
            // addChildMessageToolStripMenuItem
            // 
            this.addChildMessageToolStripMenuItem.Name = "addChildMessageToolStripMenuItem";
            this.addChildMessageToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addChildMessageToolStripMenuItem.Text = "Add Child Message";
            // 
            // addMessageToolStripMenuItem
            // 
            this.addMessageToolStripMenuItem.Name = "addMessageToolStripMenuItem";
            this.addMessageToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addMessageToolStripMenuItem.Text = "Add Message";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // FormSML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 588);
            this.Controls.Add(this.treeView1);
            this.Name = "FormSML";
            this.Text = "Auto Reply Config";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editScodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChildMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}