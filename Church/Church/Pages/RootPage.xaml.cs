﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Church
{
	public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
			MasterBehavior = MasterBehavior.Popover;            
        }
    }
}
