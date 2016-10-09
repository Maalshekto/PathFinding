namespace WindowsFormsApplication1
{
    partial class PathFinding
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.validate01 = new System.Windows.Forms.Button();
            this.lengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.generateMapButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownXStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownXEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYEnd = new System.Windows.Forms.NumericUpDown();
            this.algorithmChoice = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.costLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYEnd)).BeginInit();
            this.algorithmChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(318, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Map 10*10";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(475, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Matrix 20*10";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // validate01
            // 
            this.validate01.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validate01.Location = new System.Drawing.Point(435, 556);
            this.validate01.Name = "validate01";
            this.validate01.Size = new System.Drawing.Size(151, 60);
            this.validate01.TabIndex = 4;
            this.validate01.Text = "Find Path";
            this.validate01.UseVisualStyleBackColor = true;
            this.validate01.Visible = false;
            this.validate01.Click += new System.EventHandler(this.validate01_Click);
            // 
            // lengthNumericUpDown
            // 
            this.lengthNumericUpDown.Location = new System.Drawing.Point(108, 16);
            this.lengthNumericUpDown.Name = "lengthNumericUpDown";
            this.lengthNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.lengthNumericUpDown.TabIndex = 5;
            this.lengthNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lengthNumericUpDown.ValueChanged += new System.EventHandler(this.lengthNumericUpDown_ValueChanged);
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Location = new System.Drawing.Point(108, 45);
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.heightNumericUpDown.TabIndex = 6;
            this.heightNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightNumericUpDown.ValueChanged += new System.EventHandler(this.heightNumericUpDown_ValueChanged);
            // 
            // generateMapButton
            // 
            this.generateMapButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateMapButton.Location = new System.Drawing.Point(161, 12);
            this.generateMapButton.Name = "generateMapButton";
            this.generateMapButton.Size = new System.Drawing.Size(151, 60);
            this.generateMapButton.TabIndex = 7;
            this.generateMapButton.Text = "Custom Map";
            this.generateMapButton.UseVisualStyleBackColor = true;
            this.generateMapButton.Click += new System.EventHandler(this.generateMapButton_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Map Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Map Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start X";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 588);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Start Y";
            this.label4.Visible = false;
            // 
            // numericUpDownXStart
            // 
            this.numericUpDownXStart.Location = new System.Drawing.Point(71, 556);
            this.numericUpDownXStart.Name = "numericUpDownXStart";
            this.numericUpDownXStart.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownXStart.TabIndex = 12;
            this.numericUpDownXStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownXStart.Visible = false;
            this.numericUpDownXStart.ValueChanged += new System.EventHandler(this.numericUpDownXStart_ValueChanged);
            // 
            // numericUpDownYStart
            // 
            this.numericUpDownYStart.Location = new System.Drawing.Point(71, 588);
            this.numericUpDownYStart.Name = "numericUpDownYStart";
            this.numericUpDownYStart.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownYStart.TabIndex = 13;
            this.numericUpDownYStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownYStart.Visible = false;
            this.numericUpDownYStart.ValueChanged += new System.EventHandler(this.numericUpDownYStart_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "End X";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "End Y";
            this.label6.Visible = false;
            // 
            // numericUpDownXEnd
            // 
            this.numericUpDownXEnd.Location = new System.Drawing.Point(195, 556);
            this.numericUpDownXEnd.Name = "numericUpDownXEnd";
            this.numericUpDownXEnd.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownXEnd.TabIndex = 16;
            this.numericUpDownXEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownXEnd.Visible = false;
            this.numericUpDownXEnd.ValueChanged += new System.EventHandler(this.numericUpDownXEnd_ValueChanged);
            // 
            // numericUpDownYEnd
            // 
            this.numericUpDownYEnd.Location = new System.Drawing.Point(193, 587);
            this.numericUpDownYEnd.Name = "numericUpDownYEnd";
            this.numericUpDownYEnd.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownYEnd.TabIndex = 17;
            this.numericUpDownYEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownYEnd.Visible = false;
            this.numericUpDownYEnd.ValueChanged += new System.EventHandler(this.numericUpDownYEnd_ValueChanged);
            // 
            // algorithmChoice
            // 
            this.algorithmChoice.Controls.Add(this.radioButton5);
            this.algorithmChoice.Controls.Add(this.radioButton4);
            this.algorithmChoice.Controls.Add(this.radioButton3);
            this.algorithmChoice.Controls.Add(this.radioButton2);
            this.algorithmChoice.Controls.Add(this.radioButton1);
            this.algorithmChoice.Location = new System.Drawing.Point(238, 548);
            this.algorithmChoice.Name = "algorithmChoice";
            this.algorithmChoice.Size = new System.Drawing.Size(164, 68);
            this.algorithmChoice.TabIndex = 18;
            this.algorithmChoice.TabStop = false;
            this.algorithmChoice.Visible = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(82, 24);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(60, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Dijkstra";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(82, 6);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(76, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Depth First";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(0, 43);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(84, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Breadth First";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(0, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Bellman Ford";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(0, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "A Star";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.Location = new System.Drawing.Point(606, 565);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(85, 37);
            this.costLabel.TabIndex = 19;
            this.costLabel.Text = "Cost : ";
            this.costLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 628);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.algorithmChoice);
            this.Controls.Add(this.numericUpDownYEnd);
            this.Controls.Add(this.numericUpDownXEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownYStart);
            this.Controls.Add(this.numericUpDownXStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateMapButton);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.lengthNumericUpDown);
            this.Controls.Add(this.validate01);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PathFinding";
            this.Text = "PathFinding";
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYEnd)).EndInit();
            this.algorithmChoice.ResumeLayout(false);
            this.algorithmChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MapUI mapUserInterface;
        private System.Windows.Forms.Button validate01;
        private System.Windows.Forms.NumericUpDown lengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown;
        private System.Windows.Forms.Button generateMapButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownXStart;
        private System.Windows.Forms.NumericUpDown numericUpDownYStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownXEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownYEnd;
        private System.Windows.Forms.GroupBox algorithmChoice;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label costLabel;
    }
}

