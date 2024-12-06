using DTO;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Utils
{
    public class ImageUtils
    {
        public async static Task<Image> LoadImageFromUrl(string url)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    if(!response.IsSuccessStatusCode) 
                    { 
                        return null;
                    }

                    var imageBytes = await response.Content.ReadAsByteArrayAsync();
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        using (var magickImage = new MagickImage(memoryStream))
                        {
                            using (var ms = new MemoryStream())
                            {
                                magickImage.Write(ms, MagickFormat.Png);
                                return Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
