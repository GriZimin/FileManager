using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace FileManager
{    
    public partial class MainWindow : Window
    {
        List<string[]> buttonsSettings = new List<string[]>();
        FilesGetter loader = new FilesGetter();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddFilesToList(string path)
        {                       
            MainListBox.Items.Clear();
            var dirList = loader.GetDirs(path);
            var fileList = loader.GetFiles(path);
            for(int i = 0; i < dirList.Count; i++)
            {
                MainListBox.Items.Add(dirList[i]);                
            }
            for (int i = 0; i < fileList.Count; i++)
            {
                MainListBox.Items.Add(fileList[i]);
            }
        }      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PathTextBox.Text = @"C:\";
            AddFilesToList(@"C:\");                
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            AddFilesToList(PathTextBox.Text);
        }        

        private void MainListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(PathTextBox.Text,MainListBox.SelectedItem.ToString())) == "")
            {
                PathTextBox.Text = Path.Combine(PathTextBox.Text,MainListBox.SelectedItem.ToString());
                AddFilesToList(PathTextBox.Text);
            }
            else
            {
                Process.Start(Path.Combine(PathTextBox.Text, MainListBox.SelectedItem.ToString()));
            }
        }
    }    
}
