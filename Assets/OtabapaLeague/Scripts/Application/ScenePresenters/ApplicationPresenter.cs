using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.SceneLoader;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Application.ScenePresenters
{
    public class ApplicationPresenter : MonoBehaviour
    {
        private 
            ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            LoadScenes();
        }

        private async UniTask LoadScenes()
        {
            await _sceneLoader.Init();
            await _sceneLoader.LoadMainScene();
            await _sceneLoader.LoadUIScene();
        }
    }
}