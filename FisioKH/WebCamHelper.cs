using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Video;
using Accord.Video.DirectShow;

namespace FisioKH
{
    public class WebCamHelper
    {
        public VideoCaptureDevice videoSource;
        public FilterInfoCollection videoDevices;
        public Bitmap currentFrame;
        public float zoomFactor = 1.0f;
        public const float zoomStep = 0.1f;
        public Bitmap zoomedFrame;

        // Assign this to a PictureBox on your form
        public PictureBox TargetPictureBox { get; set; }

        public WebCamHelper(PictureBox targetPictureBox)
        {
            TargetPictureBox = targetPictureBox;
        }

        public byte[] ImageToByteArray(PictureBox picBox)
        {
            if (picBox.Image == null)
                return null;

            using (var bmp = new Bitmap(picBox.Image))
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public Bitmap ApplyZoom(Bitmap original, float zoom)
        {
            if (zoom == 1.0f) return (Bitmap)original.Clone();

            int newWidth = (int)(original.Width / zoom);
            int newHeight = (int)(original.Height / zoom);

            int x = (original.Width - newWidth) / 2;
            int y = (original.Height - newHeight) / 2;

            Rectangle cropRect = new Rectangle(x, y, newWidth, newHeight);
            Bitmap cropped = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(original, new Rectangle(0, 0, newWidth, newHeight), cropRect, GraphicsUnit.Pixel);
            }

            Bitmap resized = new Bitmap(cropped, original.Size);
            cropped.Dispose();
            return resized;
        }

        public void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No webcam detected!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

            videoSource.VideoResolution = videoSource.VideoCapabilities
                .FirstOrDefault(vc => vc.FrameSize.Width == 640 && vc.FrameSize.Height == 480)
                ?? videoSource.VideoCapabilities[0];

            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }

        public void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.NewFrame -= VideoSource_NewFrame;
            }
        }

        public void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                currentFrame?.Dispose();
                currentFrame = (Bitmap)eventArgs.Frame.Clone();

                // Apply zoom
                zoomedFrame = ApplyZoom(currentFrame, zoomFactor);

                // Safely assign to PictureBox on UI thread
                if (TargetPictureBox != null && !TargetPictureBox.IsDisposed && TargetPictureBox.IsHandleCreated)
                {
                    TargetPictureBox.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            TargetPictureBox.Image?.Dispose();
                            TargetPictureBox.Image = (Bitmap)zoomedFrame.Clone();
                        }
                        catch { /* Ignore errors if PictureBox is gone */ }
                    }));
                }
            }
            catch
            {
                // Ignore errors during form closing or if frame cloning fails
            }
        }


        public void ZoomIn()
        {
            zoomFactor += zoomStep;
        }

        public void ZoomOut()
        {
            zoomFactor = Math.Max(zoomStep, zoomFactor - zoomStep);
        }
    }
}
