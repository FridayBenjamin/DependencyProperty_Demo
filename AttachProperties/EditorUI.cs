using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media;

namespace DP_Demo.AttachProperties
{
    public class EditorUI : UIElement
    {
        public static int GetZoom(DependencyObject obj)
        {
            return (int)obj.GetValue(ZoomProperty);
        }

        public static void SetZoom(DependencyObject obj, int value)
        {
            obj.SetValue(ZoomProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.RegisterAttached("Zoom", typeof(int), typeof(EditorUI), new PropertyMetadata(0));


        public EditorUI()
        {

        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return base.OnCreateAutomationPeer();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
    }
}
