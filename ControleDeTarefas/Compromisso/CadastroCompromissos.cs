using ControleDeTarefas.Contato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeTarefas.Compromisso
{
    public partial class CadastroCompromissos : Form
    {
        Compromisso compromisso = new Compromisso();
        List<Contato.Contato> contatos = new List<Contato.Contato>();
        RepositorioContato repositorioContato;
        
        public CadastroCompromissos()
        {
            InitializeComponent();
            SerializadorJson serializadorJson = new SerializadorJson();
            repositorioContato = new RepositorioContato(serializadorJson);
            contatos = serializadorJson.CarregarObjetosDoArquivoContato();

            foreach (var item in contatos)
            {
                if(txtContato.Text == item.Nome)
                {

                    compromisso.Contato = item;
                    break;

                }
                    
            }
        }

        public Compromisso Compromisso
        {
            get
            {
                return compromisso;
            }
            set
            {
                compromisso = value;
                txtNumero.Text = compromisso.Numero.ToString();
                //txtContato.Text = compromisso.Contato.Nome;
                txtAssunto.Text = compromisso.Assunto;
                txtLocal.Text = compromisso.Local;
                txtData.Text = compromisso.Data.ToShortDateString();
                txtHoraInicio.Text = compromisso.HoraInicio.ToString();
                txtHoraTermino.Text = compromisso.HoraTermino.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            compromisso.Assunto = txtAssunto.Text;
            compromisso.Local = txtLocal.Text;
            try
            {
                compromisso.Data = Convert.ToDateTime(txtData.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Data inválida!"
                , "Cadastro Compromisso"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }

            try
            {
                compromisso.HoraInicio = Convert.ToInt32(txtHoraInicio.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Hora inválida!"
                , "Cadastro Compromisso"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }

            try
            {
                compromisso.HoraTermino = Convert.ToInt32(txtHoraTermino.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Hora inválida!"
                , "Cadastro Compromisso"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }

            if(txtContato.Text.Length > 0)
            {

                bool contatoExiste = repositorioContato.VerificarContato(txtContato.Text);

                if (!contatoExiste)
                {

                    MessageBox.Show("Contato inexistente!!"
                    , "Cadastro Compromisso"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;

                }
            }
        }
    }
}
