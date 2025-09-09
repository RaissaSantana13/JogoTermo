using System.Globalization;

namespace TermoLib
{
    public class Letra
    {
        public Letra(char caracter, char cor)
        {
            Caracter= caracter;
            Cor= cor;
        }
        public char Caracter;
        public char Cor;
    }
    public class Termo
    {
        public List<String> palavra;
        public string palavraSorteada;
        public List<List<Letra>> tabuleiro;
        public Dictionary<char, char> teclado;
        public int palavraAtual;
        public bool jogoFinalizado;

        public Termo()
        {
            jogoFinalizado = false;
            CarregaPalavras("palavra.txt");
            SorteiaPalavra();
            palavraAtual =1;

            tabuleiro = new List<List<Letra>>();
            teclado = new Dictionary<char, char>();
            for(int i=65; i<=90; i++)
            {
                //C - nao digitado| V- posicao correta | A- na palavra | P - nao faz parte

                teclado.Add((char)i, 'C');
            }
        }
        public void CarregaPalavras(string fileName)
        {
            palavra = File.ReadAllLines(fileName).ToList();
        }

        public void SorteiaPalavra()
        {
            Random rdn = new Random();
            var index = rdn.Next(0, palavra.Count() - 1);
            palavraSorteada = palavra[index];
        }
        
        public void ChecaPalavra(string palavra)
        {
            if (palavra == palavraSorteada)
            {
                jogoFinalizado=true;
            }

            if(palavra.Length != 5)
            {
                throw new Exception("Palavra com tamanho incorreto!");
            }

            // adicionando a palavra na matriz do tabuleiro
            var palavraTabuleiro = new List<Letra>();
            char cor; 
            for (int i =0; i<palavra.Length; i++)
            {

                if (palavra[i] == palavraSorteada[i])
                {
                    cor = 'V';
                }

                else if (palavraSorteada.Contains(palavra[i]))
                {
                    cor = 'A';

                }
                else
                {
                    cor = 'P';
                }

                palavraTabuleiro.Add(new Letra(palavra[i], cor));
                teclado[palavra[i]] = cor;
            }
            tabuleiro.Add(palavraTabuleiro);
            palavraAtual++; 
        }
    }
}
