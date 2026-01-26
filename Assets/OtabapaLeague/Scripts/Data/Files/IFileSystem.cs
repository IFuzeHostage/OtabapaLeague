using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.Systems.Files
{
    public interface IFileSystem
    {
        Sprite SelectImage();
        void SaveImage(Sprite texture, string key);
        Sprite LoadSprite(string key);
    }
}