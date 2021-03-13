namespace Downloader
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
            this.label2 = new System.Windows.Forms.Label();
            this.EpisodeFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AnimeName = new System.Windows.Forms.TextBox();
            this.SeasonTextBox = new System.Windows.Forms.TextBox();
            this.AddSource = new System.Windows.Forms.Button();
            this.IsLongSeason = new System.Windows.Forms.CheckBox();
            this.UpdateSource = new System.Windows.Forms.Button();
            this.DeleteSource = new System.Windows.Forms.Button();
            this.AddSlash = new System.Windows.Forms.CheckBox();
            this.EsArchivo = new System.Windows.Forms.CheckBox();
            this.EpisodeAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EsTemporada = new System.Windows.Forms.RadioButton();
            this.EsPelicula = new System.Windows.Forms.RadioButton();
            this.EsOva = new System.Windows.Forms.RadioButton();
            this.EsCapitulo = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.UrlPreview = new System.Windows.Forms.TextBox();
            this.Solo = new System.Windows.Forms.CheckBox();
            this.EpisodeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FileNamePreview = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Formato";
            // 
            // EpisodeFormat
            // 
            this.EpisodeFormat.Location = new System.Drawing.Point(206, 158);
            this.EpisodeFormat.Name = "EpisodeFormat";
            this.EpisodeFormat.Size = new System.Drawing.Size(37, 20);
            this.EpisodeFormat.TabIndex = 3;
            this.EpisodeFormat.Text = "00";
            this.EpisodeFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EpisodeFormat.TextChanged += new System.EventHandler(this.EpisodeFormat_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Anime:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nro";
            // 
            // AnimeName
            // 
            this.AnimeName.Location = new System.Drawing.Point(206, 181);
            this.AnimeName.Name = "AnimeName";
            this.AnimeName.Size = new System.Drawing.Size(151, 20);
            this.AnimeName.TabIndex = 6;
            // 
            // SeasonTextBox
            // 
            this.SeasonTextBox.Location = new System.Drawing.Point(206, 112);
            this.SeasonTextBox.Name = "SeasonTextBox";
            this.SeasonTextBox.Size = new System.Drawing.Size(37, 20);
            this.SeasonTextBox.TabIndex = 7;
            this.SeasonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddSource
            // 
            this.AddSource.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.AddSource.Location = new System.Drawing.Point(16, 257);
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
            this.IsLongSeason.Location = new System.Drawing.Point(313, 134);
            this.IsLongSeason.Name = "IsLongSeason";
            this.IsLongSeason.Size = new System.Drawing.Size(110, 17);
            this.IsLongSeason.TabIndex = 9;
            this.IsLongSeason.Text = "Temporada Larga";
            this.IsLongSeason.UseVisualStyleBackColor = true;
            this.IsLongSeason.CheckedChanged += new System.EventHandler(this.IsLongSeason_CheckedChanged);
            // 
            // UpdateSource
            // 
            this.UpdateSource.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UpdateSource.Location = new System.Drawing.Point(424, 257);
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
            this.DeleteSource.Location = new System.Drawing.Point(522, 257);
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
            this.AddSlash.Location = new System.Drawing.Point(449, 52);
            this.AddSlash.Name = "AddSlash";
            this.AddSlash.Size = new System.Drawing.Size(165, 17);
            this.AddSlash.TabIndex = 12;
            this.AddSlash.Text = "Agregar \"/\" antes del número";
            this.AddSlash.UseVisualStyleBackColor = true;
            // 
            // EsArchivo
            // 
            this.EsArchivo.AutoSize = true;
            this.EsArchivo.Location = new System.Drawing.Point(346, 52);
            this.EsArchivo.Name = "EsArchivo";
            this.EsArchivo.Size = new System.Drawing.Size(77, 17);
            this.EsArchivo.TabIndex = 15;
            this.EsArchivo.Text = "Es Archivo";
            this.EsArchivo.UseVisualStyleBackColor = true;
            // 
            // EpisodeAmount
            // 
            this.EpisodeAmount.Location = new System.Drawing.Point(206, 135);
            this.EpisodeAmount.Name = "EpisodeAmount";
            this.EpisodeAmount.Size = new System.Drawing.Size(37, 20);
            this.EpisodeAmount.TabIndex = 17;
            this.EpisodeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cantidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Link
            // 
            this.Link.Location = new System.Drawing.Point(12, 27);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(602, 20);
            this.Link.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Link";
            // 
            // EsTemporada
            // 
            this.EsTemporada.AutoSize = true;
            this.EsTemporada.Location = new System.Drawing.Point(12, 136);
            this.EsTemporada.Name = "EsTemporada";
            this.EsTemporada.Size = new System.Drawing.Size(79, 17);
            this.EsTemporada.TabIndex = 22;
            this.EsTemporada.TabStop = true;
            this.EsTemporada.Text = "Temporada";
            this.EsTemporada.UseVisualStyleBackColor = true;
            this.EsTemporada.CheckedChanged += new System.EventHandler(this.EsTemporada_CheckedChanged);
            // 
            // EsPelicula
            // 
            this.EsPelicula.AutoSize = true;
            this.EsPelicula.Location = new System.Drawing.Point(12, 159);
            this.EsPelicula.Name = "EsPelicula";
            this.EsPelicula.Size = new System.Drawing.Size(62, 17);
            this.EsPelicula.TabIndex = 23;
            this.EsPelicula.TabStop = true;
            this.EsPelicula.Text = "Pelicula";
            this.EsPelicula.UseVisualStyleBackColor = true;
            // 
            // EsOva
            // 
            this.EsOva.AutoSize = true;
            this.EsOva.Location = new System.Drawing.Point(12, 182);
            this.EsOva.Name = "EsOva";
            this.EsOva.Size = new System.Drawing.Size(45, 17);
            this.EsOva.TabIndex = 24;
            this.EsOva.TabStop = true;
            this.EsOva.Text = "Ova";
            this.EsOva.UseVisualStyleBackColor = true;
            // 
            // EsCapitulo
            // 
            this.EsCapitulo.AutoSize = true;
            this.EsCapitulo.Location = new System.Drawing.Point(12, 113);
            this.EsCapitulo.Name = "EsCapitulo";
            this.EsCapitulo.Size = new System.Drawing.Size(63, 17);
            this.EsCapitulo.TabIndex = 25;
            this.EsCapitulo.TabStop = true;
            this.EsCapitulo.Text = "Capitulo";
            this.EsCapitulo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Vista Previa:";
            // 
            // UrlPreview
            // 
            this.UrlPreview.Enabled = false;
            this.UrlPreview.Location = new System.Drawing.Point(12, 75);
            this.UrlPreview.Name = "UrlPreview";
            this.UrlPreview.Size = new System.Drawing.Size(602, 20);
            this.UrlPreview.TabIndex = 26;
            // 
            // Solo
            // 
            this.Solo.AutoSize = true;
            this.Solo.Location = new System.Drawing.Point(313, 114);
            this.Solo.Name = "Solo";
            this.Solo.Size = new System.Drawing.Size(70, 17);
            this.Solo.TabIndex = 27;
            this.Solo.Text = "Solo Uno";
            this.Solo.UseVisualStyleBackColor = true;
            // 
            // EpisodeName
            // 
            this.EpisodeName.Location = new System.Drawing.Point(442, 181);
            this.EpisodeName.Name = "EpisodeName";
            this.EpisodeName.Size = new System.Drawing.Size(172, 20);
            this.EpisodeName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Extra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Vista Previa:";
            // 
            // FileNamePreview
            // 
            this.FileNamePreview.Enabled = false;
            this.FileNamePreview.Location = new System.Drawing.Point(206, 204);
            this.FileNamePreview.Name = "FileNamePreview";
            this.FileNamePreview.Size = new System.Drawing.Size(408, 20);
            this.FileNamePreview.TabIndex = 26;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(343, 257);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 28;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // AddSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 293);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Solo);
            this.Controls.Add(this.FileNamePreview);
            this.Controls.Add(this.UrlPreview);
            this.Controls.Add(this.EpisodeAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EsCapitulo);
            this.Controls.Add(this.EpisodeFormat);
            this.Controls.Add(this.EsOva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EsPelicula);
            this.Controls.Add(this.SeasonTextBox);
            this.Controls.Add(this.EsTemporada);
            this.Controls.Add(this.IsLongSeason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.EsArchivo);
            this.Controls.Add(this.AddSlash);
            this.Controls.Add(this.DeleteSource);
            this.Controls.Add(this.UpdateSource);
            this.Controls.Add(this.AddSource);
            this.Controls.Add(this.EpisodeName);
            this.Controls.Add(this.AnimeName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "AddSourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.AddSourceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EpisodeFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AnimeName;
        private System.Windows.Forms.TextBox SeasonTextBox;
        private System.Windows.Forms.Button AddSource;
        private System.Windows.Forms.CheckBox IsLongSeason;
        private System.Windows.Forms.Button UpdateSource;
        private System.Windows.Forms.Button DeleteSource;
        private System.Windows.Forms.CheckBox AddSlash;
        private System.Windows.Forms.CheckBox EsArchivo;
        private System.Windows.Forms.TextBox EpisodeAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Link;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton EsTemporada;
        private System.Windows.Forms.RadioButton EsPelicula;
        private System.Windows.Forms.RadioButton EsOva;
        private System.Windows.Forms.RadioButton EsCapitulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UrlPreview;
        private System.Windows.Forms.CheckBox Solo;
        private System.Windows.Forms.TextBox EpisodeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FileNamePreview;
        private System.Windows.Forms.Button Update;
    }
}