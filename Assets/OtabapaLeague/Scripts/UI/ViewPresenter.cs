namespace OtabapaLeague.Application.UI
{
    public abstract class ViewPresenter<T> where T : View
    {
        protected T View;
        
        public virtual void SetView(T view)
        {
            View = view;
        }
        
        public abstract void OnViewReady();
        public abstract void OnViewDisabled();
    }
}