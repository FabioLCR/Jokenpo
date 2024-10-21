namespace Jokenpo
{
    public class Jogo
    {
        private static readonly Dictionary<(JogadaEnum vence, JogadaEnum perde), string> Regras =
            new()
            {
            { (JogadaEnum.Tesoura, JogadaEnum.Papel), "Tesoura corta Papel" },
            { (JogadaEnum.Tesoura, JogadaEnum.Lagarto), "Tesoura decapita Lagarto" },
            { (JogadaEnum.Papel, JogadaEnum.Pedra), "Papel cobre Pedra" },
            { (JogadaEnum.Papel, JogadaEnum.Spock), "Papel refuta Spock" },
            { (JogadaEnum.Pedra, JogadaEnum.Tesoura), "Pedra quebra Tesoura" },
            { (JogadaEnum.Pedra, JogadaEnum.Lagarto), "Pedra esmaga Lagarto" },
            { (JogadaEnum.Lagarto, JogadaEnum.Spock), "Lagarto envenena Spock" },
            { (JogadaEnum.Lagarto, JogadaEnum.Papel), "Lagarto come Papel" },
            { (JogadaEnum.Spock, JogadaEnum.Tesoura), "Spock esmaga Tesoura" },
            { (JogadaEnum.Spock, JogadaEnum.Pedra), "Spock vaporiza Pedra" }
        };

        public static ResultadoJogo Jogar(Dictionary<string, JogadaEnum> jogadoresPorJogada)
        {
            var jogadasAgrupadas = jogadoresPorJogada
                .GroupBy(par => par.Value)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.Select(par => par.Key).ToList());

            var jogadasDistintas = jogadasAgrupadas.Keys.ToList();
            var jogadasVencedoras = new HashSet<JogadaEnum>();
            var jogadasPerdedoras = new HashSet<JogadaEnum>();
            var narrativas = new List<string>();

            foreach (var jogada1 in jogadasDistintas)
            {
                foreach (var jogada2 in jogadasDistintas)
                {
                    if (jogada1 == jogada2) continue; // Ignorar comparações consigo mesmo

                    if (Regras.TryGetValue((jogada1, jogada2), out string? narrativa))
                    {
                        narrativas.Add(narrativa);
                        jogadasVencedoras.Add(jogada1);
                        jogadasPerdedoras.Add(jogada2);
                    }
                }
            }

            if (jogadasVencedoras.SetEquals(jogadasPerdedoras))
            {
                return new ResultadoJogo([], [], true, [.. narrativas]);
            }

            var jogadoresVencedores = jogadasVencedoras
                .Where(jogada => !jogadasPerdedoras.Contains(jogada))
                .SelectMany(jogada => jogadasAgrupadas[jogada])
                .ToList();

            var jogadoresPerdedores = jogadasPerdedoras
                .SelectMany(jogada => jogadasAgrupadas[jogada])
                .ToList();

            bool houveEmpate = jogadoresVencedores.Count > 1 || jogadoresVencedores.Count == 0;

            return new ResultadoJogo([.. jogadoresVencedores], [.. jogadoresPerdedores], houveEmpate, [.. narrativas]);
        }
    }
}