using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Demo
{
    public class AppStart : IMvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Start(object hint = null)
        {
            try
            {
                // Use this start to try the xaml bindings
                // _navigationService.Navigate<MainViewModel>().GetAwaiter().GetResult();

                // Use this start to try the code behind View & ViewModel
                //_navigationService.Navigate<CodeBehindViewModel>().GetAwaiter().GetResult();


                // Use this start to try the MvxFormsListview
                _navigationService.Navigate<HomeViewModel>().GetAwaiter().GetResult();
            }
            catch (System.Exception e)
            {
            }
        }
    }
}
