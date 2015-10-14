using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TreeViewFooter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public ObservableCollection<TreeViewItem> Items
        {
            get { return (ObservableCollection<TreeViewItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<TreeViewItem>), typeof(MainWindow), new PropertyMetadata(null));



        ObservableCollection<TreeViewItem> _realItems;

        public MainWindow()
        {
            InitializeComponent();

            Items = new ObservableCollection<TreeViewItem>();
            _realItems = Items;
            Items.Add(new TreeViewItem() { Header = "Yayy", IsExpanded = true });
            Items[0].ItemsSource = new ObservableCollection<TreeViewItem>();
            ((ObservableCollection<TreeViewItem>)Items[0].ItemsSource).Add(new TreeViewItem() { Header = "Child 1" });
            ((ObservableCollection<TreeViewItem>)Items[0].ItemsSource).Add(new TreeViewItem() { Header = "Child 2" });

            Items.Add(new TreeViewItem() { Header = "Yayy 2", IsExpanded = true });
            Items[1].ItemsSource = new ObservableCollection<TreeViewItem>();
            ((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).Add(new TreeViewItem() { Header = "Child 1" });
            ((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).Add(new TreeViewItem() { Header = "Child 2", IsExpanded = true });

            ((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource = new ObservableCollection<TreeViewItem>();
            ((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource).Add(new TreeViewItem() { Header = "Child 2.1" });
            ((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource).Add(new TreeViewItem() { Header = "Child 2.2" });

            ((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource).ElementAt(1).ItemsSource = new ObservableCollection<TreeViewItem>();
            ((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource).ElementAt(1).ItemsSource).Add(new TreeViewItem() { Header = "Child 2.2.1" });


            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //((ObservableCollection<TreeViewItem>)((ObservableCollection<TreeViewItem>)Items[1].ItemsSource).ElementAt(1).ItemsSource).Move(0, 1);
            if (Items == null)
            {
                Items = _realItems;
            }
            else
            {
                Items = null;
            }
        }
    }
}
