using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OtabapaLeague.Application.UI
{
    public abstract class LoaderEndpoint<T> : IViewEndpoint where T : View
    {
        protected abstract string ViewPath { get; }
        
        private readonly IUIHolder _uiHolder;

        protected T View;

        public LoaderEndpoint(IUIHolder uiHolder)
        {
            _uiHolder = uiHolder;
        }

        public async UniTask Open()
        {
            LoadView();
            InitView();
            await View.Open();
        }

        public async UniTask Close()
        {
            if(View == null)
                return;
            
            await View.Close();
        }

        protected abstract void InitView();
        protected abstract void DisposeView();
        
        protected virtual void LoadView()
        {
            if (_uiHolder.TryGetView(ViewPath, out var view))
            {
                View = (T)view;
                return;
            }
            var viewPrefab = Resources.Load<T>(ViewPath);
            View = GameObject.Instantiate(viewPrefab);
            _uiHolder.AddView(ViewPath, View);
        }
    }
}