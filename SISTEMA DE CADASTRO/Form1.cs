using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_CADASTRO
{
    public partial class Form1 : Form
    {

        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            ComboEC.Items.Add("Casado");
            ComboEC.Items.Add("Solteiro");
            ComboEC.Items.Add("Viuvo");
            ComboEC.Items.Add("Separado");

            ComboEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            int index = -1; //Esta variavel é para ver se a pessoa esta cadastrada ou não no listbox.

            foreach (Pessoa pessoa in pessoas)//A cada alteração vamos colocar em nossa Listbox.
            {
                if (pessoa.Nome == txtnome.Text)//codigo usado para verficar se o cadastro é igual o nome na textbox.
                {
                    index = pessoas.IndexOf(pessoa);//estamos atribuindo o index dentro da nossa lista de pessoas.
                }               
            }
            if (txtnome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome.");
                txtnome.Focus();
                return;
            }

            if (txtTelefone.Text == "")
            {
                MessageBox.Show("Preencha o campo telefone.");
                txtTelefone.Focus();
                return;
            }

            char sexo;

            if (radioM.Checked)//checar qual radio button esta selecionada.
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtnome.Text;
            p.Datanascimento = dateaniversario.Text;
            p.estadocivil = ComboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = Boxcasa.Checked;
            p.Veiculo = Boxcarro.Checked;
            p.Sexo = sexo;

            if(index < 0)
            {
                pessoas.Add(p);//add um novo item na variavel de pessoa.
            }
            else
            {
                pessoas[index] = p;//pegando um index e colocando na variavel p.
            }

            btnLimpar_Click( btnLimpar, EventArgs.Empty);//desse jeito posso usar o metodo limpar dentro do programa, facilitando no programa.

            Listar();//Utilizando o metodo LISTAR para adiciona os dados na textbox.
        }        

        private void Listar()//metodo usado para listar todos as pessoas cadastradas dentro da listbox.
        {
            lista.Items.Clear();//codigo usado para limpar o list box.

            foreach (Pessoa p in pessoas)// codigo usado para verificar os itens da ListBox.
            {
                lista.Items.Add(p.Nome);//Estamos fazendo com que a propriedade NOME seja adicionada na listbox.
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            dateaniversario.Text = "";
            ComboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            Boxcasa.Checked = false;
            Boxcarro.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtnome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;//seleciona o item para a variavel 'indice'.
            pessoas.RemoveAt(indice);//remove o item selecionado para a variavel 'indice'.
            Listar();
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)//usando o evento mousedoubleclick onde sera selecionado quando clicar duas vezes com o mouse.
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtnome.Text = p.Nome;
            dateaniversario.Text = p.Datanascimento;
            ComboEC.SelectedItem = p.estadocivil;
            txtTelefone.Text = p.Telefone;
            Boxcasa.Checked = p.CasaPropria;
            Boxcarro.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }
    }
}
