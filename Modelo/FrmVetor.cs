using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo
{
    public partial class FrmVetor : Form
    {
        List<String> nomes = new List<String>();
        List<String> cidade = new List<string>(new string[100]);
        public FrmVetor()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVetor_Load(object sender, EventArgs e)
        {

        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            nomes.Sort();
            cidade.Sort();
            mostra();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int p = nomes.IndexOf(txtEntrada.Text);
            if (p == -1)
                MessageBox.Show("Não encontrado na lista de nomes :(");
            else
                MessageBox.Show("Encontrado no 1° quadrante na posicao:" + p);

            int j = cidade.IndexOf(txtEntrada.Text);
            if (j == -1)
                MessageBox.Show("Não encontrado na lista de cidades :(");
            else
                MessageBox.Show("Encontrado no 2° quadrante na posicao:" + j);
        }

        private void BtnBuscaBinaria_Click(object sender, EventArgs e)
        {
            int p = nomes.BinarySearch(txtEntrada.Text);

            if (p < 0)
                MessageBox.Show("Não encontrado na lista de nomes :(" + p);
            else
                MessageBox.Show("Nome Encontrado na posicao:" + p);

            int j = cidade.BinarySearch(txtEntrada.Text);

            if (j < 0)
                MessageBox.Show("Não encontrado na lista de cidadedes :(" + j);
            else
                MessageBox.Show("Cidade encontrada na posicao:" + j);

        }

        private void BtnCarregar_Click(object sender, EventArgs e)
        {
            StreamReader arquivo = new StreamReader("DUPLA_(9).txt");
            string linha;
            int c = 0;
            var n = 0;
        
            using (var reader = File.OpenText("DUPLA_(9).txt"))
            {
                while (reader.ReadLine() != null)
                {
                    n++;
                }
            }
            
            do
            {
                linha = arquivo.ReadLine();
                listCidades.Items.Add(linha); // listCidades é um ListBox
                cidade[c] = linha; // cidades é um vetor, declarado como variável global da classe          
                c++;
            } while (c < n); // n é a quantidade de elementos do arquivo
            arquivo.Close();
            MessageBox.Show("Dados Carregados");
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            StreamWriter arquivo = new StreamWriter("ordenado.txt");
            foreach (string c in cidade)
                arquivo.WriteLine(c);
            MessageBox.Show("Dados Salvos!");
            arquivo.Close();
        }

        private void listCidades_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        void mostra()
        {
            listDados.Items.Clear();
            listCidades.Items.Clear();

            foreach (String n in nomes)
                listDados.Items.Add(n);

            foreach (String n in cidade)
                listCidades.Items.Add(n);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            nomes.Add(txtEntrada.Text);
            mostra();
            txtEntrada.Clear();
            txtEntrada.Focus();
        }
    }
}
