﻿namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpdate = new DateTimePicker();
            label2 = new Label();
            cbAuthor = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            rb = new RadioButton();
            rbInport = new RadioButton();
            rbSubaru = new RadioButton();
            rbHonda = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            cbCarName = new ComboBox();
            tbReport = new TextBox();
            label6 = new Label();
            btPicOpen = new Button();
            btPicDelete = new Button();
            pictureBox1 = new PictureBox();
            btAddReport = new Button();
            pbPicture = new PictureBox();
            btModifyReport = new Button();
            btDeleteReport = new Button();
            label7 = new Label();
            dgvCarReport = new DataGridView();
            btReportOpen = new Button();
            btReportSave = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarReport).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(28, 35);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpdate
            // 
            dtpdate.CalendarFont = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpdate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpdate.Location = new Point(95, 29);
            dtpdate.Name = "dtpdate";
            dtpdate.Size = new Size(200, 33);
            dtpdate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(28, 86);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 2;
            label2.Text = "記録";
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(95, 83);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(253, 33);
            cbAuthor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(28, 139);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 2;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(28, 184);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 2;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(24, 242);
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 2;
            label5.Text = "レポート";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rb);
            groupBox1.Controls.Add(rbInport);
            groupBox1.Controls.Add(rbSubaru);
            groupBox1.Controls.Add(rbHonda);
            groupBox1.Controls.Add(rbNissan);
            groupBox1.Controls.Add(rbToyota);
            groupBox1.Location = new Point(95, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 36);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // rb
            // 
            rb.AutoSize = true;
            rb.Location = new Point(313, 14);
            rb.Name = "rb";
            rb.Size = new Size(56, 19);
            rb.TabIndex = 0;
            rb.TabStop = true;
            rb.Text = "その他";
            rb.UseVisualStyleBackColor = true;
            // 
            // rbInport
            // 
            rbInport.AutoSize = true;
            rbInport.Location = new Point(246, 14);
            rbInport.Name = "rbInport";
            rbInport.Size = new Size(61, 19);
            rbInport.TabIndex = 0;
            rbInport.TabStop = true;
            rbInport.Text = "輸入車";
            rbInport.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(190, 14);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 0;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(131, 14);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 0;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(69, 14);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 0;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(13, 14);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(95, 181);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(253, 33);
            cbCarName.TabIndex = 3;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(97, 242);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(411, 125);
            tbReport.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(551, 64);
            label6.Name = "label6";
            label6.Size = new Size(50, 25);
            label6.TabIndex = 0;
            label6.Text = "画像";
            // 
            // btPicOpen
            // 
            btPicOpen.Location = new Point(652, 64);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(75, 23);
            btPicOpen.TabIndex = 6;
            btPicOpen.Text = "開く…";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += btPicOpen_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.Location = new Point(741, 63);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(75, 23);
            btPicDelete.TabIndex = 6;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += btPicDelete_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Location = new Point(551, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 229);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btAddReport
            // 
            btAddReport.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAddReport.Location = new Point(551, 327);
            btAddReport.Name = "btAddReport";
            btAddReport.Size = new Size(65, 41);
            btAddReport.TabIndex = 6;
            btAddReport.Text = "追加";
            btAddReport.UseVisualStyleBackColor = true;
            btAddReport.Click += btAddReport_Click;
            // 
            // pbPicture
            // 
            pbPicture.BackColor = SystemColors.GradientInactiveCaption;
            pbPicture.Location = new Point(551, 92);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(265, 229);
            pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbPicture.TabIndex = 7;
            pbPicture.TabStop = false;
            // 
            // btModifyReport
            // 
            btModifyReport.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btModifyReport.Location = new Point(652, 327);
            btModifyReport.Name = "btModifyReport";
            btModifyReport.Size = new Size(65, 41);
            btModifyReport.TabIndex = 6;
            btModifyReport.Text = "修正";
            btModifyReport.UseVisualStyleBackColor = true;
            btModifyReport.Click += btModifyReport_Click;
            // 
            // btDeleteReport
            // 
            btDeleteReport.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDeleteReport.Location = new Point(751, 327);
            btDeleteReport.Name = "btDeleteReport";
            btDeleteReport.Size = new Size(65, 41);
            btDeleteReport.TabIndex = 6;
            btDeleteReport.Text = "削除";
            btDeleteReport.UseVisualStyleBackColor = true;
            btDeleteReport.Click += btDeleteReport_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(41, 400);
            label7.Name = "label7";
            label7.Size = new Size(50, 25);
            label7.TabIndex = 2;
            label7.Text = "一覧";
            // 
            // dgvCarReport
            // 
            dgvCarReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarReport.Location = new Point(99, 389);
            dgvCarReport.MultiSelect = false;
            dgvCarReport.Name = "dgvCarReport";
            dgvCarReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarReport.Size = new Size(717, 144);
            dgvCarReport.TabIndex = 8;
            dgvCarReport.CellContentClick += dgvCarReport_Click;
            // 
            // btReportOpen
            // 
            btReportOpen.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btReportOpen.Location = new Point(30, 468);
            btReportOpen.Name = "btReportOpen";
            btReportOpen.Size = new Size(63, 31);
            btReportOpen.TabIndex = 6;
            btReportOpen.Text = "開く…";
            btReportOpen.UseVisualStyleBackColor = true;
            // 
            // btReportSave
            // 
            btReportSave.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btReportSave.Location = new Point(30, 505);
            btReportSave.Name = "btReportSave";
            btReportSave.Size = new Size(63, 28);
            btReportSave.TabIndex = 6;
            btReportSave.Text = "保存…";
            btReportSave.UseVisualStyleBackColor = true;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 560);
            Controls.Add(dgvCarReport);
            Controls.Add(pbPicture);
            Controls.Add(pictureBox1);
            Controls.Add(btDeleteReport);
            Controls.Add(btModifyReport);
            Controls.Add(btReportOpen);
            Controls.Add(btReportSave);
            Controls.Add(btAddReport);
            Controls.Add(btPicDelete);
            Controls.Add(btPicOpen);
            Controls.Add(tbReport);
            Controls.Add(groupBox1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpdate);
            Controls.Add(label6);
            Controls.Add(label1);
            Name = "Form1";
            Text = "試乗レポート管理システム";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpdate;
        private Label label2;
        private ComboBox cbAuthor;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton rb;
        private RadioButton rbInport;
        private RadioButton rbSubaru;
        private RadioButton rbHonda;
        private RadioButton rbNissan;
        private RadioButton rbToyota;
        private ComboBox cbCarName;
        private TextBox tbReport;
        private Label label6;
        private Button btPicOpen;
        private Button btPicDelete;
        private PictureBox pictureBox1;
        private Button btAddReport;
        private PictureBox pbPicture;
        private Button btModifyReport;
        private Button btDeleteReport;
        private Label label7;
        private DataGridView dgvCarReport;
        private Button btReportOpen;
        private Button btReportSave;
        private OpenFileDialog ofdPicFileOpen;
    }
}
