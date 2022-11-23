using Practice_SQL_QUERY.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SQL_QUERY.ViewModels
{
    class InsertViewModel:BaseViewModel
    {
        private Author author;

        public Author Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged(); }
        }

        //public int ID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public InsertViewModel()
        {
            Author=new Author();
        }

    }
}
