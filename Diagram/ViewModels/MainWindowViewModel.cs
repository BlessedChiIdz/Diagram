using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Diagram.Models;
using Diagram.Views;
using System.Collections.ObjectModel;

namespace Diagram.ViewModels
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        public Canvas _canv;
        public int numb = 0;
        public string _name;
        public int _posTop = 100;
        public int _posLeft = 100;
        private ObservableCollection<DModel> Coll;
        public MainWindowViewModel(MainWindow mw)
        {
            _canv = mw.Find<Canvas>("canvas");
            Coll = new ObservableCollection<DModel>();

        }
        public void CreateClass()
        {
            DefStackPanel stackPanel = new DefStackPanel
            {
                StartPoint = new Point(200, 200),
                Name = Name,
                Number = numb,
                Height = 50,
                Width = 50,
            };
            numb++;
            COLL.Add(stackPanel);
        }

        public ObservableCollection<DModel> COLL
        {
            get => Coll;
            set => this.SetProperty(ref Coll, value);
        }
        public int PosTop
        {
            get => _posTop;
            set => SetProperty(ref _posTop, value);
        }
        public int PosLeft
        {
            get => _posLeft;
            set => SetProperty(ref _posLeft, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    
    }
}
