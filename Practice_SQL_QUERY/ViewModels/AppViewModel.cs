﻿using Practice_SQL_QUERY.Commands;
using Practice_SQL_QUERY.Models;
using Practice_SQL_QUERY.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practice_SQL_QUERY.ViewModels
{
    class AppViewModel : BaseViewModel
    {

        private ObservableCollection<Author> librarians;

        public ObservableCollection<Author> Librarians
        {
            get { return librarians; }
            set { librarians = value;OnPropertyChanged(); }
        }


        public Author InsertedAuthor { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public AppViewModel()
        {
            Librarians = new ObservableCollection<Author>(ReadTable.GetData());

            InsertCommand = new RelayCommand(c =>
            {

                var insertView = new InsertWindow();
                var viewModel = new InsertViewModel();
                insertView.DataContext = viewModel;
                insertView.ShowDialog();
                InsertedAuthor = viewModel.Author;

                if (Librarians.Any(d => d.Id == InsertedAuthor.Id))
                {
                    MessageBox.Show($"Author with ID {InsertedAuthor.Id} already exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (InsertedAuthor.FirstName==null ||
                InsertedAuthor.LastName==null || InsertedAuthor.Id==0)
                {
                    MessageBox.Show($"Wrong Input Format", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DMLOpeations.Insert(InsertedAuthor.Id, InsertedAuthor.FirstName, InsertedAuthor.LastName);
                    MessageBox.Show($"{InsertedAuthor.FirstName} {InsertedAuthor.LastName} has been successfully added");
                }

                Librarians = new ObservableCollection<Author>(ReadTable.GetData());
            });

            DeleteCommand = new RelayCommand(c =>
            {
                var deleteView = new DeleteWindow();
                var viewModel = new DeleteViewModel();
                deleteView.DataContext = viewModel;
                deleteView.ShowDialog();

                var deletedAuthor = Librarians.ToList().Find(m => m.Id == viewModel.ID);

                if (Librarians.Any(d => d.Id == viewModel.ID))
                {
                    DMLOpeations.Delete(viewModel.ID);
                    MessageBox.Show($"{deletedAuthor.FirstName} {deletedAuthor.LastName} has been successfully deleted");
                }
                else
                    MessageBox.Show($"Author with ID {viewModel.ID} does not exist in database", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                Librarians = new ObservableCollection<Author>(ReadTable.GetData());

            });

        }

    }
}
