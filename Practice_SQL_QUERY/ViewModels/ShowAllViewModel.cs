using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SQL_QUERY.ViewModels
{
     class ShowAllViewModel:BaseViewModel
    {

        private ObservableCollection<Author> authors;

        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged();  }
        }



    }
}
