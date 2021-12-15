
namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panelToDo = new System.Windows.Forms.FlowLayoutPanel();
            this.todo = new System.Windows.Forms.Label();
            this.panelFinished = new System.Windows.Forms.FlowLayoutPanel();
            this.finished = new System.Windows.Forms.Label();
            this.panelExpired = new System.Windows.Forms.FlowLayoutPanel();
            this.expired = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelToDo.SuspendLayout();
            this.panelFinished.SuspendLayout();
            this.panelExpired.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(122, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "To Do List";
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(312, 120);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(72, 72);
            this.add.TabIndex = 1;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox.Location = new System.Drawing.Point(31, 120);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(228, 23);
            this.textBox.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker.Location = new System.Drawing.Point(31, 159);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(228, 23);
            this.dateTimePicker.TabIndex = 4;
            // 
            // panelToDo
            // 
            this.panelToDo.AutoScroll = true;
            this.panelToDo.BackColor = System.Drawing.Color.LightGray;
            this.panelToDo.Controls.Add(this.todo);
            this.panelToDo.Location = new System.Drawing.Point(12, 214);
            this.panelToDo.Name = "panelToDo";
            this.panelToDo.Size = new System.Drawing.Size(410, 244);
            this.panelToDo.TabIndex = 5;
            // 
            // todo
            // 
            this.todo.AutoSize = true;
            this.todo.BackColor = System.Drawing.Color.PaleGreen;
            this.todo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.todo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.todo.Location = new System.Drawing.Point(3, 0);
            this.todo.Name = "todo";
            this.todo.Size = new System.Drawing.Size(49, 21);
            this.todo.TabIndex = 0;
            this.todo.Text = "To Do";
            // 
            // panelFinished
            // 
            this.panelFinished.AutoScroll = true;
            this.panelFinished.BackColor = System.Drawing.Color.LightGray;
            this.panelFinished.Controls.Add(this.finished);
            this.panelFinished.Location = new System.Drawing.Point(12, 478);
            this.panelFinished.Name = "panelFinished";
            this.panelFinished.Size = new System.Drawing.Size(410, 244);
            this.panelFinished.TabIndex = 6;
            // 
            // finished
            // 
            this.finished.AutoSize = true;
            this.finished.BackColor = System.Drawing.Color.PaleGreen;
            this.finished.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finished.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.finished.Location = new System.Drawing.Point(3, 0);
            this.finished.Name = "finished";
            this.finished.Size = new System.Drawing.Size(68, 21);
            this.finished.TabIndex = 0;
            this.finished.Text = "Finished";
            // 
            // panelExpired
            // 
            this.panelExpired.AutoScroll = true;
            this.panelExpired.BackColor = System.Drawing.Color.LightGray;
            this.panelExpired.Controls.Add(this.expired);
            this.panelExpired.Location = new System.Drawing.Point(12, 741);
            this.panelExpired.Name = "panelExpired";
            this.panelExpired.Size = new System.Drawing.Size(410, 244);
            this.panelExpired.TabIndex = 7;
            // 
            // expired
            // 
            this.expired.AutoSize = true;
            this.expired.BackColor = System.Drawing.Color.PaleGreen;
            this.expired.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expired.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.expired.Location = new System.Drawing.Point(3, 0);
            this.expired.Name = "expired";
            this.expired.Size = new System.Drawing.Size(61, 21);
            this.expired.TabIndex = 0;
            this.expired.Text = "Expired";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(434, 1001);
            this.Controls.Add(this.panelExpired);
            this.Controls.Add(this.panelFinished);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.add);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelToDo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelToDo.ResumeLayout(false);
            this.panelToDo.PerformLayout();
            this.panelFinished.ResumeLayout(false);
            this.panelFinished.PerformLayout();
            this.panelExpired.ResumeLayout(false);
            this.panelExpired.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.FlowLayoutPanel panelToDo;
        private System.Windows.Forms.Label todo;
        private System.Windows.Forms.FlowLayoutPanel panelFinished;
        private System.Windows.Forms.Label finished;
        private System.Windows.Forms.FlowLayoutPanel panelExpired;
        private System.Windows.Forms.Label expired;
    }
}

