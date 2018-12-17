namespace AqCameraModule
{
    partial class AqCameraParametersSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxExposureTime = new System.Windows.Forms.TextBox();
            this.textBoxGain = new System.Windows.Forms.TextBox();
            this.textBoxAcquisitionFrequency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxTriggerEdge = new System.Windows.Forms.ComboBox();
            this.comboBoxTriggerMode = new System.Windows.Forms.ComboBox();
            this.comboBoxTriggerSource = new System.Windows.Forms.ComboBox();
            this.comboBoxTriggerSwitch = new System.Windows.Forms.ComboBox();
            this.textBoxTriggerDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAutoGain = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCameraName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCameraRename = new System.Windows.Forms.TextBox();
            this.textBoxCameraID = new System.Windows.Forms.TextBox();
            this.textBoxMacAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCameraIP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTip = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxImageOffsetY = new System.Windows.Forms.TextBox();
            this.textBoxImageOffsetX = new System.Windows.Forms.TextBox();
            this.textBoxImageHeight = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxImageWidth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonReadParam = new System.Windows.Forms.Button();
            this.buttonSaveParam = new System.Windows.Forms.Button();
            this.buttonDeleteParam = new System.Windows.Forms.Button();
            this.buttonApplyParam = new System.Windows.Forms.Button();
            this.checkBoxConstPath = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(30, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "触发模式";
            // 
            // textBoxExposureTime
            // 
            this.textBoxExposureTime.Location = new System.Drawing.Point(129, 247);
            this.textBoxExposureTime.Name = "textBoxExposureTime";
            this.textBoxExposureTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxExposureTime.TabIndex = 13;
            this.textBoxExposureTime.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxGain
            // 
            this.textBoxGain.Location = new System.Drawing.Point(129, 291);
            this.textBoxGain.Name = "textBoxGain";
            this.textBoxGain.Size = new System.Drawing.Size(100, 21);
            this.textBoxGain.TabIndex = 14;
            this.textBoxGain.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxAcquisitionFrequency
            // 
            this.textBoxAcquisitionFrequency.Location = new System.Drawing.Point(129, 335);
            this.textBoxAcquisitionFrequency.Name = "textBoxAcquisitionFrequency";
            this.textBoxAcquisitionFrequency.Size = new System.Drawing.Size(100, 21);
            this.textBoxAcquisitionFrequency.TabIndex = 15;
            this.textBoxAcquisitionFrequency.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(30, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "曝光时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(30, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "采集频率";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxTriggerEdge);
            this.groupBox3.Controls.Add(this.comboBoxTriggerMode);
            this.groupBox3.Controls.Add(this.comboBoxTriggerSource);
            this.groupBox3.Controls.Add(this.comboBoxTriggerSwitch);
            this.groupBox3.Controls.Add(this.textBoxTriggerDelay);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.checkBoxAutoGain);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxExposureTime);
            this.groupBox3.Controls.Add(this.textBoxGain);
            this.groupBox3.Controls.Add(this.textBoxAcquisitionFrequency);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(452, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 385);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "采集参数";
            // 
            // comboBoxTriggerEdge
            // 
            this.comboBoxTriggerEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerEdge.FormattingEnabled = true;
            this.comboBoxTriggerEdge.Items.AddRange(new object[] {
            "UnKnown",
            "FallingEdge",
            "RisingEdge"});
            this.comboBoxTriggerEdge.Location = new System.Drawing.Point(131, 155);
            this.comboBoxTriggerEdge.Name = "comboBoxTriggerEdge";
            this.comboBoxTriggerEdge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTriggerEdge.Size = new System.Drawing.Size(100, 20);
            this.comboBoxTriggerEdge.TabIndex = 11;
            this.comboBoxTriggerEdge.SelectedIndexChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // comboBoxTriggerMode
            // 
            this.comboBoxTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerMode.FormattingEnabled = true;
            this.comboBoxTriggerMode.Items.AddRange(new object[] {
            "UnKnown",
            "Continuous",
            "HardWare",
            "EventTrigger"});
            this.comboBoxTriggerMode.Location = new System.Drawing.Point(131, 111);
            this.comboBoxTriggerMode.Name = "comboBoxTriggerMode";
            this.comboBoxTriggerMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTriggerMode.Size = new System.Drawing.Size(100, 20);
            this.comboBoxTriggerMode.TabIndex = 10;
            this.comboBoxTriggerMode.SelectedIndexChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // comboBoxTriggerSource
            // 
            this.comboBoxTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerSource.FormattingEnabled = true;
            this.comboBoxTriggerSource.Items.AddRange(new object[] {
            "UnKnown",
            "SoftWare",
            "Line0",
            "Line1",
            "Line2",
            "Line3",
            "Line4",
            "Line5",
            "Line6",
            "Line7"});
            this.comboBoxTriggerSource.Location = new System.Drawing.Point(131, 68);
            this.comboBoxTriggerSource.Name = "comboBoxTriggerSource";
            this.comboBoxTriggerSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTriggerSource.Size = new System.Drawing.Size(100, 20);
            this.comboBoxTriggerSource.TabIndex = 9;
            this.comboBoxTriggerSource.SelectedIndexChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // comboBoxTriggerSwitch
            // 
            this.comboBoxTriggerSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerSwitch.FormattingEnabled = true;
            this.comboBoxTriggerSwitch.Items.AddRange(new object[] {
            "UnKnown",
            "OFF",
            "ON"});
            this.comboBoxTriggerSwitch.Location = new System.Drawing.Point(131, 32);
            this.comboBoxTriggerSwitch.Name = "comboBoxTriggerSwitch";
            this.comboBoxTriggerSwitch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTriggerSwitch.Size = new System.Drawing.Size(100, 20);
            this.comboBoxTriggerSwitch.TabIndex = 8;
            this.comboBoxTriggerSwitch.SelectedIndexChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxTriggerDelay
            // 
            this.textBoxTriggerDelay.Location = new System.Drawing.Point(129, 201);
            this.textBoxTriggerDelay.Name = "textBoxTriggerDelay";
            this.textBoxTriggerDelay.Size = new System.Drawing.Size(100, 21);
            this.textBoxTriggerDelay.TabIndex = 12;
            this.textBoxTriggerDelay.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(30, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "触发延时";
            // 
            // checkBoxAutoGain
            // 
            this.checkBoxAutoGain.AutoSize = true;
            this.checkBoxAutoGain.Location = new System.Drawing.Point(11, 296);
            this.checkBoxAutoGain.Name = "checkBoxAutoGain";
            this.checkBoxAutoGain.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoGain.TabIndex = 13;
            this.checkBoxAutoGain.Text = "自动增益";
            this.checkBoxAutoGain.UseVisualStyleBackColor = true;
            this.checkBoxAutoGain.CheckedChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(30, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "触发极性";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(30, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "触发源";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(30, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "触发开关";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCameraName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxCameraRename);
            this.groupBox1.Controls.Add(this.textBoxCameraID);
            this.groupBox1.Controls.Add(this.textBoxMacAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCameraIP);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lbTip);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 198);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机信息";
            // 
            // comboBoxCameraName
            // 
            this.comboBoxCameraName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraName.FormattingEnabled = true;
            this.comboBoxCameraName.Location = new System.Drawing.Point(124, 32);
            this.comboBoxCameraName.Name = "comboBoxCameraName";
            this.comboBoxCameraName.Size = new System.Drawing.Size(255, 20);
            this.comboBoxCameraName.TabIndex = 6;
            this.comboBoxCameraName.SelectedIndexChanged += new System.EventHandler(this.OnCameraNameChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(30, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "MAC地址";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(30, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "相机IP";
            // 
            // textBoxCameraRename
            // 
            this.textBoxCameraRename.Location = new System.Drawing.Point(124, 64);
            this.textBoxCameraRename.Name = "textBoxCameraRename";
            this.textBoxCameraRename.Size = new System.Drawing.Size(255, 21);
            this.textBoxCameraRename.TabIndex = 1;
            this.textBoxCameraRename.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxCameraID
            // 
            this.textBoxCameraID.Location = new System.Drawing.Point(124, 95);
            this.textBoxCameraID.Name = "textBoxCameraID";
            this.textBoxCameraID.Size = new System.Drawing.Size(255, 21);
            this.textBoxCameraID.TabIndex = 1;
            this.textBoxCameraID.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxMacAddress
            // 
            this.textBoxMacAddress.Location = new System.Drawing.Point(124, 165);
            this.textBoxMacAddress.Name = "textBoxMacAddress";
            this.textBoxMacAddress.Size = new System.Drawing.Size(255, 21);
            this.textBoxMacAddress.TabIndex = 3;
            this.textBoxMacAddress.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(30, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "相机ID";
            // 
            // textBoxCameraIP
            // 
            this.textBoxCameraIP.Location = new System.Drawing.Point(124, 131);
            this.textBoxCameraIP.Name = "textBoxCameraIP";
            this.textBoxCameraIP.Size = new System.Drawing.Size(255, 21);
            this.textBoxCameraIP.TabIndex = 2;
            this.textBoxCameraIP.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(30, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "相机命名";
            // 
            // lbTip
            // 
            this.lbTip.AutoSize = true;
            this.lbTip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTip.Location = new System.Drawing.Point(30, 37);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(53, 12);
            this.lbTip.TabIndex = 0;
            this.lbTip.Text = "相机选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxImageOffsetY);
            this.groupBox2.Controls.Add(this.textBoxImageOffsetX);
            this.groupBox2.Controls.Add(this.textBoxImageHeight);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBoxImageWidth);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(23, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 181);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像参数";
            // 
            // textBoxImageOffsetY
            // 
            this.textBoxImageOffsetY.Location = new System.Drawing.Point(124, 151);
            this.textBoxImageOffsetY.Name = "textBoxImageOffsetY";
            this.textBoxImageOffsetY.Size = new System.Drawing.Size(255, 21);
            this.textBoxImageOffsetY.TabIndex = 7;
            this.textBoxImageOffsetY.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxImageOffsetX
            // 
            this.textBoxImageOffsetX.Location = new System.Drawing.Point(124, 114);
            this.textBoxImageOffsetX.Name = "textBoxImageOffsetX";
            this.textBoxImageOffsetX.Size = new System.Drawing.Size(255, 21);
            this.textBoxImageOffsetX.TabIndex = 6;
            this.textBoxImageOffsetX.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // textBoxImageHeight
            // 
            this.textBoxImageHeight.Location = new System.Drawing.Point(124, 68);
            this.textBoxImageHeight.Name = "textBoxImageHeight";
            this.textBoxImageHeight.Size = new System.Drawing.Size(255, 21);
            this.textBoxImageHeight.TabIndex = 5;
            this.textBoxImageHeight.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "Y轴偏移";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(28, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "图像高度";
            // 
            // textBoxImageWidth
            // 
            this.textBoxImageWidth.Location = new System.Drawing.Point(124, 28);
            this.textBoxImageWidth.Name = "textBoxImageWidth";
            this.textBoxImageWidth.Size = new System.Drawing.Size(255, 21);
            this.textBoxImageWidth.TabIndex = 4;
            this.textBoxImageWidth.TextChanged += new System.EventHandler(this.OnCameraParamChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(28, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "X轴偏移";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(28, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "图像宽度";
            // 
            // buttonReadParam
            // 
            this.buttonReadParam.Location = new System.Drawing.Point(310, 415);
            this.buttonReadParam.Name = "buttonReadParam";
            this.buttonReadParam.Size = new System.Drawing.Size(75, 23);
            this.buttonReadParam.TabIndex = 16;
            this.buttonReadParam.Text = "读取";
            this.buttonReadParam.UseVisualStyleBackColor = true;
            this.buttonReadParam.Click += new System.EventHandler(this.buttonReadParam_Click);
            // 
            // buttonSaveParam
            // 
            this.buttonSaveParam.Location = new System.Drawing.Point(217, 415);
            this.buttonSaveParam.Name = "buttonSaveParam";
            this.buttonSaveParam.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveParam.TabIndex = 17;
            this.buttonSaveParam.Text = "保存";
            this.buttonSaveParam.UseVisualStyleBackColor = true;
            this.buttonSaveParam.Click += new System.EventHandler(this.buttonSaveParam_Click);
            // 
            // buttonDeleteParam
            // 
            this.buttonDeleteParam.Location = new System.Drawing.Point(405, 415);
            this.buttonDeleteParam.Name = "buttonDeleteParam";
            this.buttonDeleteParam.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteParam.TabIndex = 18;
            this.buttonDeleteParam.Text = "删除";
            this.buttonDeleteParam.UseVisualStyleBackColor = true;
            this.buttonDeleteParam.Click += new System.EventHandler(this.buttonDeleteParam_Click);
            // 
            // buttonApplyParam
            // 
            this.buttonApplyParam.Location = new System.Drawing.Point(501, 415);
            this.buttonApplyParam.Name = "buttonApplyParam";
            this.buttonApplyParam.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyParam.TabIndex = 19;
            this.buttonApplyParam.Text = "应用";
            this.buttonApplyParam.UseVisualStyleBackColor = true;
            this.buttonApplyParam.Click += new System.EventHandler(this.buttonApplyParam_Click);
            // 
            // checkBoxConstPath
            // 
            this.checkBoxConstPath.AutoSize = true;
            this.checkBoxConstPath.Checked = true;
            this.checkBoxConstPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConstPath.Location = new System.Drawing.Point(144, 418);
            this.checkBoxConstPath.Name = "checkBoxConstPath";
            this.checkBoxConstPath.Size = new System.Drawing.Size(72, 16);
            this.checkBoxConstPath.TabIndex = 20;
            this.checkBoxConstPath.Text = "固定路径";
            this.checkBoxConstPath.UseVisualStyleBackColor = true;
            // 
            // AqCameraParametersSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 460);
            this.Controls.Add(this.checkBoxConstPath);
            this.Controls.Add(this.buttonApplyParam);
            this.Controls.Add(this.buttonDeleteParam);
            this.Controls.Add(this.buttonSaveParam);
            this.Controls.Add(this.buttonReadParam);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "AqCameraParametersSet";
            this.Text = "相机参数设置";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxExposureTime;
        private System.Windows.Forms.TextBox textBoxGain;
        private System.Windows.Forms.TextBox textBoxAcquisitionFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxAutoGain;
        private System.Windows.Forms.ComboBox comboBoxTriggerSwitch;
        private System.Windows.Forms.TextBox textBoxTriggerDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCameraID;
        private System.Windows.Forms.TextBox textBoxMacAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCameraIP;
        private System.Windows.Forms.Label lbTip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxImageWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxTriggerSource;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxTriggerEdge;
        private System.Windows.Forms.ComboBox comboBoxTriggerMode;
        private System.Windows.Forms.TextBox textBoxImageOffsetY;
        private System.Windows.Forms.TextBox textBoxImageOffsetX;
        private System.Windows.Forms.TextBox textBoxImageHeight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonReadParam;
        private System.Windows.Forms.Button buttonSaveParam;
        private System.Windows.Forms.ComboBox comboBoxCameraName;
        private System.Windows.Forms.TextBox textBoxCameraRename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonDeleteParam;
        private System.Windows.Forms.Button buttonApplyParam;
        private System.Windows.Forms.CheckBox checkBoxConstPath;
    }
}