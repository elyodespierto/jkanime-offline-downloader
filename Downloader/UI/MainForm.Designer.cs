namespace Downloader
{
    partial class MainForm
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
            this.Download = new System.Windows.Forms.Button();
            this.URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.TextBox();
            this.FolderNameLabel = new System.Windows.Forms.Label();
            this.FolderName = new System.Windows.Forms.TextBox();
            this.SelectDestinButton = new System.Windows.Forms.Button();
            this.SelectedFolder = new System.Windows.Forms.Label();
            this.URLCombo = new System.Windows.Forms.ComboBox();
            this.AddConfig = new System.Windows.Forms.Button();
            this.CancelCurrentDownload = new System.Windows.Forms.Button();
            this.SetAsDefault = new System.Windows.Forms.CheckBox();
            this.Status = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FinalDestination = new System.Windows.Forms.Label();
            this.DownloadAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Download
            // 
            this.Download.BackColor = System.Drawing.Color.Honeydew;
            this.Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Download.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Download.Location = new System.Drawing.Point(12, 228);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(110, 23);
            this.Download.TabIndex = 0;
            this.Download.Text = "Descargar";
            this.Download.UseVisualStyleBackColor = false;
            this.Download.Click += new System.EventHandler(this.ButtonDownload_Click);
            // 
            // URL
            // 
            this.URL.Enabled = false;
            this.URL.Location = new System.Drawing.Point(12, 56);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(485, 20);
            this.URL.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desde";
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(12, 105);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(35, 20);
            this.From.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta";
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(53, 105);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(35, 20);
            this.To.TabIndex = 7;
            // 
            // FolderNameLabel
            // 
            this.FolderNameLabel.AutoSize = true;
            this.FolderNameLabel.Location = new System.Drawing.Point(153, 89);
            this.FolderNameLabel.Name = "FolderNameLabel";
            this.FolderNameLabel.Size = new System.Drawing.Size(84, 13);
            this.FolderNameLabel.TabIndex = 8;
            this.FolderNameLabel.Text = "Nombre Carpeta";
            // 
            // FolderName
            // 
            this.FolderName.Enabled = false;
            this.FolderName.Location = new System.Drawing.Point(156, 105);
            this.FolderName.Name = "FolderName";
            this.FolderName.Size = new System.Drawing.Size(115, 20);
            this.FolderName.TabIndex = 9;
            this.FolderName.TextChanged += new System.EventHandler(this.FolderNameTextBox_TextChanged);
            // 
            // SelectDestinButton
            // 
            this.SelectDestinButton.Location = new System.Drawing.Point(12, 140);
            this.SelectDestinButton.Name = "SelectDestinButton";
            this.SelectDestinButton.Size = new System.Drawing.Size(134, 23);
            this.SelectDestinButton.TabIndex = 10;
            this.SelectDestinButton.Text = "Seleccionar Destino";
            this.SelectDestinButton.UseVisualStyleBackColor = true;
            this.SelectDestinButton.Click += new System.EventHandler(this.SelectDestinButton_Click);
            // 
            // SelectedFolder
            // 
            this.SelectedFolder.AutoSize = true;
            this.SelectedFolder.Location = new System.Drawing.Point(152, 145);
            this.SelectedFolder.Name = "SelectedFolder";
            this.SelectedFolder.Size = new System.Drawing.Size(13, 13);
            this.SelectedFolder.TabIndex = 11;
            this.SelectedFolder.Text = "  ";
            // 
            // URLCombo
            // 
            this.URLCombo.FormattingEnabled = true;
            this.URLCombo.Location = new System.Drawing.Point(12, 12);
            this.URLCombo.Name = "URLCombo";
            this.URLCombo.Size = new System.Drawing.Size(394, 21);
            this.URLCombo.TabIndex = 12;
            this.URLCombo.SelectedIndexChanged += new System.EventHandler(this.URLSelectionComboBox_SelectedIndexChanged);
            // 
            // AddConfig
            // 
            this.AddConfig.Location = new System.Drawing.Point(412, 12);
            this.AddConfig.Name = "AddConfig";
            this.AddConfig.Size = new System.Drawing.Size(85, 21);
            this.AddConfig.TabIndex = 13;
            this.AddConfig.Text = "Configurar";
            this.AddConfig.UseVisualStyleBackColor = true;
            this.AddConfig.Click += new System.EventHandler(this.AddConfigButton_Click);
            // 
            // CancelCurrentDownload
            // 
            this.CancelCurrentDownload.BackColor = System.Drawing.Color.LightCoral;
            this.CancelCurrentDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelCurrentDownload.Location = new System.Drawing.Point(387, 200);
            this.CancelCurrentDownload.Name = "CancelCurrentDownload";
            this.CancelCurrentDownload.Size = new System.Drawing.Size(110, 23);
            this.CancelCurrentDownload.TabIndex = 14;
            this.CancelCurrentDownload.Text = "Cancelar Descarga";
            this.CancelCurrentDownload.UseVisualStyleBackColor = false;
            this.CancelCurrentDownload.Click += new System.EventHandler(this.CancelCurrentDownload_Click);
            // 
            // SetAsDefault
            // 
            this.SetAsDefault.AutoSize = true;
            this.SetAsDefault.Location = new System.Drawing.Point(12, 169);
            this.SetAsDefault.Name = "SetAsDefault";
            this.SetAsDefault.Size = new System.Drawing.Size(179, 17);
            this.SetAsDefault.TabIndex = 15;
            this.SetAsDefault.Text = "Establecer destino como Default";
            this.SetAsDefault.UseVisualStyleBackColor = true;
            this.SetAsDefault.CheckedChanged += new System.EventHandler(this.SetAsDefaultCheckBox_CheckedChanged);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(12, 257);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status.Size = new System.Drawing.Size(485, 96);
            this.Status.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Destino Final:";
            // 
            // FinalDestination
            // 
            this.FinalDestination.AutoSize = true;
            this.FinalDestination.Location = new System.Drawing.Point(86, 200);
            this.FinalDestination.Name = "FinalDestination";
            this.FinalDestination.Size = new System.Drawing.Size(13, 13);
            this.FinalDestination.TabIndex = 11;
            this.FinalDestination.Text = "  ";
            // 
            // DownloadAll
            // 
            this.DownloadAll.BackColor = System.Drawing.Color.DarkGreen;
            this.DownloadAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DownloadAll.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadAll.Location = new System.Drawing.Point(388, 171);
            this.DownloadAll.Name = "DownloadAll";
            this.DownloadAll.Size = new System.Drawing.Size(109, 23);
            this.DownloadAll.TabIndex = 17;
            this.DownloadAll.Text = "Descargar Todo";
            this.DownloadAll.UseVisualStyleBackColor = false;
            this.DownloadAll.Click += new System.EventHandler(this.DownloadAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cantidad";
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(94, 105);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(35, 20);
            this.Amount.TabIndex = 18;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(387, 228);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(110, 23);
            this.Close.TabIndex = 19;
            this.Close.Text = "Cerrar";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Copy
            // 
            this.Copy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Copy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Copy.Location = new System.Drawing.Point(388, 142);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(109, 23);
            this.Copy.TabIndex = 20;
            this.Copy.Text = "Copiar";
            this.Copy.UseVisualStyleBackColor = false;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 365);
            this.ControlBox = false;
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.DownloadAll);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.SetAsDefault);
            this.Controls.Add(this.CancelCurrentDownload);
            this.Controls.Add(this.AddConfig);
            this.Controls.Add(this.URLCombo);
            this.Controls.Add(this.FinalDestination);
            this.Controls.Add(this.SelectedFolder);
            this.Controls.Add(this.SelectDestinButton);
            this.Controls.Add(this.FolderName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FolderNameLabel);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.From);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.Download);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox From;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox To;
        private System.Windows.Forms.Label FolderNameLabel;
        private System.Windows.Forms.TextBox FolderName;
        private System.Windows.Forms.Button SelectDestinButton;
        private System.Windows.Forms.Label SelectedFolder;
        private System.Windows.Forms.ComboBox URLCombo;
        private System.Windows.Forms.Button AddConfig;
        private System.Windows.Forms.Button CancelCurrentDownload;
        private System.Windows.Forms.CheckBox SetAsDefault;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FinalDestination;
        private System.Windows.Forms.Button DownloadAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Amount;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Copy;
    }
}

