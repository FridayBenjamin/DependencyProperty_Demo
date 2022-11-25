using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DP_Demo
{
    public class CustomRectangle : UIElement
    {
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width",
                typeof(double), 
                typeof(CustomRectangle),
                new PropertyMetadata(100.0, new PropertyChangedCallback(OnValueChanged)));

        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", 
                typeof(double), 
                typeof(CustomRectangle),
                new PropertyMetadata(50.0, new PropertyChangedCallback(OnValueChanged)));


        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness",
                typeof(double),
                typeof(CustomRectangle),
                new PropertyMetadata(2.0, new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == WidthProperty ||
                    e.Property == HeightProperty ||
                    e.Property == StrokeThicknessProperty)
            {
                var ui = (UIElement)d;
                ui.InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var stroke = new SolidColorBrush(Colors.Black);
            Pen drawingPen = new(stroke, StrokeThickness);
            drawingContext.DrawRectangle(null, drawingPen, new Rect(10, 10, Width, Height));
        }

        public static void BindTo(string name, object source, DependencyObject d, DependencyProperty property)
        {
            var binding = new Binding(name)
            {
                Source = source,
                Mode = BindingMode.TwoWay
            };
            BindingOperations.SetBinding(d, property, binding);
        }
    }
}
