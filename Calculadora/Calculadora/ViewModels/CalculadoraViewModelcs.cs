using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculadora.ViewModels
{
    public class CalculadoraViewModelcs : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                if (true)
                {

                }
            }
        }
    }
}
