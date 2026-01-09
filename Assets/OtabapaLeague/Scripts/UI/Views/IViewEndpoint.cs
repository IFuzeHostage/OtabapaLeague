using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Scripts.UI.Views
{
    public interface IViewEndpoint
    {
        UniTask Open();
        UniTask Close();
    }
}