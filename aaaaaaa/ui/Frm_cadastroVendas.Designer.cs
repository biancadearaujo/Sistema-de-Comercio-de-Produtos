
namespace aaaaaaa.ui
{
    partial class Frm_cadastroVendas
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.rbCartaoDebito = new System.Windows.Forms.RadioButton();
            this.rbCartaoCredito = new System.Windows.Forms.RadioButton();
            this.rbPix = new System.Windows.Forms.RadioButton();
            this.rbDinheiro = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.idProdutoSelecionado = new System.Windows.Forms.TextBox();
            this.valorSelecionado = new System.Windows.Forms.TextBox();
            this.unidadeSelecionada = new System.Windows.Forms.TextBox();
            this.produtoSelecionado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEfetuarPagamento = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTotalPago = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAdicionarProduto = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.idClienteSelecionado = new System.Windows.Forms.TextBox();
            this.clienteSelecionado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdicionarCliente = new System.Windows.Forms.Button();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdicionarProduto)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.dgvAdicionarProduto);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 892);
            this.panel1.TabIndex = 24;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.rbCartaoDebito);
            this.panel7.Controls.Add(this.rbCartaoCredito);
            this.panel7.Controls.Add(this.rbPix);
            this.panel7.Controls.Add(this.rbDinheiro);
            this.panel7.Location = new System.Drawing.Point(12, 742);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(718, 70);
            this.panel7.TabIndex = 13;
            // 
            // rbCartaoDebito
            // 
            this.rbCartaoDebito.AutoSize = true;
            this.rbCartaoDebito.Location = new System.Drawing.Point(460, 26);
            this.rbCartaoDebito.Margin = new System.Windows.Forms.Padding(2);
            this.rbCartaoDebito.Name = "rbCartaoDebito";
            this.rbCartaoDebito.Size = new System.Drawing.Size(145, 24);
            this.rbCartaoDebito.TabIndex = 3;
            this.rbCartaoDebito.Text = "Cartão de Débito";
            this.rbCartaoDebito.UseVisualStyleBackColor = true;
            // 
            // rbCartaoCredito
            // 
            this.rbCartaoCredito.AutoSize = true;
            this.rbCartaoCredito.Location = new System.Drawing.Point(262, 26);
            this.rbCartaoCredito.Margin = new System.Windows.Forms.Padding(2);
            this.rbCartaoCredito.Name = "rbCartaoCredito";
            this.rbCartaoCredito.Size = new System.Drawing.Size(148, 24);
            this.rbCartaoCredito.TabIndex = 2;
            this.rbCartaoCredito.Text = "Cartão de Crédito";
            this.rbCartaoCredito.UseVisualStyleBackColor = true;
            // 
            // rbPix
            // 
            this.rbPix.AutoSize = true;
            this.rbPix.Location = new System.Drawing.Point(164, 26);
            this.rbPix.Margin = new System.Windows.Forms.Padding(2);
            this.rbPix.Name = "rbPix";
            this.rbPix.Size = new System.Drawing.Size(51, 24);
            this.rbPix.TabIndex = 1;
            this.rbPix.Text = "PIX";
            this.rbPix.UseVisualStyleBackColor = true;
            // 
            // rbDinheiro
            // 
            this.rbDinheiro.AutoSize = true;
            this.rbDinheiro.Checked = true;
            this.rbDinheiro.Location = new System.Drawing.Point(31, 26);
            this.rbDinheiro.Margin = new System.Windows.Forms.Padding(2);
            this.rbDinheiro.Name = "rbDinheiro";
            this.rbDinheiro.Size = new System.Drawing.Size(87, 24);
            this.rbDinheiro.TabIndex = 0;
            this.rbDinheiro.TabStop = true;
            this.rbDinheiro.Text = "Dinheiro";
            this.rbDinheiro.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.idProdutoSelecionado);
            this.panel6.Controls.Add(this.valorSelecionado);
            this.panel6.Controls.Add(this.unidadeSelecionada);
            this.panel6.Controls.Add(this.produtoSelecionado);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txtQuantidade);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(12, 99);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(718, 209);
            this.panel6.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(501, 160);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Adicionar ao Carrinho";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idProdutoSelecionado
            // 
            this.idProdutoSelecionado.Enabled = false;
            this.idProdutoSelecionado.Location = new System.Drawing.Point(84, 22);
            this.idProdutoSelecionado.Margin = new System.Windows.Forms.Padding(2);
            this.idProdutoSelecionado.Name = "idProdutoSelecionado";
            this.idProdutoSelecionado.PlaceholderText = "0";
            this.idProdutoSelecionado.ReadOnly = true;
            this.idProdutoSelecionado.Size = new System.Drawing.Size(32, 27);
            this.idProdutoSelecionado.TabIndex = 12;
            // 
            // valorSelecionado
            // 
            this.valorSelecionado.Enabled = false;
            this.valorSelecionado.Location = new System.Drawing.Point(84, 114);
            this.valorSelecionado.Margin = new System.Windows.Forms.Padding(2);
            this.valorSelecionado.Name = "valorSelecionado";
            this.valorSelecionado.PlaceholderText = "Valor";
            this.valorSelecionado.ReadOnly = true;
            this.valorSelecionado.Size = new System.Drawing.Size(200, 27);
            this.valorSelecionado.TabIndex = 11;
            // 
            // unidadeSelecionada
            // 
            this.unidadeSelecionada.Enabled = false;
            this.unidadeSelecionada.Location = new System.Drawing.Point(84, 64);
            this.unidadeSelecionada.Margin = new System.Windows.Forms.Padding(2);
            this.unidadeSelecionada.Name = "unidadeSelecionada";
            this.unidadeSelecionada.PlaceholderText = "Unidade";
            this.unidadeSelecionada.ReadOnly = true;
            this.unidadeSelecionada.Size = new System.Drawing.Size(604, 27);
            this.unidadeSelecionada.TabIndex = 10;
            // 
            // produtoSelecionado
            // 
            this.produtoSelecionado.Enabled = false;
            this.produtoSelecionado.Location = new System.Drawing.Point(122, 22);
            this.produtoSelecionado.Margin = new System.Windows.Forms.Padding(2);
            this.produtoSelecionado.Name = "produtoSelecionado";
            this.produtoSelecionado.PlaceholderText = "Selecione um produto";
            this.produtoSelecionado.ReadOnly = true;
            this.produtoSelecionado.Size = new System.Drawing.Size(566, 27);
            this.produtoSelecionado.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Produto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Unidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(460, 114);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(229, 27);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Valor:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.btnSair);
            this.panel5.Controls.Add(this.btnEfetuarPagamento);
            this.panel5.Location = new System.Drawing.Point(10, 818);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(720, 65);
            this.panel5.TabIndex = 11;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(599, 19);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(94, 29);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnEfetuarPagamento
            // 
            this.btnEfetuarPagamento.Location = new System.Drawing.Point(18, 2);
            this.btnEfetuarPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.btnEfetuarPagamento.Name = "btnEfetuarPagamento";
            this.btnEfetuarPagamento.Size = new System.Drawing.Size(168, 45);
            this.btnEfetuarPagamento.TabIndex = 0;
            this.btnEfetuarPagamento.Text = "Finalizar venda";
            this.btnEfetuarPagamento.UseVisualStyleBackColor = true;
            this.btnEfetuarPagamento.Click += new System.EventHandler(this.btnEfetuarPagamento_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.txtTotalPago);
            this.panel4.Controls.Add(this.txtSubtotal);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtTroco);
            this.panel4.Controls.Add(this.txtValorTotal);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(10, 638);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 102);
            this.panel4.TabIndex = 10;
            // 
            // txtTotalPago
            // 
            this.txtTotalPago.Location = new System.Drawing.Point(391, 15);
            this.txtTotalPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPago.Name = "txtTotalPago";
            this.txtTotalPago.PlaceholderText = "0";
            this.txtTotalPago.Size = new System.Drawing.Size(183, 27);
            this.txtTotalPago.TabIndex = 7;
            this.txtTotalPago.Text = "0";
            this.txtTotalPago.Leave += new System.EventHandler(this.txtTotalPago_Leave);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Location = new System.Drawing.Point(101, 15);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(183, 27);
            this.txtSubtotal.TabIndex = 6;
            this.txtSubtotal.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Total Pago:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Subtotal:";
            // 
            // txtTroco
            // 
            this.txtTroco.Enabled = false;
            this.txtTroco.Location = new System.Drawing.Point(391, 60);
            this.txtTroco.Margin = new System.Windows.Forms.Padding(2);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.PlaceholderText = "0";
            this.txtTroco.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(183, 27);
            this.txtTroco.TabIndex = 3;
            this.txtTroco.Text = "0";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Location = new System.Drawing.Point(101, 60);
            this.txtValorTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.PlaceholderText = "0";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(183, 27);
            this.txtValorTotal.TabIndex = 2;
            this.txtValorTotal.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Troco:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Total:";
            // 
            // dgvAdicionarProduto
            // 
            this.dgvAdicionarProduto.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAdicionarProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdicionarProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.codigo,
            this.produto,
            this.valor,
            this.unidade,
            this.total});
            this.dgvAdicionarProduto.Location = new System.Drawing.Point(12, 312);
            this.dgvAdicionarProduto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAdicionarProduto.Name = "dgvAdicionarProduto";
            this.dgvAdicionarProduto.RowHeadersWidth = 51;
            this.dgvAdicionarProduto.RowTemplate.Height = 29;
            this.dgvAdicionarProduto.Size = new System.Drawing.Size(718, 321);
            this.dgvAdicionarProduto.TabIndex = 9;
            // 
            // numero
            // 
            this.numero.HeaderText = "Número";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.Width = 125;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Nome";
            this.codigo.MinimumWidth = 6;
            this.codigo.Name = "codigo";
            this.codigo.Width = 125;
            // 
            // produto
            // 
            this.produto.HeaderText = "Qtd Estoque";
            this.produto.MinimumWidth = 6;
            this.produto.Name = "produto";
            this.produto.Width = 125;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.MinimumWidth = 6;
            this.valor.Name = "valor";
            this.valor.Width = 125;
            // 
            // unidade
            // 
            this.unidade.HeaderText = "Quantidade";
            this.unidade.MinimumWidth = 6;
            this.unidade.Name = "unidade";
            this.unidade.Width = 125;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.Width = 125;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.idClienteSelecionado);
            this.panel3.Controls.Add(this.clienteSelecionado);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(14, 16);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(715, 74);
            this.panel3.TabIndex = 8;
            // 
            // idClienteSelecionado
            // 
            this.idClienteSelecionado.Enabled = false;
            this.idClienteSelecionado.Location = new System.Drawing.Point(85, 15);
            this.idClienteSelecionado.Margin = new System.Windows.Forms.Padding(2);
            this.idClienteSelecionado.Name = "idClienteSelecionado";
            this.idClienteSelecionado.PlaceholderText = "0";
            this.idClienteSelecionado.ReadOnly = true;
            this.idClienteSelecionado.Size = new System.Drawing.Size(32, 27);
            this.idClienteSelecionado.TabIndex = 2;
            // 
            // clienteSelecionado
            // 
            this.clienteSelecionado.Enabled = false;
            this.clienteSelecionado.Location = new System.Drawing.Point(122, 15);
            this.clienteSelecionado.Margin = new System.Windows.Forms.Padding(2);
            this.clienteSelecionado.Name = "clienteSelecionado";
            this.clienteSelecionado.PlaceholderText = "Selecione um cliente";
            this.clienteSelecionado.ReadOnly = true;
            this.clienteSelecionado.Size = new System.Drawing.Size(498, 27);
            this.clienteSelecionado.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnAdicionarCliente);
            this.panel2.Controls.Add(this.btnAdicionarProduto);
            this.panel2.Controls.Add(this.btnExcluir);
            this.panel2.Location = new System.Drawing.Point(766, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 892);
            this.panel2.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(28, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 70);
            this.button2.TabIndex = 10;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdicionarCliente
            // 
            this.btnAdicionarCliente.BackColor = System.Drawing.Color.White;
            this.btnAdicionarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAdicionarCliente.Location = new System.Drawing.Point(28, 21);
            this.btnAdicionarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarCliente.Name = "btnAdicionarCliente";
            this.btnAdicionarCliente.Size = new System.Drawing.Size(170, 70);
            this.btnAdicionarCliente.TabIndex = 7;
            this.btnAdicionarCliente.Text = "Adicionar Cliente";
            this.btnAdicionarCliente.UseVisualStyleBackColor = false;
            this.btnAdicionarCliente.Click += new System.EventHandler(this.btnAdicionarCliente_Click);
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.BackColor = System.Drawing.Color.White;
            this.btnAdicionarProduto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAdicionarProduto.Location = new System.Drawing.Point(28, 128);
            this.btnAdicionarProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(170, 70);
            this.btnAdicionarProduto.TabIndex = 8;
            this.btnAdicionarProduto.Text = "Adicionar Produto";
            this.btnAdicionarProduto.UseVisualStyleBackColor = false;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnExcluir.Location = new System.Drawing.Point(28, 238);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(170, 70);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // Frm_cadastroVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1026, 881);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_cadastroVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Venda";
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdicionarProduto)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rbCartaoDebito;
        private System.Windows.Forms.RadioButton rbCartaoCredito;
        private System.Windows.Forms.RadioButton rbPix;
        private System.Windows.Forms.RadioButton rbDinheiro;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEfetuarPagamento;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtTotalPago;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAdicionarProduto;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox clienteSelecionado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdicionarCliente;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox idClienteSelecionado;
        private System.Windows.Forms.TextBox idProdutoSelecionado;
        private System.Windows.Forms.TextBox valorSelecionado;
        private System.Windows.Forms.TextBox unidadeSelecionada;
        private System.Windows.Forms.TextBox produtoSelecionado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Button button2;
    }
}