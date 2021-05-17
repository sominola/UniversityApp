using System.Collections.Generic;

namespace UniversityApp.Services
{
    public class NavigationView<T> : INavigationView<T>
    {
        private int _currentIndex = -1;
        public IList<T> ListViews { get; init; }

        public NavigationView(IList<T> listViews)
        {
            ListViews = listViews;
        }

        public bool CanMoveNext()
        {
            return _currentIndex < ListViews.Count - 1;
        }

        public T MoveNext()
        {
            _currentIndex++;
            return ListViews[_currentIndex];
        }

        public bool CanMoveBack()
        {
            return _currentIndex != 0;
        }

        public T MoveBack()
        {
            _currentIndex--;
            return ListViews[_currentIndex];
        }
    }
}