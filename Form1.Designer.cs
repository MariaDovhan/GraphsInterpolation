namespace GraphsInterpolation
{
    partial class InterpolationForm
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label1 = new Label();
            button1 = new Button();
            trackBar1 = new TrackBar();
            radioButton3 = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button3 = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            button5 = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            button4 = new Button();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.AutoScroll = true;
            formsPlot1.AutoSize = true;
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new System.Drawing.Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(400, 400);
            formsPlot1.TabIndex = 0;
            formsPlot1.SizeChanged += FormsPlot1_SizeChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton1.Location = new System.Drawing.Point(3, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(141, 25);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "метод Лагранжа";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Location = new System.Drawing.Point(150, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(129, 25);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "схема Ейткена";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(28, 17);
            label1.Name = "label1";
            label1.Size = new Size(182, 28);
            label1.TabIndex = 6;
            label1.Text = "Метод інтерполяції";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new System.Drawing.Point(217, 551);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 7;
            button1.Text = "Обчислити!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new System.Drawing.Point(52, 152);
            trackBar1.Minimum = 2;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(255, 56);
            trackBar1.TabIndex = 8;
            trackBar1.Value = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Location = new System.Drawing.Point(3, 34);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(131, 25);
            radioButton3.TabIndex = 10;
            radioButton3.TabStop = true;
            radioButton3.Text = "обидва методи";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 200);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(376, 117);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new System.Drawing.Point(25, 551);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 14;
            button2.Text = "Спробувати ще";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(radioButton1);
            flowLayoutPanel2.Controls.Add(radioButton2);
            flowLayoutPanel2.Controls.Add(radioButton3);
            flowLayoutPanel2.Location = new System.Drawing.Point(28, 50);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(320, 60);
            flowLayoutPanel2.TabIndex = 17;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button3);
            flowLayoutPanel3.Location = new System.Drawing.Point(25, 328);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(320, 202);
            flowLayoutPanel3.TabIndex = 18;
            // 
            // button3
            // 
            button3.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new System.Drawing.Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(141, 29);
            button3.TabIndex = 17;
            button3.Text = "Додати точку";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 588);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(button5);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label4);
            panel3.Location = new System.Drawing.Point(0, 406);
            panel3.Name = "panel3";
            panel3.Size = new Size(413, 182);
            panel3.TabIndex = 7;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(28, 145);
            button5.Name = "button5";
            button5.Size = new Size(229, 29);
            button5.TabIndex = 21;
            button5.Text = "Зберегти";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(269, 145);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Ім'я файлу";
            textBox3.Size = new Size(127, 27);
            textBox3.TabIndex = 20;
            textBox3.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(28, 48);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new System.Drawing.Point(28, 10);
            label5.Name = "label5";
            label5.Size = new Size(2, 23);
            label5.TabIndex = 7;
            label5.Visible = false;
            // 
            // button4
            // 
            button4.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new System.Drawing.Point(28, 145);
            button4.Name = "button4";
            button4.Size = new Size(229, 29);
            button4.TabIndex = 6;
            button4.Text = "Зберегти зображення графіка";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new System.Drawing.Point(376, 4);
            label3.Name = "label3";
            label3.Size = new Size(23, 28);
            label3.TabIndex = 2;
            label3.Text = "-";
            label3.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(346, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(50, 27);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new System.Drawing.Point(346, 4);
            label2.Name = "label2";
            label2.Size = new Size(24, 28);
            label2.TabIndex = 1;
            label2.Text = "+";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(269, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(48, 27);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new System.Drawing.Point(28, 100);
            label4.Name = "label4";
            label4.Size = new Size(229, 21);
            label4.TabIndex = 3;
            label4.Text = "Проміжок для побудови графіка";
            // 
            // panel2
            // 
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(trackBar1);
            panel2.Controls.Add(button1);
            panel2.Location = new System.Drawing.Point(415, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 588);
            panel2.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Bahnschrift Light SemiCondensed", 10.2F, FontStyle.Underline, GraphicsUnit.Point, 204);
            label10.Location = new System.Drawing.Point(236, 2);
            label10.Name = "label10";
            label10.Size = new Size(153, 21);
            label10.TabIndex = 20;
            label10.Text = "Довідка користувача";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new System.Drawing.Point(319, 157);
            label9.Name = "label9";
            label9.Size = new Size(23, 21);
            label9.TabIndex = 21;
            label9.Text = "10";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new System.Drawing.Point(28, 157);
            label8.Name = "label8";
            label8.Size = new Size(18, 21);
            label8.TabIndex = 20;
            label8.Text = "2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new System.Drawing.Point(28, 117);
            label7.Name = "label7";
            label7.Size = new Size(184, 28);
            label7.TabIndex = 19;
            label7.Text = "Вузли інтерполяції ";
            // 
            // InterpolationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 589);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "InterpolationForm";
            Text = "Graph Interpolation";
            Load += InterpolationForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label1;
        private Button button1;
        private TrackBar trackBar1;
        private RadioButton radioButton3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Button button3;
        private Button button4;
        private Panel panel2;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox3;
        private Button button5;
    }
}
