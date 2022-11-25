using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Demo
{
    public class RectModel : INotifyPropertyChanged
    {       
        public double Width
        {
            get => _width;
            set 
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        private double _width;


        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
        private double _height;

        public double StrokeThickness
        {
            get => _strokeThickness;
            set
            {
                _strokeThickness = value;
                OnPropertyChanged(nameof(StrokeThickness));
            }
        }
        private double _strokeThickness;

        protected virtual void OnPropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
