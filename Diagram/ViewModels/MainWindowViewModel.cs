using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Diagram.Models;
using Diagram.Views;
using DynamicData;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Diagram.ViewModels
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        public Canvas _canv;
        public int _selNumb;
        public int numb = 0;
        public string _name;
        public int _posTop = 100;
        public int _posLeft = 100;
        private ObservableCollection<DModel> Coll;
        public DefStackPanel SelColl;
        int selectedIndex;
        string _textOper;

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
                Height = 100,
                Width = 300,
                Operations = new ObservableCollection<string>(),

            };
            stackPanel.Operations.Add("Double Click Top Line to Modify");
            
            numb++;
            COLL.Add(stackPanel);
        }
        public int SelectedIndex
        {
            get => selectedIndex;
            set => SetProperty(ref selectedIndex, value);
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
        public int SelNumb
        {
            get => _selNumb;
            set
            {
                SetProperty(ref _selNumb, value);
                SelColl = (DefStackPanel)Coll[_selNumb];
            }
        }
        public DefStackPanel DefSCOLL
        {
            get => SelColl;
        }
        public string SelName
        {
            get => SelColl.Name;

            set
            {
                string NameS = SelColl.Name;
                SetProperty(ref NameS, value);
                SelColl.Name = NameS;
            }
        }
        public string SelSter
        {

            get
            {
                if (SelColl.Stereotip != null)
                    return SelColl.Stereotip;
                else return "no Stereotip";
            }
            set
            {
                string Ster = SelColl.Stereotip;
                SetProperty(ref Ster, value);
                SelColl.Stereotip = Ster;
            }
        }
        public string SelVid
        {
            get => SelColl.Vidimost;

            set
            {
                string Vid = SelColl.Vidimost;
                SetProperty(ref Vid, value);
                SelColl.Vidimost = Vid;
            }
        }
        public ObservableCollection<string> SelList
        {
            get => SelColl.Operations;
        }
        public void Add()
        {
            SelColl.Operations.Add(TextForOper);
        }
        public void Remove()
        {
            SelColl.Operations.Remove(SelColl.Operations[SelectedIndex]);
        }
        public string TextForOper
        {
            get => _textOper;
            set => SetProperty(ref _textOper, value);
        }
    }
}
