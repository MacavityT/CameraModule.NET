using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows;
using MvCamCtrl.NET;
using AqDevice;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Configuration;

namespace HikVision
{
    class AqHikVisionCamera :AqDevice.IAqCamera
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

        //set window event
        private event AqDevice.AqCaptureDelegate eventCapture;
        //set get image event
        public static List<IAqCamera> allbaslercamera = null;
        public  MyCamera  getonecamera;
        private int nRet = MyCamera.MV_OK;
        public static MyCamera.cbOutputExdelegate ImageCallback;


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
            getonecamera = new MyCamera();
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE, ref stDevList);

            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Can not find device", nRet);
                return 0;
            }

            Console.WriteLine("Enum device count : " + Convert.ToString(stDevList.nDeviceNum));

            if (0 == stDevList.nDeviceNum)
            {
                return 0;
            }

            MyCamera.MV_CC_DEVICE_INFO stDevInfo;                            // 通用设备信息

            // ch:打印设备信息 en:Print device info
            for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
            {
              //赋值结构体的一种方式
                stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                //judge camera is gige
                if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    // ch:显示IP | en:Display IP
                    UInt32 nIp1 = (stGigEDeviceInfo.nCurrentIp & 0xFF000000) >> 24;
                    UInt32 nIp2 = (stGigEDeviceInfo.nCurrentIp & 0x00FF0000) >> 16;
                    UInt32 nIp3 = (stGigEDeviceInfo.nCurrentIp & 0x0000FF00) >> 8;
                    UInt32 nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000FF);
                    string tempCameraIp = nIp1.ToString() + "." + nIp2.ToString() + "." + nIp3.ToString() + "." + nIp4.ToString();

                    if (stGigEDeviceInfo.chUserDefinedName == this.Name || tempCameraIp == this.Ip)
                    {
                        nRet = getonecamera.MV_CC_CreateDevice_NET(ref stDevInfo);
                        if (MyCamera.MV_OK != nRet)
                        {
                            Console.WriteLine("Create device failed:{0:x8}", nRet);
                            return 0;
                        }
                        // ch:打开设备 | en:Open device
                        nRet = getonecamera.MV_CC_OpenDevice_NET();
                        if (MyCamera.MV_OK != nRet)
                        {
                            Console.WriteLine("Open device failed:{0:x8}", nRet);
                            return 0;
                        }
                        // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                        if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                        {
                            int nPacketSize = getonecamera.MV_CC_GetOptimalPacketSize_NET();
                            if (nPacketSize > 0)
                            {
                                nRet = getonecamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                                if (nRet != MyCamera.MV_OK)
                                {
                                    Console.WriteLine("Warning: Set Packet Size failed {0:x8}", nRet);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Warning: Get Packet Size failed {0:x8}", nPacketSize);
                            }
                        }
                      
                     }                                        
                  }
              }

            return 1;
        }

        public int CloseCamera()
        {
            
            CloseStream();
            // ch:关闭设备 | en:Close device
            nRet = getonecamera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Close device failed{0:x8}", nRet);
                return 0;
            }

            // ch:销毁设备 | en:Destroy device
            nRet = getonecamera.MV_CC_DestroyDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Destroy device failed:{0:x8}", nRet);
                return 0;
            }

            return 1;
          }

        public int OpenStream()
        {
            TriggerConfiguration();
            SetExposureTime();                       
            SetImageROI();
            nRet = getonecamera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Register image callback failed!");
                return 0;
            }

            // ch:开启抓图 | en:start grab
            nRet = getonecamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Start grabbing failed:{0:x8}", nRet);
                return 0;
            }
            
            return 1;
        }

        public int CloseStream()
        {
            nRet = getonecamera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Stop grabbing failed{0:x8}", nRet);
                return 0;
            }
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
            if(TriggerMode == TriggerModes.Unknow)
                nRet = getonecamera.MV_CC_SetCommandValue_NET("TriggerSoftware");

            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("please set triggermode = unknow");          
            }
        }

        public void TriggerConfiguration()
        {
             // ch:设置采集连续模式 | en:Set Continues Aquisition Mode
            getonecamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);
            //set param
            // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
            //           1 - Line1;
            //           2 - Line2;
            //           3 - Line3;
            //           4 - Counter;
            //           7 - Software;
            if (TriggerMode == TriggerModes.Continuous)
            {
                nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerMode", 0);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Set TriggerMode failed!");
                   
                }

                nRet = getonecamera.MV_CC_SetTriggerDelay_NET(0);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set GainAuto failed!");
                }
            }
            else if (TriggerMode == TriggerModes.Unknow)
            {
                nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Set TriggerMode failed!");

                }

                nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerSource", 7);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Set TriggerSource failed!");
                    
                }

                nRet = getonecamera.MV_CC_SetTriggerDelay_NET(0);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set GainAuto failed!");
                }

            }
            else if (TriggerMode == TriggerModes.HardWare)
            {
                nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Set TriggerMode failed!");

                }
                //           1 - Line1;
                //           2 - Line2;
                //           3 - Line3;
                if (TriggerSource == AqDevice.TriggerSources.Line1)
                {
                    nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerSource", 1);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Set TriggerSource failed!");

                    }
                }
                else if (TriggerSource == AqDevice.TriggerSources.Line2)
                {
                    nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerSource", 2);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Set TriggerSource failed!");

                    }
                }
                else if (TriggerSource == AqDevice.TriggerSources.Line3)
                {
                    nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerSource", 2);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Set TriggerSource failed!");

                    }
                }

                //rising edge
                nRet = getonecamera.MV_CC_SetEnumValue_NET("TriggerActivation", 1);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("Set TriggerActivation failed!");

                }

                nRet = getonecamera.MV_CC_SetTriggerDelay_NET(0);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set GainAuto failed!");
                }

            }

            // ch:注册回调函数 | en:Register image callback
            ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
        }

        public void TriggerHardWare()
        {

        }

        public void SetImageROI()
        {
            try
            {
                MyCamera.MVCC_INTVALUE pstValue = new MyCamera.MVCC_INTVALUE();
                nRet = getonecamera.MV_CC_GetWidth_NET(ref pstValue);

                if ((uint)ImageWidth > pstValue.nMin && (uint)ImageWidth < pstValue.nMax)
                {
                    nRet = getonecamera.MV_CC_SetWidth_NET((uint)ImageWidth);
                    if (nRet != MyCamera.MV_OK)
                    {
                        Console.WriteLine("Set ImageWidth failed!");
                    }
                }
                else
                {
                    nRet = getonecamera.MV_CC_SetWidth_NET(pstValue.nMax);
                    if (nRet != MyCamera.MV_OK)
                    {
                        Console.WriteLine("Set ImageWidth failed!");
                    }
                }

                nRet = getonecamera.MV_CC_GetHeight_NET(ref pstValue);
                if ((uint)ImageHeight > pstValue.nMin && (uint)ImageHeight < pstValue.nMax)
                {
                    nRet = getonecamera.MV_CC_SetHeight_NET((uint)ImageHeight);
                    if (nRet != MyCamera.MV_OK)
                    {
                        Console.WriteLine("Set ImageWidth failed!");
                    }
                }
                else
                {
                    nRet = getonecamera.MV_CC_SetHeight_NET(pstValue.nMax);
                    if (nRet != MyCamera.MV_OK)
                    {
                        Console.WriteLine("Set ImageWidth failed!");
                    }
                }
              
                nRet = getonecamera.MV_CC_SetAOIoffsetX_NET((uint)ImageoffsetX);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set ImageoffsetX failed!");
                }
                nRet = getonecamera.MV_CC_SetAOIoffsetY_NET((uint)ImageoffsetY);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set ImageoffsetY failed!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Set ImageoffsetY  or ImageoffsetX or ImageHeight or ImageWidth failed!");
            }
            
        }

        public void SetExposureTime()
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

            nRet = getonecamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (nRet == MyCamera.MV_OK)
            {
                // something is wrong,the param can not set
                nRet = getonecamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set ExposureAuto failed!");
                }
            }
            
            nRet = getonecamera.MV_CC_SetEnumValueByString_NET("ExposureMode", "Timed");
            if (nRet != MyCamera.MV_OK)
            {
                Console.WriteLine("Set ExposureMode failed!");
            }
           
            nRet = getonecamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);

            if ((float)ExposureTime > stParam.fMin && (float)ExposureTime < stParam.fMax)
            {
                nRet = getonecamera.MV_CC_SetFloatValue_NET("ExposureTime", (float)ExposureTime);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Set ExposureTime failed!");
                }
            }
           
            nRet = getonecamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
            if (nRet != MyCamera.MV_OK)
            {
                Console.WriteLine("Set GainAuto failed!");
            }

        }

        private Boolean IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }

        /************************************************************************
       *  @fn     IsColorData()
       *  @brief  判断是否是彩色数据
       *  @param  enGvspPixelType         [IN]           像素格式
       *  @return 成功，返回0；错误，返回-1 
       ************************************************************************/
        private Boolean IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
                    return true;

                default:
                    return false;
            }
        }


        private void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            Console.WriteLine("Get one frame: Width[" + Convert.ToString(pFrameInfo.nWidth) + "] , Height[" + Convert.ToString(pFrameInfo.nHeight)
                                + "] , FrameNum[" + Convert.ToString(pFrameInfo.nFrameNum) + "]");


            MyCamera.MvGvspPixelType enDstPixelType;
            if (IsMonoData(pFrameInfo.enPixelType))
            {
                enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
            }
            else if (IsColorData(pFrameInfo.enPixelType))
            {
                enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
            }
            else
            {
                
                return;
            }


            byte[] m_pBufForSaveImage = new byte[3*(pFrameInfo.nWidth * pFrameInfo.nHeight) + 2048];

            IntPtr pImage = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForSaveImage, 0);
            MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
            stConverPixelParam.nWidth = pFrameInfo.nWidth;
            stConverPixelParam.nHeight = pFrameInfo.nHeight;
            stConverPixelParam.pSrcData = pData;
            stConverPixelParam.nSrcDataLen = pFrameInfo.nFrameLen;
            stConverPixelParam.enSrcPixelType = pFrameInfo.enPixelType;
            stConverPixelParam.enDstPixelType = enDstPixelType;
            stConverPixelParam.pDstBuffer = pImage;
            stConverPixelParam.nDstBufferSize = (uint)(3*(pFrameInfo.nWidth * pFrameInfo.nHeight) + 2048);
            nRet = getonecamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
            if (MyCamera.MV_OK != nRet)
            {
                return;
            }

            if (enDstPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
            {
                //************************Mono8 转 Bitmap*******************************
                Bitmap bmp = new Bitmap(pFrameInfo.nWidth, pFrameInfo.nHeight, pFrameInfo.nWidth * 1, PixelFormat.Format8bppIndexed, pImage);

                ColorPalette cp = bmp.Palette;
                // init palette
                for (int i = 0; i < 256; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                // set palette back
                bmp.Palette = cp;

                Bitmap temp = (Bitmap)bmp.Clone();

                CallFunction(this.Name, bmp);

                GC.Collect();
            }
            else
            {
                //*********************RGB8 转 Bitmap**************************
                for (int i = 0; i < pFrameInfo.nHeight; i++)
                {
                    for (int j = 0; j < pFrameInfo.nWidth; j++)
                    {
                        byte chRed = m_pBufForSaveImage[i * pFrameInfo.nWidth * 3 + j * 3];
                        m_pBufForSaveImage[i * pFrameInfo.nWidth * 3 + j * 3] = m_pBufForSaveImage[i * pFrameInfo.nWidth * 3 + j * 3 + 2];
                        m_pBufForSaveImage[i * pFrameInfo.nWidth * 3 + j * 3 + 2] = chRed;
                    }
                }
                try
                {
                    Bitmap bmp = new Bitmap(pFrameInfo.nWidth, pFrameInfo.nHeight, pFrameInfo.nWidth * 3, PixelFormat.Format24bppRgb, pImage);
                    Bitmap temp = (Bitmap)bmp.Clone();

                    CallFunction(this.Name, bmp);

                    GC.Collect();
                }
                catch
                {
                }

            }
           
        }

    }
}
