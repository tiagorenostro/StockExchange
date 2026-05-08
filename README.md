📈 Stock Exchange Terminal
Um sistema de negociação de ativos de baixa latência que utiliza processamento in-memory e comunicação em tempo real via FIX Protocol (simulado) e SignalR.

🏗️ Arquitetura do Projeto
O ecossistema é composto por três aplicações integradas:

Trading Worker (Engine): O "coração" do sistema. Valida ordens, controla a exposição financeira por símbolo e gerencia o estado do portfólio em memória RAM.

Trading API (Backend): Interface REST que recebe as intenções de compra/venda do usuário e as encaminha para o motor de execução.

Trading Terminal (Frontend): Dashboard interativo em Vue.js para envio de ordens e visualização de posição em tempo real.

🛠️ Tecnologias Utilizadas
Backend: .NET 10 (C#)

Frontend: Vue.js 3, Vite, SignalR Client

Comunicação: SignalR (Real-time) e Injeção de Dependência

Banco de Dados: In-Memory (RAM) usando ConcurrentDictionary (Zero Infra!)

🚀 Como Executar
1. Backend (C#)

Certifique-se de ter o SDK do .NET 10 instalado.

Importante: A sequência de inicialização é fundamental para o registro dos serviços.

Navegue até a pasta do Worker e execute:

Bash
dotnet run
Navegue até a pasta da Web API e execute:

Bash
dotnet run
2. Frontend (Vue.js)

Certifique-se de ter o Node.js (versão LTS recomendada) instalado.

Entre na pasta do projeto frontend:

Bash
    cd stock-exchange-web
    ```
2.  Instale as dependências:
    ```bash
    npm install
    ```
3.  Inicie a aplicação:
    ```bash
    npm run dev
    ```

---

## ⚠️ Observações Importantes

*   **Persistência:** Por ser um banco de dados **in-memory**, todos os dados (ordens e posições) serão resetados ao reiniciar o Worker e a API.
*   **Portas de Comunicação:** 
    *   A API está configurada para rodar por padrão na porta `5151`.
    *   O Front-end busca o Hub do SignalR em `http://localhost:5151/tradingHub`.
    *   Caso as portas variem no seu ambiente, ajuste as URLs no arquivo `App.vue`.
*   **CORS:** O backend está configurado para aceitar requisições originadas do front (`localhost:5173`).

---