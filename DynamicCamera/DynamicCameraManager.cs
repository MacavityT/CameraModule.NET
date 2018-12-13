using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AqDevice;

namespace Camera_Dynamic
{
    class DynamicCameraManager :AqDevice.IAqCameraManager
    {
        List<AqDevice.IAqCamera> cameras = new List<AqDevice.IAqCamera>();

        public bool Init()
        {
            AqDevice.IAqCamera camera = new AqDynamicCamera();
            cameras.Add(camera);
            return true;
        }

        public void Uninit()
        {
            
        }

        public List<AqDevice.IAqCamera> GetCameras()
        {
            return cameras;
        }

    }
}
