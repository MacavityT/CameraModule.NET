using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqDevice
{
    public class AqCameraFactory
    {
        static IAqCameraManager instance = null;
        static public AqDevice.IAqCameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BalserCamera.BalserCameraManager();
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
