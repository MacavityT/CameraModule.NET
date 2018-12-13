//***************************************************************
// 文件名（File Name）：    AqAcqusitionImage.cs
//
// 数据表（Tables）：       Nothing
//
// 作者（Author）：         台琰
//
// 日期（Create Date）：    2018.12.04
//
//***************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CameraModule;
using AqDevice;
using HalconDotNet;

namespace AqVision.Acquisition
{
    public delegate void DelegateOnError(int id);
    public delegate void DelegateOnBitmap(string strBmpBase64);

    public partial class AqAcqusitionImage: UserControl
    {
        bool _isContinue = false;
        bool _isConnected = false;
        bool _isGetBitmapSuc = false;
        AqDevice.IAqCameraManager _cameraManager = null;
        List<AqDevice.IAqCamera> _cameras;
        Dictionary<string, int> _cameraNameToIndex = new Dictionary<string, int>();
        CameraParameters _cameraParam = new CameraParameters();
        ImageSource _imageSource = new ImageSource();
        System.Drawing.Bitmap _revBitmap = null;

        public CameraParameters CameraParam { get => _cameraParam; set => _cameraParam = value; }
        public ImageSource ImageSource { get => _imageSource; set => _imageSource = value; }
        public System.Drawing.Bitmap RevBitmap
        {
            get { return _revBitmap; }
            set { _revBitmap = value; }
        }

        private event DelegateOnError EventOnError;
        private event DelegateOnBitmap EventOnBitmap;

        public AqAcqusitionImage()
        {
            InitializeComponent();
            InitializationCameraParam();
        }

        public AqAcqusitionImage(int cameraNumber)
        {
            //预留此构造函数，用于外界调用
            InitializationCameraParam();
        }

        private void InitializationCameraParam()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\CameraData.dat";
            CameraParam = CameraParam.DeSerializeAndRead(path);
        }

        #region 选择图像采集源
        #region From Camera
        private void radioButtonCamera_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = true;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = false;
            panelAcquisitionCtrl.Enabled = true;
        }

        private void buttonParameterSet_Click(object sender, EventArgs e)
        {
            AqCameraParametersSet CameraParamSet;
            CameraParamSet = new AqCameraParametersSet(CameraParam);
            CameraParamSet.Show();
            CameraParamSet.Focus();
        }
        #endregion

        #region From File
        private void radioButtonLocalFile_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = true;
            panelLocalFolder.Enabled = false;
            panelAcquisitionCtrl.Enabled = false;
        }

        private void buttonLocationDirectory_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxFile.Text = dialog.FileName;
            }
        }
        #endregion

        #region From Folder
        private void radioButtonLocalFolder_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = true;
            panelAcquisitionCtrl.Enabled = false;
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = folder.SelectedPath;
            }
        }
        #endregion

        #endregion

        #region 相机控制按钮
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
            
        private void buttonSaveImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonSingle_Click(object sender, EventArgs e)
        {

        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if(_isContinue)
            {
                buttonContinue.Text = "连续采集";
            }
            else
            {
                buttonContinue.Text = "停止采集";
            }
            _isContinue = !_isContinue;
        }
        #endregion

        #region 相机控制函数
        public void RecCapture(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            _isGetBitmapSuc = true;        }

        public bool Connect()
        {
            try
            {
                if (comboBoxCameraBrand.SelectedIndex == -1)
                {
                    MessageBox.Show("未选择相机品牌", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string dllPath = System.IO.Directory.GetCurrentDirectory() + "\\" + comboBoxCameraBrand.Text + ".dll";
                Assembly assem = Assembly.LoadFile(dllPath);
                Type type = assem.GetType("AqDevice.AqCameraFactory");
                MethodInfo mi = type.GetMethod("GetInstance");
                object obj = mi.Invoke(null, null);

                _cameraManager = (IAqCameraManager)obj;
                _cameraManager.Init();
                _cameras = _cameraManager.GetCameras();

                string name;
                for (int i = 0; i < _cameras.Count; i++)
                {
                    if (i < CameraParam.CameraName.Count)
                    {
                        _cameras[i].Name = CameraParam.CameraName[i];
                        name = _cameras[i].Name;
                        _cameras[i].Id = CameraParam.CameraId[name];
                        _cameras[i].Ip = CameraParam.CameraIp[name];
                        _cameras[i].Mac = CameraParam.CameraMac[name];
                        _cameras[i].TriggerSource = CameraParam.CameraTriggerSource[name];
                        _cameras[i].TriggerSwitch = CameraParam.CameraTriggerSwitch[name];
                        _cameras[i].TriggerMode = CameraParam.CameraTriggerMode[name];
                        _cameras[i].TriggerEdge = CameraParam.CameraTriggerEdge[name];
                        _cameras[i].ExposureTime = CameraParam.CameraExposureTime[name];
                        _cameras[i].AcquisitionFrequency = CameraParam.CameraAcquisitionFrequency[name];
                        _cameras[i].TriggerDelay = CameraParam.CameraTriggerDelay[name];
                        _cameras[i].Gain = CameraParam.CameraGain[name];
                        _cameras[i].GainAuto = CameraParam.CameraGainAuto[name];
                        _cameras[i].ImageWidth = CameraParam.CameraImageWidth[name];
                        _cameras[i].ImageHeight = CameraParam.CameraImageHeight[name];
                        _cameras[i].ImageoffsetX = CameraParam.CameraImageOffsetX[name];
                        _cameras[i].ImageoffsetY = CameraParam.CameraImageOffsetY[name];
                    }
                    else
                    {
                        //当连接新相机，但本地参数文件中不存在时
                        //如何处理待定，暂时先增加参数
                        CameraParam.CameraName.Add(_cameras[i].Name);
                        //Mark:init()和GetCameras()执行后，并不会给曝光时间赋值，所以这里有问题，待修改
                        CameraParam.CameraExposureTime[_cameras[i].Name] = Convert.ToInt64(_cameras[i].ExposureTime);
                    }

                    _cameraNameToIndex.Add(_cameras[i].Name, i);

                    _cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture));

                    _cameras[i].OpenCamera();
                    _cameras[i].OpenStream();
                }
            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting Connect Format error " + ex.Message);
                //Mark:此处加入log
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting Connect error " + ex.Message);
                //Mark:此处加入log
            }

            return true;
        }

        public bool DisConnect()
        {
            try
            {
                if(_isConnected)
                {
                    for (int i = 0; i < _cameras.Count; i++)
                    {
                        _cameras[i].CloseCamera();
                    }
                }
                _isConnected = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting DisConnect error " + ex.Message);
                //Mark:此处加入log
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
                    switch(ImageSource.CameraAcqusitionMode[acquisitionCameraName[i]])
                    {

                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                //Mark:加入log
                return false;
            }           
        }

        public bool AcquisitionFile(ref List<System.Drawing.Bitmap> acquisitionBmp, List<string> acquisitionFileName)
        {
            return true;
        }
        #endregion
    }
}
