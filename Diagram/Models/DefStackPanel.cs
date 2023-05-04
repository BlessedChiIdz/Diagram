using Avalonia;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string _vid;
        private List<string> _attrib;
        private ObservableCollection<string> _oper;
        private int _height;
        private int _width;
        private int _numb;

        public int Width { get => _width; set => SetProperty(ref _width, value); }

        public int Height { get => _height; set => SetProperty(ref _height, value); }

        public int Top { get => _top; set => SetProperty(ref _top, value); }

        public int Left { get => _left; set => SetProperty(ref _left, value); }

        public string? Stereotip { get { if (_stereotip != null) return _stereotip; else return "no Stereotip"; } set=>SetProperty(ref _stereotip,value); }

        public string Vidimost { get { if (_vid != null) return _vid; else return "VidimostNeZadana"; } set =>SetProperty(ref _vid,value); }

        public List<string> Attributes { get => _attrib; set => SetProperty(ref _attrib, value); }

        public ObservableCollection<string> Operations { get => _oper; set => SetProperty(ref _oper, value); }

        public int Number { get => _numb; set => SetProperty(ref _numb, value); }

    }
}
