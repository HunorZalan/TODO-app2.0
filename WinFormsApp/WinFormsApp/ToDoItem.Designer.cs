
namespace WinFormsApp
{
    partial class ToDoItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToDoItem));
            this.title = new System.Windows.Forms.Label();
            this.trash = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.Label();
            this.pipe = new System.Windows.Forms.Button();
            this.pencil = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.minus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(19, 4);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(67, 30);
            this.title.TabIndex = 1;
            this.title.Text = "To Do";
            // 
            // trash
            // 
            this.trash.Image = ((System.Drawing.Image)(resources.GetObject("trash.Image")));
            this.trash.Location = new System.Drawing.Point(344, 12);
            this.trash.Name = "trash";
            this.trash.Size = new System.Drawing.Size(39, 39);
            this.trash.TabIndex = 2;
            this.trash.UseVisualStyleBackColor = true;
            this.trash.Click += new System.EventHandler(this.trash_Click);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.date.Location = new System.Drawing.Point(19, 34);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(35, 17);
            this.date.TabIndex = 3;
            this.date.Text = "Date";
            // 
            // pipe
            // 
            this.pipe.Image = ((System.Drawing.Image)(resources.GetObject("pipe.Image")));
            this.pipe.Location = new System.Drawing.Point(223, 12);
            this.pipe.Name = "pipe";
            this.pipe.Size = new System.Drawing.Size(43, 39);
            this.pipe.TabIndex = 4;
            this.pipe.UseVisualStyleBackColor = true;
            this.pipe.Click += new System.EventHandler(this.pipe_Click);
            // 
            // pencil
            // 
            this.pencil.Image = ((System.Drawing.Image)(resources.GetObject("pencil.Image")));
            this.pencil.Location = new System.Drawing.Point(282, 12);
            this.pencil.Name = "pencil";
            this.pencil.Size = new System.Drawing.Size(38, 39);
            this.pencil.TabIndex = 5;
            this.pencil.UseVisualStyleBackColor = true;
            this.pencil.Click += new System.EventHandler(this.pencil_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(19, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 35);
            this.textBox.TabIndex = 6;
            // 
            // minus
            // 
            this.minus.Image = ((System.Drawing.Image)(resources.GetObject("minus.Image")));
            this.minus.Location = new System.Drawing.Point(223, 12);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(43, 39);
            this.minus.TabIndex = 7;
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // ToDoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.minus);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.pencil);
            this.Controls.Add(this.pipe);
            this.Controls.Add(this.date);
            this.Controls.Add(this.trash);
            this.Controls.Add(this.title);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ToDoItem";
            this.Size = new System.Drawing.Size(399, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button trash;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button pipe;
        private System.Windows.Forms.Button pencil;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button minus;
    }
}
