using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pustakalay.Infrastructure
{
    public class ViewModelBase:IViewModel,INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            
        }
        
        
        
        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
