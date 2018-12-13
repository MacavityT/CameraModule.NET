using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    instance = new HikVision.HikVisionCameraManager();
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
