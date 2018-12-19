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
using System.Threading;
using AqCameraModule;
using AqDevice;

namespace AqVision.Acquisition
{
    public partial class AqAcqusitionControl : UserControl
    {
        AqAcquisitionImage _acquisitionImage = new AqAcquisitionImage();
        public AqAcquisitionImage AcquisitionImage
        {
            get => _acquisitionImage;
            set => _acquisitionImage = value;
        }

        public AqAcqusitionControl()
        {
            InitializeComponent();
            InitializationControlShow();
            radioButtonCamera_CheckedChanged(null, null);
        }

        private void InitializationControlShow()
        {
            //初始化相机列表

            //初始化文件列表
            comboBoxFile.Items.Add("新增文件");
            //初始化文件夹列表
            comboBoxFolder.Items.Add("新增文件夹");
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
            AqCameraParametersSet CameraParamSet = new AqCameraParametersSet();
            CameraParamSet.CameraParam = AcquisitionImage.CameraParam;
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


        private void comboBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == "新增文件")
            {

            }
        }

        private void buttonLocationDirectory_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                comboBoxFile.Items.Add(dialog.FileName);
            }
        }

        private void ReArrangeComboBoxFile()
        {

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

        private void comboBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                comboBoxFolder.Items.Add(folder.SelectedPath);
            }
        }

        private void ReArrangeComboBoxFolder()
        {

        }
        #endregion

        #endregion

        #region 相机控制按钮
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxCameraBrand.SelectedIndex == -1)
            {
                MessageBox.Show("未选择相机品牌", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AcquisitionImage.OpenAllCamera();
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonSingle_Click(object sender, EventArgs e)
        {
            if (!AcquisitionImage.IsContinue)
            {
                AcquisitionImage.CameraParam.CameraTriggerMode[comboBoxCameraName.Text] = TriggerModes.Unknow;
                AcquisitionImage.OpenOneStream(comboBoxCameraName.SelectedIndex);
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (AcquisitionImage.IsContinue)
            {
                buttonContinue.Text = "连续采集";
                AcquisitionImage.CameraParam.CameraTriggerMode[comboBoxCameraName.Text] = TriggerModes.Unknow;
            }
            else
            {
                buttonContinue.Text = "停止采集";
                AcquisitionImage.CameraParam.CameraTriggerMode[comboBoxCameraName.Text] = TriggerModes.Continuous;
            }
            AcquisitionImage.OpenOneStream(comboBoxCameraName.SelectedIndex);
        }
        #endregion
    }
}
