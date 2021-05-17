using System.Collections.Generic;

namespace UniversityApp.Services
{
    public interface INavigationView<T>
    {
        public IList<T> ListViews { get; init; }
        public bool CanMoveNext();
        public T MoveNext();
        public bool CanMoveBack();
        public T MoveBack();
    }
}