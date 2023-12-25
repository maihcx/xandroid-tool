namespace XAndroid_Tool.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {   
            _isInitialized = true;

            //List<NavigationButton> _PageButtons = new List<NavigationButton>();
            //_PageButtons.Add(new NavigationButton
            //{
            //    ButtonView = new Button
            //    {
            //        Content = "Android Tool",
            //        Icon = new SymbolIcon { Symbol = SymbolRegular.BoxToolbox24 }
            //    },
            //    TargetPageType = typeof(OverlayToolPage)
            //}
            //);

            //PageButtons = _PageButtons;

            //var _NavigationCards = new List<NavigationCard>();
            //_NavigationCards.Add(new NavigationCard {
            //    Name = "Overlay Tool",
            //    Icon = SymbolRegular.DeveloperBoardSearch20,
            //    Description = "No Desc",
            //    PageType = typeof(Views.Pages.AndroidTools.OverlayToolPage)
            //});


            //NavigationCards = _NavigationCards;
        }

    }
}
