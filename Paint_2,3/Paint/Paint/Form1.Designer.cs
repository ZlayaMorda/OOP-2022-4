namespace Paint
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrushColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBarWidth = new System.Windows.Forms.TrackBar();
            this.Before = new System.Windows.Forms.Button();
            this.After = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.comboBoxPLugins = new System.Windows.Forms.ComboBox();
            this.AddPlug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(992, 520);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Line",
            "Rectangle",
            "Ellipse",
            "BrokenLine"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 36);
            this.comboBox1.TabIndex = 1;
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLineColor.Location = new System.Drawing.Point(284, 12);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(50, 49);
            this.buttonLineColor.TabIndex = 2;
            this.buttonLineColor.UseVisualStyleBackColor = false;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Цвет\r\nлинии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Цвет\r\nзаливки";
            // 
            // buttonBrushColor
            // 
            this.buttonBrushColor.Location = new System.Drawing.Point(410, 12);
            this.buttonBrushColor.Name = "buttonBrushColor";
            this.buttonBrushColor.Size = new System.Drawing.Size(50, 49);
            this.buttonBrushColor.TabIndex = 4;
            this.buttonBrushColor.UseVisualStyleBackColor = true;
            this.buttonBrushColor.Click += new System.EventHandler(this.buttonBrushColor_Click);
            // 
            // trackBarWidth
            // 
            this.trackBarWidth.Location = new System.Drawing.Point(466, 12);
            this.trackBarWidth.Maximum = 12;
            this.trackBarWidth.Minimum = 1;
            this.trackBarWidth.Name = "trackBarWidth";
            this.trackBarWidth.Size = new System.Drawing.Size(135, 56);
            this.trackBarWidth.TabIndex = 6;
            this.trackBarWidth.Value = 1;
            // 
            // Before
            // 
            this.Before.BackgroundImage = global::Paint.Properties.Resources.blue_arrow_left73_600x600;
            this.Before.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Before.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Before.FlatAppearance.BorderSize = 0;
            this.Before.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Before.Location = new System.Drawing.Point(607, 12);
            this.Before.Name = "Before";
            this.Before.Size = new System.Drawing.Size(50, 49);
            this.Before.TabIndex = 7;
            this.Before.UseVisualStyleBackColor = true;
            this.Before.Click += new System.EventHandler(this.Before_Click);
            // 
            // After
            // 
            this.After.BackgroundImage = global::Paint.Properties.Resources.blue_arrow_right73_600x600;
            this.After.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.After.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.After.Location = new System.Drawing.Point(663, 12);
            this.After.Name = "After";
            this.After.Size = new System.Drawing.Size(50, 49);
            this.After.TabIndex = 8;
            this.After.UseVisualStyleBackColor = true;
            this.After.Click += new System.EventHandler(this.After_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Save.Location = new System.Drawing.Point(719, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(80, 49);
            this.Save.TabIndex = 9;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Load.Location = new System.Drawing.Point(805, 12);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(80, 49);
            this.Load.TabIndex = 10;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // comboBoxPLugins
            // 
            this.comboBoxPLugins.FormattingEnabled = true;
            this.comboBoxPLugins.Items.AddRange(new object[] {
            "Trapeze"});
            this.comboBoxPLugins.Location = new System.Drawing.Point(891, 9);
            this.comboBoxPLugins.Name = "comboBoxPLugins";
            this.comboBoxPLugins.Size = new System.Drawing.Size(113, 28);
            this.comboBoxPLugins.TabIndex = 11;
            // 
            // AddPlug
            // 
            this.AddPlug.Location = new System.Drawing.Point(891, 43);
            this.AddPlug.Name = "AddPlug";
            this.AddPlug.Size = new System.Drawing.Size(113, 27);
            this.AddPlug.TabIndex = 12;
            this.AddPlug.Text = "Add Plugin";
            this.AddPlug.UseVisualStyleBackColor = true;
            this.AddPlug.Click += new System.EventHandler(this.AddPlug_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 614);
            this.Controls.Add(this.AddPlug);
            this.Controls.Add(this.comboBoxPLugins);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.After);
            this.Controls.Add(this.Before);
            this.Controls.Add(this.trackBarWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrushColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLineColor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Button buttonLineColor;
        private Label label1;
        private Label label2;
        private Button buttonBrushColor;
        private ColorDialog colorDialog1;
        private TrackBar trackBarWidth;
        private Button Before;
        private Button After;
        private Button Save;
        private Button Load;
        private ComboBox comboBoxPLugins;
        private Button AddPlug;
    }
}