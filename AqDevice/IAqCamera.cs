using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AqDevice
{
    public interface IAqCamera
    {
        

        int OpenCamera();
        int CloseCamera();
 
        int OpenStream();
        int CloseStream();

        string Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string Ip
        {
            get;
            set;
        }

        string Mac
        {
            get;
            set;
        }

        TriggerSources TriggerSource
        {
            get;
            set;
        }

        AqDevice.TriggerSwitchs TriggerSwitch
        {
            get;
            set;
        }

        AqDevice.TriggerModes TriggerMode
        {
            get;
            set;
        }

        AqDevice.TriggerEdges TriggerEdge
        {
            get;
            set;
        }

        double ExposureTime
        {
            get;
            set;
        }

        double AcquisitionFrequency
        {
            get;
            set;
        }

        double TriggerDelay
        {
            get;
            set;
        }

        double Gain
        {
            get;
            set;
        }

        bool GainAuto
        {
            get;
            set;
        }

        //set image ROI
        Int64 ImageWidth
        {
            get;
            set;
        }
        Int64 ImageHeight
        {
            get;
            set;
        }
        Int64 ImageoffsetX
        {
            get;
            set;
        }
        Int64 ImageoffsetY
        {
            get;
            set;
        }

        void RegisterCaptureCallback(AqCaptureDelegate delCaptureFun);

        void TriggerSoftware();

    }
}
