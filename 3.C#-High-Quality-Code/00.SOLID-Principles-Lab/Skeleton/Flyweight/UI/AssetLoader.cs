namespace FlyweightGame.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();

        private Dictionary<AssetType, ImageSource> images;

        private AssetLoader()
        {
            this.images = new Dictionary<AssetType, ImageSource>();
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            return new Image()
            {
                Source = this.LoadImage(type)
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default:
                    throw new ArgumentException("Unsupported asset type.");
            }

            if (!this.images.ContainsKey(type))
            {
                var src = new Uri(path, UriKind.Relative);
                this.images[type] = BitmapFrame.Create(src);
            }
            return this.images[type];
        }
    }
}
