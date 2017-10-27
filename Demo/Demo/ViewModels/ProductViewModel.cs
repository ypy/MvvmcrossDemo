using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Demo.ViewModels
{
    public class ProductViewModel: MvxViewModel<Dictionary<string, string>>
    {
        private readonly IMvxNavigationService _navigationService;
        private Dictionary<string, string> _parameter;

        public ProductViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string MainPageButtonText { get; set; } = "Test";

        public override void Prepare(Dictionary<string, string> parameter)
        {
            _parameter = parameter;
            if (_parameter != null && _parameter.ContainsKey("ButtonText"))
                MainPageButtonText = _parameter["ButtonText"];
        }
    }
}
