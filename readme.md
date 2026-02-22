# 🧮 Projeto: Calculadora Simples com C# e Windows Forms
**Unidade Curricular 12 (UC 12) - Desenvolvimento Desktop**

Olá! Bem-vindo(a) ao repositório do nosso primeiro projeto prático. Se você está chegando agora ou revisando o conteúdo, não se preocupe: este guia foi feito para te ajudar a entender passo a passo como construímos uma calculadora funcional utilizando a linguagem C# e a interface do Windows Forms.

O objetivo aqui é praticar **lógica de programação**, **manipulação de variáveis**, **criação de métodos** e **eventos de clique**. Vamos lá?

## 🛠️ Pré-requisitos
* Visual Studio instalado (com o pacote de Desenvolvimento para Desktop com .NET).
* Vontade de aprender e não ter medo de errar!

---

## 🎨 Passo 1: Desenhando a Interface (UI)
Antes de programar, precisamos da tela da nossa calculadora. No Visual Studio, ao criar um projeto "Aplicativo do Windows Forms (.NET)", você verá um formulário em branco. Arraste os seguintes componentes da sua *Caixa de Ferramentas (Toolbox)* para a tela:

* **1 TextBox:** Onde os números e resultados vão aparecer.
  * *Nomeie para:* `txtResultado`
  * *Dica:* Mude a propriedade `Text` dele para `0` e o `TextAlign` para `Right` (direita).
* **10 Buttons (Números de 0 a 9):**
  * *Nomeie para:* `btn0`, `btn1`, `btn2`, ..., `btn9`.
* **4 Buttons (Operações Matemáticas):**
  * *Nomeie para:* `btnSomar`, `btnSubtrair`, `btnMultiplicar`, `btnDividir`.
* **3 Buttons (Ações Extras):**
  * *Nomeie para:* `btnResultado` (botão de Igual `=`)
  * `btnLimpar` (botão de limpar a tela `C`)
  * `btnVirgula` (botão da vírgula `,`)

---

## 🧠 Passo 2: A Lógica por Trás da Calculadora
Uma calculadora não resolve a conta de uma vez. Quando você digita "5 + 3 =", ela precisa memorizar o **5** e o **+** enquanto você digita o **3**. Para isso, usamos duas variáveis globais no topo do nosso código:

```csharp
private double primeiroValor; // Guarda o primeiro número digitado
private string operacao;      // Guarda qual operação foi escolhida (+, -, *, /)
```
## ⚙️ Passo 3: Os Métodos Principais (O "Coração" do Código)
Para não repetirmos código toda hora, criamos "MÉTODOS" (funções) que agrupam lógicas que usaremos várias vezes.

* 1. Digitando os Números: EscreverNumero()
Quando clicamos no botão "1", não queremos apagar o que já está na tela, queremos colocar o "1" do lado (concatenar). Mas atenção: se a tela só tiver um "0", devemos substituir o "0" pelo número digitado.

```C#
private void EscreverNumero(string numero)
{
    // Se o texto não for o "0" inicial, juntamos o número novo ao texto existente.
    if (txtResultado.Text != "0")
        txtResultado.Text += numero;
    else
        // Se for "0", substituímos pelo número digitado.
        txtResultado.Text = numero;
}
```
* 2. Escolhendo a Operação: SelecionarOperacao()
Quando o usuário clica em +, -, * ou /, nós precisamos salvar o número que está na tela no nosso primeiroValor, salvar a operação escolhida, e "limpar" a tela para o usuário digitar o segundo número.

```csharp
private void SelecionarOperacao(string operacao_selecionada)
{
    primeiroValor = Convert.ToDouble(txtResultado.Text); // Salva o número
    txtResultado.Text = "0"; // Prepara a tela para o próximo número
    operacao = operacao_selecionada; // Salva o sinal matemático
}
```
* 3. Fazendo a Conta: RealizarOperacao()
Este método usa o comando switch (uma espécie de "escolha-caso") para olhar a variável operacao e decidir qual cálculo fazer. Note que ele já tem uma proteção para evitar que o programa quebre ao tentar dividir por zero!

```csharp
private double RealizarOperacao(double valor1, double valor2)
{
    double resultado = 0;
    switch (operacao)
    {
        case "+": resultado = valor1 + valor2; break;
        case "-": resultado = valor1 - valor2; break;
        case "*": resultado = valor1 * valor2; break;
        case "/": 
            if (valor2 != 0) // Evita erro de divisão por zero!
                resultado = valor1 / valor2; 
            break;
    }
    return resultado;
}
```
## 🖱️ Passo 4: Ligando os Botões (Eventos de Clique)
Com a lógica pronta, basta dar dois cliques em cada botão no visual da sua calculadora para gerar o "Evento de Clique" no código e chamar os métodos que criamos.

Nos botões de número, chamamos o método EscreverNumero("1"), passando o número do botão.

Nos botões de operação, chamamos o método SelecionarOperacao("+"), passando o sinal da operação.

No botão de Igual (=) (btnResultado_Click), pegamos o segundo valor da tela, chamamos o método que faz a conta, e exibimos o resultado!

E não se esqueça do botão da vírgula! Ele tem uma verificação inteligente Contains(",") para garantir que o usuário não digite duas vírgulas no mesmo número (ex: "5,,2").
