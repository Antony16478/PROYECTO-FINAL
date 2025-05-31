namespace PlanificadorNutricionalIA
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox groupBoxResultado;
        private System.Windows.Forms.ListBox listBoxResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBienvenida = new Label();
            lblInstruccion = new Label();
            txtEntrada = new TextBox();
            btnGenerar = new Button();
            groupBoxResultado = new GroupBox();
            listBoxResultado = new ListBox();
            groupBoxResultado.SuspendLayout();
            SuspendLayout();
            
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(50, 20);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(408, 15);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido, soy tu asistente nutricionista IA, dime como puedo ayudarte? :D";
            
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(156, 64);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(261, 30);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "En este Apartado: escribe tu nombre, edad, peso\r\ny objetivo a cerca de lo que quieras lograr";
            
            txtEntrada.Location = new Point(50, 108);
            txtEntrada.Multiline = true;
            txtEntrada.Name = "txtEntrada";
            txtEntrada.Size = new Size(479, 70);
            txtEntrada.TabIndex = 2;
            
            btnGenerar.Location = new Point(250, 184);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(100, 30);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            
            groupBoxResultado.Controls.Add(listBoxResultado);
            groupBoxResultado.Location = new Point(50, 247);
            groupBoxResultado.Name = "groupBoxResultado";
            groupBoxResultado.Size = new Size(482, 248);
            groupBoxResultado.TabIndex = 4;
            groupBoxResultado.TabStop = false;
            groupBoxResultado.Text = "Resultados del asistente";
            groupBoxResultado.Enter += groupBoxResultado_Enter;
             
            listBoxResultado.Dock = DockStyle.Fill;
            listBoxResultado.FormattingEnabled = true;
            listBoxResultado.Location = new Point(3, 19);
            listBoxResultado.Name = "listBoxResultado";
            listBoxResultado.Size = new Size(476, 226);
            listBoxResultado.TabIndex = 0;
            
            ClientSize = new Size(607, 621);
            Controls.Add(groupBoxResultado);
            Controls.Add(btnGenerar);
            Controls.Add(txtEntrada);
            Controls.Add(lblInstruccion);
            Controls.Add(lblBienvenida);
            Name = "Form1";
            Text = "Planificador de Alimentación Saludable con IA";
            groupBoxResultado.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
