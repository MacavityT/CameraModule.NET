namespace AqVision.Acquisition
{
    partial class AqAcqusitionImage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLocalFolder = new System.Windows.Forms.Panel();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.radioButtonCamera = new System.Windows.Forms.RadioButton();
            this.comboBoxCameraName = new System.Windows.Forms.ComboBox();
            this.panelCamera = new System.Windows.Forms.Panel();
            this.comboBoxCameraBrand = new System.Windows.Forms.ComboBox();
            this.buttonParameterSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonLocationDirectory = new System.Windows.Forms.Button();
            this.panelCamerapanelLocalFile = new System.Windows.Forms.Panel();
            this.radioButtonLocalFolder = new System.Windows.Forms.RadioButton();
            this.radioButtonLocalFile = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.pictureBoxImageShow = new System.Windows.Forms.PictureBox();
            this.panelAcquisitionCtrl = new System.Windows.Forms.Panel();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonSingle = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelLocalFolder.SuspendLayout();
            this.panelCamera.SuspendLayout();
            this.panelCamerapanelLocalFile.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageShow)).BeginInit();
            this.panelAcquisitionCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLocalFolder
            // 
            this.panelLocalFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLocalFolder.Controls.Add(this.textBoxFolder);
            this.panelLocalFolder.Controls.Add(this.buttonSelectFolder);
            this.panelLocalFolder.Location = new System.Drawing.Point(13, 202);
            this.panelLocalFolder.Name = "panelLocalFolder";
            this.panelLocalFolder.Size = new System.Drawing.Size(502, 47);
            this.panelLocalFolder.TabIndex = 8;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(2, 16);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(408, 21);
            this.textBoxFolder.TabIndex = 9;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(415, 13);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(77, 24);
            this.buttonSelectFolder.TabIndex = 10;
            this.buttonSelectFolder.Text = "选择";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // radioButtonCamera
            // 
            this.radioButtonCamera.AutoSize = true;
            this.radioButtonCamera.Checked = true;
            this.radioButtonCamera.Location = new System.Drawing.Point(13, 20);
            this.radioButtonCamera.Name = "radioButtonCamera";
            this.radioButtonCamera.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCamera.TabIndex = 8;
            this.radioButtonCamera.TabStop = true;
            this.radioButtonCamera.Text = "相机";
            this.radioButtonCamera.UseVisualStyleBackColor = true;
            this.radioButtonCamera.CheckedChanged += new System.EventHandler(this.radioButtonCamera_CheckedChanged);
            // 
            // comboBoxCameraName
            // 
            this.comboBoxCameraName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraName.FormattingEnabled = true;
            this.comboBoxCameraName.Location = new System.Drawing.Point(67, 17);
            this.comboBoxCameraName.Name = "comboBoxCameraName";
            this.comboBoxCameraName.Size = new System.Drawing.Size(144, 20);
            this.comboBoxCameraName.TabIndex = 1;
            // 
            // panelCamera
            // 
            this.panelCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCamera.Controls.Add(this.comboBoxCameraName);
            this.panelCamera.Controls.Add(this.comboBoxCameraBrand);
            this.panelCamera.Controls.Add(this.buttonParameterSet);
            this.panelCamera.Controls.Add(this.label1);
            this.panelCamera.Controls.Add(this.label2);
            this.panelCamera.Location = new System.Drawing.Point(13, 40);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(501, 51);
            this.panelCamera.TabIndex = 8;
            // 
            // comboBoxCameraBrand
            // 
            this.comboBoxCameraBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraBrand.FormattingEnabled = true;
            this.comboBoxCameraBrand.Items.AddRange(new object[] {
            "DaHeng",
            "Balser",
            "HikVision"});
            this.comboBoxCameraBrand.Location = new System.Drawing.Point(276, 17);
            this.comboBoxCameraBrand.Name = "comboBoxCameraBrand";
            this.comboBoxCameraBrand.Size = new System.Drawing.Size(132, 20);
            this.comboBoxCameraBrand.TabIndex = 1;
            // 
            // buttonParameterSet
            // 
            this.buttonParameterSet.Location = new System.Drawing.Point(414, 15);
            this.buttonParameterSet.Name = "buttonParameterSet";
            this.buttonParameterSet.Size = new System.Drawing.Size(78, 24);
            this.buttonParameterSet.TabIndex = 2;
            this.buttonParameterSet.Text = "相机设置";
            this.buttonParameterSet.UseVisualStyleBackColor = true;
            this.buttonParameterSet.Click += new System.EventHandler(this.buttonParameterSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机品牌";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "相机名称";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(2, 18);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(408, 21);
            this.textBoxFile.TabIndex = 9;
            // 
            // buttonLocationDirectory
            // 
            this.buttonLocationDirectory.Location = new System.Drawing.Point(417, 17);
            this.buttonLocationDirectory.Name = "buttonLocationDirectory";
            this.buttonLocationDirectory.Size = new System.Drawing.Size(79, 24);
            this.buttonLocationDirectory.TabIndex = 10;
            this.buttonLocationDirectory.Text = "选择";
            this.buttonLocationDirectory.UseVisualStyleBackColor = true;
            this.buttonLocationDirectory.Click += new System.EventHandler(this.buttonLocationDirectory_Click);
            // 
            // panelCamerapanelLocalFile
            // 
            this.panelCamerapanelLocalFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCamerapanelLocalFile.Controls.Add(this.textBoxFile);
            this.panelCamerapanelLocalFile.Controls.Add(this.buttonLocationDirectory);
            this.panelCamerapanelLocalFile.Location = new System.Drawing.Point(13, 117);
            this.panelCamerapanelLocalFile.Name = "panelCamerapanelLocalFile";
            this.panelCamerapanelLocalFile.Size = new System.Drawing.Size(502, 57);
            this.panelCamerapanelLocalFile.TabIndex = 8;
            // 
            // radioButtonLocalFolder
            // 
            this.radioButtonLocalFolder.AutoSize = true;
            this.radioButtonLocalFolder.Location = new System.Drawing.Point(13, 180);
            this.radioButtonLocalFolder.Name = "radioButtonLocalFolder";
            this.radioButtonLocalFolder.Size = new System.Drawing.Size(59, 16);
            this.radioButtonLocalFolder.TabIndex = 8;
            this.radioButtonLocalFolder.Text = "文件夹";
            this.radioButtonLocalFolder.UseVisualStyleBackColor = true;
            this.radioButtonLocalFolder.CheckedChanged += new System.EventHandler(this.radioButtonLocalFolder_CheckedChanged);
            // 
            // radioButtonLocalFile
            // 
            this.radioButtonLocalFile.AutoSize = true;
            this.radioButtonLocalFile.Location = new System.Drawing.Point(13, 97);
            this.radioButtonLocalFile.Name = "radioButtonLocalFile";
            this.radioButtonLocalFile.Size = new System.Drawing.Size(47, 16);
            this.radioButtonLocalFile.TabIndex = 8;
            this.radioButtonLocalFile.Text = "文件";
            this.radioButtonLocalFile.UseVisualStyleBackColor = true;
            this.radioButtonLocalFile.CheckedChanged += new System.EventHandler(this.radioButtonLocalFile_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panelLocalFolder);
            this.groupBox.Controls.Add(this.panelCamerapanelLocalFile);
            this.groupBox.Controls.Add(this.panelCamera);
            this.groupBox.Controls.Add(this.radioButtonCamera);
            this.groupBox.Controls.Add(this.radioButtonLocalFolder);
            this.groupBox.Controls.Add(this.radioButtonLocalFile);
            this.groupBox.Location = new System.Drawing.Point(18, 22);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(521, 265);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            // 
            // pictureBoxImageShow
            // 
            this.pictureBoxImageShow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxImageShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxImageShow.Location = new System.Drawing.Point(565, 33);
            this.pictureBoxImageShow.Name = "pictureBoxImageShow";
            this.pictureBoxImageShow.Size = new System.Drawing.Size(632, 483);
            this.pictureBoxImageShow.TabIndex = 11;
            this.pictureBoxImageShow.TabStop = false;
            // 
            // panelAcquisitionCtrl
            // 
            this.panelAcquisitionCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAcquisitionCtrl.Controls.Add(this.buttonSaveImage);
            this.panelAcquisitionCtrl.Controls.Add(this.buttonSingle);
            this.panelAcquisitionCtrl.Controls.Add(this.buttonContinue);
            this.panelAcquisitionCtrl.Controls.Add(this.buttonConnect);
            this.panelAcquisitionCtrl.Location = new System.Drawing.Point(18, 316);
            this.panelAcquisitionCtrl.Name = "panelAcquisitionCtrl";
            this.panelAcquisitionCtrl.Size = new System.Drawing.Size(521, 200);
            this.panelAcquisitionCtrl.TabIndex = 12;
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(298, 18);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(147, 63);
            this.buttonSaveImage.TabIndex = 4;
            this.buttonSaveImage.Text = "保存图像";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonSingle
            // 
            this.buttonSingle.Location = new System.Drawing.Point(298, 118);
            this.buttonSingle.Name = "buttonSingle";
            this.buttonSingle.Size = new System.Drawing.Size(147, 63);
            this.buttonSingle.TabIndex = 4;
            this.buttonSingle.Text = "单帧采集";
            this.buttonSingle.UseVisualStyleBackColor = true;
            this.buttonSingle.Click += new System.EventHandler(this.buttonSingle_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(54, 119);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(147, 62);
            this.buttonContinue.TabIndex = 3;
            this.buttonContinue.Text = "连续采集";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(54, 19);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(147, 62);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "连接相机";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "采集控制";
            // 
            // AqAcqusitionImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAcquisitionCtrl);
            this.Controls.Add(this.pictureBoxImageShow);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label3);
            this.Name = "AqAcqusitionImage";
            this.Size = new System.Drawing.Size(1220, 560);
            this.panelLocalFolder.ResumeLayout(false);
            this.panelLocalFolder.PerformLayout();
            this.panelCamera.ResumeLayout(false);
            this.panelCamera.PerformLayout();
            this.panelCamerapanelLocalFile.ResumeLayout(false);
            this.panelCamerapanelLocalFile.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageShow)).EndInit();
            this.panelAcquisitionCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLocalFolder;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.RadioButton radioButtonCamera;
        private System.Windows.Forms.ComboBox comboBoxCameraName;
        private System.Windows.Forms.Panel panelCamera;
        private System.Windows.Forms.ComboBox comboBoxCameraBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonLocationDirectory;
        private System.Windows.Forms.Panel panelCamerapanelLocalFile;
        private System.Windows.Forms.RadioButton radioButtonLocalFolder;
        private System.Windows.Forms.RadioButton radioButtonLocalFile;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonParameterSet;
        private System.Windows.Forms.PictureBox pictureBoxImageShow;
        private System.Windows.Forms.Panel panelAcquisitionCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSingle;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonConnect;
    }
}
