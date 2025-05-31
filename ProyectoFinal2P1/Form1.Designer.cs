namespace ProyectoFinal2P1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.btnInvestigar = new System.Windows.Forms.Button();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.btnCargarHistorial = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPregunta
            // 
            this.txtPregunta.Location = new System.Drawing.Point(63, 72);
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(142, 22);
            this.txtPregunta.TabIndex = 0;
            this.txtPregunta.TextChanged += new System.EventHandler(this.txtPregunta_TextChanged);
            // 
            // btnInvestigar
            // 
            this.btnInvestigar.Location = new System.Drawing.Point(211, 63);
            this.btnInvestigar.Name = "btnInvestigar";
            this.btnInvestigar.Size = new System.Drawing.Size(120, 31);
            this.btnInvestigar.TabIndex = 1;
            this.btnInvestigar.Text = "Investigar";
            this.btnInvestigar.UseVisualStyleBackColor = true;
            this.btnInvestigar.Click += new System.EventHandler(this.btnInvestigar_Click);
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(63, 120);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(501, 199);
            this.txtRespuesta.TabIndex = 2;
            this.txtRespuesta.TextChanged += new System.EventHandler(this.txtRespuesta_TextChanged);
            // 
            // btnCargarHistorial
            // 
            this.btnCargarHistorial.Location = new System.Drawing.Point(602, 71);
            this.btnCargarHistorial.Name = "btnCargarHistorial";
            this.btnCargarHistorial.Size = new System.Drawing.Size(137, 23);
            this.btnCargarHistorial.TabIndex = 3;
            this.btnCargarHistorial.Text = "Ver historial";
            this.btnCargarHistorial.UseVisualStyleBackColor = true;
            this.btnCargarHistorial.Click += new System.EventHandler(this.btnCargarHistorial_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(602, 120);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.RowTemplate.Height = 24;
            this.dgvHistorial.Size = new System.Drawing.Size(550, 199);
            this.dgvHistorial.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumOrchid;
            this.label1.Location = new System.Drawing.Point(60, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingresar investigación";
            // 
            // btnExportarWord
            // 
            this.btnExportarWord.Location = new System.Drawing.Point(602, 342);
            this.btnExportarWord.Name = "btnExportarWord";
            this.btnExportarWord.Size = new System.Drawing.Size(149, 23);
            this.btnExportarWord.TabIndex = 6;
            this.btnExportarWord.Text = "Exportar a Word";
            this.btnExportarWord.UseVisualStyleBackColor = true;
            this.btnExportarWord.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoFinal2P1.Properties.Resources.Minimalist_Background_HD;
            this.ClientSize = new System.Drawing.Size(1283, 467);
            this.Controls.Add(this.btnExportarWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnCargarHistorial);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.btnInvestigar);
            this.Controls.Add(this.txtPregunta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.Button btnInvestigar;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Button btnCargarHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarWord;
    }
}

