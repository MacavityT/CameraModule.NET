using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Threading;
using AqDevice;
using System.Windows.Forms;

namespace Camera_Dynamic
{
    public class AqDynamicCamera : AqDevice.IAqCamera
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
        private Int64 imagewidth;
        private Int64 imageheight;
        private Int64 imageoffsetX;
        private Int64 imageoffsetY;

        private AqDevice.TriggerSources triggersource;
        private AqDevice.TriggerSwitchs triggerswitchs;
        private AqDevice.TriggerModes triggermodes;
        private AqDevice.TriggerEdges triggeredges;

        private event AqDevice.AqCaptureDelegate eventCapture;
        Thread showimagethread;
        private bool flag = false;
        private bool stopthread = false;

        private List<string> frameimagepath;
        private int allframecount;
        static private int numcount;
        public List<Image> frameimage;

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

        public double Gain
        {
            get { return gain; }
            set { gain = value; }
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

        public AqDevice.TriggerSwitchs TriggerSwitch
        {
            get { return triggerswitchs; }
            set { triggerswitchs = value; }
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

        public int OpenCamera()
        {
            frameimagepath = new List<string>();           
            frameimage = new List<Image>();
            string currentpath = System.Environment.CurrentDirectory + "\\1";

            foreach (string Path in Directory.GetFiles(currentpath))
            {
                frameimagepath.Add(Path);  
            }

            if (frameimagepath.Count != 0)
            {
                allframecount = frameimagepath.Count; 
            }

            int index;
            for (index = 0; index < frameimagepath.Count; index++)
            {
                frameimage.Add(Bitmap.FromFile(frameimagepath[index]));
            }

            showimagethread = new Thread(new ThreadStart(GetFrameImage));
            showimagethread.Start();

            return 1;
        }

        public int CloseCamera()
        {
            stopthread = true;
            showimagethread.Abort();
            Thread.Sleep(10);
            return 1;
        }

        public int OpenStream()
        {
            if (allframecount != 0)
                return 1;
            
            return 0;   
        }

        public int CloseStream()
        {
            return 1;
        }

        public void RegisterCaptureCallback(AqCaptureDelegate delCaptureFun)
        {
            eventCapture += delCaptureFun;
        }

        public void CallFunction(object obj, Bitmap bmp)
        {
            eventCapture(obj, bmp);
        }

        public void TriggerSoftware()
        {
            TriggerMode = AqDevice.TriggerModes.Unknow;
            flag = true;
           
        }

        public void TriggerHardWare()
        {
            TriggerMode = AqDevice.TriggerModes.Continuous;
        }

        public void GetFrameImage()
        {
            numcount = 0;
            while (true)
            {
                if (!stopthread)
                {
                     if (TriggerMode == AqDevice.TriggerModes.Continuous && flag == false)
                    {                
                        if (allframecount <= numcount)
                            numcount = 0;
                        Bitmap test =(Bitmap) frameimage[numcount].Clone();
                        CallFunction(null, test);
                        numcount++;
                        Thread.Sleep(50);
                    }
                    else if (TriggerMode == AqDevice.TriggerModes.Unknow && flag == true)
                    {
                        if (allframecount <= numcount)
                            numcount = 0;
                        //Bitmap indeximage = new Bitmap(frameimage[numcount]);
                        CallFunction(null, (Bitmap)frameimage[numcount]);
                        numcount++;
                        flag = false;
                        Thread.Sleep(10);
                    }          
                }
                Thread.Sleep(10);
            }  
        }
    }
}
