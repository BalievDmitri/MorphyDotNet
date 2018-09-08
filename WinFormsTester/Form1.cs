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
        
        void CreateMorphAnalizer()
        {
            try
            {
                m_morphAnalyzer = new MorphAnalyzer(m_dictionaryPath);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("DirectoryNotFoundException.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UnauthorizedAccessException.");
            }
            catch (IOException)
            {
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
