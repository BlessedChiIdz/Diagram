using Avalonia;
using Diagram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.Models
{
    public class DefLine : DModel
    {
        private Point endPoint;
        private Point startPoint;
        private int _conNumbSt;
        private int _conNumbEnd;
        public int ConnNumbStart
        {
            get => _conNumbSt;
            set => SetProperty(ref _conNumbSt, value);
        }
        public int ConnNumbEnd
        {
            get => _conNumbEnd;
            set => SetProperty(ref _conNumbEnd, value);
        }
        public Point EndPoint
        {
            get => endPoint;
            set => SetProperty(ref endPoint, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                SetProperty(ref startPoint, value);
            }
        }
    }
}
