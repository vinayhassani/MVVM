using System.ComponentModel;

namespace MVVMDemo.Model
{
    public  class Person  :INotifyPropertyChanged
    {
        private string fname;

        public string Fname
        {
            get { return fname; }
            set { fname = value;
              //  OnPropertyChanged(Fname);
            }
        }

        private string lname;

        public string Lname
        {
            get { return lname; }
            set
            {
                lname = value;
              //  OnPropertyChanged(Lname);
            }
        }


        private string fullname;

        public string Fullname
        {
            get { return fullname = Fname + " " + Lname; }
            set
            {
                if (Fullname != null)
                {
                    fullname = value;
                    
                }
            }

        }
               
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        
    }
}
           