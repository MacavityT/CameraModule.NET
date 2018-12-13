using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AqDevice;
using Camera_Dynamic;

namespace AqDevice
{
    class AqCameraFactory 
    {
        static IAqCameraManager instance = null;
        static public AqDevice.IAqCameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera_Dynamic.DynamicCameraManager();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        static public IAqCameraManager GetInstance()
        {
            return Instance;
        }

    }
}
