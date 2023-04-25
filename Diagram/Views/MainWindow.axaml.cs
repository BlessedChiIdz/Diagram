using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using Diagram.ViewModels;
using System.Linq;
using Diagram.ViewModels;
using System;


namespace Diagram.Views
{
    public partial class MainWindow : Window
    {

        
        private Point pointPointerPressed;
        private Point pointerPosInShape;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void PointerPressedOnCanv(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs
                .GetPosition(
                this.GetVisualDescendants()
                .OfType<Canvas>()
                .FirstOrDefault()
                );
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                if (pointerPressedEventArgs.Source is Shape shape)
                {
                    pointerPosInShape = pointerPressedEventArgs.GetPosition(shape);
                    this.PointerMoved += PoinerMoveFigure;
                    this.PointerReleased += PointerPressedRelease;
                }
            }

        }

        private void PoinerMoveFigure(object? sender, PointerEventArgs pointEventArgs)
        {
            if (pointEventArgs.Source is Shape shape)
            {
                Point currentPointPos = pointEventArgs
                        .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>().FirstOrDefault()
                    );
                if (pointEventArgs.Source is Line line)
                {
                    double test = line.StartPoint.X;
                    Canvas.SetLeft(line, currentPointPos.X - line.StartPoint.X);
                    Canvas.SetTop(line, currentPointPos.Y - line.StartPoint.Y);
                }
                if (pointEventArgs.Source is Rectangle Rec)
                {
                    Canvas.SetLeft(Rec, currentPointPos.X);
                    Canvas.SetTop(Rec, currentPointPos.Y);
                }
                if (pointEventArgs.Source is Polyline Poly)
                {
                    Canvas.SetLeft(Poly, currentPointPos.X);
                    Canvas.SetTop(Poly, currentPointPos.Y);
                }
                if (pointEventArgs.Source is Ellipse El)
                {
                    Canvas.SetLeft(El, currentPointPos.X);
                    Canvas.SetTop(El, currentPointPos.Y);
                }
                if (pointEventArgs.Source is Avalonia.Controls.Shapes.Path P)
                {
                    Canvas.SetLeft(P, currentPointPos.X);
                    Canvas.SetTop(P, currentPointPos.Y);
                }

            }
        }
        private void PointerPressedRelease(object? sender, PointerReleasedEventArgs pointEventArgs)
        {
            this.PointerMoved -= PoinerMoveFigure;
            this.PointerReleased -= PointerPressedRelease;
        }
        private void AddStackPanel(object? sender, PointerEventArgs pointerEventArgs)
        {
        }

    }
}
