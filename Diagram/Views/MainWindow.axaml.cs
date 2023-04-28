using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using Diagram.ViewModels;
using System.Data;
using System.Linq;
namespace Diagram.Views
{
    public partial class MainWindow : Window
    {
        private Point pointerPosInShape;
        private Line line = new Line();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
            
        }
        void PressedOnCanv(object sender, PointerPressedEventArgs args)
        {
            if(DataContext is MainWindowViewModel mw)
            {
                if(args.Source is Rectangle rec)
                {
                    this.PointerMoved += NewStrelochka;
                    this.PointerReleased += FreeStrelochka;
                }
                if(args.Source is Border border)
                {
                    this.PointerMoved += MoveStruct;
                    this.PointerReleased += StopStruct;
                }
            }
        }
        void MoveStruct(object sender,PointerEventArgs args)
        {
            Point currentPointPos = args
                        .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>().FirstOrDefault()
                    );
            if(DataContext is MainWindowViewModel wm)
            {
                if(args.Source is Border border)
                {
                    Canvas.SetLeft((StackPanel)border.Parent, currentPointPos.X);
                    Canvas.SetTop((StackPanel)border.Parent, currentPointPos.Y);
                    StackPanel stack = (StackPanel)border.Parent;
                    Canvas canvas = (Canvas)stack.Parent;
                    for(int i = 0; i < canvas.Children.Count(); i++)
                    {
                        if (canvas.Children[i] is Line lineqwe)
                        {
                            Point qwe = new Point(500, 500);
                            lineqwe.StartPoint = qwe;
                        }
                    }
                }
            }
        }
        void StopStruct(object sender,PointerReleasedEventArgs args)
        {
            this.PointerMoved -= MoveStruct;
            this.PointerReleased -= StopStruct;
        }
        void FreeStrelochka(object sender, PointerReleasedEventArgs args)
        {
            this.PointerMoved -= NewStrelochka;
            
            if(DataContext is MainWindowViewModel wm)
            {
                Line line1 = new Line();
                line1.EndPoint = line.EndPoint;
                line1.StrokeThickness = line.StrokeThickness;
                line1.Stroke = line.Stroke;
                Point point = new Point(5, 5);
                line1.StartPoint = line.StartPoint + point;
                wm._canv.Children.Remove(line);
                wm._canv.Children.Add(line1);
                
            }

            this.PointerReleased -= FreeStrelochka;
        }
        void NewStrelochka(object sender, PointerEventArgs args)
        {
            Point currentPointPos = args
                        .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>().FirstOrDefault()
                    );

            if(DataContext is MainWindowViewModel wm) {
                if(args.Source is Rectangle rec)
                {
                    line.StrokeThickness = 5;
                    line.StartPoint = rec.Bounds.Position + rec.Parent.Bounds.Position;
                    line.EndPoint = currentPointPos;
                    line.Stroke = Brushes.Black;
                    wm._canv.Children.Remove(line);
                    wm._canv.Children.Add(line);
                }
                
                
            }
            
        }
    }
}
