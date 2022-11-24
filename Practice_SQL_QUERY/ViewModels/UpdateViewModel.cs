using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SQL_QUERY.ViewModels
{
     class UpdateViewModel:BaseViewModel
    {
        private Author author;

        public Author Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged(); }
        }

    }
}
