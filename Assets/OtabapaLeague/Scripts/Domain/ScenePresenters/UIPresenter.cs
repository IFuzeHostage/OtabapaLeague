using OtabapaLeague.Domain.SceneLoader;
using OtabapaLeague.Scripts.Domain.UIController;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Scripts.Domain.ScenePresenters
{
    public class UIPresenter : MonoBehaviour
    {
        [SerializeField]
        private UIParent _uiRoot;
        
        private IUIHolder _uiHolder;
        
        [Inject]
        public void Construct(IUIHolder uiHolder)
        {
            _uiHolder = uiHolder;   
        }

        private void Awake()
        {
            _uiHolder.Init(_uiRoot);
        }
    }
}