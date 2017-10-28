namespace Kadrovska_sluzba.Settings
{
    partial class ucGodisnjiOdmori
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtUpisiDana = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbZatvori = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtZatvoriDana = new DevExpress.XtraEditors.TextEdit();
            this.txtPrethodnaGodina = new DevExpress.XtraEditors.TextEdit();
            this.txtNovaGodina = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpisiDana.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZatvori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZatvoriDana.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrethodnaGodina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovaGodina.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Godišnji odmori";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(396, 346);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(98, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Zatvori/upiši";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtUpisiDana
            // 
            this.txtUpisiDana.EditValue = "0";
            this.txtUpisiDana.Location = new System.Drawing.Point(180, 245);
            this.txtUpisiDana.Name = "txtUpisiDana";
            this.txtUpisiDana.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUpisiDana.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtUpisiDana.Properties.Mask.EditMask = "f0";
            this.txtUpisiDana.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtUpisiDana.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUpisiDana.Size = new System.Drawing.Size(59, 20);
            this.txtUpisiDana.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(80, 248);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Upiši svim radnicima";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(245, 248);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(149, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "dana novog godišnjeg odmora.";
            // 
            // cbZatvori
            // 
            this.cbZatvori.EditValue = true;
            this.cbZatvori.Location = new System.Drawing.Point(80, 220);
            this.cbZatvori.Name = "cbZatvori";
            this.cbZatvori.Properties.Caption = "Zatvori sve neiskorištene dane godišnjeg odmora.";
            this.cbZatvori.Size = new System.Drawing.Size(278, 19);
            this.cbZatvori.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(80, 105);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Prethodna godina:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(80, 131);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Nova godina:";
            // 
            // txtZatvoriDana
            // 
            this.txtZatvoriDana.EditValue = "0";
            this.txtZatvoriDana.Enabled = false;
            this.txtZatvoriDana.Location = new System.Drawing.Point(348, 194);
            this.txtZatvoriDana.Name = "txtZatvoriDana";
            this.txtZatvoriDana.Properties.Appearance.Options.UseTextOptions = true;
            this.txtZatvoriDana.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtZatvoriDana.Properties.Mask.EditMask = "f0";
            this.txtZatvoriDana.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtZatvoriDana.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtZatvoriDana.Size = new System.Drawing.Size(59, 20);
            this.txtZatvoriDana.TabIndex = 10;
            // 
            // txtPrethodnaGodina
            // 
            this.txtPrethodnaGodina.EditValue = "2017";
            this.txtPrethodnaGodina.Location = new System.Drawing.Point(180, 102);
            this.txtPrethodnaGodina.Name = "txtPrethodnaGodina";
            this.txtPrethodnaGodina.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrethodnaGodina.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPrethodnaGodina.Properties.Mask.EditMask = "f0";
            this.txtPrethodnaGodina.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrethodnaGodina.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrethodnaGodina.Size = new System.Drawing.Size(59, 20);
            this.txtPrethodnaGodina.TabIndex = 11;
            // 
            // txtNovaGodina
            // 
            this.txtNovaGodina.EditValue = "2018";
            this.txtNovaGodina.Location = new System.Drawing.Point(180, 128);
            this.txtNovaGodina.Name = "txtNovaGodina";
            this.txtNovaGodina.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNovaGodina.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtNovaGodina.Properties.Mask.EditMask = "f0";
            this.txtNovaGodina.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNovaGodina.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNovaGodina.Size = new System.Drawing.Size(59, 20);
            this.txtNovaGodina.TabIndex = 12;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(81, 197);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(245, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Radnici imaju neiskorištenih dana godišnjeg odmora";
            // 
            // ucGodisnjiOdmori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtNovaGodina);
            this.Controls.Add(this.txtPrethodnaGodina);
            this.Controls.Add(this.txtZatvoriDana);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cbZatvori);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtUpisiDana);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucGodisnjiOdmori";
            this.Size = new System.Drawing.Size(544, 471);
            this.Load += new System.EventHandler(this.ucGodisnjiOdmori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUpisiDana.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZatvori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZatvoriDana.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrethodnaGodina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNovaGodina.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtUpisiDana;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit cbZatvori;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtZatvoriDana;
        private DevExpress.XtraEditors.TextEdit txtPrethodnaGodina;
        private DevExpress.XtraEditors.TextEdit txtNovaGodina;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
