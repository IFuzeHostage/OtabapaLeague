namespace OtabapaLeague.Application.UI
{
    public abstract class ViewPresenter<T> where T : View
    {
        protected T View;
        
        public virtual void SetView(T view)
        {
            View = view;
            View.OnOpened += OnViewReady;
            View.OnClosed += OnViewClosed;
        }

        public virtual void DetachView()
        {
        }
        
        public abstract void OnViewReady();
        public abstract void OnViewDisabled();

        private void OnViewClosed()
        {
            View.OnOpened -= OnViewReady;
            View.OnClosed -= OnViewDisabled;
            OnViewDisabled();
        }
    }
}