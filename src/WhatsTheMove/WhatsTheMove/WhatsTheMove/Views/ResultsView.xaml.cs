﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTheMove.UI.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsTheMove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView : ContentPageBase
    {
        public ResultsView()
        {
            InitializeComponent();

            SetContext();
        }
    }
}