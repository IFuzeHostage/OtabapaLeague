using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.UI
{
    public abstract class ArgsLoaderEndpoint<TArgs, TView> : LoaderEndpoint<TView>, IArgsViewEndpoint<TArgs> where TView : View
    {
        protected ArgsLoaderEndpoint(IUIHolder uiHolder) : base(uiHolder)
        {
        }
        
        public async UniTask Open(TArgs args)
        {
            LoadView();
            InitView(args);
            await View.Open();
        }
        
        protected abstract void InitView(TArgs args);

        protected override void InitView() { }
    }
}