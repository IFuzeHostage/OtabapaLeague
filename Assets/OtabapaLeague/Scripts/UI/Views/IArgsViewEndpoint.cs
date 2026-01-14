using Cysharp.Threading.Tasks;

namespace OtabapaLeague.Application.UI
{
    public interface IArgsViewEndpoint<TArgs> : IViewEndpoint
    {
        UniTask Open(TArgs args);
    }
}