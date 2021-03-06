using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo_SQLite.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        public ListPage()
        {
            this.Loaded += ListPage_Loaded;
            
            this.InitializeComponent();
        }

        private void ListPage_Loaded(object sender, RoutedEventArgs e)
        {
            var list = Data.DatabaseInitialize.FindAll();
            ListView listView = new ListView();
            listView.Items.Add("Name - Description - Detail - Money - CreatedAt - Category");
            foreach( var person in list)
            {
                listView.Items.Add(person.ToString());
            }
            Personal.Children.Add(listView);
           
        }
    }
}
