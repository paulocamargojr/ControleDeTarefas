﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeTarefas
{
    public partial class CadastroItensTarefa : Form
    {
        private readonly Tarefa tarefa;
        public CadastroItensTarefa(Tarefa tarefa)
        {
            InitializeComponent();

            this.tarefa = tarefa;

            labelTituloTarefa.Text = tarefa.Titulo;

            foreach (var item in tarefa.Itens)
                listItensTarefa.Items.Add(item);
        }

        public List<ItemTarefa> ItensAdicionados { 
            get
            { 
                return listItensTarefa.Items.Cast<ItemTarefa>().ToList();
            } 
        }

        private void btnInserirItem_Click(object sender, EventArgs e)
        {

            List<string> titulos = ItensAdicionados.Select(x => x.Titulo).ToList();

            if (titulos.Count == 0 || titulos.Contains(txtTitulo.Text) == false)
            {
                ItemTarefa itemTarefa = new ItemTarefa();

                itemTarefa.Titulo = txtTitulo.Text;

                listItensTarefa.Items.Add(itemTarefa);

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
