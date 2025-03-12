using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace P1_FileHandling
{
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\PGYSW023\Desktop\output.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mulTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mulTxt.Text.Split().Any(line => line.Trim().ToUpper() == "STOP"))
            {
                mulTxt.IsEnabled = false;
                MessageBox.Show("You entered 'STOP'. You can't enter more text!", "Input Stopped", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void saveTxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] lines = mulTxt.Text.Split();
                StringBuilder sb = new StringBuilder();

                foreach (string line in lines)
                {
                    File.WriteAllText(path, sb.ToString());
                    if (line.Trim().ToUpper() == "STOP")
                        return;
                    sb.AppendLine(line);
                }
                mulTxt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    

        private void DispalyTxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    txtOutput.Text = content;
                }
                else
                {
                    MessageBox.Show("File not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
    }

    }


    
    

