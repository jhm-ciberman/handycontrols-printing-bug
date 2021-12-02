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

namespace HandyControlsPrintBug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person[] PersonsList { get; private set; } = new[]
        {
            new Person { Name = "Alice", Age = 43, Pet = "Dog" },
            new Person { Name = "Bob", Age = 12, Pet = "Cat" },
            new Person { Name = "Charlie", Age = 23, Pet = "Parrot" },
        };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Pet { get; set; }
        }

        private void ButtonNoBug_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this.elementToPrint, "Printing bug!");
            }
        }

        private void ButtonBug_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                var print = new MyPrintPageView(); // offscreen! 
                print.DataContext = this;
                printDialog.PrintVisual(print, "All works fine!");
            }
        }
    }
}
