using System.IO;
using SFB;
using UnityEngine;

namespace OtabapaLeague.Scripts.Domain.Systems.Files
{
    public class FileSystem : IFileSystem
    {
        public Sprite SelectImage()
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
            if (paths.Length > 0)
            {
                var selectedPath = paths[0];
                
                Texture2D tex = new Texture2D(2, 2);
                ImageConversion.LoadImage(tex, File.ReadAllBytes(selectedPath));
                return ConvertToSprite(tex);
            }
            
            return null;
        }

        public void SaveImage(Sprite sprite, string key)
        {
            var texture = sprite.texture;
            byte[] bytes = texture.EncodeToPNG();

            string path = Path.Combine(UnityEngine.Application.persistentDataPath, key);
            File.WriteAllBytes(path, bytes);

            Debug.Log("Saved image to: " + path);
        }

        public Texture2D LoadImage(string key)
        {
            string path = Path.Combine(UnityEngine.Application.persistentDataPath, key);

            if (!File.Exists(path))
            {
                Debug.LogWarning("Image not found at: " + path);
                return null;
            }

            byte[] bytes = File.ReadAllBytes(path);

            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes); // auto-resizes texture

            return texture;
        }

        public Sprite LoadSprite(string key)
        {
            var texture = LoadImage(key);

            return ConvertToSprite(texture);
        }

        private Sprite ConvertToSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}