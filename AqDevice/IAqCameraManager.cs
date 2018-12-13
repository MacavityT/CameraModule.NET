using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqDevice
{
    public interface IAqCameraManager
    {
        bool Init();
        void Uninit();
        List<AqDevice.IAqCamera> GetCameras();
    }
}
