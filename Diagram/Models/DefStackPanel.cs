using Avalonia;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.Models
{
    public class DefStackPanel : DModel
    {
        private int _top;
        private int _left;
        private string? _stereotip;
        private bool _vid=true;
        private List<string> _attrib;
        private List<string> _oper;
        private int _height;
        private int _width;
        private int _numb;

        public int Width { get => _width; set => SetProperty(ref _width, value); }

        public int Height { get => _height; set => SetProperty(ref _height, value); }

        public int Top { get => _top; set => SetProperty(ref _top, value); }

        public int Left { get => _left; set => SetProperty(ref _left, value); }

        public string? Stereotip { get=>_stereotip; set=>SetProperty(ref _stereotip,value); }

        public bool Vidimost { get=>_vid; set=>SetProperty(ref _vid,value); }

        public List<string> Attributes { get => _attrib; set => SetProperty(ref _attrib, value); }

        public List<string> Operations { get => _oper; set => SetProperty(ref _oper, value); }

        public int Number { get => _numb; set => SetProperty(ref _numb, value); }

    }
}
