using System;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;
using System.Drawing.Text;
namespace Common
{
	/// <summary>
	/// Summary description for IResize.
	/// </summary>
	public class IResize
	{
		
		public static bool getThumbs(string vKey, string vDirSource, string vDirDestination,string vFileName)
		{			
			if(File.Exists(vDirSource+"\\"+vFileName))
				return ReSize(vKey,vDirSource,vDirDestination,vFileName);	
				//return ReSize(vKey,vDirSource,vDirDestination,vFileName);	
			else
				return false;
		}

		public static bool DrawThumbs(string vKey, string vDirSource, string vDirDestination,string vFileName)
		{			
			if(File.Exists(vDirSource+"\\"+vFileName))
				//return DrawNewImage(vKey,vDirSource,vDirDestination,vFileName);	
				return ReSize(vKey,vDirSource,vDirDestination,vFileName);	
			else
				return false;
		}
		public static bool DrawGifThumbs(string vKey, string vDirSource, string vDirDestination,string vFileName)
		{			
			if(File.Exists(vDirSource+"\\"+vFileName))
				return DrawNewGifImage(vKey,vDirSource,vDirDestination,vFileName);	
			else
				return false;
		}
		public static bool getLogoThumbs(string vKey, string vDirSource, string vDirDestination,string vFileName)
		{			
			if(File.Exists(vDirSource+"\\"+vFileName))
				return GReSize(vKey,vDirSource,vDirDestination,vFileName);	
			else
				return false;
		}
		/// <summary>
		/// Resize image
		/// </summary>
		/// <param name="key">parameter by height and weight from Webconfig
		/// key format(100x200 <->hxw)</param>
		/// <param name="vDirSource">Folder image resize</param>
		/// <param name="vDirDestination">Folder thumbs </param>
		/// <param name="vFileName">Image thumbs </param>
		/// <returns></returns>
		public static bool ReSize(string key, string vDirSource, string vDirDestination,string vFileName)
		{

			string vDir = vDirSource;
			//string key format (100x200) <--> (wxh)
			string[] tSize= key.Split('x');
			// find the image that was requested
			string file = Path.Combine(vDir, vFileName);			
			
			System.Drawing.Image img = System.Drawing.Image.FromFile(file);

			// load it up
				bool rs = true;

				int MAX_WIDTH = int.Parse(tSize[0]), MAX_HEIGHT = int.Parse(tSize[1]);

					float rW = 1, rH = 1;
					//Get Origine Image Size
					int sizeWidth = img.Width, sizeHeight = img.Height;

					if (img.Width >= MAX_WIDTH)
						rW = (float)MAX_WIDTH / img.Width;
					if (img.Height >= MAX_HEIGHT)
						rH = (float)MAX_HEIGHT / img.Height;

					if (rW != 1 && rW < rH)
					{            
						sizeWidth = MAX_WIDTH;
						sizeHeight = (int)((float)rW * img.Height);
					}
					else
					{
						if (rH != 1 && rH <= rW)
						{
							sizeHeight = MAX_HEIGHT;
							sizeWidth = (int)((float)rH * img.Width);
						}
					}
		
				// create the thumbnail image
					if(vDirDestination!="") vDir=vDirDestination;
					// emit it to the response strea,
					Image bmp = new Bitmap(MAX_WIDTH, MAX_HEIGHT);
					
					Graphics grp = Graphics.FromImage(bmp);

					grp.SmoothingMode = SmoothingMode.HighQuality;
					grp.CompositingQuality = CompositingQuality.HighQuality;
					grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
					grp.PixelOffsetMode = PixelOffsetMode.HighQuality;

					Rectangle oRectangle = new Rectangle(0, 0, MAX_WIDTH, MAX_HEIGHT);
					grp.DrawImage(img, oRectangle);

					LinearGradientBrush l1 = new LinearGradientBrush(new Rectangle(0, 0, MAX_WIDTH, MAX_HEIGHT), Color.White, Color.White, LinearGradientMode.Vertical);
					grp.FillRectangle(l1, 0, 0, MAX_WIDTH, MAX_HEIGHT);

                    Rectangle rg1 = new Rectangle(0, bmp.Height / 2+140, bmp.Width, bmp.Height);
                    Rectangle rg2 = new Rectangle(0, bmp.Height / 2 + 80, bmp.Width, bmp.Height);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;

					grp.DrawImage(img, (MAX_WIDTH-sizeWidth)/2, (MAX_HEIGHT-sizeHeight)/2, sizeWidth, sizeHeight);
                    if (int.Parse(tSize[0])>300)
                        grp.DrawString("thoitrangxuatkhau.net.vn", new Font("arial", (float)16, FontStyle.Regular), Brushes.Silver, rg1, sf);
                    else grp.DrawString("thoitrangxuatkhau.net.vn", new Font("arial", (float)8, FontStyle.Regular), Brushes.Silver, rg2, sf);
//					grp.DrawImage(img, (MAX_WIDTH-sizeWidth)/2, 0, sizeWidth, sizeHeight);
				

					EncoderParameters eps = new EncoderParameters(1);
					EncoderParameter ep = new EncoderParameter(Encoder.Quality,80L);
					eps.Param[0] = ep;
					ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

//					string ext = ici.FilenameExtension.Split(';')[0];
//					ext = System.IO.Path.GetExtension(ext).ToLower();
//					vFileName = System.IO.Path.ChangeExtension(vFileName, ext);

					string fname = Path.Combine(vDir,vFileName);

					
					bmp.Save(fname,ici,eps);
					
					bmp.Dispose();
					grp.Dispose();
					img.Dispose();
					return rs;
		}
		
		public static bool DrawNewImage(string key, string vDirSource, string vDirDestination,string vFileName)
		{
			string vDir = vDirSource;
			//string key format (100x200) <--> (wxh)
			string[] tSize= key.Split('x');
			// find the image that was requested
			string file = Path.Combine(vDir, vFileName);			
			
			System.Drawing.Image img = System.Drawing.Image.FromFile(file);
			
			bool rs = true;


			int thumbWidth = int.Parse(tSize[0]);
			int thumbHeight = int.Parse(tSize[1]);

			System.Drawing.Image bmp = new Bitmap(thumbWidth, thumbHeight);
			if(vDirDestination!="") vDir=vDirDestination;
			
			Graphics grp = Graphics.FromImage(bmp);
					
			grp.SmoothingMode = SmoothingMode.HighQuality;
			grp.CompositingQuality = CompositingQuality.HighQuality;
			grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
			grp.PixelOffsetMode = PixelOffsetMode.HighQuality;

			//			LinearGradientBrush l1 = new LinearGradientBrush(new Rectangle(0, 0, MAX_WIDTH, MAX_HEIGHT), Color.White, Color.White, LinearGradientMode.Vertical);
			//			grp.FillRectangle(l1, 0, 0, 50, 50);

			//			grp.DrawImage(img, 0, 0, 50, 50);
			Rectangle rec = new Rectangle(0, 0, thumbWidth, thumbHeight);
			//grp.DrawImage(img, rec, 200,100,img.Width,img.Height,System.Drawing.GraphicsUnit.Pixel);

			int width = img.Width;
			int height = img.Height;
			int eHeight = (int)((thumbHeight*width)/thumbWidth);
			int eWidth =  (int)((thumbWidth*height)/thumbHeight);
 
			int newHeight =0;
			int newWidth =0;
			//kiem tra xem chieu nao ti le lon hon
			if (height > eHeight)
			{
				newHeight = eHeight;
				newWidth = width;
			}
			else
			{
				newHeight = height;
				newWidth = eWidth;
			}

			//find the cut position
			int y = (height - newHeight)/2;
			int x = (width - newWidth)/2;

			grp.DrawImage(img, rec,x,y,newWidth,newHeight,System.Drawing.GraphicsUnit.Pixel);

			
			//
			//			Rectangle oRectangle = new Rectangle(0, 0, sizeWidth, sizeHeight);
			//			grp.DrawImage(img, oRectangle);
					
			EncoderParameters eps = new EncoderParameters(1);
			eps.Param[0] = new EncoderParameter(Encoder.Quality,80L);
			ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
					
//			string ext = ici.FilenameExtension.Split(';')[0];
//			ext = System.IO.Path.GetExtension(ext).ToLower();
//			vFileName = System.IO.Path.ChangeExtension(vFileName, ext);

			string fname = Path.Combine(vDir,vFileName);
			bmp.Save(fname,ici,eps);
					
			grp.Dispose();
			bmp.Dispose();
			img.Dispose();
			return rs;
		}
        public static void BuildNoImage(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            int w = 800;
            int h = 140;

            string[] mSize = imgSize.Split('x');

            if (mSize.Length == 2)
            {
                w = int.Parse(mSize[0]);
                h = int.Parse(mSize[1]);
            }
            Color FontColor = Color.Black; 
            //fore color
            SolidBrush objBrushForeColor = new SolidBrush(FontColor); 

            Bitmap b = new Bitmap(w, h);
            b.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(b);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.FillRectangle(Brushes.White, 0, 0, b.Width, b.Height);
            g.DrawRectangle(new Pen(Color.White, (float)1), 0, 0, b.Width - 1, b.Height - 1);

            Rectangle rg = new Rectangle(0, b.Height / 2 - 50, b.Width, b.Height);
            Rectangle rg1 = new Rectangle(0, b.Height / 2+38, b.Width+590, b.Height);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(pathfont);
            
            try
            {
                g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Regular), objBrushForeColor, rg, sf);
                g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Regular), Brushes.Silver, rg1, sf);
            }
            catch (System.Exception)
            {
                try
                {
                    g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Italic), objBrushForeColor, rg, sf);
                    g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Regular), Brushes.Silver, rg1, sf);
                }
                catch (System.Exception)
                {
                    try
                    {
                        g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Bold), objBrushForeColor, rg, sf);
                        g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Regular), Brushes.Silver, rg1, sf);
                    }
                    catch (System.Exception)
                    {
                    	
                    }
                    
                }
            }

            string fname = Path.Combine(path, name);
            b.Save(fname, System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            b.Dispose();
        }
        public static bool BuildUploadAdmin(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            int w = 800;
            int h = 140;

            string[] mSize = imgSize.Split('x');

            if (mSize.Length == 2)
            {
                w = int.Parse(mSize[0]);
                h = int.Parse(mSize[1]);
            }
            Bitmap b = new Bitmap(w, h);
            b.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.FillRectangle(Brushes.White, 0, 0, b.Width, b.Height);
            g.DrawRectangle(new Pen(Color.White, (float)1), 0, 0, b.Width - 1, b.Height - 1);

            Rectangle rg = new Rectangle(0, b.Height / 2 - 50, b.Width, b.Height);
            Rectangle rg1 = new Rectangle(0, b.Height / 2 + 38, b.Width + 590, b.Height);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(pathfont);
            bool t = true;
            try
            {
                g.DrawString(fontCollection.Families[0].Name, new Font(fontCollection.Families[0], textsize, FontStyle.Regular), Brushes.Black, rg, sf);
                g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Regular), Brushes.Silver, rg1, sf);
            }
            catch (System.Exception)
            {
                try
                {
                    g.DrawString(fontCollection.Families[0].Name, new Font(fontCollection.Families[0], textsize, FontStyle.Italic), Brushes.Black, rg, sf);
                    g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Italic), Brushes.Silver, rg1, sf);
                }
                catch (System.Exception)
                {
                    try
                    {
                        g.DrawString(fontCollection.Families[0].Name, new Font(fontCollection.Families[0], textsize, FontStyle.Bold), Brushes.Black, rg, sf);
                        g.DrawString("© font.vn", new Font("arial", (float)11, FontStyle.Bold), Brushes.Silver, rg1, sf);
                    }
                    catch (System.Exception)
                    {
                        t = false;
                    }

                }
            }
            if (t)
            {
                string fname = Path.Combine(path, name.Split('.')[0] + ".png");
                b.Save(fname, System.Drawing.Imaging.ImageFormat.Png);
                g.Dispose();
                b.Dispose();
                return true;
            }
            return false;
        }
        public static void BuildNoImageAdmin(string path, string name, string text, string imgSize, string pathfont, int textsize)
        {
            int w = 800;
            int h = 140;

            string[] mSize = imgSize.Split('x');

            if (mSize.Length == 2)
            {
                w = int.Parse(mSize[0]);
                h = int.Parse(mSize[1]);
            }
            Bitmap b = new Bitmap(w, h);
            b.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.FillRectangle(Brushes.White, 0, 0, b.Width, b.Height);
            g.DrawRectangle(new Pen(Color.White, (float)1), 0, 0, b.Width - 1, b.Height - 1);

            Rectangle rg = new Rectangle(0, b.Height / 2 - 20, b.Width, b.Height);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(pathfont);
            try
            {
                g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Regular), Brushes.Black, rg, sf);
            }
            catch (System.Exception)
            {
                try
                {
                    g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Italic), Brushes.Black, rg, sf);
                }
                catch (System.Exception)
                {
                    try
                    {
                        g.DrawString(text, new Font(fontCollection.Families[0], textsize, FontStyle.Bold), Brushes.Black, rg, sf);
                    }
                    catch (System.Exception)
                    {

                    }

                }
            }

            string fname = Path.Combine(path, name);
            b.Save(fname, System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            b.Dispose();
        }
		public static bool GReSize(string key, string vDirSource, string vDirDestination,string vFileName)
		{

			string vDir = vDirSource;
			//string key format (100x200) <--> (wxh)
			string[] tSize= key.Split('x');
			// find the image that was requested
			string file = Path.Combine(vDir, vFileName);			
			
			System.Drawing.Image img = System.Drawing.Image.FromFile(file);
			
			bool rs = true;

			int MAX_WIDTH = int.Parse(tSize[0]), MAX_HEIGHT = int.Parse(tSize[1]);

			float rW = 1, rH = 1;
			//Get Origine Image Size
			int sizeWidth = img.Width, sizeHeight = img.Height;
				
			if (img.Width >= MAX_WIDTH)
				rW = (float)MAX_WIDTH / img.Width;


			if (img.Height >= MAX_HEIGHT)
				rH = (float)MAX_HEIGHT / img.Height;

				
			if (rW != 1 && rW < rH)
			{
				//					sizeWidth = MAX_HEIGHT;
				sizeWidth = MAX_WIDTH;
				sizeHeight = (int)((float)rW * img.Height);
			}
			else
			{
				if (rH != 1 && rH <= rW)
				{
					sizeHeight = MAX_HEIGHT;
					sizeWidth = (int)((float)rH * img.Width);
				}
			}

			System.Drawing.Image bmp = new Bitmap(sizeWidth, sizeHeight);
			if(vDirDestination!="") vDir=vDirDestination;
			
			Graphics grp = Graphics.FromImage(bmp);
					
			grp.SmoothingMode = SmoothingMode.HighQuality;
			grp.CompositingQuality = CompositingQuality.HighQuality;
			grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
			grp.PixelOffsetMode = PixelOffsetMode.HighQuality;

			Rectangle oRectangle = new Rectangle(0, 0, sizeWidth, sizeHeight);
			grp.DrawImage(img, oRectangle);
					
			EncoderParameters eps = new EncoderParameters(1);
			eps.Param[0] = new EncoderParameter(Encoder.Quality,100L);
			ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
					
			string fname = Path.Combine(vDir,vFileName);
			bmp.Save(fname,ici,eps);
					
			bmp.Dispose();
			img.Dispose();
			return rs;
		}

		public static bool DrawNewGifImage(string key, string vDirSource, string vDirDestination,string vFileName)
		{
			string vDir = vDirSource;
			//string key format (100x200) <--> (wxh)
			string[] tSize= key.Split('x');
			// find the image that was requested
			string file = Path.Combine(vDir, vFileName);			
			
			System.Drawing.Image img = System.Drawing.Image.FromFile(file);
			
			bool rs = true;


			int thumbWidth = int.Parse(tSize[0]);
			int thumbHeight = int.Parse(tSize[1]);
            if (thumbWidth / thumbHeight == img.Width / img.Height)
            {
                getThumbs(key, vDirSource, vDirDestination, vFileName);
                return rs;
            }
			System.Drawing.Image bmp = new Bitmap(thumbWidth, thumbHeight);
			if(vDirDestination!="") vDir=vDirDestination;
			
			Graphics grp = Graphics.FromImage(bmp);
					
			grp.SmoothingMode = SmoothingMode.HighQuality;
			grp.CompositingQuality = CompositingQuality.HighQuality;
			grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
			grp.PixelOffsetMode = PixelOffsetMode.HighQuality;

			//			LinearGradientBrush l1 = new LinearGradientBrush(new Rectangle(0, 0, MAX_WIDTH, MAX_HEIGHT), Color.White, Color.White, LinearGradientMode.Vertical);
			//			grp.FillRectangle(l1, 0, 0, 50, 50);

			//			grp.DrawImage(img, 0, 0, 50, 50);
			Rectangle rec = new Rectangle(0, 0, thumbWidth, thumbHeight);
			//grp.DrawImage(img, rec, 200,100,img.Width,img.Height,System.Drawing.GraphicsUnit.Pixel);

			int width = img.Width;
			int height = img.Height;
			int eHeight = (int)((thumbHeight*width)/thumbWidth);
			int eWidth =  (int)((thumbWidth*height)/thumbHeight);
 
			int newHeight =0;
			int newWidth =0;
			//kiem tra xem chieu nao ti le lon hon
			if (height > eHeight)
			{
				newHeight = eHeight;
				newWidth = width;
			}
			else
			{
				newHeight = height;
				newWidth = eWidth;
			}

			//find the cut position
			int y = (height - newHeight)/2;
			int x = (width - newWidth)/2;

			grp.DrawImage(img, rec,x,y,newWidth,newHeight,System.Drawing.GraphicsUnit.Pixel);

			
			//
			//			Rectangle oRectangle = new Rectangle(0, 0, sizeWidth, sizeHeight);
			//			grp.DrawImage(img, oRectangle);
					
			EncoderParameters eps = new EncoderParameters(1);
			eps.Param[0] = new EncoderParameter(Encoder.Quality,80L);
			ImageCodecInfo ici = GetEncoderInfo("image/gif");
					
//			string ext = ici.FilenameExtension.Split(';')[0];
//			ext = System.IO.Path.GetExtension(ext).ToLower();
//			vFileName = System.IO.Path.ChangeExtension(vFileName, ext);

			string fname = Path.Combine(vDir,vFileName);
			bmp.Save(fname,ici,eps);
					

			bmp.Dispose();
			img.Dispose();
			grp.Dispose();
			return rs;
		}
		
		/// <summary>
		/// Required, but not used
		/// </summary>
		/// <returns>true</returns>
		static bool ThumbnailCallback()
		{
			return true;
		}
		public bool IsReusable
		{
			get {return true;}
		}

		static bool Abort()
		{
			return false;
		}
		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for(j = 0; j < encoders.Length; ++j)
			{
				if(encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;
		}

	}
}
