using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.SceneLoader;
using OtabapaLeague.Data.Player;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Application.ScenePresenters
{
    public class ApplicationPresenter : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private IPlayersRepository _playersRepository;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader, IPlayersRepository playersRepository)
        {
            _sceneLoader = sceneLoader;
            _playersRepository = playersRepository;
        }

        private async void Awake()
        {
            await InitCoreSustems();
            await LoadScenes();
        }

        private async UniTask InitCoreSustems()
        {
            await _playersRepository.Load();
        }
        
        private async UniTask LoadScenes()
        {
            await _sceneLoader.Init();
            await _sceneLoader.LoadMainScene();
            await _sceneLoader.LoadUIScene();
        }
    }
}