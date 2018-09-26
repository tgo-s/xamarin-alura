using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace carros_2.viewmodel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // Invoca se não for nulo
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
