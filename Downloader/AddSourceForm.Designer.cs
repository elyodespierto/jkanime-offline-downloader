﻿namespace Downloader
{
    partial class AddSourceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.URL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EpisodeFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SeasonTextBox = new System.Windows.Forms.TextBox();
            this.AddSource = new System.Windows.Forms.Button();
            this.IsLongSeason = new System.Windows.Forms.CheckBox();
            this.UpdateSource = new System.Windows.Forms.Button();
            this.DeleteSource = new System.Windows.Forms.Button();
            this.AddSlash = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FinalURL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // URL
            // 
            this.URL.Location = new System.Drawing.Point(48, 10);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(566, 20);
            this.URL.TabIndex = 1;
            this.URL.TextChanged += new System.EventHandler(this.URL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Formato";
            // 
            // EpisodeFormat
            // 
            this.EpisodeFormat.Location = new System.Drawing.Point(64, 41);
            this.EpisodeFormat.Name = "EpisodeFormat";
            this.EpisodeFormat.Size = new System.Drawing.Size(28, 20);
            this.EpisodeFormat.TabIndex = 3;
            this.EpisodeFormat.Text = "00";
            this.EpisodeFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EpisodeFormat.TextChanged += new System.EventHandler(this.EpisodeFormat_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Temporada";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(413, 41);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(201, 20);
            this.NameTextBox.TabIndex = 6;
            // 
            // SeasonTextBox
            // 
            this.SeasonTextBox.Location = new System.Drawing.Point(80, 100);
            this.SeasonTextBox.Name = "SeasonTextBox";
            this.SeasonTextBox.Size = new System.Drawing.Size(28, 20);
            this.SeasonTextBox.TabIndex = 7;
            this.SeasonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddSource
            // 
            this.AddSource.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.AddSource.Location = new System.Drawing.Point(16, 143);
            this.AddSource.Name = "AddSource";
            this.AddSource.Size = new System.Drawing.Size(92, 23);
            this.AddSource.TabIndex = 8;
            this.AddSource.Text = "Agregar";
            this.AddSource.UseVisualStyleBackColor = false;
            this.AddSource.Click += new System.EventHandler(this.AddSource_Click);
            // 
            // IsLongSeason
            // 
            this.IsLongSeason.AutoSize = true;
            this.IsLongSeason.Location = new System.Drawing.Point(123, 102);
            this.IsLongSeason.Name = "IsLongSeason";
            this.IsLongSeason.Size = new System.Drawing.Size(125, 17);
            this.IsLongSeason.TabIndex = 9;
            this.IsLongSeason.Text = "Es Temporada Larga";
            this.IsLongSeason.UseVisualStyleBackColor = true;
            // 
            // UpdateSource
            // 
            this.UpdateSource.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UpdateSource.Location = new System.Drawing.Point(424, 143);
            this.UpdateSource.Name = "UpdateSource";
            this.UpdateSource.Size = new System.Drawing.Size(92, 23);
            this.UpdateSource.TabIndex = 10;
            this.UpdateSource.Text = "Modificar";
            this.UpdateSource.UseVisualStyleBackColor = false;
            this.UpdateSource.Click += new System.EventHandler(this.UpdateSource_Click);
            // 
            // DeleteSource
            // 
            this.DeleteSource.BackColor = System.Drawing.Color.RosyBrown;
            this.DeleteSource.Location = new System.Drawing.Point(522, 143);
            this.DeleteSource.Name = "DeleteSource";
            this.DeleteSource.Size = new System.Drawing.Size(92, 23);
            this.DeleteSource.TabIndex = 11;
            this.DeleteSource.Text = "Eliminar";
            this.DeleteSource.UseVisualStyleBackColor = false;
            this.DeleteSource.Click += new System.EventHandler(this.DeleteSource_Click);
            // 
            // AddSlash
            // 
            this.AddSlash.AutoSize = true;
            this.AddSlash.Location = new System.Drawing.Point(108, 43);
            this.AddSlash.Name = "AddSlash";
            this.AddSlash.Size = new System.Drawing.Size(165, 17);
            this.AddSlash.TabIndex = 12;
            this.AddSlash.Text = "Agregar \"/\" antes del número";
            this.AddSlash.UseVisualStyleBackColor = true;
            this.AddSlash.CheckedChanged += new System.EventHandler(this.AddSlash_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "URL Final:";
            // 
            // FinalURL
            // 
            this.FinalURL.AutoSize = true;
            this.FinalURL.Location = new System.Drawing.Point(76, 74);
            this.FinalURL.Name = "FinalURL";
            this.FinalURL.Size = new System.Drawing.Size(13, 13);
            this.FinalURL.TabIndex = 13;
            this.FinalURL.Text = "  ";
            // 
            // AddSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 178);
            this.Controls.Add(this.FinalURL);
            this.Controls.Add(this.AddSlash);
            this.Controls.Add(this.DeleteSource);
            this.Controls.Add(this.UpdateSource);
            this.Controls.Add(this.IsLongSeason);
            this.Controls.Add(this.AddSource);
            this.Controls.Add(this.SeasonTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EpisodeFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AddSourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.AddSourceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EpisodeFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox SeasonTextBox;
        private System.Windows.Forms.Button AddSource;
        private System.Windows.Forms.CheckBox IsLongSeason;
        private System.Windows.Forms.Button UpdateSource;
        private System.Windows.Forms.Button DeleteSource;
        private System.Windows.Forms.CheckBox AddSlash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label FinalURL;
    }
}