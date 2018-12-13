using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AqDevice;
using MvCamCtrl.NET;
using System.Runtime.InteropServices;

namespace HikVision
{
    class HikVisionCameraManager : AqDevice.IAqCameraManager
    {
        List<AqDevice.IAqCamera> cameras = new List<AqDevice.IAqCamera>();

        public bool Init()
        {
            int nRet = MyCamera.MV_OK;
            MyCamera device = new MyCamera();
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE, ref stDevList);

            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Can not find device", nRet);
                return false;
            }

            Console.WriteLine("Enum device count : " + Convert.ToString(stDevList.nDeviceNum));

            if (0 == stDevList.nDeviceNum)
            {
                return false;
            }

            MyCamera.MV_CC_DEVICE_INFO stDevInfo;                            // 通用设备信息

            // ch:打印设备信息 en:Print device info
            for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
            {

                AqHikVisionCamera camera = new AqHikVisionCamera();

                stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                    uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                    uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                    uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);

                    string ip = nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4;

                    camera.Name = stGigEDeviceInfo.chUserDefinedName;
                    camera.Ip = ip;
                    camera.Id = stGigEDeviceInfo.chSerialNumber;
                    cameras.Add(camera);
                }               
            }

            if (cameras.Count == 0)
                return false;

            AqHikVisionCamera.AllBalserCamera = cameras;
            return true;
          } //end function

            
        public void Uninit()
        {
            
        }

        public List<AqDevice.IAqCamera> GetCameras()
        {
            return cameras;
        }
      
      
    }
}// namespace
