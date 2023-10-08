# cast-validacao-conhecimentos
Validação de conhecimentos – .NET Core

Pré-requisitos: 
Equipamento próprio contendo as seguintes ferramentas já instaladas:
1. Docker; 
2. Git; 
3. IDE .Net (Visual Studio Community ou Visual Code);

Instruções: adicionais:
É permitido consultar a internet, porém não é permitido solicitar apoio a outras pessoas. 
É necessário criar uma conta no endereço: https://github.com/. 
A conta deverá ser utilizada para postar o projeto e implementar o build/release da aplicação. 

Critérios observados na avaliação: 
• Tempo total para finalizar a prova; 
• Coesão e baixo acoplamento; 
• Padrão de nomenclatura e organização; 
• Utilização adequada dos códigos de status e verbos HTTP; 
• Quantidade de tarefas finalizadas; 

Avaliação: 
Crie uma nova solução no Visual Studio com um projeto web em C# usando .Net Core 6.0.
Versione o projeto no GitHub e crie a estrutura de desenvolvimento e branches baseadas no GitFlow; 
Será necessário criar uma API REST (formato JSON) usando ASP.NET WebApi com seguintes itens: 
• Crie uma chamada para o serviço http://viacep.com.br/ws/01001000/json/ utilizando RestSharp e disponibilize um endpoint para expor o resultado da chamada, utilizando swagger. 
• Desenvolva um CRUD para a entidade “Conta” e exponha como operações na API. A entidade precisa ter apenas os atributos: nome e descrição. O acesso aos dados deve ser feito com o ORM Entity Framework usando a abordagem CodeFirst. 
Para persistência dos dados, utilize um banco de dados embedded (SQL Server LocalDB) ou um mecanismo de banco de dados em memória (Entity Framework Core In-memory ou similar); 

Crie um projeto de testes para a API seguindo as orientações: 
• Deverá ser feito ao menos um processo deste CRUD com cobertura de teste unitário. 

Crie um projeto ASP.NET MVC com Razor para consumo da API REST criada anteriormente. Os requisitos para este projeto são: 
• Usar “Data Annotations” para validação dos campos obrigatórios 
• Utilizar o template HTML padrão fornecido pela IDE. (Visual Studio Community ou Visual Code) 
• Criar as seguintes páginas e formulários: o Listagem de Contas (c/ botão “Remover Conta”) o Criação de nova Conta o Alteração de Conta existente 
O Projeto deverá ser entregue em um dockerfile funcional contendo a aplicação desenvolvida.
