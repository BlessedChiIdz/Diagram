using Avalonia.Controls;
using Avalonia.Interactivity;
using Diagram.ViewModels;

namespace Diagram.Views
{
    public partial class DiagWind : Window
    {
        
        public DiagWind()
        {
            InitializeComponent();
            var window1 = this.DataContext;
            DataContext = window1;
        }
    }
}
