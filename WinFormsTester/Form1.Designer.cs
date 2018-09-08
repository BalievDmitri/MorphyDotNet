namespace WinFormsTester
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
            this.dictionaryPath_textBox = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dictionaryPath_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.wordToParse_textBox = new System.Windows.Forms.TextBox();
            this.parses_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dictionaryPath_textBox
            // 
            this.dictionaryPath_textBox.Location = new System.Drawing.Point(12, 25);
            this.dictionaryPath_textBox.Name = "dictionaryPath_textBox";
            this.dictionaryPath_textBox.Size = new System.Drawing.Size(695, 20);
            this.dictionaryPath_textBox.TabIndex = 0;
            this.dictionaryPath_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dictionaryPath_textBox_KeyDown);
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(713, 23);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 1;
            this.browse_button.Text = "Обзор";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Расположение файла со словарями:";
            // 
            // dictionaryPath_folderBrowserDialog
            // 
            this.dictionaryPath_folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.parses_listBox);
            this.panel1.Controls.Add(this.wordToParse_textBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 386);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Введите слово для разбора:";
            // 
            // wordToParse_textBox
            // 
            this.wordToParse_textBox.Location = new System.Drawing.Point(7, 20);
            this.wordToParse_textBox.Name = "wordToParse_textBox";
            this.wordToParse_textBox.Size = new System.Drawing.Size(766, 20);
            this.wordToParse_textBox.TabIndex = 1;
            this.wordToParse_textBox.TextChanged += new System.EventHandler(this.wordToParse_textBox_TextChanged);
            // 
            // parses_listBox
            // 
            this.parses_listBox.FormattingEnabled = true;
            this.parses_listBox.Location = new System.Drawing.Point(7, 59);
            this.parses_listBox.Name = "parses_listBox";
            this.parses_listBox.Size = new System.Drawing.Size(766, 316);
            this.parses_listBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Морфологический разбор слова:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.dictionaryPath_textBox);
            this.Name = "Form1";
            this.Text = "Проверка работы MorphyDotNet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dictionaryPath_textBox;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dictionaryPath_folderBrowserDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox parses_listBox;
        private System.Windows.Forms.TextBox wordToParse_textBox;
    }
}

