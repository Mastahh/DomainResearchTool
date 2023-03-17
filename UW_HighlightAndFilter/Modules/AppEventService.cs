using UW_HighlightAndFilter.Models;

namespace UW_HighlightAndFilter.Modules
{
    public static class AppEventService
    {
        public static event Action AppSettingsChanged;
        public static event Action DomainFilteringStarted;
        public static event Action DomainFilteringEnded;
        public static event Action<int> GridPageSizeChanged;
        public static event Action<DomainItem> DomainItemAddedToFavorites;
        public static event Action<DomainItem> DomainItemRemovedFromFavorites;

        public static void TriggerAppSettingsChanged()
        {
            if (AppSettingsChanged != null) { AppSettingsChanged.Invoke(); }
        }

        public static void TriggerDomainFilteringStarted()
        {
            if (DomainFilteringStarted != null) { DomainFilteringStarted.Invoke(); }
        }

        public static void TriggerDomainFilteringEnded()
        {
            if (DomainFilteringEnded != null) { DomainFilteringEnded.Invoke(); }
        }

        public static void TriggerDomainAddedToFavorites(DomainItem favoriteItem)
        {
            if (DomainItemAddedToFavorites != null) { DomainItemAddedToFavorites.Invoke(favoriteItem); }
        }

        public static void TriggerDomainRemovedFromFavorites(DomainItem favoriteItem)
        {
            if (DomainItemRemovedFromFavorites != null) { DomainItemRemovedFromFavorites.Invoke(favoriteItem); }
        }

        public static void TriggerGridPageSizeChange(int newPageSize)
        {
            if (GridPageSizeChanged != null) { GridPageSizeChanged.Invoke(newPageSize); }
        }
    }
}
