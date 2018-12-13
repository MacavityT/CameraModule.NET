using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using AqDevice;

namespace CameraModule
{
    [Serializable]
    public class CameraParameters
    {
        bool _acquisitionParamChanged = false;

        List<string> _cameraName = new List<string>();       
        Dictionary<string, string> _cameraId = new Dictionary<string, string>();
        Dictionary<string, string> _cameraIp = new Dictionary<string, string>();
        Dictionary<string, string> _cameraMac = new Dictionary<string, string>();
        Dictionary<string, AqDevice.TriggerSources> _cameraTriggerSource = new Dictionary<string, AqDevice.TriggerSources>();
        Dictionary<string, AqDevice.TriggerSwitchs> _cameraTriggerSwitch = new Dictionary<string, AqDevice.TriggerSwitchs>();
        Dictionary<string, AqDevice.TriggerModes> _cameraTriggerMode = new Dictionary<string, AqDevice.TriggerModes>();
        Dictionary<string, AqDevice.TriggerEdges> _cameraTriggerEdge = new Dictionary<string, AqDevice.TriggerEdges>();
        Dictionary<string, double> _cameraExposureTime = new Dictionary<string, double>();
        Dictionary<string, double> _cameraAcquisitionFrequency = new Dictionary<string, double>();
        Dictionary<string, double> _cameraTriggerDelay = new Dictionary<string, double>();
        Dictionary<string, double> _cameraGain = new Dictionary<string, double>();
        Dictionary<string, bool> _cameraGainAuto = new Dictionary<string, bool>();
        Dictionary<string, Int64> _cameraImageWidth = new Dictionary<string, Int64>();
        Dictionary<string, Int64> _cameraImageHeight = new Dictionary<string, Int64>();
        Dictionary<string, Int64> _cameraImageOffsetX = new Dictionary<string, Int64>();
        Dictionary<string, Int64> _cameraImageOffsetY = new Dictionary<string, Int64>();

        public bool AcquisitionParamChanged
        {
            get { return _acquisitionParamChanged; }
            set { _acquisitionParamChanged = value; }
        }

        /// <summary>
        /// 相机参数：对应SDK开发接口
        /// </summary>
        ///         
        public List<string> CameraName
        {
            get { return _cameraName; }
            set { _cameraName = value; }
        }

        public Dictionary<string, string> CameraId
        {
            get { return _cameraId; }
            set { _cameraId = value; }
        }

        public Dictionary<string, string> CameraIp
        {
            get { return _cameraIp; }
            set { _cameraIp = value; }
        }

        public Dictionary<string, string> CameraMac
        {
            get { return _cameraMac; }
            set { _cameraMac = value; }
        }

        public Dictionary<string, AqDevice.TriggerSources> CameraTriggerSource
        {
            get { return _cameraTriggerSource; }
            set { _cameraTriggerSource = value; }
        }

        public Dictionary<string, AqDevice.TriggerSwitchs> CameraTriggerSwitch
        {
            get { return _cameraTriggerSwitch; }
            set { _cameraTriggerSwitch = value; }
        }

        public Dictionary<string, AqDevice.TriggerModes> CameraTriggerMode
        {
            get { return _cameraTriggerMode; }
            set { _cameraTriggerMode = value; }
        }

        public Dictionary<string, AqDevice.TriggerEdges> CameraTriggerEdge
        {
            get { return _cameraTriggerEdge; }
            set { _cameraTriggerEdge = value; }
        }

        public Dictionary<string, double> CameraExposureTime
        {
            get { return _cameraExposureTime; }
            set { _cameraExposureTime = value; }
        }

        public Dictionary<string, double> CameraAcquisitionFrequency
        {
            get { return _cameraAcquisitionFrequency; }
            set { _cameraAcquisitionFrequency = value; }
        }

        public Dictionary<string, double> CameraTriggerDelay
        {
            get { return _cameraTriggerDelay; }
            set { _cameraTriggerDelay = value; }
        }

        public Dictionary<string, double> CameraGain
        {
            get { return _cameraGain; }
            set { _cameraGain = value; }
        }

        public Dictionary<string, bool> CameraGainAuto
        {
            get { return _cameraGainAuto; }
            set { _cameraGainAuto = value; }
        }

        public Dictionary<string, Int64> CameraImageWidth
        {
            get { return _cameraImageWidth; }
            set { _cameraImageWidth = value; }
        }

        public Dictionary<string, Int64> CameraImageHeight
        {
            get { return _cameraImageHeight; }
            set { _cameraImageHeight = value; }
        }

        public Dictionary<string, Int64> CameraImageOffsetX
        {
            get { return _cameraImageOffsetX; }
            set { _cameraImageOffsetX = value; }
        }

        public Dictionary<string, Int64> CameraImageOffsetY
        {
            get { return _cameraImageOffsetY; }
            set { _cameraImageOffsetY = value; }
        }

        /// <summary>
        /// 串行化，用于数据保存
        /// </summary>
        public void SerializeAndSave(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fileStream, this);
            fileStream.Close();
        }

        public CameraParameters DeSerializeAndRead(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter binary = new BinaryFormatter();
            CameraParameters param = binary.Deserialize(fileStream) as CameraParameters;
            fileStream.Close();
            return param;
        }
    }

    public class ImageSource
    {
        Dictionary<string, AqCameraBrand> _cameraBrand = new Dictionary<string, AqCameraBrand>();
        Dictionary<string, string> _cameraInputFile = new Dictionary<string, string>();
        Dictionary<string, string> _cameraInputFolder = new Dictionary<string, string>();
        Dictionary<string, List<string>> _folderFiles = new Dictionary<string, List<string>>();
        Dictionary<string, UInt32> _folderIndex = new Dictionary<string, uint>();
        Dictionary<string, AcquisitionMode> _cameraAcqusitionMode = new Dictionary<string, AcquisitionMode>();

        public Dictionary<string, AqCameraBrand> CameraBrand
        {
            get { return _cameraBrand; }
            set { _cameraBrand = value; }
        }

        public Dictionary<string, string> CameraInputFile
        {
            get { return _cameraInputFile; }
            set { _cameraInputFile = value; }
        }

        public Dictionary<string, string> CameraInputFolder
        {
            get { return _cameraInputFolder; }
            set { _cameraInputFolder = value; }
        }

        public Dictionary<string, List<string>> FolderFiles
        {
            get { return _folderFiles; }
            set { _folderFiles = value; }
        }

        public Dictionary<string, UInt32> FolderIndex
        {
            get { return _folderIndex; }
            set { _folderIndex = value; }
        }

        public Dictionary<string, AcquisitionMode> CameraAcqusitionMode
        {
            get { return _cameraAcqusitionMode; }
            set { _cameraAcqusitionMode = value; }
        }

        /// <summary>
        /// 方法：逐一添加文件到文件夹字段
        /// </summary>
        public void UpdateFilesUnderFolder()
        {
            FolderFiles.Clear();
            FolderIndex.Clear();

            foreach (string folder in CameraInputFolder.Values)
            {
                if (folder != "")
                {
                    if (Directory.Exists(folder))
                    {
                        if (Directory.GetFiles(folder).Length != 0)
                        {
                            FolderFiles.Add(folder, new List<string>(Directory.GetFiles(folder)));
                            FolderIndex.Add(folder, 0);
                        }
                    }
                }
            }

        }
    }
}
