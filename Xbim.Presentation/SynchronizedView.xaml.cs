﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xbim.IO;

namespace Xbim.Presentation
{
    /// <summary>
    /// Interaction logic for SynchronizedView.xaml
    /// </summary>
    public partial class SynchronizedView : UserControl
    {
        public SynchronizedView()
        {
            InitializeComponent();
            LeftView.Viewport.Camera = RightView.Viewport.Camera;
        }



        public XbimModel Model
        {
            get { return (XbimModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(XbimModel), typeof(SynchronizedView), new UIPropertyMetadata(ModelChandegCallBack));

        private static void ModelChandegCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SynchronizedView sv = d as SynchronizedView;
            if (sv != null && e.NewValue is XbimModel)
            {
                sv.DataContext = e.NewValue;
            }
            else
                sv.DataContext = null;

        }
    }
}
