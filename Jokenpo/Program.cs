namespace Jokenpo
{
    class Program
    {
        static void Main()
        {
            var jogadores = new Dictionary<string, JogadaEnum>
            {
                { "Fábio", JogadaEnum.Pedra },
                { "Letícia", JogadaEnum.Papel },
                { "Leon", JogadaEnum.Tesoura }
            };

            JogarJokenpo(jogadores);
        }

        private static string FormatarJogadores(IReadOnlyList<string> itens)
        {
            if (itens.Count > 1)
                return $"{string.Join(", ", itens.Take(..^1))} e {itens[^1]}";

            return itens[0]!;
        }

        public static void JogarJokenpo(Dictionary<string, JogadaEnum> jogadoresPorJogada)
        {
            var resultado = Jogo.Jogar(jogadoresPorJogada);

            if (resultado.Narrativas.Count > 0)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("                  NARRATIVAS DO JOGO");
                Console.WriteLine("--------------------------------------------------");
                foreach (var narrativa in resultado.Narrativas)
                    Console.WriteLine($"- {narrativa}");
            }

            if (resultado.Empate)
            {
                if (resultado.Vencedores.Count == 0)
                {
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.WriteLine("                    EMPATE!");
                    Console.WriteLine("--------------------------------------------------");
                }
                else
                {
                    var ganhadores = FormatarJogadores(resultado.Vencedores);
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.WriteLine($"Empate entre {ganhadores}");
                    Console.WriteLine("--------------------------------------------------");
                }

                return;
            }

            if (resultado.Vencedores.Count == 1)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine($"{resultado.Vencedores[0]} venceu o jogo!!!");
                Console.WriteLine("--------------------------------------------------");
            }

            if (resultado.Perdedores.Count > 0)
            {
                var perdedores = FormatarJogadores(resultado.Perdedores);
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine($"{perdedores} perderam o jogo!");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}