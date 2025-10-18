# desafio

Projeto de API em .NET para um desafio técnico.

## 🚀 Rodando o projeto

Para rodar o projeto em ambiente de desenvolvimento, você só precisa ter o Docker e o Docker Compose instalados na sua máquina.

Com o Docker em execução, navegue até a pasta raiz do projeto e execute o seguinte comando:

```bash
docker compose up
```

Este comando irá:
1.  Subir uma instância do banco de dados PostgreSQL.
2.  Construir e iniciar a aplicação da API.
3.  Aplicar as migrations do Entity Framework automaticamente.
4.  Executar os *seeds* para popular o banco com dados iniciais, incluindo um usuário administrador.

## 📚 Documentação da API (Swagger)

A documentação dos endpoints da API está disponível via Swagger. Após iniciar a aplicação, você pode acessá-la no seu navegador através do seguinte endereço:

[http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)

## 🔑 Autenticação

Os *seeds* do projeto criam um usuário administrador padrão. Para obter um token de autenticação, envie uma requisição `POST` para o endpoint `/api/token/login` com o seguinte corpo (JSON):

```json
{
  "username": "admin",
  "password": "Admin@123"
}
```

Utilize o token JWT retornado no cabeçalho `Authorization` das requisições protegidas, no formato `Bearer {seu-token}`.

## 🏛️ Estrutura do Projeto + +O projeto foi desenvolvido seguindo os princípios da Clean Architecture, separando as responsabilidades em diferentes camadas. A solução é composta por 4 projetos: 
    * Desafio.Domain: A camada mais interna, contendo as entidades e as regras de negócio essenciais da aplicação.
    * Desafio.Application: Contém as regras de domínio da aplicação (casos de uso). Serve como um orquestrador entre a camada de apresentação e a camada de domínio.
    * Desafio.Infrastructure: Responsável pela implementação de detalhes de infraestrutura, como o acesso ao banco de dados (repositórios), e pela configuração do container de injeção de dependência (DI) do .NET.
    * Desafio.Api: A camada mais externa, responsável por expor os endpoints da API, receber as requisições HTTP e retornar as respostas.
