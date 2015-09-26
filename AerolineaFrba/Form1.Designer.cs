namespace AerolineaFrba
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ingresar = new System.Windows.Forms.Button();
            this.textoUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textoPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Ingresar
            // 
            this.Ingresar.Location = new System.Drawing.Point(138, 173);
            this.Ingresar.Name = "Ingresar";
            this.Ingresar.Size = new System.Drawing.Size(100, 23);
            this.Ingresar.TabIndex = 0;
            this.Ingresar.Text = "Ingresar";
            this.Ingresar.UseVisualStyleBackColor = true;
            this.Ingresar.Click += new System.EventHandler(this.Ingresar_click);
            // 
            // textoUsuario
            // 
            this.textoUsuario.Location = new System.Drawing.Point(138, 79);
            this.textoUsuario.Name = "textoUsuario";
            this.textoUsuario.Size = new System.Drawing.Size(100, 20);
            this.textoUsuario.TabIndex = 1;
            this.textoUsuario.TextChanged += new System.EventHandler(this.textoUsuario_TextChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(61, 86);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(61, 128);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(53, 13);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Password";
            // 
            // textoPass
            // 
            this.textoPass.Location = new System.Drawing.Point(138, 121);
            this.textoPass.Name = "textoPass";
            this.textoPass.Size = new System.Drawing.Size(100, 20);
            this.textoPass.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 262);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textoPass);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textoUsuario);
            this.Controls.Add(this.Ingresar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ingresar;
        private System.Windows.Forms.TextBox textoUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textoPass;
    }
}

