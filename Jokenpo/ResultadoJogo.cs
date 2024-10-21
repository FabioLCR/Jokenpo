namespace Jokenpo
{
    public class ResultadoJogo(IReadOnlyList<string> vencedores, IReadOnlyList<string> perdedores, bool empate, IReadOnlyList<string> narrativas)
    {
        public IReadOnlyList<string> Vencedores { get; } = vencedores;
        public IReadOnlyList<string> Perdedores { get; } = perdedores;
        public bool Empate { get; } = empate;
        public IReadOnlyList<string> Narrativas { get; } = narrativas;
    }
}