namespace GetWebpage
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folerTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.maxLevelSelector = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxLevelSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(687, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(32, 220);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(99, 51);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(664, 25);
            this.urlTextBox.TabIndex = 3;
            this.urlTextBox.Text = "https://www.baidu.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Foler:";
            // 
            // folerTextBox
            // 
            this.folerTextBox.Location = new System.Drawing.Point(99, 101);
            this.folerTextBox.Name = "folerTextBox";
            this.folerTextBox.Size = new System.Drawing.Size(567, 25);
            this.folerTextBox.TabIndex = 5;
            this.folerTextBox.Text = "CatchedData";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keyword:";
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(99, 143);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(663, 25);
            this.keywordTextBox.TabIndex = 7;
            // 
            // maxLevelSelector
            // 
            this.maxLevelSelector.Location = new System.Drawing.Point(99, 176);
            this.maxLevelSelector.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.maxLevelSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLevelSelector.Name = "maxLevelSelector";
            this.maxLevelSelector.Size = new System.Drawing.Size(54, 25);
            this.maxLevelSelector.TabIndex = 8;
            this.maxLevelSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "MaxLevel:";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(123, 220);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 257);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxLevelSelector);
            this.Controls.Add(this.keywordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.folerTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.maxLevelSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox folerTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.NumericUpDown maxLevelSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopButton;
    }
}

