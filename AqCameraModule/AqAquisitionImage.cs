using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Threading;
using AqCameraModule;
using AqDevice;


namespace AqCameraModule
{
    public delegate void DelegateOnError(int id);
    public delegate void DelegateOnBitmap(string strBmpBase64);

    public class AqAcquisitionImage
    {
        bool _isOpened = false;
        bool _isContinue = false;
        bool _isCaptured = false;
        AqCameraParameters _cameraParam = new AqCameraParameters();
        AqFileParameters _fileParam = new AqFileParameters();
        System.Drawing.Bitmap _revBitmap = null;
        AqDevice.IAqCameraManager _cameraManager = null;
        List<AqDevice.IAqCamera> _cameras = null;
        Dictionary<string, int> _cameraNameToIndex = new Dictionary<string, int>();

        public bool IsOpened { get => _isOpened; set => _isOpened = value; }
        public bool IsContinue { get => _isContinue; set => _isContinue = value; }
        public bool IsCaptured { get => _isCaptured; set => _isCaptured = value; }
        public AqCameraParameters CameraParam { get => _cameraParam; set => _cameraParam = value; }
        public AqFileParameters FileParam { get => _fileParam; set => _fileParam = value; }
        public System.Drawing.Bitmap RevBitmap
        {
            get { return _revBitmap; }
            set { _revBitmap = value; }
        }

        private event DelegateOnError EventOnError;
        private event DelegateOnBitmap EventOnBitmap;

        public AqAcquisitionImage()
        {
            InitializeAcquisitionParam();
        }

        private void InitializeAcquisitionParam()
        {
            string currentPath = System.IO.Directory.GetCurrentDirectory();
            //currentPath = Application.StartupPath + "\\Config.ini"; //使用哪种获取当前路径方式待定
            string cameraParamPath = currentPath + "\\CameraData.dat";
            string imageSourcePath = currentPath + "\\ImageSource.ini";
            CameraParam = CameraParam.DeSerializeAndRead(cameraParamPath);
            FileParam = FileParam.DeSerializeAndRead(imageSourcePath);
        }

        #region 相机控制函数
        //采集回调
        public void RecCapture(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            IsCaptured = true;
        }

        public bool OpenAllCamera()
        {
            if (!IsOpened)
            {
                string dllPath = System.IO.Directory.GetCurrentDirectory() + "\\" + comboBoxCameraBrand.Text + ".dll";
                Assembly assem = Assembly.LoadFile(dllPath);
                Type type = assem.GetType("AqDevice.AqCameraFactory");
                MethodInfo mi = type.GetMethod("GetInstance");
                object obj = mi.Invoke(null, null);

                _cameraManager = (IAqCameraManager)obj;
                _cameraManager.Init();
                _cameras = _cameraManager.GetCameras();
                _cameraNameToIndex.Clear();
                if (_cameras.Count == 0) return false;

                for (int i = 0; i < _cameras.Count; i++)
                {
                    _cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture));
                    _cameras[i].OpenCamera();
                    _cameraNameToIndex.Add(_cameras[i].Name, i);
                }

                IsOpened = true;
            }

            return true;
        }

        public bool OpenOneStream(int index)
        {
            if (!IsOpened) return false;

            string name = _cameras[index].Name;
            if (CameraParam.CameraName.Contains(_cameras[index].Name))
            {
                _cameras[index].Id = CameraParam.CameraId[name];
                _cameras[index].Ip = CameraParam.CameraIp[name];
                _cameras[index].Mac = CameraParam.CameraMac[name];
                _cameras[index].TriggerSource = CameraParam.CameraTriggerSource[name];
                _cameras[index].TriggerSwitch = CameraParam.CameraTriggerSwitch[name];
                _cameras[index].TriggerMode = CameraParam.CameraTriggerMode[name];
                _cameras[index].TriggerEdge = CameraParam.CameraTriggerEdge[name];
                _cameras[index].ExposureTime = CameraParam.CameraExposureTime[name];
                _cameras[index].AcquisitionFrequency = CameraParam.CameraAcquisitionFrequency[name];
                _cameras[index].TriggerDelay = CameraParam.CameraTriggerDelay[name];
                _cameras[index].Gain = CameraParam.CameraGain[name];
                _cameras[index].GainAuto = CameraParam.CameraGainAuto[name];
                _cameras[index].ImageWidth = CameraParam.CameraImageWidth[name];
                _cameras[index].ImageHeight = CameraParam.CameraImageHeight[name];
                _cameras[index].ImageoffsetX = CameraParam.CameraImageOffsetX[name];
                _cameras[index].ImageoffsetY = CameraParam.CameraImageOffsetY[name];
            }
            else
            {
                CameraParam.CameraName.Add(_cameras[index].Name);
            }

            if (_cameras[index].OpenStream() != 1) return false;

            if (_cameras[index].TriggerMode == AqDevice.TriggerModes.Continuous) IsContinue = true;
            else IsContinue = false;

            return true;
        }

        public bool CloseAllCamera()
        {
            try
            {
                if (IsOpened)
                {
                    for (int i = 0; i < _cameras.Count; i++)
                    {
                        _cameras[i].CloseCamera();
                    }
                }
                IsOpened = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting DisConnect error " + ex.Message);
                //Mark:此处加入log
            }
            return true;
        }

        public bool Connect()
        {
            try
            {
                //preservation and wait for use.
            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("Camera Connect Format error " + ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Camera Connect error " + ex.Message);
            }

            return true;
        }

        public bool AcquisitionCamera(ref List<System.Drawing.Bitmap> acquisitionBmp, List<string> acquisitionCameraName)
        {
            try
            {
                GC.Collect();
                for (int i = 0; i < acquisitionCameraName.Count; i++)
                {
                    if (CameraParam.AcquisitionParamChanged)
                    {
                        for (int j = 0; j < _cameras.Count; j++)
                        {
                            OpenOneStream(j);
                        }
                        CameraParam.AcquisitionParamChanged = false;
                    }

                    if (_cameras.Count < acquisitionCameraName.Count) return false;

                    IsCaptured = false;

                    _cameras[_cameraNameToIndex[acquisitionCameraName[i]]].TriggerSoftware();
                    while (!IsCaptured)
                    {
                        Thread.Sleep(10);//等待采集回调
                    }
                    acquisitionBmp.Add(RevBitmap);
                }

                return true;
            }
            catch (Exception ex)
            {
                //Mark:加入log
                return false;
            }
        }

        //Index=0采集所有保存的文件路径
        public bool AcquisitionFile(ref List<System.Drawing.Bitmap> acquisitionBmp, int[] index)
        {
            foreach (int key in index)
            {
                acquisitionBmp.Add(Image.FromFile(FileParam.InputFile[key]) as Bitmap);
            }
            return true;
        }

        //Index=0采集所有保存的文件夹路径
        public bool AcquisitionFolder(ref List<System.Drawing.Bitmap> acquisitionBmp, int[] index)
        {
            foreach (int key in index)
            {
                foreach (string file in FileParam.FolderFiles[key])
                {
                    acquisitionBmp.Add(Image.FromFile(file) as Bitmap);
                }
            }
            return true;
        }
        #endregion
    }
}
