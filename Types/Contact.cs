using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Contact : INotifyPropertyChanged
    {
        private string _name, _birthDay;
        private Gender _gender;
        public string Name
        {
            set { _name = value; RaisePropertyChanged("Name"); }
            get { return _name; }
        }
        public Gender Gender
        {
            set { _gender = value; RaisePropertyChanged("Gender"); }
            get { return _gender; }
        }

        public string BirthDay
        {
            set { _birthDay = value; RaisePropertyChanged("BirthDay"); }
            get { return _birthDay; }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate{};
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }


        public int Age
        {
            get
            {
                int dy = 0;
                DateTime dt;
                if (DateTime.TryParseExact(BirthDay, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
                {
                    dy = DateTime.Now.Year - dt.Year;
                    if (DateTime.Now.Month > dt.Month)
                        dy++;
                    else if (DateTime.Now.Month == dt.Month && DateTime.Now.Day > dt.Day)
                        dy++;
                }
                return dy;
            }
        }

    }
}
