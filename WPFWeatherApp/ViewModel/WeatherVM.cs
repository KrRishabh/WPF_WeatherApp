using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFWeatherApp.Model;
using WPFWeatherApp.ViewModel.Commands;
using WPFWeatherApp.ViewModel.Helper;

namespace WPFWeatherApp.ViewModel
{
    public class WeatherVM: INotifyPropertyChanged
    {


        private string query;

        public string Query
        {
            get { return query; }
            set {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentCondition currentConditions;

        public CurrentCondition CurrentConditions
        {
            get { return currentConditions; }
            set { 
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        public SearchCommand SearchCommand {
            get;
            set;
        }

        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set {
                selectedCity = value;

                
                OnPropertyChanged("SelectedCity");
                GetCurrentConditions();
            }
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions =  await AccuweatherHelper.GetCurrentCondition(SelectedCity.Key);
        }

        public async void makeQuery()
        {
            var cities = await AccuweatherHelper.GetCities(Query);
            Cities.Clear();
            foreach(City i in cities)
            {
                Cities.Add(i);
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
