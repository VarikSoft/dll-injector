namespace DLL_Injector
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textBoxProccesId = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.lableProccesID = new System.Windows.Forms.Label();
            this.injectFuncsGroup = new System.Windows.Forms.GroupBox();
            this.buttonClearDlls = new System.Windows.Forms.Button();
            this.buttonRemoveDll = new System.Windows.Forms.Button();
            this.buttonEnableDisable = new System.Windows.Forms.Button();
            this.listDlls = new System.Windows.Forms.ListBox();
            this.buttonAddDll = new System.Windows.Forms.Button();
            this.buttonInject = new System.Windows.Forms.Button();
            this.injectFuncsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxProccesId
            // 
            this.textBoxProccesId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProccesId.Enabled = false;
            this.textBoxProccesId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProccesId.Location = new System.Drawing.Point(18, 51);
            this.textBoxProccesId.Name = "textBoxProccesId";
            this.textBoxProccesId.Size = new System.Drawing.Size(311, 28);
            this.textBoxProccesId.TabIndex = 0;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(335, 51);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(57, 30);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // lableProccesID
            // 
            this.lableProccesID.AutoSize = true;
            this.lableProccesID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableProccesID.Location = new System.Drawing.Point(12, 9);
            this.lableProccesID.Name = "lableProccesID";
            this.lableProccesID.Size = new System.Drawing.Size(128, 32);
            this.lableProccesID.TabIndex = 2;
            this.lableProccesID.Text = "Process ID:";
            // 
            // injectFuncsGroup
            // 
            this.injectFuncsGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.injectFuncsGroup.Controls.Add(this.buttonClearDlls);
            this.injectFuncsGroup.Controls.Add(this.buttonRemoveDll);
            this.injectFuncsGroup.Controls.Add(this.buttonEnableDisable);
            this.injectFuncsGroup.Controls.Add(this.listDlls);
            this.injectFuncsGroup.Controls.Add(this.buttonAddDll);
            this.injectFuncsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectFuncsGroup.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.injectFuncsGroup.Location = new System.Drawing.Point(18, 85);
            this.injectFuncsGroup.Name = "injectFuncsGroup";
            this.injectFuncsGroup.Size = new System.Drawing.Size(374, 179);
            this.injectFuncsGroup.TabIndex = 3;
            this.injectFuncsGroup.TabStop = false;
            this.injectFuncsGroup.Text = "Inject Funcs";
            // 
            // buttonClearDlls
            // 
            this.buttonClearDlls.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearDlls.Location = new System.Drawing.Point(6, 139);
            this.buttonClearDlls.Name = "buttonClearDlls";
            this.buttonClearDlls.Size = new System.Drawing.Size(108, 26);
            this.buttonClearDlls.TabIndex = 7;
            this.buttonClearDlls.Text = "Clear List";
            this.buttonClearDlls.UseVisualStyleBackColor = true;
            this.buttonClearDlls.Click += new System.EventHandler(this.buttonClearDlls_Click);
            // 
            // buttonRemoveDll
            // 
            this.buttonRemoveDll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveDll.Location = new System.Drawing.Point(6, 107);
            this.buttonRemoveDll.Name = "buttonRemoveDll";
            this.buttonRemoveDll.Size = new System.Drawing.Size(108, 26);
            this.buttonRemoveDll.TabIndex = 6;
            this.buttonRemoveDll.Text = "Remove DLL";
            this.buttonRemoveDll.UseVisualStyleBackColor = true;
            this.buttonRemoveDll.Click += new System.EventHandler(this.buttonRemoveDll_Click);
            // 
            // buttonEnableDisable
            // 
            this.buttonEnableDisable.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnableDisable.Location = new System.Drawing.Point(6, 75);
            this.buttonEnableDisable.Name = "buttonEnableDisable";
            this.buttonEnableDisable.Size = new System.Drawing.Size(108, 26);
            this.buttonEnableDisable.TabIndex = 5;
            this.buttonEnableDisable.Text = "Enable/Disable";
            this.buttonEnableDisable.UseVisualStyleBackColor = true;
            this.buttonEnableDisable.Click += new System.EventHandler(this.buttonEnableDisable_Click);
            // 
            // listDlls
            // 
            this.listDlls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDlls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDlls.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listDlls.FormattingEnabled = true;
            this.listDlls.ItemHeight = 21;
            this.listDlls.Location = new System.Drawing.Point(120, 42);
            this.listDlls.Name = "listDlls";
            this.listDlls.Size = new System.Drawing.Size(248, 126);
            this.listDlls.TabIndex = 4;
            this.listDlls.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonAddDll
            // 
            this.buttonAddDll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDll.Location = new System.Drawing.Point(6, 44);
            this.buttonAddDll.Name = "buttonAddDll";
            this.buttonAddDll.Size = new System.Drawing.Size(108, 25);
            this.buttonAddDll.TabIndex = 0;
            this.buttonAddDll.Text = "Add DLL";
            this.buttonAddDll.UseVisualStyleBackColor = true;
            this.buttonAddDll.Click += new System.EventHandler(this.buttonAddDll_Click);
            // 
            // buttonInject
            // 
            this.buttonInject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInject.Location = new System.Drawing.Point(18, 270);
            this.buttonInject.Name = "buttonInject";
            this.buttonInject.Size = new System.Drawing.Size(374, 30);
            this.buttonInject.TabIndex = 8;
            this.buttonInject.Text = "Inject";
            this.buttonInject.UseVisualStyleBackColor = true;
            this.buttonInject.Click += new System.EventHandler(this.buttonInject_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(408, 316);
            this.Controls.Add(this.buttonInject);
            this.Controls.Add(this.injectFuncsGroup);
            this.Controls.Add(this.lableProccesID);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxProccesId);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(424, 355);
            this.MinimumSize = new System.Drawing.Size(424, 355);
            this.Name = "Main";
            this.Text = "DLL Injector";
            this.injectFuncsGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProccesId;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label lableProccesID;
        private System.Windows.Forms.GroupBox injectFuncsGroup;
        private System.Windows.Forms.ListBox listDlls;
        private System.Windows.Forms.Button buttonAddDll;
        private System.Windows.Forms.Button buttonClearDlls;
        private System.Windows.Forms.Button buttonRemoveDll;
        private System.Windows.Forms.Button buttonEnableDisable;
        private System.Windows.Forms.Button buttonInject;
    }
}

