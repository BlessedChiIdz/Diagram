using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.Models
{
    internal class DModel
    {
        public string? Name { get; set; }

        public string? Stereotip { get; set; }

        public bool Vidimost { get; set; }

        public int Thick = 5;

        public int Width = 150;

        public int BlockHeight = 20;

        public List<String> Attributes = new List<string>();

        public List<String> Operations = new List<string>();

        public List<int> StLinePoint = new List<int>();

        public List<int> EndLinePoint = new List<int>();
    }
}
