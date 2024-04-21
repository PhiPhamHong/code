using System;
using System.Text.RegularExpressions;
using System.Web;
using Core.Extensions;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace Core.FrontEnds.Libraries.Images
{
    public class ImageHandler : IHttpHandler
    {
        public const string regexString = "/w([0-9]+)h([0-9]+)/(c|n)_(.*)";
        public const string dot2 = "-dot-";
        public const string filePathMap = "~/{0}/{1}/{2}";
        public const string rootPath = "/";
        public const string http = "http://";
        public const string map1 = "~{0}{1}";
        public const string map2 = "~/{0}/{1}/";
        public const string map3 = "/{0}/{1}/{2}";
        public const string _h = "_h";
        public const string _w = "_w";

        /// <summary>
        /// Thực hiện xử lý request tài nguyên image
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var url = context.Request.RawUrl;

            var strRegex = regexString.Frmat(context.Request.Url.Authority);
            var rex = new Regex(strRegex, RegexOptions.IgnoreCase);
            var match = rex.Match(url);

            if (match.Success)
            {
                var w = Convert.ToInt32(match.Groups[1].Value); // Độ rộng cần thumb
                var h = Convert.ToInt32(match.Groups[2].Value); // Chiều cao ảnh cần thumb

                var crop = match.Groups[3].Value == "c";

                var path = match.Groups[4].Value;
                path = HttpUtility.UrlDecode(path.Replace(dot2, PathImage.DOT));

                var fileName = GetFileName(path, w, h, crop);
                var saveFolder = Setting.SaveFolder;
                var filePath = context.Server.MapPath(filePathMap.Frmat(saveFolder, fileName[0], fileName[1]));
                var exits = File.Exists(filePath);

                if (!exits)
                {
                    Image image;
                    if (Setting.ServerImage.IndexOf(http) >= 0)
                    {
                        var request = (HttpWebRequest)WebRequest.Create(Setting.ServerImage + "/" + path);
                        request.Timeout = 10000;
                        var response = (HttpWebResponse)request.GetResponse();
                        image = Image.FromStream(response.GetResponseStream());
                    }
                    else
                    {
                        var imageFile = context.Server.MapPath(map1.Frmat(Setting.ServerImage, path));
                        image = Image.FromFile(imageFile);
                    }

                    if (Setting.IsSaveThumb)
                    {
                        var folder = context.Server.MapPath(map2.Frmat(saveFolder, fileName[0]));
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                    }

                    if (image == null) return;
                    DoImage(image, w, h, filePath, crop);
                }
                else
                {
                    var image = Image.FromFile(filePath);
                    using (var thumb = new Bitmap(image))
                    {
                        using (var ms = new MemoryStream())
                        {
                            thumb.Save(ms, ImageFormat.Png);
                            ms.WriteTo(HttpContext.Current.Response.OutputStream);
                        }
                        HttpContext.Current.Response.ContentType = "image/png";
                    }
                }
                //if (Setting.IsSaveThumb) context.Response.Redirect(map3.Frmat(saveFolder, fileName[0], fileName[1]));
            }

        }

        
        private string[] GetFileName(string path, int w, int h, bool crop)
        {
            var fileNameOri = path.Substring(path.LastIndexOf(rootPath) + 1); // file.extension
            var folder = path.Substring(0, path.LastIndexOf(rootPath));
            var extension = fileNameOri.Substring(fileNameOri.LastIndexOf(PathImage.DOT) + 1);
            var fileName = fileNameOri.Substring(0, fileNameOri.LastIndexOf(PathImage.DOT));

            string[] str = new string[2];
            str[0] = folder;
            str[1] = fileName + (w < 0 ? string.Empty : _w + w) + (h < 0 ? string.Empty : _h + h) + "_" + (crop ? "c" : "n") + PathImage.DOT + extension;
            
            return str;
        }

        private void DoImage(Image image, int toWidth, int toHeight, string path, bool crop)
        {
            if (!crop)
            {
                int rWidth = image.Width; // Chiều rộng của ảnh
                int rHeight = image.Height; // Chiều cao của ảnh

                if (toWidth == 0 && toHeight == 0)
                {
                    toWidth = rWidth;
                    toHeight = rHeight;
                }

                //Nếu một trong 2 kích thước cần thumb = 0
                else if (toWidth == 0 || toHeight == 0)
                {
                    // Thumb theo chiều rộng
                    if (toWidth != 0 && toHeight == 0 && toWidth < rWidth)
                    {
                        toHeight = (toWidth * rHeight) / rWidth;
                    }
                    // Thumb theo chiều cao
                    else if (toHeight != 0 && toWidth == 0 && toHeight < rHeight)
                    {
                        toWidth = (toHeight * rWidth) / rHeight;
                    }
                    // Các trường hợp còn lại thì ko thumb, giữ nguyên kích thước ảnh
                    else
                    {
                        toWidth = rWidth;
                        toHeight = rHeight;
                    }
                }
                // Nếu cả hai kích thước khác không
                else
                {
                    // Cả 2 kích thước đều nhỏ hơn kích thước thực thì chỉ crop
                    if (toWidth <= rWidth && toHeight <= rHeight)
                    {
                        //Giữ nguyên kích thước thumb
                    }
                    // Một trong 2 kích thước nhỏ hơn kích thước thực thì mới thực hiện
                    else if (toWidth < rWidth || toHeight < rHeight)
                    {
                        if ((rWidth / toWidth) > (rHeight / toHeight)) toHeight = (int)(rHeight * ((double)toWidth / (double)rWidth));

                        else toWidth = (int)(rWidth * ((double)toHeight / (double)rHeight));
                    }
                    else if (toWidth < rWidth && toHeight > rHeight) toHeight = rHeight;

                    // Trường hợp còn lại thì không thumb, giữ nguyên kích thước ảnh
                    else
                    {
                        toWidth = rWidth;
                        toHeight = rHeight;
                    }
                }
            }

            var img = Crop(image, toWidth, toHeight, AnchorPosition.Center);
            using (var thumb = new Bitmap(img))
            {
                //thumb.SetResolution(P_Width, P_Width);
                using (var g = Graphics.FromImage(thumb)) // Create Graphics object from original Image
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.High;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(thumb, new Rectangle(0, 0, thumb.Width, thumb.Height));

                    if (Setting.IsSaveThumb)
                    {
                        var codec = ImageCodecInfo.GetImageEncoders()[1]; //Set Image codec of JPEG type, the index of JPEG codec is "1"
                        var eParams = new EncoderParameters(1); //Set the parameters for defining the quality of the thumbnail... here it is set to 100%
                        eParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 92L);
                        thumb.Save(path, codec, eParams);
                    }

                    // else
                    //thumb.Save(HttpContext.Current.Response.OutputStream, codec, eParams);
                    using (var ms = new MemoryStream())
                    {
                        thumb.Save(ms, ImageFormat.Png);
                        ms.WriteTo(HttpContext.Current.Response.OutputStream);
                    }
                    HttpContext.Current.Response.ContentType = "image/png";
                }
            }
        }
        private Image Crop(Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            float nPercentW = Width / (float)sourceWidth;
            float nPercentH = Height / (float)sourceHeight;
            float nPercent;
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top:
                        destY = 0;
                        break;
                    case AnchorPosition.Bottom:
                        destY = (int)(Height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)((Height - (sourceHeight * nPercent)) / 2);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left:
                        destX = 0;
                        break;
                    case AnchorPosition.Right:
                        destX = (int)(Width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)((Width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            var bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        enum AnchorPosition
        {
            Top,
            Center,
            Bottom,
            Left,
            Right
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
