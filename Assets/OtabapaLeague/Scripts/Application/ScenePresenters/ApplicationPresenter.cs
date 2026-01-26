using Cysharp.Threading.Tasks;
using OtabapaLeague.Application.SceneLoader;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Data.GamesRepository;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Application.ScenePresenters
{
    public class ApplicationPresenter : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private IPlayersRepository _playersRepository;
        private IGamesRepository _gamesRepository;
        private IPlayerAvatarsRepository _playerAvatarsRepository;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader, IPlayersRepository playersRepository, 
            IGamesRepository gamesRepository, IPlayerAvatarsRepository playerAvatarsRepository)
        {
            _sceneLoader = sceneLoader;
            _playersRepository = playersRepository;
            _gamesRepository = gamesRepository;
            _playerAvatarsRepository = playerAvatarsRepository;
        }

        private async void Awake()
        {
            await InitCoreSustems();
            await LoadScenes();
        }

        private async UniTask InitCoreSustems()
        {
            await _playersRepository.Load();
            await _gamesRepository.Load();
            await _playerAvatarsRepository.Load();
        }
        
        private async UniTask LoadScenes()
        {
            await _sceneLoader.Init();
            await _sceneLoader.LoadMainScene();
            await _sceneLoader.LoadUIScene();
        }
    }
}