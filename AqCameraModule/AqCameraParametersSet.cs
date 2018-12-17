//***************************************************************
// 文件名（File Name）：    AqCameraParameters.cs
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace AqCameraModule
{   
    public partial class AqCameraParametersSet : Form
    {
        CameraParameters _cameraParam = new CameraParameters();
        bool _isParamChanged = false;
        bool _isShowingParam = false;

        public CameraParameters CameraParam
        {
            get { return _cameraParam; }
            set { _cameraParam = value; }
        }

        public string CurrentCameraName { get; set; }
        public int CurrentCameraIndex { get; set; }

        public AqCameraParametersSet(ref CameraParameters param)
        {
            InitializeComponent();
            CameraParam = param ?? throw new ArgumentNullException(nameof(param));  
            
            RearrangeCameraName();           
            DisplayParam(CameraParam, 0);
        }

        public AqCameraParametersSet()
        {
            InitializeComponent();
            RearrangeCameraName();
        }

        protected override void OnClosing(CancelEventArgs eventArgs)
        {
            if(_isParamChanged)
            {
                if (MessageBox.Show("参数未保存，确定退出？", "提示信息", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    eventArgs.Cancel = true;
                    this.Hide();
                }
                else
                {
                    eventArgs.Cancel = false;
                }
            }
        }

        //所有修改参数操作都会触发此函数
        private void OnCameraParamChanged(object sender, EventArgs e)
        {
            if (_isShowingParam) return;
            _isParamChanged = true;
        }

        private void OnCameraNameChanged(object sender, EventArgs e)
        {
            if (_isParamChanged)
            {
                if (MessageBox.Show("参数未保存，确定替换？", "提示信息", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            int index = ((ComboBox)sender).SelectedIndex;
            string name = ((ComboBox)sender).Text;
            if (index == -1) return;

            if (name == "新增相机")
            {
                ClearParam();
            }
            else
            {
                DisplayParam(CameraParam, index);
            }

            CurrentCameraIndex = index;
            CurrentCameraName = name;
        }

        #region 读取和保存参数功能
        private void buttonReadParam_Click(object sender, EventArgs e)
        {
            if(_isParamChanged)
            {
                if (MessageBox.Show("参数未保存，确定替换？", "提示信息", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择输入文件";
            dialog.Filter = "相机配置文件（*.dat）|*.dat";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CameraParam = CameraParam.DeSerializeAndRead(dialog.FileName);
                DisplayParam(CameraParam, 0);
            }
            RearrangeCameraName();
        }

        private void buttonSaveParam_Click(object sender, EventArgs e)
        {

            if (false == UpdateAllData(CurrentCameraIndex, CurrentCameraName)) return;

            string localFilePath = "";
            if(checkBoxConstPath.Checked)
            {
                localFilePath = System.IO.Directory.GetCurrentDirectory() + "\\CameraData.dat";
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "相机配置文件（*.dat）|*.dat";
                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString(); //获得文件路径 
                }
                else
                {
                    MessageBox.Show("保存失败");
                    return;
                }
            }
            CameraParam.SerializeAndSave(localFilePath);
            _isParamChanged = false;
            RearrangeCameraName();
        }

        private void buttonDeleteParam_Click(object sender, EventArgs e)
        {
            DeleteData(CurrentCameraIndex, CurrentCameraName);
            RearrangeCameraName();
        }

        private void buttonApplyParam_Click(object sender, EventArgs e)
        {
            UpdateAllData(CurrentCameraIndex, CurrentCameraName);
        }
        #endregion

        #region 功能函数
        //刷新相机名显示
        private void RearrangeCameraName()
        {
            comboBoxCameraName.Items.Clear();
            for (int i = 0; i < CameraParam.CameraName.Count(); i++)
            {
                comboBoxCameraName.Items.Add(CameraParam.CameraName[i]);
            }
            comboBoxCameraName.Items.Add("新增相机");
            //显示1号相机
            comboBoxCameraName.SelectedIndex = 0;
        }


        private void ClearParam()
        {
            foreach (Control control in this.Controls) 
            {
                if (control is GroupBox) 
                {
                    foreach (Control control2 in ((GroupBox)control).Controls) 
                    {
                        if (control2 is TextBox)
                        {
                            ((TextBox)control2).Clear();
                        }
                        else if (control2 is ComboBox)
                        {
                            ((ComboBox)control2).SelectedIndex = -1;
                        }
                        else if (control2 is CheckBox)
                        {
                            ((CheckBox)control2).Checked = false;
                        }
                    }
                }
            }
        }
        //刷新窗体显示
        private void DisplayParam(CameraParameters param, int index)
        {
            _isShowingParam = true;

            string name = param.CameraName[index];
            //相机信息
            textBoxCameraRename.Text = name;
            textBoxCameraID.Text = param.CameraId[name];
            textBoxCameraIP.Text = param.CameraIp[name];
            textBoxMacAddress.Text = param.CameraMac[name];
            //图像参数
            textBoxImageWidth.Text = param.CameraImageWidth[name].ToString();
            textBoxImageHeight.Text = param.CameraImageHeight[name].ToString();
            textBoxImageOffsetX.Text = param.CameraImageOffsetX[name].ToString();
            textBoxImageOffsetY.Text = param.CameraImageOffsetY[name].ToString();
            //采集参数
            comboBoxTriggerSwitch.SelectedIndex = (int)param.CameraTriggerSwitch[name];
            comboBoxTriggerSource.SelectedIndex = (int)param.CameraTriggerSource[name];
            comboBoxTriggerMode.SelectedIndex = (int)param.CameraTriggerMode[name];
            comboBoxTriggerEdge.SelectedIndex = (int)param.CameraTriggerEdge[name];
            textBoxTriggerDelay.Text = param.CameraTriggerDelay[name].ToString();
            textBoxExposureTime.Text = param.CameraExposureTime[name].ToString();
            textBoxGain.Text = param.CameraGain[name].ToString();
            textBoxAcquisitionFrequency.Text = param.CameraAcquisitionFrequency[name].ToString();
            checkBoxAutoGain.Checked = param.CameraGainAuto[name];

            _isShowingParam = false;
        }

        private bool UpdateAllData(int index, string name)
        {
            //应先删除原对应相机名及参数
            //除非点击“新增相机”，否则CameraName的数量总比Index大
            if (name != textBoxCameraRename.Text &&
                CameraParam.CameraName.Count > index) 
            {
                DeleteData(index, name);
            }
            //更新参数
            name = textBoxCameraRename.Text;     
            foreach(string it in CameraParam.CameraName)
            {
                if (name == it && comboBoxCameraName.Text == "") 
                {
                    MessageBox.Show("请勿重复命名");
                    return false;
                }
            }
            //相机信息      
            CameraParam.AcquisitionParamChanged = true;
            CameraParam.CameraName.Insert(index, name);
            CameraParam.CameraId[name] = textBoxCameraID.Text;
            CameraParam.CameraIp[name] = textBoxCameraIP.Text;
            CameraParam.CameraMac[name] = textBoxMacAddress.Text;
            //图像参数
            CameraParam.CameraImageWidth[name] = Convert.ToInt64(textBoxImageWidth.Text);
            CameraParam.CameraImageHeight[name] = Convert.ToInt64(textBoxImageHeight.Text);
            CameraParam.CameraImageOffsetX[name] = Convert.ToInt64(textBoxImageOffsetX.Text);
            CameraParam.CameraImageOffsetY[name] = Convert.ToInt64(textBoxImageOffsetY.Text);
            //采集参数
            CameraParam.CameraTriggerSwitch[name] = (AqDevice.TriggerSwitchs)comboBoxTriggerSwitch.SelectedIndex;
            CameraParam.CameraTriggerSource[name] = (AqDevice.TriggerSources)comboBoxTriggerSource.SelectedIndex;
            CameraParam.CameraTriggerMode[name] = (AqDevice.TriggerModes)comboBoxTriggerMode.SelectedIndex;
            CameraParam.CameraTriggerEdge[name] = (AqDevice.TriggerEdges)comboBoxTriggerEdge.SelectedIndex;
            CameraParam.CameraTriggerDelay[name] = Convert.ToDouble(textBoxTriggerDelay.Text);
            CameraParam.CameraExposureTime[name] = Convert.ToDouble(textBoxExposureTime.Text);
            CameraParam.CameraGain[name] = Convert.ToDouble(textBoxGain.Text);
            CameraParam.CameraAcquisitionFrequency[name] = Convert.ToDouble(textBoxAcquisitionFrequency.Text);
            CameraParam.CameraGainAuto[name] = Convert.ToBoolean(checkBoxAutoGain.Checked);

            return true;
        }

        private void DeleteData(int index, string name)
        {
            CameraParam.CameraName.RemoveAt(index);
            CameraParam.CameraId.Remove(name);
            CameraParam.CameraIp.Remove(name);
            CameraParam.CameraMac.Remove(name);
            CameraParam.CameraImageWidth.Remove(name);
            CameraParam.CameraImageHeight.Remove(name);
            CameraParam.CameraImageOffsetX.Remove(name);
            CameraParam.CameraImageOffsetY.Remove(name);
            CameraParam.CameraTriggerSwitch.Remove(name);
            CameraParam.CameraTriggerSource.Remove(name);
            CameraParam.CameraTriggerMode.Remove(name);
            CameraParam.CameraTriggerEdge.Remove(name);
            CameraParam.CameraTriggerDelay.Remove(name);
            CameraParam.CameraExposureTime.Remove(name);
            CameraParam.CameraGain.Remove(name);
            CameraParam.CameraAcquisitionFrequency.Remove(name);
            CameraParam.CameraGainAuto.Remove(name);
        }
        #endregion
    }
}
