using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CustomerApp.Objects {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte[] ImageData { get; set; }

        public void SetImageFromFile(string filePath) {
            if (File.Exists(filePath)) {
                ImageData = File.ReadAllBytes(filePath);
            }
        }

        public BitmapImage ImageSource {
            get {
                if (ImageData == null || ImageData.Length == 0) return null;
                using (var ms = new MemoryStream(ImageData)) {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    return bitmap;
                }
            }
        }

        public void ClearImage() {
            ImageData = null;
        }
    }
}
