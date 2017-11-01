using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Demo.Sqlite;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Demo.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IBaseDataService _dataService;
        private List<RecordData> _recordDatas;

        public HomeViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs, IBaseDataService dataService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _dataService = dataService;
            _recordDatas = _dataService.Query();
        }

        private bool _isTrue = true;

        public List<RecordData> RecordDatas
        {
            get => _recordDatas;
            set
            {
                _recordDatas = value;
                RaisePropertyChanged();
            }
        }

        public bool IsTrue
        {
            get => _isTrue;
            set
            {
                _isTrue = value;
                RaisePropertyChanged();
            }
        }



        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);

        public IMvxAsyncCommand GoToSecondPageCommand =>
            new MvxAsyncCommand(async () =>
            {
                var param = new Dictionary<string, string> {{"ButtonText", "ButtonText"}};

                await _navigationService.Navigate<ProductViewModel,Dictionary<string,string>>(param);
            });


        public IMvxCommand LabelTappedCommand => new MvxCommand(ShowMessage);

        public IMvxCommand AddProductCommand=>new MvxCommand(  AddProduct);

        private  void AddProduct()
        {
             _dataService.Add(new RecordData
            {
                RecordId= Guid.NewGuid().ToString("N"),
                CreateTime=DateTime.Now
             });

            RecordDatas = _dataService.Query();
        }

        void ShowMessage()
        {
            Text = IsTrue ? "True" : "False";
        }

        private void ResetText()
        {
            Text = "Hello MvvmCross";
            _userDialogs.Alert("test alert");
        }

        public override void Start()
        {
            base.Start();
        }

        private string _text = "Hello MvvmCross";

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }
    }
}