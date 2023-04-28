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
    internal partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<DModel> Coll = new ObservableCollection<DModel>();
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
            Rectangle Rec = new Rectangle();
            StackPanel stackPanel = new StackPanel();
            TextBox textBox = new TextBox();
            Border border = new Border();
            Avalonia.Thickness thickness = new Thickness(3,3,3,3);
            border.BorderThickness = thickness;
            border.BorderBrush = Brushes.Black;
            stackPanel.Children.Add(border);
            textBox.Text = Name;
            textBox.Width = 200;
            textBox.Margin = thickness;
            stackPanel.Height = 50;
            stackPanel.Name = textBox.Text;
            stackPanel.Children.Add(textBox);
            Rec.Width = 10;
            Rec.Height = 10;
            Rec.StrokeThickness = 2;
            Rec.Stroke = Brushes.Black;
            Rec.Fill = Brushes.Black;
            Canvas.SetLeft(Rec, 200);
            Canvas.SetTop(Rec, 0);
            stackPanel.Children.Add(Rec);
            _canv.Children.Add(stackPanel);
            Coll.Add(new DModel
            {
                Name = textBox.Text,
                Vidimost = true,

            }) ;
        }
        public MainWindowViewModel(MainWindow mw)
        {
            _canv = mw.Find<Canvas>("MyCanv");
        }
    }
}
