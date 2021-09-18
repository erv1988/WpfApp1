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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ContactListControl.xaml
    /// </summary>
    public partial class ContactListControl : UserControl
    {
        public ContactListControl()
        {
            InitializeComponent();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {
            var dlg = new NewContactWindow();
            var ret = dlg.ShowDialog(); 
            if (ret.HasValue && ret.Value)
            {
                ContactList contactList = this.DataContext as ContactList;
                contactList.Contacts.Add(dlg.Contact);
            }
        }

        private void SaveContactsClick(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
