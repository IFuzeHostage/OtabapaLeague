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
        
        private ISceneLoader _sceneLoader;
        
        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            
        }
    }
}