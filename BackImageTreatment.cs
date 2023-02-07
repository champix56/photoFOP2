namespace photoFOP2
{

    public class BackImageTreatment
    {
        public readonly string BackFileAlpha = System.IO.Directory.GetCurrentDirectory() + "\\TEMP\\alphaBack.png";
        public readonly string BackFileNoAlpha = System.IO.Directory.GetCurrentDirectory() + "\\TEMP\\NoalphaBack.png";
        private string imgPath;
        private string outputPath;
        private int w;
        private int h;
        private Config config;
        private decimal outputRatio;

        public BackImageTreatment(string imgPath, string outputPath, int w, int h, ref Config config)
        {
            this.imgPath = imgPath;
            this.outputPath = outputPath;
            this.w = w;
            this.h = h;
            this.config = config;
            this.outputRatio = w / h;
        }
        public void createRatioImage()
        {

            Image img = Bitmap.FromFile(imgPath);
            int szW = 0, szH = 0;
            if (config.defaultUnit == "mm")
            {
                szW = (int)(w / 25.4 * config.backDPI);
                szH = (int)(h / 25.4 * config.backDPI);
            }
            else if (config.defaultUnit == "cm")
            {
                szW = (int)(w / 2.54 * config.backDPI);
                szH = (int)(h / 2.54 * config.backDPI);

            }
            else if (config.defaultUnit == "in")
            {
                szW = (int)(w * config.backDPI);
                szH = (int)(h * config.backDPI);
            }
            Point positionBack = new Point(0, 0);
            Image rimg = img;
            if (rimg.Width < szW)
            {

                rimg = new Bitmap(rimg, new Size(szW, szW / rimg.Width * img.Height));

            }
            if (rimg.Height < szH)
            {
                rimg = new Bitmap(rimg, new Size(szH / rimg.Height * rimg.Width, szH));

            }
            img.Dispose();
            try
            {
                Image ratioOutput = new Bitmap(szW, szH);



                Graphics graphics = Graphics.FromImage(ratioOutput);

                //graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, 0, 55)), 0, 500, (int)szW - 20, (int)szH - 20);
                graphics.DrawImage(rimg, new Point(0, 0));

                graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, 255, 255, 255)), 0, 0, szW, szH);
                
                ratioOutput.Save(BackFileAlpha);
                config.backImageAlpha = new ImageXML(BackFileAlpha.Substring(0, BackFileAlpha.LastIndexOf('\\') + 1), BackFileAlpha.Substring(BackFileAlpha.LastIndexOf('\\') + 1), "");
                ratioOutput.Dispose();

                rimg.Save(BackFileNoAlpha);
                rimg.Dispose();
                config.backImageNoAlpha = new ImageXML(BackFileNoAlpha.Substring(0, BackFileNoAlpha.LastIndexOf('\\') + 1), BackFileNoAlpha.Substring(BackFileNoAlpha.LastIndexOf('\\') + 1), "");

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


        }
        public void createOpacityImage() { }
    }
}
