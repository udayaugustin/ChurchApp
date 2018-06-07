using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Church
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
			BindingContext = new  MenuViewModel(new PageService());
            InitializeComponent();
        }
    }
}
