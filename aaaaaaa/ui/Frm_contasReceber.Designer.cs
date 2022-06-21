
namespace aaaaaaa.ui
{
    partial class Frm_contasReceber
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBaixa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.rbPagas = new System.Windows.Forms.RadioButton();
            this.rbAtraso = new System.Windows.Forms.RadioButton();
            this.rbVencer = new System.Windows.Forms.RadioButton();
            this.rbReceber = new System.Windows.Forms.RadioButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacaoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnBaixa);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 689);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.data,
            this.hora,
            this.cliente,
            this.totalVenda,
            this.situacaoVenda});
            this.dataGridView1.Location = new System.Drawing.Point(14, 144);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(752, 469);
            this.dataGridView1.TabIndex = 10;
            // 
            // btnBaixa
            // 
            this.btnBaixa.Location = new System.Drawing.Point(672, 642);
            this.btnBaixa.Name = "btnBaixa";
            this.btnBaixa.Size = new System.Drawing.Size(94, 29);
            this.btnBaixa.TabIndex = 1;
            this.btnBaixa.Text = "Dar Baixa";
            this.btnBaixa.UseVisualStyleBackColor = true;
            this.btnBaixa.Click += new System.EventHandler(this.btnBaixa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnGerar);
            this.groupBox1.Controls.Add(this.rbPagas);
            this.groupBox1.Controls.Add(this.rbAtraso);
            this.groupBox1.Controls.Add(this.rbVencer);
            this.groupBox1.Controls.Add(this.rbReceber);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(620, 55);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(94, 29);
            this.btnGerar.TabIndex = 4;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // rbPagas
            // 
            this.rbPagas.AutoSize = true;
            this.rbPagas.Location = new System.Drawing.Point(492, 55);
            this.rbPagas.Name = "rbPagas";
            this.rbPagas.Size = new System.Drawing.Size(68, 24);
            this.rbPagas.TabIndex = 3;
            this.rbPagas.TabStop = true;
            this.rbPagas.Text = "Pagas";
            this.rbPagas.UseVisualStyleBackColor = true;
            // 
            // rbAtraso
            // 
            this.rbAtraso.AutoSize = true;
            this.rbAtraso.Location = new System.Drawing.Point(322, 55);
            this.rbAtraso.Name = "rbAtraso";
            this.rbAtraso.Size = new System.Drawing.Size(98, 24);
            this.rbAtraso.TabIndex = 2;
            this.rbAtraso.TabStop = true;
            this.rbAtraso.Text = "Em Atraso";
            this.rbAtraso.UseVisualStyleBackColor = true;
            // 
            // rbVencer
            // 
            this.rbVencer.AutoSize = true;
            this.rbVencer.Location = new System.Drawing.Point(184, 55);
            this.rbVencer.Name = "rbVencer";
            this.rbVencer.Size = new System.Drawing.Size(88, 24);
            this.rbVencer.TabIndex = 1;
            this.rbVencer.TabStop = true;
            this.rbVencer.Text = "A Vencer";
            this.rbVencer.UseVisualStyleBackColor = true;
            // 
            // rbReceber
            // 
            this.rbReceber.AutoSize = true;
            this.rbReceber.Location = new System.Drawing.Point(30, 57);
            this.rbReceber.Name = "rbReceber";
            this.rbReceber.Size = new System.Drawing.Size(98, 24);
            this.rbReceber.TabIndex = 0;
            this.rbReceber.TabStop = true;
            this.rbReceber.Text = "A Receber";
            this.rbReceber.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 80;
            // 
            // data
            // 
            this.data.HeaderText = "Data";
            this.data.MinimumWidth = 6;
            this.data.Name = "data";
            this.data.Width = 125;
            // 
            // hora
            // 
            this.hora.HeaderText = "Hora";
            this.hora.MinimumWidth = 6;
            this.hora.Name = "hora";
            this.hora.Width = 125;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.MinimumWidth = 6;
            this.cliente.Name = "cliente";
            this.cliente.Width = 125;
            // 
            // totalVenda
            // 
            this.totalVenda.HeaderText = "Total Venda";
            this.totalVenda.MinimumWidth = 6;
            this.totalVenda.Name = "totalVenda";
            this.totalVenda.Width = 125;
            // 
            // situacaoVenda
            // 
            this.situacaoVenda.HeaderText = "Situação Venda";
            this.situacaoVenda.MinimumWidth = 6;
            this.situacaoVenda.Name = "situacaoVenda";
            this.situacaoVenda.Width = 125;
            // 
            // Frm_contasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 715);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_contasReceber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a Receber";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBaixa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.RadioButton rbPagas;
        private System.Windows.Forms.RadioButton rbAtraso;
        private System.Windows.Forms.RadioButton rbVencer;
        private System.Windows.Forms.RadioButton rbReceber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacaoVenda;
    }
}