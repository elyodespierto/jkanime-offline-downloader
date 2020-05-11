namespace Downloader.UI
{
    partial class CopyForm
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
            this.CopyGrid = new System.Windows.Forms.DataGridView();
            this.Copy = new System.Windows.Forms.Button();
            this.SelectDestination = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.Label();
            this.SelectedToCopyGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AllFilesCount = new System.Windows.Forms.Label();
            this.SelectedFilesCount = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CopyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedToCopyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CopyGrid
            // 
            this.CopyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CopyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CopyGrid.Location = new System.Drawing.Point(12, 25);
            this.CopyGrid.Name = "CopyGrid";
            this.CopyGrid.Size = new System.Drawing.Size(609, 285);
            this.CopyGrid.TabIndex = 0;
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(808, 316);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(123, 23);
            this.Copy.TabIndex = 1;
            this.Copy.Text = "Copiar";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // SelectDestination
            // 
            this.SelectDestination.Location = new System.Drawing.Point(12, 316);
            this.SelectDestination.Name = "SelectDestination";
            this.SelectDestination.Size = new System.Drawing.Size(123, 23);
            this.SelectDestination.TabIndex = 2;
            this.SelectDestination.Text = "Seleccionar Destino";
            this.SelectDestination.UseVisualStyleBackColor = true;
            this.SelectDestination.Click += new System.EventHandler(this.SelectDestination_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Destino:";
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Location = new System.Drawing.Point(193, 321);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(10, 13);
            this.Destination.TabIndex = 4;
            this.Destination.Text = " ";
            // 
            // SelectedToCopyGrid
            // 
            this.SelectedToCopyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SelectedToCopyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectedToCopyGrid.Location = new System.Drawing.Point(627, 25);
            this.SelectedToCopyGrid.Name = "SelectedToCopyGrid";
            this.SelectedToCopyGrid.Size = new System.Drawing.Size(304, 285);
            this.SelectedToCopyGrid.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Todos los archivos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleccionados:";
            // 
            // AllFilesCount
            // 
            this.AllFilesCount.AutoSize = true;
            this.AllFilesCount.Location = new System.Drawing.Point(117, 9);
            this.AllFilesCount.Name = "AllFilesCount";
            this.AllFilesCount.Size = new System.Drawing.Size(10, 13);
            this.AllFilesCount.TabIndex = 6;
            this.AllFilesCount.Text = " ";
            // 
            // SelectedFilesCount
            // 
            this.SelectedFilesCount.AutoSize = true;
            this.SelectedFilesCount.Location = new System.Drawing.Point(707, 9);
            this.SelectedFilesCount.Name = "SelectedFilesCount";
            this.SelectedFilesCount.Size = new System.Drawing.Size(10, 13);
            this.SelectedFilesCount.TabIndex = 7;
            this.SelectedFilesCount.Text = " ";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(12, 345);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status.Size = new System.Drawing.Size(919, 96);
            this.Status.TabIndex = 17;
            // 
            // CopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 451);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.SelectedFilesCount);
            this.Controls.Add(this.AllFilesCount);
            this.Controls.Add(this.SelectedToCopyGrid);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectDestination);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.CopyGrid);
            this.Name = "CopyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CopyForm";
            this.Load += new System.EventHandler(this.CopyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CopyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedToCopyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CopyGrid;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button SelectDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.DataGridView SelectedToCopyGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AllFilesCount;
        private System.Windows.Forms.Label SelectedFilesCount;
        private System.Windows.Forms.TextBox Status;
    }
}