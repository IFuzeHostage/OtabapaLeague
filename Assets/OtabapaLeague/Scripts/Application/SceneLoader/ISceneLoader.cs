using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Init();
        UniTask LoadUIScene();
        UniTask LoadMainScene();
    }
}