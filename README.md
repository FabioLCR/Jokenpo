# Pedra, Papel, Tesoura, Lagarto, Spock

Este software implementa a lógica do jogo **Pedra, Papel, Tesoura, Lagarto, Spock**, permitindo que múltiplos jogadores participem simultaneamente. O método central do software recebe as jogadas dos jogadores e determina os `ganhadores` e `perdedores` com base nas interações entre as jogadas, além de gerar uma narrativa simples descrevendo as interações.

## Regras do Jogo

1. O método deve receber um `dicionário` onde as chaves são os nomes dos jogadores e os valores são as jogadas realizadas por cada jogador (`JogadaEnum`).

2. Se todas as jogadas forem iguais, o resultado será considerado um **empate total** e não haverá perdedores.

3. As interações entre jogadas seguem as seguintes regras:
   - **Tesoura** corta **Papel**.
   - **Papel** cobre **Pedra**.
   - **Pedra** esmaga **Lagarto**.
   - **Lagarto** envenena **Spock**.
   - **Spock** esmaga **Tesoura**.
   - **Tesoura** decapita **Lagarto**.
   - **Lagarto** come **Papel**.
   - **Papel** refuta **Spock**.
   - **Spock** vaporiza **Pedra**.
   - **Pedra** quebra **Tesoura**.

4. O software deve gerar uma `narrativa` simples descrevendo as interações vencedoras entre as jogadas, com base nas regras acima. Exemplo: `Tesoura corta Papel`, `Spock vaporiza Pedra`.

5. Mesmo que uma jogada perca para outra, suas interações vencedoras sobre outras jogadas também devem ser descritas na narrativa.

6. O software deve ser capaz de identificar os **ganhadores** e **perdedores** com base nas seguintes regras:
   - Um jogador é considerado `perdedor` se sua jogada foi vencida por qualquer outra jogada presente.
   - Um jogador é considerado `ganhador` se sua jogada não foi vencida por nenhuma outra jogada presente.

7. Se houver duas ou mais jogadas que não forem vencidas por nenhuma outra jogada, essas jogadas serão consideradas um **empate entre os ganhadores**. Jogadores cujas jogadas foram vencidas entrarão na lista de `perdedores`.

8. Se **todos os jogadores** forem vencidos por alguma jogada (ou seja, todos forem perdedores), o resultado será um **empate total**.

9. O resultado final deve:
   - Declarar a lista de **ganhadores** (ou o `empate` entre eles, caso haja múltiplos ganhadores).
   - Declarar a lista de `perdedores`, ou
   - Declarar um **empate total** se todos forem perdedores ou se todos jogarem a mesma jogada.

10. O resultado deve ser baseado apenas nas interações entre as jogadas, sem levar em conta a ordem em que elas foram feitas.

## Exemplo de Funcionamento

Considerando um `dicionário` com três jogadores e suas respectivas jogadas:

```csharp
var jogadores = new Dictionary<string, JogadaEnum>
{
    { "Fábio", JogadaEnum.Pedra },
    { "Letícia", JogadaEnum.Tesoura },
    { "Leon", JogadaEnum.Papel }
};
```

Neste caso:
- A narrativa seria:
  - `Pedra quebra Tesoura`
  - `Papel cobre Pedra`

- **Resultado final**:
  - `Leon` seria o ganhador (já que sua jogada não foi vencida por ninguém).
  - `Fábio` e `Letícia` seriam os perdedores (pois suas jogadas foram vencidas).

Outro exemplo, se as jogadas fossem:

```csharp
var jogadores = new Dictionary<string, JogadaEnum>
{
    { "Fábio", JogadaEnum.Pedra },
    { "Letícia", JogadaEnum.Papel },
    { "Leon", JogadaEnum.Tesoura }
};
```

- A narrativa seria:
  - `Papel cobre Pedra`
  - `Tesoura corta Papel`
  - `Pedra quebra Tesoura`

- **Resultado final**:
  - Todos os jogadores seriam considerados perdedores, portanto o resultado seria um **empate total**.

## Exemplo de Saída no Console

Para o primeiro exemplo com `"Fábio"`, `"Letícia"` e `"Leon"`, o resultado seria apresentado assim:

```bash
--------------------------------------------------
                  NARRATIVAS DO JOGO
--------------------------------------------------
- Pedra quebra Tesoura
- Papel cobre Pedra

--------------------------------------------------
Leon venceu o jogo!!!
--------------------------------------------------

--------------------------------------------------
Letícia e Fábio perderam o jogo!
--------------------------------------------------
```

Para o segundo exemplo, o resultado seria apresentado assim:

```bash
--------------------------------------------------
                  NARRATIVAS DO JOGO
--------------------------------------------------
- Papel cobre Pedra
- Tesoura corta Papel
- Pedra quebra Tesoura

--------------------------------------------------
                    EMPATE!
--------------------------------------------------
```

## Requisitos do Software

- Capacidade de identificar **ganhadores** e **perdedores** com base nas interações das jogadas.
- Geração de uma `narrativa` simples explicando as interações vencedoras.
- Suporte para qualquer número de jogadores, com no mínimo dois jogadores.
- Tratamento de casos de **empate total** (todos os jogadores fazem a mesma jogada ou todos são perdedores).
- Tratamento de casos de **empate parcial** (múltiplos ganhadores), com os perdedores claramente identificados.
- Identificação dos **perdedores** mesmo em situações de empate entre ganhadores.