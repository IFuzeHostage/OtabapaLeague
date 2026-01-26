using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OtabapaLeague.Scripts.Data.AvatarsRepository
{
    public interface IPlayerAvatarsRepository
    {
        UniTask Load();
        Sprite SelectAvatar();
        void SaveAvatar(int playerId, Sprite avatar);
        Sprite GetAvatar(int playerId);
    }
}