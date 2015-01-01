namespace puzzle_8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.cmd_derecha = new System.Windows.Forms.Button();
            this.cmd_izquierda = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolverJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarSolucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblnotificacion = new System.Windows.Forms.Label();
            this.Tresolucion = new System.Windows.Forms.Timer(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblcontador_movimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbltiempo_transcurrido = new System.Windows.Forms.ToolStripMenuItem();
            this.Ttrascurrido = new System.Windows.Forms.Timer(this.components);
            this.BarraProgreso = new System.Windows.Forms.ProgressBar();
            this.ListaDetallesSolucion = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(89, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 68);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Std Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "PUZZLE UDB ";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(170, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 68);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Tag = "2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(251, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 68);
            this.button3.TabIndex = 3;
            this.button3.TabStop = false;
            this.button3.Tag = "3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(170, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 68);
            this.button4.TabIndex = 4;
            this.button4.TabStop = false;
            this.button4.Tag = "5";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(89, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 68);
            this.button5.TabIndex = 5;
            this.button5.TabStop = false;
            this.button5.Tag = "4";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(251, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 68);
            this.button6.TabIndex = 6;
            this.button6.TabStop = false;
            this.button6.Tag = "6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(89, 213);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 68);
            this.button7.TabIndex = 7;
            this.button7.TabStop = false;
            this.button7.Tag = "7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(170, 213);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 68);
            this.button8.TabIndex = 8;
            this.button8.TabStop = false;
            this.button8.Tag = "8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(251, 213);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 68);
            this.button9.TabIndex = 9;
            this.button9.TabStop = false;
            this.button9.Tag = "9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Image = global::puzzle_8.Properties.Resources.sq_down_icon_24;
            this.button13.Location = new System.Drawing.Point(179, 373);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(64, 29);
            this.button13.TabIndex = 12;
            this.button13.TabStop = false;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Image = global::puzzle_8.Properties.Resources.sq_up_icon_24;
            this.button12.Location = new System.Drawing.Point(179, 300);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(64, 30);
            this.button12.TabIndex = 13;
            this.button12.TabStop = false;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // cmd_derecha
            // 
            this.cmd_derecha.Image = global::puzzle_8.Properties.Resources.sq_next_icon_24;
            this.cmd_derecha.Location = new System.Drawing.Point(215, 336);
            this.cmd_derecha.Name = "cmd_derecha";
            this.cmd_derecha.Size = new System.Drawing.Size(64, 31);
            this.cmd_derecha.TabIndex = 11;
            this.cmd_derecha.TabStop = false;
            this.cmd_derecha.UseVisualStyleBackColor = true;
            this.cmd_derecha.Click += new System.EventHandler(this.cmd_derecha_Click);
            // 
            // cmd_izquierda
            // 
            this.cmd_izquierda.Image = global::puzzle_8.Properties.Resources.sq_prev_icon_24;
            this.cmd_izquierda.Location = new System.Drawing.Point(145, 336);
            this.cmd_izquierda.Name = "cmd_izquierda";
            this.cmd_izquierda.Size = new System.Drawing.Size(64, 31);
            this.cmd_izquierda.TabIndex = 10;
            this.cmd_izquierda.TabStop = false;
            this.cmd_izquierda.UseVisualStyleBackColor = true;
            this.cmd_izquierda.Click += new System.EventHandler(this.cmd_izquierda_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.opcionesToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(422, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevoJuegoToolStripMenuItem
            // 
            this.nuevoJuegoToolStripMenuItem.Name = "nuevoJuegoToolStripMenuItem";
            this.nuevoJuegoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.nuevoJuegoToolStripMenuItem.Text = "Nuevo Juego";
            this.nuevoJuegoToolStripMenuItem.Click += new System.EventHandler(this.nuevoJuegoToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resolverJuegoToolStripMenuItem,
            this.cancelarSolucionToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // resolverJuegoToolStripMenuItem
            // 
            this.resolverJuegoToolStripMenuItem.Name = "resolverJuegoToolStripMenuItem";
            this.resolverJuegoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.resolverJuegoToolStripMenuItem.Text = "Resolver juego";
            this.resolverJuegoToolStripMenuItem.Click += new System.EventHandler(this.resolverJuegoToolStripMenuItem_Click);
            // 
            // cancelarSolucionToolStripMenuItem
            // 
            this.cancelarSolucionToolStripMenuItem.Name = "cancelarSolucionToolStripMenuItem";
            this.cancelarSolucionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cancelarSolucionToolStripMenuItem.Text = "Cancelar solucion";
            this.cancelarSolucionToolStripMenuItem.Click += new System.EventHandler(this.cancelarSolucionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // lblnotificacion
            // 
            this.lblnotificacion.BackColor = System.Drawing.Color.Transparent;
            this.lblnotificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnotificacion.ForeColor = System.Drawing.Color.Blue;
            this.lblnotificacion.Location = new System.Drawing.Point(12, 405);
            this.lblnotificacion.Name = "lblnotificacion";
            this.lblnotificacion.Size = new System.Drawing.Size(398, 64);
            this.lblnotificacion.TabIndex = 15;
            this.lblnotificacion.Text = "Hola mundo";
            this.lblnotificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tresolucion
            // 
            this.Tresolucion.Tick += new System.EventHandler(this.Tresolucion_Tick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientosToolStripMenuItem,
            this.lblcontador_movimiento,
            this.toolStripMenuItem1,
            this.tiempoToolStripMenuItem,
            this.lbltiempo_transcurrido});
            this.menuStrip2.Location = new System.Drawing.Point(0, 498);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(422, 24);
            this.menuStrip2.TabIndex = 16;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.movimientosToolStripMenuItem.Text = "Movimientos: ";
            // 
            // lblcontador_movimiento
            // 
            this.lblcontador_movimiento.Name = "lblcontador_movimiento";
            this.lblcontador_movimiento.Size = new System.Drawing.Size(84, 20);
            this.lblcontador_movimiento.Text = "Movimiento";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 20);
            this.toolStripMenuItem1.Text = "||";
            // 
            // tiempoToolStripMenuItem
            // 
            this.tiempoToolStripMenuItem.Name = "tiempoToolStripMenuItem";
            this.tiempoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.tiempoToolStripMenuItem.Text = "Tiempo:";
            // 
            // lbltiempo_transcurrido
            // 
            this.lbltiempo_transcurrido.Name = "lbltiempo_transcurrido";
            this.lbltiempo_transcurrido.Size = new System.Drawing.Size(57, 20);
            this.lbltiempo_transcurrido.Text = "tiempo";
            // 
            // Ttrascurrido
            // 
            this.Ttrascurrido.Interval = 1000;
            this.Ttrascurrido.Tick += new System.EventHandler(this.Ttrascurrido_Tick);
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Location = new System.Drawing.Point(101, 472);
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(225, 23);
            this.BarraProgreso.TabIndex = 17;
            // 
            // ListaDetallesSolucion
            // 
            this.ListaDetallesSolucion.FormattingEnabled = true;
            this.ListaDetallesSolucion.Location = new System.Drawing.Point(101, 501);
            this.ListaDetallesSolucion.Name = "ListaDetallesSolucion";
            this.ListaDetallesSolucion.Size = new System.Drawing.Size(225, 95);
            this.ListaDetallesSolucion.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 522);
            this.Controls.Add(this.BarraProgreso);
            this.Controls.Add(this.lblnotificacion);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.cmd_derecha);
            this.Controls.Add(this.cmd_izquierda);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.ListaDetallesSolucion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDB PUZZLE V0.1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button cmd_izquierda;
        private System.Windows.Forms.Button cmd_derecha;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoJuegoToolStripMenuItem;
        private System.Windows.Forms.Label lblnotificacion;
        private System.Windows.Forms.Timer Tresolucion;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lblcontador_movimiento;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiempoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lbltiempo_transcurrido;
        private System.Windows.Forms.Timer Ttrascurrido;
        private System.Windows.Forms.ToolStripMenuItem resolverJuegoToolStripMenuItem;
        private System.Windows.Forms.ProgressBar BarraProgreso;
        private System.Windows.Forms.ListBox ListaDetallesSolucion;
        private System.Windows.Forms.ToolStripMenuItem cancelarSolucionToolStripMenuItem;
    }
}

