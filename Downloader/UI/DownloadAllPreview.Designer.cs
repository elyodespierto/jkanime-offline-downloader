namespace Downloader.UI
{
    partial class DownloadAllPreview
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
            this.Status = new System.Windows.Forms.TextBox();
            this.PreviewGrid = new System.Windows.Forms.DataGridView();
            this.RememberGrid = new System.Windows.Forms.DataGridView();
            this.RememberSources = new System.Windows.Forms.CheckBox();
            this.AcceptSources = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RememberGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(540, 372);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status.Size = new System.Drawing.Size(339, 66);
            this.Status.TabIndex = 18;
            // 
            // PreviewGrid
            // 
            this.PreviewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PreviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviewGrid.Location = new System.Drawing.Point(13, 13);
            this.PreviewGrid.Name = "PreviewGrid";
            this.PreviewGrid.Size = new System.Drawing.Size(521, 425);
            this.PreviewGrid.TabIndex = 19;
            // 
            // RememberGrid
            // 
            this.RememberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RememberGrid.Location = new System.Drawing.Point(540, 13);
            this.RememberGrid.Name = "RememberGrid";
            this.RememberGrid.Size = new System.Drawing.Size(339, 287);
            this.RememberGrid.TabIndex = 20;
            // 
            // RememberSources
            // 
            this.RememberSources.AutoSize = true;
            this.RememberSources.Location = new System.Drawing.Point(540, 306);
            this.RememberSources.Name = "RememberSources";
            this.RememberSources.Size = new System.Drawing.Size(70, 17);
            this.RememberSources.TabIndex = 21;
            this.RememberSources.Text = "Recordar";
            this.RememberSources.UseVisualStyleBackColor = true;
            // 
            // AcceptSources
            // 
            this.AcceptSources.Location = new System.Drawing.Point(540, 343);
            this.AcceptSources.Name = "AcceptSources";
            this.AcceptSources.Size = new System.Drawing.Size(218, 23);
            this.AcceptSources.TabIndex = 22;
            this.AcceptSources.Text = "Aceptar";
            this.AcceptSources.UseVisualStyleBackColor = true;
            this.AcceptSources.Click += new System.EventHandler(this.AcceptSources_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.AutoSize = true;
            this.SelectAll.Location = new System.Drawing.Point(764, 306);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(115, 17);
            this.SelectAll.TabIndex = 23;
            this.SelectAll.Text = "Seleccionar Todos";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.CheckedChanged += new System.EventHandler(this.SelectAll_CheckedChanged);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(764, 343);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(115, 23);
            this.Cancel.TabIndex = 24;
            this.Cancel.Text = "Cancelar";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // DownloadAllPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.AcceptSources);
            this.Controls.Add(this.RememberSources);
            this.Controls.Add(this.RememberGrid);
            this.Controls.Add(this.PreviewGrid);
            this.Controls.Add(this.Status);
            this.Name = "DownloadAllPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Previa";
            this.Load += new System.EventHandler(this.DownloadAllPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RememberGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.DataGridView PreviewGrid;
        private System.Windows.Forms.DataGridView RememberGrid;
        private System.Windows.Forms.CheckBox RememberSources;
        private System.Windows.Forms.Button AcceptSources;
        private System.Windows.Forms.CheckBox SelectAll;
        private System.Windows.Forms.Button Cancel;
    }
}