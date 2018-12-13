using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GxIAPINET;
using AqDevice;

namespace DaHengCamera
{
    class DaHengCameraManager :AqDevice.IAqCameraManager
    {
        IGXFactory m_objIGXFactory = null;
        List<AqDevice.IAqCamera> cameras = new List<AqDevice.IAqCamera>();

        public bool Init()
        {
            m_objIGXFactory = IGXFactory.GetInstance();
            m_objIGXFactory.Init();

            List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
            m_objIGXFactory.UpdateDeviceList(200, listGXDeviceInfo);

            for (int i = 0; i < listGXDeviceInfo.Count; i++)
            {
                AqDevice.IAqCamera camera = new AqDaHengCamera();
                camera.Id = listGXDeviceInfo[i].GetDeviceID();
                camera.Name = listGXDeviceInfo[i].GetUserID();
                camera.Ip = listGXDeviceInfo[i].GetIP();
                camera.Mac = listGXDeviceInfo[i].GetMAC();
                cameras.Add(camera);
            }

            AqDaHengCamera.ObjIGXFactory = m_objIGXFactory;
            return true;
        }

        public void Uninit()
        {
            m_objIGXFactory.Uninit();
        }

        public List<AqDevice.IAqCamera> GetCameras()
        {
            return cameras;
        }
    }
}
