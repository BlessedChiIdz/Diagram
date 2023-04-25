using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Diagram.Models;
using Diagram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Diagram.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<DModel> dModels = new ObservableCollection<DModel>();
        public Canvas _canv;
        public string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name,value);
        }
        public string _coor;
        public string Coor
        {
            get => _coor;
            set => SetProperty(ref _coor, value);
        }
        public void CreateClass()
        {
            StackPanel stackPanel = new StackPanel();
            TextBox textBox = new TextBox();
            Border border = new Border();
            Avalonia.Thickness thickness = new Thickness(3,3,3,3);
            border.BorderThickness = thickness;
            border.BorderBrush = Brushes.Black;
            stackPanel.Children.Add(border);
            textBox.Text = "qwe";
            textBox.Width = 100;
            textBox.Margin = thickness;
            stackPanel.Height = 50;
            stackPanel.Children.Add(textBox);
            _canv.Children.Add(stackPanel);




            DModel dModel = new DModel();
            dModel.Name = "qweew";
            dModel.Stereotip = "abstract";
            dModel.Vidimost = false;
            dModel.Attributes.Add("qweqe");
            dModel.Operations.Add("zxcxzc");
            dModel.Name = "Class1";
            Rectangle newRec = new Rectangle();
            int height = 100;
            foreach (string qwe in dModel.Attributes)
            {
                height += 20;
            }
            newRec.StrokeThickness = dModel.Thick;
            newRec.Width = dModel.Width;
            newRec.Height = height;
            newRec.Stroke = Brushes.Black;
            string[] LocalCor = Coor.Split(" ");
            int Cor0 = Convert.ToInt32(LocalCor[0]);
            int Cor1 = Convert.ToInt32(LocalCor[1]);
            Canvas.SetLeft(newRec,Cor0);
            Canvas.SetTop(newRec, Cor1);
            _canv.Children.Add(newRec);
            Rectangle nameRec = new Rectangle();
            nameRec.StrokeThickness = dModel.Thick;
            nameRec.Width = dModel.Width;
            nameRec.Height = dModel.BlockHeight;
            nameRec.Stroke = Brushes.Black;
            Canvas.SetLeft(nameRec, Cor0);
            Canvas.SetTop(nameRec, Cor1);
            _canv.Children.Add(nameRec);

        }
        public MainWindowViewModel(MainWindow mw)
        {
            _canv = mw.Find<Canvas>("MyCanv");
        }
    }
}
