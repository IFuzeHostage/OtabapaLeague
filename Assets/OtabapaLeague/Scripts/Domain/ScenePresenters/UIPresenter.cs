using OtabapaLeague.Domain.SceneLoader;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Scripts.Domain.ScenePresenters
{
    public class UIPresenter : MonoBehaviour
    {
        [SerializeField]
        private Transform _uiRoot;
        
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