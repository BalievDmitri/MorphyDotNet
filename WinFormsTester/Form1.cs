using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MorphyDotNet.ExternalApi;
using System.IO;

namespace WinFormsTester
{
    public partial class Form1 : Form
    {
        string m_dictionaryPath;
        MorphAnalyzer m_morphAnalyzer;

        public Form1()
        {
            InitializeComponent();
        }
               
        private void Form1_Load(object sender, EventArgs e)
        {
            m_dictionaryPath = Properties.Settings.Default.StartupDictionaryPath;
            CreateMorphAnalizer(supressExceptions: true);
            dictionaryPath_textBox.Text = m_dictionaryPath;
            dictionaryPath_folderBrowserDialog.SelectedPath = m_dictionaryPath;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (m_morphAnalyzer != null)
                wordToParse_textBox.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_morphAnalyzer != null)
            {
                Properties.Settings.Default.StartupDictionaryPath = m_dictionaryPath;
                Properties.Settings.Default.Save();
            }
        }

        void CreateMorphAnalizer(bool supressExceptions = false)
        {
            try
            {
                m_morphAnalyzer = new MorphAnalyzer(m_dictionaryPath);
            }
            catch (DirectoryNotFoundException)
            {
                if (!supressExceptions)
                    MessageBox.Show("DirectoryNotFoundException.");
            }
            catch (UnauthorizedAccessException)
            {
                if (!supressExceptions)
                    MessageBox.Show("UnauthorizedAccessException.");
            }
            catch (IOException)
            {
                if (!supressExceptions)
                    MessageBox.Show("IOException.");
            }
        }

        private void dictionaryPath_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_dictionaryPath = dictionaryPath_textBox.Text;
                CreateMorphAnalizer();
            }
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            if(dictionaryPath_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                m_dictionaryPath = dictionaryPath_folderBrowserDialog.SelectedPath;
                CreateMorphAnalizer();
                dictionaryPath_textBox.Text = m_dictionaryPath;
            }
        }

        private void wordToParse_textBox_TextChanged(object sender, EventArgs e)
        {
            if (m_morphAnalyzer == null)
                return;

            parses_listBox.Items.Clear();
            var parses = m_morphAnalyzer.Parse(wordToParse_textBox.Text);
            foreach(var parse in parses)
                parses_listBox.Items.Add(parse);
        }

    }
}
