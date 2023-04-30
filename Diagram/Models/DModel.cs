using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.Models
{
    public abstract class DModel : ObservableObject
    {
        private int _coorForStrelochka;
        private string name;
        private Point startPoint;
        private double scaleX;
        private double scaleY;
        private IBrush? stroke;
        private IBrush? fill;
        private double strokeThickness;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set => SetProperty(ref startPoint, value);
        }
        public double ScaleX
        {
            get => scaleX;
            set => SetProperty(ref scaleX, value);
        }
        public double ScaleY
        {
            get => scaleX;
            set => SetProperty(ref scaleX, value);
        }
        public IBrush? Stroke
        {
            get => stroke;
            set => SetProperty(ref stroke, value);
        }
        public IBrush? Fill
        {
            get => fill;
            set => SetProperty(ref fill, value);
        }
        public double StrokeThickness
        {
            get => strokeThickness;
            set => SetProperty(ref strokeThickness, value);
        }

    }
}
