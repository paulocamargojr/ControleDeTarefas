using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeTarefas.Contato
{
    public partial class CadastroContatos : Form
    {
        Contato contato = new Contato();
        public CadastroContatos()
        {
            InitializeComponent();
        }

        public Contato Contato
        {
            get
            {
                return contato;
            }
            set
            {
                contato = value;
                txtNumero.Text = contato.Numero.ToString();
                txtNome.Text = contato.Nome;
                txtEmail.Text = contato.Email;
                txtTelefone.Text = contato.Telefone;
                txtEmpresa.Text = contato.Empresa;
                txtCargo.Text = contato.Cargo;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool emailValido = ValidarEmail(txtEmail.Text);

            if (!emailValido)
            {

                MessageBox.Show("Email inválido!"
                , "Cadastro Contato"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;

            }

            bool telefoneValido = ValidarTelefone(txtTelefone.Text);

            if (!telefoneValido)
            {

                MessageBox.Show("Telefone inválido!"
                , "Cadastro Contato"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;

            }

            if(txtNome.Text.Length == 0 || txtEmail.Text.Length == 0 || txtTelefone.Text.Length == 0){

                MessageBox.Show("Você deve preencher todos os campos!"
                , "Cadastro Contato"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;

            }



            contato.Nome = txtNome.Text;
            contato.Email = txtEmail.Text;
            contato.Telefone = txtTelefone.Text;
            contato.Empresa = txtEmpresa.Text;
            contato.Cargo = txtCargo.Text;

        }

        private bool ValidarEmail(string email)
        {

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
                return true;
            return false;

        }

        private bool ValidarTelefone(string telefone)
        {

            int numTelefone = telefone.Length;
            if (numTelefone == 9)
                return true;
            return false;

        }
    }
}
