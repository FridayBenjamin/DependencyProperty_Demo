using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DP_Demo
{
    internal class ChartCanvas : Canvas
    {
        public bool IsAvailable
        {
            get { return (bool)GetValue(IsAvailableProperty); }
            set { SetValue(IsAvailableProperty, value); }
        }

        public static readonly DependencyProperty IsAvailableProperty =
            DependencyProperty.Register(
                name: "IsAvailable",
                propertyType: typeof(bool),
                ownerType: typeof(ChartCanvas),
                typeMetadata: new PropertyMetadata(
                    defaultValue: false,
                    propertyChangedCallback: new PropertyChangedCallback(OnValueChnaged),
                    coerceValueCallback: new CoerceValueCallback(OnCoerceValue)));

        private static object OnCoerceValue(DependencyObject d, object baseValue)
        {
            if (baseValue is false)
                return true;
            return baseValue;
        }

        private static void OnValueChnaged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            


        }



        public static double GetMax(DependencyObject obj)
        {
            return (double)obj.GetValue(MaxProperty);
        }

        public static void SetMax(DependencyObject obj, double value)
        {
            obj.SetValue(MaxProperty, value);
        }


        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.RegisterAttached(
                "Max",
                typeof(double),
                typeof(ChartCanvas),
                new PropertyMetadata(0.0, new PropertyChangedCallback(OnMaxValueChanged),
                    new CoerceValueCallback(OnMaxValueCoerce)));

        private static object OnMaxValueCoerce(DependencyObject d, object baseValue)
        {
            var child = (FrameworkElement)d;
            if(child.Parent != null)
            {
                var parent = (FrameworkElement)child.Parent;
                double value = (double)baseValue;
                return Math.Min(value, parent.Width);
            }
            return baseValue;
        }

        private static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            Canvas.SetBottom((UIElement)d, (double)e.NewValue);
        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static double GetMaxSize(double x, double y)
        {
            return Math.Max(x, y);
        }
    }
}
