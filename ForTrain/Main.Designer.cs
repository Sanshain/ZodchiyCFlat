namespace ForTrain
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MAP = new System.Windows.Forms.PictureBox();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolLine = new System.Windows.Forms.ToolStripButton();
            this.toolCircle = new System.Windows.Forms.ToolStripButton();
            this.toolStripRect = new System.Windows.Forms.ToolStripButton();
            this.toolStripText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripCut = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mOpen = new System.Windows.Forms.ToolStripButton();
            this.undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.RedLight = new System.Windows.Forms.ToolStripButton();
            this.BlueLight = new System.Windows.Forms.ToolStripButton();
            this.BlackLight = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxWidth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mMAP_XZ = new System.Windows.Forms.ToolStripButton();
            this.mMAP_YZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MAP_XZ = new System.Windows.Forms.PictureBox();
            this.MAP_YZ = new System.Windows.Forms.PictureBox();
            this.toolActes = new System.Windows.Forms.ToolStrip();
            this.toolMove = new System.Windows.Forms.ToolStripButton();
            this.toolCopy = new System.Windows.Forms.ToolStripButton();
            this.TPaint = new System.Windows.Forms.ToolStripButton();
            this.mSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.MAP)).BeginInit();
            this.toolStripTools.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MAP_XZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MAP_YZ)).BeginInit();
            this.toolActes.SuspendLayout();
            this.SuspendLayout();
            // 
            // MAP
            // 
            this.MAP.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MAP.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MAP.Location = new System.Drawing.Point(33, 109);
            this.MAP.Name = "MAP";
            this.MAP.Size = new System.Drawing.Size(639, 402);
            this.MAP.TabIndex = 0;
            this.MAP.TabStop = false;
            this.MAP.Paint += new System.Windows.Forms.PaintEventHandler(this.MAP_Paint);
            this.MAP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseDown);
            this.MAP.MouseEnter += new System.EventHandler(this.MAP_MouseEnter);
            this.MAP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseMove);
            this.MAP.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseWheel);
            this.MAP.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MAP_PreviewKeyDown);
            // 
            // toolStripTools
            // 
            this.toolStripTools.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLine,
            this.toolCircle,
            this.toolStripRect,
            this.toolStripText,
            this.toolStripButtonSelection,
            this.toolStripCut});
            this.toolStripTools.Location = new System.Drawing.Point(0, 24);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(768, 25);
            this.toolStripTools.TabIndex = 1;
            this.toolStripTools.Text = "toolStrip1";
            // 
            // toolLine
            // 
            this.toolLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLine.Image = ((System.Drawing.Image)(resources.GetObject("toolLine.Image")));
            this.toolLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(23, 22);
            this.toolLine.Text = "toolStripButton1";
            this.toolLine.ToolTipText = "Нарисовать линию";
            this.toolLine.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolCircle.Image")));
            this.toolCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(23, 22);
            this.toolCircle.Text = "toolStripButton1";
            this.toolCircle.ToolTipText = "Окружность";
            this.toolCircle.Click += new System.EventHandler(this.toolCircle_Click);
            // 
            // toolStripRect
            // 
            this.toolStripRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRect.Image")));
            this.toolStripRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRect.Name = "toolStripRect";
            this.toolStripRect.Size = new System.Drawing.Size(23, 22);
            this.toolStripRect.Text = "Прямоугольник";
            this.toolStripRect.Click += new System.EventHandler(this.toolStripRect_Click);
            // 
            // toolStripText
            // 
            this.toolStripText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripText.Image")));
            this.toolStripText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripText.Name = "toolStripText";
            this.toolStripText.Size = new System.Drawing.Size(23, 22);
            this.toolStripText.Text = "Текст";
            this.toolStripText.Click += new System.EventHandler(this.toolStripText_Click);
            // 
            // toolStripButtonSelection
            // 
            this.toolStripButtonSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelection.Image")));
            this.toolStripButtonSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelection.Name = "toolStripButtonSelection";
            this.toolStripButtonSelection.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSelection.Text = "toolStripButton1";
            this.toolStripButtonSelection.Click += new System.EventHandler(this.toolStripButtonSelection_Click);
            // 
            // toolStripCut
            // 
            this.toolStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCut.Image")));
            this.toolStripCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCut.Name = "toolStripCut";
            this.toolStripCut.Size = new System.Drawing.Size(23, 22);
            this.toolStripCut.Text = "Сечение";
            this.toolStripCut.Click += new System.EventHandler(this.toolStripCut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpen,
            this.mSave,
            this.undoToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(768, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mOpen
            // 
            this.mOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mOpen.Image = ((System.Drawing.Image)(resources.GetObject("mOpen.Image")));
            this.mOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mOpen.Name = "mOpen";
            this.mOpen.Size = new System.Drawing.Size(23, 22);
            this.mOpen.Text = "toolStripButton1";
            this.mOpen.ToolTipText = "Открыть";
            this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
            // 
            // undoToolStripButton
            // 
            this.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripButton.Image")));
            this.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripButton.Name = "undoToolStripButton";
            this.undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoToolStripButton.Text = "toolStripButton1";
            this.undoToolStripButton.Click += new System.EventHandler(this.undoToolStripButton_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedLight,
            this.BlueLight,
            this.BlackLight,
            this.toolStripComboBoxWidth,
            this.toolStripSeparator1,
            this.mMAP_XZ,
            this.mMAP_YZ,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(699, 74);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(69, 437);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // RedLight
            // 
            this.RedLight.AutoSize = false;
            this.RedLight.BackColor = System.Drawing.Color.Red;
            this.RedLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedLight.ForeColor = System.Drawing.Color.Red;
            this.RedLight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RedLight.ImageTransparentColor = System.Drawing.Color.BlueViolet;
            this.RedLight.Name = "RedLight";
            this.RedLight.Size = new System.Drawing.Size(14, 14);
            this.RedLight.Text = "toolStripButton1";
            this.RedLight.Click += new System.EventHandler(this.RedLight_Click);
            // 
            // BlueLight
            // 
            this.BlueLight.AutoSize = false;
            this.BlueLight.BackColor = System.Drawing.Color.Blue;
            this.BlueLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BlueLight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BlueLight.Name = "BlueLight";
            this.BlueLight.Size = new System.Drawing.Size(14, 14);
            this.BlueLight.Text = "toolStripButton1";
            this.BlueLight.Click += new System.EventHandler(this.RedLight_Click);
            // 
            // BlackLight
            // 
            this.BlackLight.AutoSize = false;
            this.BlackLight.BackColor = System.Drawing.Color.Black;
            this.BlackLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BlackLight.ForeColor = System.Drawing.Color.Red;
            this.BlackLight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BlackLight.ImageTransparentColor = System.Drawing.Color.BlueViolet;
            this.BlackLight.Name = "BlackLight";
            this.BlackLight.Size = new System.Drawing.Size(14, 14);
            this.BlackLight.Text = "toolStripButton1";
            this.BlackLight.Click += new System.EventHandler(this.RedLight_Click);
            // 
            // toolStripComboBoxWidth
            // 
            this.toolStripComboBoxWidth.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripComboBoxWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxWidth.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxWidth.Items.AddRange(new object[] {
            "1p",
            "2p",
            "3p",
            "4p"});
            this.toolStripComboBoxWidth.Name = "toolStripComboBoxWidth";
            this.toolStripComboBoxWidth.Size = new System.Drawing.Size(65, 23);
            this.toolStripComboBoxWidth.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxWidth_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(67, 6);
            // 
            // mMAP_XZ
            // 
            this.mMAP_XZ.Image = ((System.Drawing.Image)(resources.GetObject("mMAP_XZ.Image")));
            this.mMAP_XZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mMAP_XZ.Name = "mMAP_XZ";
            this.mMAP_XZ.Size = new System.Drawing.Size(67, 20);
            this.mMAP_XZ.Text = "XZ";
            this.mMAP_XZ.MouseEnter += new System.EventHandler(this.mMAP_XZ_MouseEnter);
            this.mMAP_XZ.MouseLeave += new System.EventHandler(this.mMAP_XZ_MouseLeave);
            // 
            // mMAP_YZ
            // 
            this.mMAP_YZ.Image = ((System.Drawing.Image)(resources.GetObject("mMAP_YZ.Image")));
            this.mMAP_YZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mMAP_YZ.Name = "mMAP_YZ";
            this.mMAP_YZ.Size = new System.Drawing.Size(67, 20);
            this.mMAP_YZ.Text = "YZ";
            this.mMAP_YZ.Click += new System.EventHandler(this.mMAP_YZ_Click);
            this.mMAP_YZ.MouseEnter += new System.EventHandler(this.mMAP_YZ_MouseEnter);
            this.mMAP_YZ.MouseLeave += new System.EventHandler(this.mMAP_YZ_MouseLeave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(67, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(67, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // MAP_XZ
            // 
            this.MAP_XZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MAP_XZ.Location = new System.Drawing.Point(678, 167);
            this.MAP_XZ.Name = "MAP_XZ";
            this.MAP_XZ.Size = new System.Drawing.Size(18, 15);
            this.MAP_XZ.TabIndex = 6;
            this.MAP_XZ.TabStop = false;
            this.MAP_XZ.Visible = false;
            this.MAP_XZ.Paint += new System.Windows.Forms.PaintEventHandler(this.MAP_XZ_Paint);
            // 
            // MAP_YZ
            // 
            this.MAP_YZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MAP_YZ.Location = new System.Drawing.Point(678, 188);
            this.MAP_YZ.Name = "MAP_YZ";
            this.MAP_YZ.Size = new System.Drawing.Size(19, 17);
            this.MAP_YZ.TabIndex = 7;
            this.MAP_YZ.TabStop = false;
            this.MAP_YZ.Visible = false;
            this.MAP_YZ.Paint += new System.Windows.Forms.PaintEventHandler(this.MAP_YZ_Paint);
            // 
            // toolActes
            // 
            this.toolActes.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolActes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMove,
            this.toolCopy,
            this.TPaint});
            this.toolActes.Location = new System.Drawing.Point(0, 74);
            this.toolActes.Name = "toolActes";
            this.toolActes.Size = new System.Drawing.Size(24, 415);
            this.toolActes.TabIndex = 8;
            this.toolActes.Text = "toolStrip3";
            // 
            // toolMove
            // 
            this.toolMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMove.Image = ((System.Drawing.Image)(resources.GetObject("toolMove.Image")));
            this.toolMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMove.Name = "toolMove";
            this.toolMove.Size = new System.Drawing.Size(21, 20);
            this.toolMove.Text = "toolStripButton1";
            this.toolMove.ToolTipText = "Перемещение";
            this.toolMove.Click += new System.EventHandler(this.toolMove_Click);
            // 
            // toolCopy
            // 
            this.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolCopy.Image")));
            this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopy.Name = "toolCopy";
            this.toolCopy.Size = new System.Drawing.Size(21, 20);
            this.toolCopy.Text = "toolStripButton1";
            this.toolCopy.Click += new System.EventHandler(this.toolCopy_Click);
            // 
            // TPaint
            // 
            this.TPaint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TPaint.Image = ((System.Drawing.Image)(resources.GetObject("TPaint.Image")));
            this.TPaint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TPaint.Name = "TPaint";
            this.TPaint.Size = new System.Drawing.Size(21, 20);
            this.TPaint.Text = "Вертикально-горизонтальное черчение";
            this.TPaint.Click += new System.EventHandler(this.TPaint_Click);
            // 
            // mSave
            // 
            this.mSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mSave.Image = ((System.Drawing.Image)(resources.GetObject("mSave.Image")));
            this.mSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mSave.Name = "mSave";
            this.mSave.Size = new System.Drawing.Size(23, 22);
            this.mSave.Text = "Сохранить";
            this.mSave.Click += new System.EventHandler(this.mSave_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(768, 511);
            this.Controls.Add(this.toolActes);
            this.Controls.Add(this.MAP_YZ);
            this.Controls.Add(this.MAP_XZ);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStripTools);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MAP);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Train";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MAP)).EndInit();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MAP_XZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MAP_YZ)).EndInit();
            this.toolActes.ResumeLayout(false);
            this.toolActes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion
        
        private System.Windows.Forms.PictureBox MAP;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton toolLine;
        private System.Windows.Forms.ToolStripButton toolCircle;
        private System.Windows.Forms.ToolStripButton toolStripRect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mOpen;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton RedLight;
        private System.Windows.Forms.ToolStripButton BlueLight;
        private System.Windows.Forms.ToolStripButton BlackLight;
        private System.Windows.Forms.ToolStripButton undoToolStripButton;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripText;
        private System.Windows.Forms.PictureBox MAP_XZ;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mMAP_XZ;
        private System.Windows.Forms.ToolStripButton mMAP_YZ;
        private System.Windows.Forms.PictureBox MAP_YZ;
        private System.Windows.Forms.ToolStrip toolActes;
        private System.Windows.Forms.ToolStripButton toolMove;
        private System.Windows.Forms.ToolStripButton toolCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripCut;
        private System.Windows.Forms.ToolStripButton TPaint;
        private System.Windows.Forms.ToolStripButton mSave;
    }
}

