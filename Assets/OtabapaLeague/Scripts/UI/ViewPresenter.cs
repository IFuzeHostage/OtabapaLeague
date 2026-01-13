namespace OtabapaLeague.Application.UI
{
    public abstract class ViewPresenter<T> where T : View
    {
        protected T View;
        
        public virtual void SetView(T view)
        {
            View = view;
            View.OnOpened += OnViewReady;
            View.OnClosed += OnViewDisabled;
        }
        
        public abstract void OnViewReady();
        public abstract void OnViewDisabled();
    }
}