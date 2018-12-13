using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows;
using AqDevice;
using Basler.Pylon;


namespace BalserCamera
{
    public class  AqBaslerCamera : AqDevice.IAqCamera
    {
        private string id;
        private string name;
        private string ip;
        private string mac;
        private double exposuretime;
        private double acquisitionfrequency;
        private double triggerdelay;
        private double gain;
        private bool gainauto;

        //set image ROI
        private Int64 imagewidth ;
        private Int64 imageheight;
        private Int64 imageoffsetX;
        private Int64 imageoffsetY;

       
        private AqDevice.TriggerSources triggersource;
        private AqDevice.TriggerSwitchs triggerswitchs;
        private AqDevice.TriggerModes triggermodes;
        private AqDevice.TriggerEdges triggeredges;

        //set window event
        private event AqDevice.AqCaptureDelegate eventCapture;
        //set get image event
        public static List<IAqCamera> allbaslercamera = null;
        public Camera getonecamera;
        private Stopwatch stopWatch = new Stopwatch();
        private PixelDataConverter converter = new PixelDataConverter();
     //   private Bitmap bitmap;

        public static List<IAqCamera> AllBalserCamera
        {
            get { return allbaslercamera; }
            set { allbaslercamera = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public string Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        public double ExposureTime
        {
            get { return exposuretime; }
            set { exposuretime = value; }
        }

        public double Gain
        {
            get { return gain; }
            set { gain = value; }
        }

        public double AcquisitionFrequency
        {
            get { return acquisitionfrequency; }
            set { acquisitionfrequency = value; }
        }

        public double TriggerDelay
        {
            get { return triggerdelay; }
            set { triggerdelay = value; }
        }

        public bool GainAuto
        {
            get { return gainauto; }
            set { gainauto = value; }
        }

        //set param ROI
        public Int64 ImageWidth
        {
            get { return imagewidth; }
            set { imagewidth = value; }
        }

        public Int64 ImageHeight
        {
            get { return imageheight; }
            set { imageheight = value; }
        }

        public Int64 ImageoffsetX
        {
            get { return imageoffsetX; }
            set { imageoffsetX = value; }
        }

        public Int64 ImageoffsetY
        {
            get { return imageoffsetY; }
            set { imageoffsetY = value; }
        }
        //set param ROI

        public AqDevice.TriggerSources TriggerSource
        {
            get { return triggersource; }
            set { triggersource = value; }
        }

        public AqDevice.TriggerModes TriggerMode
        {
            get { return triggermodes; }
            set { triggermodes = value; }
        }

        public AqDevice.TriggerEdges TriggerEdge
        {
            get { return triggeredges; }
            set { triggeredges = value; }
        }

        public AqDevice.TriggerSwitchs TriggerSwitch
        {
            get { return triggerswitchs; }
            set { triggerswitchs = value; }
        }
     
        public int OpenCamera()
        {
            List<ICameraInfo> allCameras = CameraFinder.Enumerate();
            foreach (ICameraInfo tempinfo in allCameras)
            {
                if (tempinfo[CameraInfoKey.UserDefinedName] == name)
                {
                    getonecamera = new Camera(tempinfo);
                    if (getonecamera.IsOpen)
                        return 0;

                    TriggerConfiguration();
                    getonecamera.Open();
                    SetExposureTime();
                    SetImageROI();
                }
            }
            return 1;
        }

        public int CloseCamera()
        {
            if (getonecamera !=null)
            {
                getonecamera.Close();
                getonecamera.Dispose();
                getonecamera = null;
                return 1;
            }        
            return 0;
        }

        public int OpenStream()
        {
            if (getonecamera.IsOpen)
            {
                if (triggermodes == TriggerModes.Continuous)
                {
                    getonecamera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                    getonecamera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                    return 1;
                }
                else if (triggermodes == TriggerModes.Unknow)
                {
                    getonecamera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                    getonecamera.Parameters[PLCamera.TriggerSelector].SetValue(PLCamera.TriggerSelector.FrameStart);
                    getonecamera.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.On);
                    getonecamera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Software);
                    getonecamera.Parameters[PLCamera.TriggerActivation].SetValue(PLCamera.TriggerActivation.RisingEdge);
                    getonecamera.Parameters[PLCamera.TriggerDelayAbs].SetValue(0);
                    getonecamera.Parameters[PLCamera.ExposureMode].SetValue(PLCamera.ExposureMode.Timed);
                    getonecamera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);
                    getonecamera.Parameters[PLCamera.AcquisitionStatusSelector].SetValue(PLCamera.AcquisitionStatusSelector.FrameTriggerWait);
                    getonecamera.Parameters[PLCamera.AcquisitionFrameCount].SetValue(2);
                    getonecamera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);

                }
                else if (triggermodes == TriggerModes.HardWare)
                {
                    getonecamera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                    getonecamera.Parameters[PLCamera.TriggerSelector].SetValue(PLCamera.TriggerSelector.FrameStart);
                    getonecamera.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.On);

                    if (triggersource == AqDevice.TriggerSources.Line1)
                    {
                        getonecamera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line1);
                    }
                    else if (triggersource == AqDevice.TriggerSources.Line2)
                    {
                        getonecamera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line2);
                    }
                    else if (triggersource == AqDevice.TriggerSources.Line3)
                    {
                        getonecamera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line3);
                    }
                    else if (triggersource == AqDevice.TriggerSources.Line4)
                    {
                        getonecamera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line4);
                    }
                    
                    getonecamera.Parameters[PLCamera.TriggerActivation].SetValue(PLCamera.TriggerActivation.RisingEdge);
                    getonecamera.Parameters[PLCamera.TriggerDelayAbs].SetValue(0);
                    getonecamera.Parameters[PLCamera.ExposureMode].SetValue(PLCamera.ExposureMode.Timed);
                    getonecamera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);
                    getonecamera.Parameters[PLCamera.AcquisitionStatusSelector].SetValue(PLCamera.AcquisitionStatusSelector.FrameTriggerWait);
                    getonecamera.Parameters[PLCamera.AcquisitionFrameCount].SetValue(2);
                    getonecamera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                }
                return 1;
            }

            return 0;
        }

        public int CloseStream()
        {
            if (getonecamera.StreamGrabber.IsGrabbing)
            {
                getonecamera.StreamGrabber.Stop();
                return 1;
            }
            return 0;
        }

        public void RegisterCaptureCallback(AqCaptureDelegate delCaptureFun)
        {
            eventCapture += delCaptureFun;
        }

        public void CallFunction(object obj, Bitmap bmp)
        {
            eventCapture(obj,bmp);
        }

        public void TriggerSoftware()
        {

            bool isWaitingFrameStart = getonecamera.Parameters[PLCamera.AcquisitionStatus].GetValue();
            if (isWaitingFrameStart)
            {
                getonecamera.Parameters[PLCamera.TriggerSoftware].Execute();
            }
            else 
            {
                bool xxx = false;
            }
               
         //   GetSoftWareFrame();
        }

        private void TriggerConfiguration()
        {
            if (triggermodes == TriggerModes.Continuous)
            {
                getonecamera.CameraOpened += Configuration.AcquireContinuous;
            }
            else if (triggermodes == TriggerModes.Unknow)
            {

            }
        }

        public void TriggerHardWare()
        {
            
        }

        public void SetImageROI()
        {
            Int64 maxWidth = getonecamera.Parameters[PLCamera.Width].GetMaximum();
            Int64 minWidth = getonecamera.Parameters[PLCamera.Width].GetMinimum();
            if (maxWidth >= ImageWidth && ImageWidth >= minWidth)
            {
                getonecamera.Parameters[PLCamera.Width].SetValue(ImageWidth);
            }

            Int64 maxHeight = getonecamera.Parameters[PLCamera.Height].GetMaximum();
            Int64 minHeight = getonecamera.Parameters[PLCamera.Height].GetMinimum();
            if (maxHeight >= ImageHeight && ImageHeight >= minHeight)
            {
                getonecamera.Parameters[PLCamera.Height].SetValue(ImageHeight);
            }

            Int64 maxoffsetX = getonecamera.Parameters[PLCamera.OffsetX].GetMaximum();
            Int64 minoffsetX = getonecamera.Parameters[PLCamera.OffsetX].GetMinimum();
            if (maxoffsetX >= ImageoffsetX && ImageoffsetX >= minoffsetX)
            {
                getonecamera.Parameters[PLCamera.OffsetX].SetValue(ImageoffsetX);
            }

            Int64 maxoffsetY = getonecamera.Parameters[PLCamera.OffsetY].GetMaximum();
            Int64 minoffsetY = getonecamera.Parameters[PLCamera.OffsetY].GetMinimum();
            if (maxoffsetY >= ImageoffsetY && ImageoffsetY >= minoffsetY)
            {
                getonecamera.Parameters[PLCamera.OffsetY].SetValue(ImageoffsetY);
            }      
        }

        public void SetExposureTime()
        {
            if (getonecamera.Parameters.Contains(PLCamera.ExposureTimeAbs))
            {
               double exposuremintime =  getonecamera.Parameters[PLCamera.ExposureTimeAbs].GetMinimum();
               double exposuremaxtime =  getonecamera.Parameters[PLCamera.ExposureTimeAbs].GetMaximum();
               if ((exposuretime > exposuremintime) && (exposuretime < exposuremaxtime))
               {
                   try
                   {
                       getonecamera.Parameters[PLCamera.ExposureTimeAbs].SetValue(exposuretime);
                   }
                   catch (Exception)
                   {
 
                   }
               }
                  
            }
            else
            {
                double exposuremintime = getonecamera.Parameters[PLCamera.ExposureTime].GetMinimum();
                double exposuremaxtime = getonecamera.Parameters[PLCamera.ExposureTime].GetMaximum();
                if ((exposuretime > exposuremintime) && (exposuretime < exposuremaxtime))
                    getonecamera.Parameters[PLCamera.ExposureTime].SetValue(exposuretime);
            }
        }

        public void GetSoftWareFrame()
        {
            using (new TimeTicker("AAA 显示消耗的时间"))
            {
                getonecamera.StreamGrabber.Start(1);
                while (getonecamera.StreamGrabber.IsGrabbing)
                {
                   using (new TimeTicker("AAA 等待时间"))
                    {

                        if (getonecamera.WaitForFrameTriggerReady(5, TimeoutHandling.ThrowException))
                        {
                            getonecamera.ExecuteSoftwareTrigger();
                        }
                    }

                    using (new TimeTicker("AAA 时间"))
                    {
                        // Wait for an image and then retrieve it. A timeout of 5000 ms is used. 
                        IGrabResult grabResult = null;
                        using (new TimeTicker("AAA RetrieveResult"))
                        {
                           // grabResult = getonecamera.StreamGrabber.GrabOne(1000);
                            grabResult = getonecamera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
                        }

                        using (grabResult)
                        {
                            // Image grabbed successfully? 
                            if (grabResult.GrabSucceeded)
                            {
                                Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                                // Lock the bits of the bitmap.
                                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                                // Place the pointer to the buffer of the bitmap.
                                converter.OutputPixelFormat = PixelType.BGRA8packed;
                                IntPtr ptrBmp = bmpData.Scan0;
                                converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult); //Exception handling TODO
                                bitmap.UnlockBits(bmpData);
                                Bitmap temp = (Bitmap)bitmap.Clone();
                                CallFunction(null, temp);
                                if (bitmap != null)
                                    bitmap.Dispose();

                                GC.Collect();
                            }
                            else
                            {
                                Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
                            }
                        }
 
                    }

                }
            }
        }
   
        public void OnImageGrabbed(object sender,ImageGrabbedEventArgs e)
        {
            using (new TimeTicker("AAAA 显示消耗的时间"))
            {
                try 
                {
                    // Get the grab result.
                    IGrabResult grabResult = e.GrabResult;
                    // Check if the image can be displayed.
                    if (grabResult.IsValid)
                    {

                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        // Lock the bits of the bitmap.
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        // Place the pointer to the buffer of the bitmap.
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);              
                        bitmap.UnlockBits(bmpData);
                        Bitmap temp = (Bitmap)bitmap.Clone();
                        CallFunction(this.Name, temp);
                        
                            //Thread.Sleep(15);
                        if (bitmap != null)
                            bitmap.Dispose();

                       GC.Collect();
                    }
                }
                catch (Exception exception)
                {
               
                }
            }
                
        }

        private static T DeepCopyByBin<T>(T obj)
        {
            object retval;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = 
                       new  System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
         }

        public Bitmap CopyBitmap(Bitmap source)
        {
            int depth = Bitmap.GetPixelFormatSize(source.PixelFormat);
            if (depth != 8 && depth != 24 && depth != 32)
            {
                return null;
            }
            Bitmap destination = new Bitmap(source.Width, source.Height, source.PixelFormat);
            BitmapData source_bitmapdata = null;
            BitmapData destination_bitmapdata = null;
            try
            {
                source_bitmapdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite,
                                                source.PixelFormat);
                destination_bitmapdata = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.ReadWrite,
                                                destination.PixelFormat);
                unsafe
                {
                    byte* source_ptr = (byte*)source_bitmapdata.Scan0;
                    byte* destination_ptr = (byte*)destination_bitmapdata.Scan0;

                    
                    for (int i = 0; i < (source.Width * source.Height * (depth / 8)); i++)
                    {
                        *destination_ptr = *source_ptr;
                        source_ptr++;
                        destination_ptr++;
                    }
                }
                source.UnlockBits(source_bitmapdata);
                destination.UnlockBits(destination_bitmapdata);
                return destination;
            }
            catch
            {
                destination.Dispose();
                return null;
            }
        }

    }//end class 


}
