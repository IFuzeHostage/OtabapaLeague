using OtabapaLeague.Domain.SceneLoader;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Scripts.Domain.ScenePresenters
{
    public class ApplicationPresenter : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
    }
}