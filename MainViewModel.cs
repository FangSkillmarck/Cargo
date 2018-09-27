using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlygFraktMedFart
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> AllPlanes { get; set; }
        public ObservableCollection<string> AllCratesOnPlane { get; set; }
        public string SizeOfCrate { get; set; }
        public string Weight { get; set; }
        public string Recipient { get; set; }

        internal class ButtonCommand : ICommand
        {
            private readonly Action _callBack;
            internal ButtonCommand(Action a)
            {
                _callBack = a;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _callBack();
            }

            public event EventHandler CanExecuteChanged;
        }

        private ButtonCommand _addCommand;
        private ButtonCommand _removeCommand;

        public ICommand AddInventory { get { return _addCommand = _addCommand ?? new ButtonCommand(AddContentToPlane); } }
        public ICommand RemoveInventory { get { return _removeCommand = _removeCommand ?? new ButtonCommand(RemoveContentFromPlane); } }

        private void AddContentToPlane()
        {
            throw new NotImplementedException();
        }

        private void RemoveContentFromPlane()
        {
            throw new NotImplementedException();
        }

        public MainViewModel()
        {
            AllPlanes = new ObservableCollection<string>
            {
                "Plane 1",
                "Plane 2",
                "Plane 3",
                "Plane 4"
            };
            AllCratesOnPlane = new ObservableCollection<string>();
            SizeOfCrate = 8.ToString();
            Weight = 20.ToString();
            Recipient = "Receiver1";
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
