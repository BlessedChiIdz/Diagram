using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using Diagram.Models;
using Diagram.ViewModels;
using System.Data;
using System.Linq;
namespace Diagram.Views
{
    public partial class MainWindow : Window
    {
        private Point pointerPosInShape;
        private DefLine line = new DefLine();
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
                    pointerPosInShape = args.GetPosition(border);
                    this.PointerMoved += MoveStruct;
                    this.PointerReleased += StopStruct;
                    if(border.DataContext is DefStackPanel def)
                    {
                        if (args.ClickCount == 2)
                        {
                            mw.SelNumb = def.Number;
                            ButtonClicked(def);
                        }
                    }
                }
                if(args.Source is Line line)
                {
                    if(line.DataContext is DefLine def)
                    {
                        mw.COLL.Remove(def);
                    }
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
                if(args.Source.InteractiveParent is StackPanel st)
                {
                    if (st.DataContext is DefStackPanel dModel) 
                    {
                        dModel.StartPoint = new Point
                        (
                            currentPointPos.X - pointerPosInShape.X,
                            currentPointPos.Y - pointerPosInShape.Y);


                        for (int i = 0; i < wm.COLL.Count(); i++)
                        {
                            if (wm.COLL[i] is DefLine line)
                            {
                                if(dModel.Number == line.ConnNumbStart)
                                    line.StartPoint = dModel.StartPoint;
                                if (dModel.Number == line.ConnNumbEnd)
                                    line.EndPoint = dModel.StartPoint + new Point(0, line.ConnNumbEnd * 10);
                            }
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
            bool flag = false;
            if (DataContext is MainWindowViewModel mw)
            {
                
                Point currentPointPos = args
                            .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>().FirstOrDefault()
                        );
                
                for (int i = 0; i < mw.COLL.Count(); i++)
                {
                    if (mw.COLL[i] is DefStackPanel def)
                    {
                        for(int q = 0;q < def.Width; q++)
                        {
                            for(int j = 0; j < def.Height; j++)
                            {
                                Point point = new Point(q, j);
                                if (def.StartPoint + point == currentPointPos)
                                {
                                    line.ConnNumbEnd = def.Number;
                                    mw.COLL.Add(line);
                                    flag = true;

                                }
                            }
                        }
                    }
                }
                if (flag == false) mw.COLL.Remove(line);
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
            if (DataContext is MainWindowViewModel mw)
            {
                if(args.Source is Rectangle rec)
                {
                    if(rec.DataContext is DefStackPanel stackPanel)
                    {
                        if(line!=null) mw.COLL.Remove(line);
                        line = new DefLine
                        {
                            StartPoint = stackPanel.StartPoint,
                            EndPoint = currentPointPos,
                            ConnNumbStart = stackPanel.Number,
                            Stroke = Brushes.Black,
                            StrokeThickness = 5,
                        };
                        mw.COLL.Add(line);
                    }
                }
            }
        }
        private void ButtonClicked(DefStackPanel def)
        {
            if(DataContext is MainWindowViewModel mw)
            {
                DiagWind subWindow = new DiagWind();
                subWindow.DataContext = mw;
                subWindow.Show();
            }
        }
       

    }
}
