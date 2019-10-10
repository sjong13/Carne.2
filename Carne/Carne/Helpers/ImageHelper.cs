using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace Carne.Helpers
{
    public class ImageHelper
    {
        /// <summary>
        /// Convert IO stream into byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] GetBytes(Stream stream)
        {
            if (stream == null) return null;


            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }


        public static ImageSource GetImageSourceFromBytes(byte[] bytes)
        {
            return ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        public static ImageSource GetImageSourceFromUrl(string url)
        {
            ImageSource imageSource;

            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(url);
                byte[] bytes = GetBytes(stream);
                imageSource = GetImageSourceFromBytes(bytes);
            }

            return imageSource;
        }
    }
}
