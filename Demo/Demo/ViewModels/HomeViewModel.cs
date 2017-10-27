using System.Collections.Generic;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Demo.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public HomeViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
        }

        private bool _isTrue = true;

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