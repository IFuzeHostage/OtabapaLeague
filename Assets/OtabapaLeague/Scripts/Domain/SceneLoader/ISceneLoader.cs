using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Domain.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Init();
        UniTask LoadUIScene();
        UniTask LoadMainScene();
    }
}