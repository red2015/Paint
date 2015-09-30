namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button_pencil = new System.Windows.Forms.Button();
            this.button_flood = new System.Windows.Forms.Button();
            this.pictureBox_canvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_rubber = new System.Windows.Forms.Button();
            this.button_rectangle = new System.Windows.Forms.Button();
            this.textBox_VerticalPosiotion = new System.Windows.Forms.TextBox();
            this.button_circle = new System.Windows.Forms.Button();
            this.button_line = new System.Windows.Forms.Button();
            this.button_setSize = new System.Windows.Forms.Button();
            this.textBox_HorizontalPositon = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreesInRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreesInLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_pencil
            // 
            this.button_pencil.Location = new System.Drawing.Point(3, 14);
            this.button_pencil.Name = "button_pencil";
            this.button_pencil.Size = new System.Drawing.Size(75, 23);
            this.button_pencil.TabIndex = 1;
            this.button_pencil.Text = "Pencil";
            this.button_pencil.UseVisualStyleBackColor = true;
            this.button_pencil.Click += new System.EventHandler(this.button_pencil_Click);
            // 
            // button_flood
            // 
            this.button_flood.Location = new System.Drawing.Point(84, 14);
            this.button_flood.Name = "button_flood";
            this.button_flood.Size = new System.Drawing.Size(75, 23);
            this.button_flood.TabIndex = 2;
            this.button_flood.Text = "Flood";
            this.button_flood.UseVisualStyleBackColor = true;
            this.button_flood.Click += new System.EventHandler(this.button_flood_Click);
            // 
            // pictureBox_canvas
            // 
            this.pictureBox_canvas.BackColor = System.Drawing.Color.White;
            this.pictureBox_canvas.Location = new System.Drawing.Point(3, 55);
            this.pictureBox_canvas.Name = "pictureBox_canvas";
            this.pictureBox_canvas.Size = new System.Drawing.Size(800, 600);
            this.pictureBox_canvas.TabIndex = 3;
            this.pictureBox_canvas.TabStop = false;
            this.pictureBox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_canvas_Paint);
            this.pictureBox_canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_canvas_MouseClick);
            this.pictureBox_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_canvas_MouseDown);
            this.pictureBox_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_canvas_MouseMove);
            this.pictureBox_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_canvas_MouseUp);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox_canvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 667);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_rubber);
            this.panel2.Controls.Add(this.button_rectangle);
            this.panel2.Controls.Add(this.textBox_VerticalPosiotion);
            this.panel2.Controls.Add(this.button_circle);
            this.panel2.Controls.Add(this.button_line);
            this.panel2.Controls.Add(this.button_setSize);
            this.panel2.Controls.Add(this.textBox_HorizontalPositon);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button_flood);
            this.panel2.Controls.Add(this.button_pencil);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 49);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Color";
            // 
            // button_rubber
            // 
            this.button_rubber.Location = new System.Drawing.Point(740, 17);
            this.button_rubber.Name = "button_rubber";
            this.button_rubber.Size = new System.Drawing.Size(75, 23);
            this.button_rubber.TabIndex = 10;
            this.button_rubber.Text = "Rubber";
            this.button_rubber.UseVisualStyleBackColor = true;
            this.button_rubber.Click += new System.EventHandler(this.button_rubber_Click);
            // 
            // button_rectangle
            // 
            this.button_rectangle.Location = new System.Drawing.Point(659, 17);
            this.button_rectangle.Name = "button_rectangle";
            this.button_rectangle.Size = new System.Drawing.Size(75, 23);
            this.button_rectangle.TabIndex = 9;
            this.button_rectangle.Text = "Rectangle";
            this.button_rectangle.UseVisualStyleBackColor = true;
            this.button_rectangle.Click += new System.EventHandler(this.button_rectangle_Click);
            // 
            // textBox_VerticalPosiotion
            // 
            this.textBox_VerticalPosiotion.Location = new System.Drawing.Point(310, 17);
            this.textBox_VerticalPosiotion.Name = "textBox_VerticalPosiotion";
            this.textBox_VerticalPosiotion.Size = new System.Drawing.Size(100, 20);
            this.textBox_VerticalPosiotion.TabIndex = 5;
            // 
            // button_circle
            // 
            this.button_circle.Location = new System.Drawing.Point(578, 17);
            this.button_circle.Name = "button_circle";
            this.button_circle.Size = new System.Drawing.Size(75, 23);
            this.button_circle.TabIndex = 8;
            this.button_circle.Text = "Circle";
            this.button_circle.UseVisualStyleBackColor = true;
            this.button_circle.Click += new System.EventHandler(this.button_circle_Click);
            // 
            // button_line
            // 
            this.button_line.Location = new System.Drawing.Point(497, 17);
            this.button_line.Name = "button_line";
            this.button_line.Size = new System.Drawing.Size(75, 23);
            this.button_line.TabIndex = 7;
            this.button_line.Text = "Line";
            this.button_line.UseVisualStyleBackColor = true;
            this.button_line.Click += new System.EventHandler(this.button_line_Click);
            // 
            // button_setSize
            // 
            this.button_setSize.Location = new System.Drawing.Point(416, 17);
            this.button_setSize.Name = "button_setSize";
            this.button_setSize.Size = new System.Drawing.Size(75, 23);
            this.button_setSize.TabIndex = 6;
            this.button_setSize.Text = "Set Size";
            this.button_setSize.UseVisualStyleBackColor = true;
            this.button_setSize.Click += new System.EventHandler(this.button_setSize_Click);
            // 
            // textBox_HorizontalPositon
            // 
            this.textBox_HorizontalPositon.Location = new System.Drawing.Point(204, 17);
            this.textBox_HorizontalPositon.Name = "textBox_HorizontalPositon";
            this.textBox_HorizontalPositon.Size = new System.Drawing.Size(100, 20);
            this.textBox_HorizontalPositon.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(165, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(23, 20);
            this.panel3.TabIndex = 3;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1162, 24);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.flipToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.degreesInRightToolStripMenuItem,
            this.degreesInLeftToolStripMenuItem,
            this.degreesToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            // 
            // degreesInRightToolStripMenuItem
            // 
            this.degreesInRightToolStripMenuItem.Name = "degreesInRightToolStripMenuItem";
            this.degreesInRightToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.degreesInRightToolStripMenuItem.Text = "90 degrees in right";
            this.degreesInRightToolStripMenuItem.Click += new System.EventHandler(this.degreesInRightToolStripMenuItem_Click);
            // 
            // degreesInLeftToolStripMenuItem
            // 
            this.degreesInLeftToolStripMenuItem.Name = "degreesInLeftToolStripMenuItem";
            this.degreesInLeftToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.degreesInLeftToolStripMenuItem.Text = "90 degrees in left";
            this.degreesInLeftToolStripMenuItem.Click += new System.EventHandler(this.degreesInLeftToolStripMenuItem_Click);
            // 
            // degreesToolStripMenuItem
            // 
            this.degreesToolStripMenuItem.Name = "degreesToolStripMenuItem";
            this.degreesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.degreesToolStripMenuItem.Text = "180 degrees";
            this.degreesToolStripMenuItem.Click += new System.EventHandler(this.degreesToolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.flipToolStripMenuItem.Text = "Flip";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Width";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 691);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_pencil;
        private System.Windows.Forms.Button button_flood;
        private System.Windows.Forms.PictureBox pictureBox_canvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Button button_setSize;
        private System.Windows.Forms.TextBox textBox_VerticalPosiotion;
        private System.Windows.Forms.TextBox textBox_HorizontalPositon;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreesInRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreesInLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.Button button_line;
        private System.Windows.Forms.Button button_circle;
        private System.Windows.Forms.Button button_rectangle;
        private System.Windows.Forms.Button button_rubber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}

