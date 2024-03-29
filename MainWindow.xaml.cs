﻿using System;
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

namespace DP_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var model = new RectModel()
            {
                Width = 200,
                Height = 100,
                StrokeThickness = 3
            };
            DataContext = model;

            CustomRectangle.BindTo(nameof(model.Width), model, view, CustomRectangle.WidthProperty);
            CustomRectangle.BindTo(nameof(model.Height), model, view, CustomRectangle.HeightProperty);
            CustomRectangle.BindTo(nameof(model.StrokeThickness), model, view, CustomRectangle.StrokeThicknessProperty);
        }
    }
}
