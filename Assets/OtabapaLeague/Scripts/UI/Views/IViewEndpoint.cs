using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.UI
{
    public interface IViewEndpoint
    {
        UniTask Open();
        UniTask Close();
    }
}