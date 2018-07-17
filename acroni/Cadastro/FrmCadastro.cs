﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace acroni.Cadastro
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //--Propriedade para checar se o cadastro foi concluido ou não no form Login
        public static bool cadastro_SUCCESS = false;

        //--Inicializando uma conexão e um COMANDO
        SqlConnection conexao_SQL = new SqlConnection(Colorpicker.ColorpickerHandlers.nome_conexao);
        SqlCommand comando_SQL;
        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!possuiCamposVazios())
            {
                try
                {
                    //--Abrindo a conexão
                    if (conexao_SQL.State != ConnectionState.Open)
                        conexao_SQL.Open();

                    //--Inicializando um comando SELECT para ver se aquele nome já existe
                    String select = "SELECT email FROM tblCliente WHERE email IN ('" + txtEmail.Text + "')";
                    comando_SQL = new SqlCommand(select, conexao_SQL);
                    SqlDataReader tem_usuario = comando_SQL.ExecuteReader();

                    //--Lendo a resposta
                    tem_usuario.Read();

                    //-- ".HasRows" é uma propriedade que mostra se teve alguma resposta
                    if (!tem_usuario.HasRows)
                    {
                        //--Fechando o SELECT para poder reutilizar
                        tem_usuario.Close();
                        if (validacao_email.IsMatch(txtEmail.Text))
                        {
                            if (txtSenha.Text.Equals(txtRepetirSenha.Text))
                            {
                                try
                                {
                                    //--Abrindo a conexão
                                    if (conexao_SQL.State != ConnectionState.Open)
                                        conexao_SQL.Open();

                                    //--Inicializando um comando INSERT e execuntando
                                    String insert = "INSERT INTO tblCliente VALUES ('" + txtUsuario.Text + "','" + txtSenha.Text + "','" + txtEmail.Text + "')";
                                    comando_SQL = new SqlCommand(insert, conexao_SQL);
                                    //--Para executar, utilizo ExecuteNonQuery(), pois ele retorna apenas o numero de linhas afetadas
                                    int n_linhas_afetadas = comando_SQL.ExecuteNonQuery();

                                    if (n_linhas_afetadas > 0)
                                    {
                                        MessageBox.Show("Cadastro concluido");
                                        cadastro_SUCCESS = true;
                                        Colorpicker.ColorpickerHandlers.nome_usuario = txtUsuario.Text;
                                        this.Close();
                                    } else
                                    {
                                        MessageBox.Show("Cadastro não foi concluido com SUCCESS");
                                        txtEmail.ResetText(); txtRepetirSenha.ResetText(); txtSenha.ResetText(); txtUsuario.ResetText();
                                    }
                                    //--Fechando a conexão (NÃO ESQUECER!)
                                    conexao_SQL.Close();
                                } catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            } else {
                                lblAviso.Text = "As senhas não são iguais";
                                lblAviso.Visible = true;
                            }
                        } else
                        {
                            lblAviso.Text = "O email não é valido";
                            lblAviso.Visible = true;
                        }
                    } else {
                        lblAviso.Text = "Este email está em outra conta";
                        lblAviso.Visible = true;

                        //--Fechando o SELECT para poder reutilizar
                        tem_usuario.Close();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    conexao_SQL.Close();
                }
            }
            else
            {
                lblAviso.Text = "Existem campos vazios";
                lblAviso.Visible = true;
            }
        }

        //--Método que checa se o Form possui campos vazios
        private bool possuiCamposVazios()
        {
            bool b = false;
            foreach (Control controle in Controls)
            {
                if (controle is Bunifu.Framework.UI.BunifuMaterialTextbox)
                {
                    if ((controle as Bunifu.Framework.UI.BunifuMaterialTextbox).Text.Equals(String.Empty))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }

        private void txtSenha_OnValueChanged(object sender, EventArgs e)
        {
            txtSenha.isPassword = true;
        }

        private void txtRepetirSenha_OnValueChanged(object sender, EventArgs e)
        {
            txtRepetirSenha.isPassword = true;
        }
    }
}