using TermoLib;
using static System.Windows.Forms.LinkLabel;
namespace TermoApp
{
    public partial class FormJogo : Form
    {
        public Termo termo;
        int coluna = 1; 
        public FormJogo()
        {
            InitializeComponent();
            termo = new Termo();
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {

            if (coluna > 5) return; 
            // botao do teclado 
            var button =(Button)sender;
            var linha = termo.palavraAtual;
            var nomeButton = $"btn{linha}{coluna}";
            //botao do tabuleiro da linha e coluna atual
            var buttonTabuleiro= Controls.Find(nomeButton, true)[0];
            var buttonTabluleiro = RetornaBotao(nomeButton);
            buttonTabuleiro.Text = button.Text;
            coluna++; 
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var palavra=string.Empty;
            for (int i=1; i<=5; i++)
            {
                var nomeBotao = $"btn{termo.palavraAtual}{i}";
                var botao=RetornaBotao(nomeBotao);
                palavra += botao.Text;

            }
            termo.ChecaPalavra(palavra);
            AtualizaTabuleiro();
            if (termo.jogoFinalizado)
            {
                MessageBox.Show("Parabens, palavra correta!", "Jogo Termo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            AtualizaTeclado();
            coluna = 1;
        }

        private Button RetornaBotao(string name)
        {
            return (Button)Controls.Find(name, true)[0];
        }

        private void AtualizaTabuleiro()
        {
            for(int col=1; col<=5; col++)
            {
                var letra = termo.tabuleiro[termo.palavraAtual - 2][col-1];
                var nomeBotaoTab= $"btn{termo.palavraAtual-1}{col}";
                var botaoTab = RetornaBotao(nomeBotaoTab);
                var nomeBotaoKey = $"btn{letra.Caracter}";
                var botaoKey = RetornaBotao(nomeBotaoKey);

                if (letra.Cor == 'A')
                {
                    botaoTab.BackColor = Color.Yellow;
                    botaoKey.BackColor = Color.Yellow;
                }
                else if(letra.Cor =='V')
                {
                    botaoTab.BackColor= Color.Green;
                    botaoKey.BackColor = Color.Green;
                }

                else
                {
                    botaoTab.BackColor=Color.Black;
                    botaoKey.BackColor = Color.Black;
                }
            }
        }


        private void AtualizaTeclado()
        {

        }
    }
}
