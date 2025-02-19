# Tibia Ciclopedia

Este é um projeto de WebAPI criado com o objetivo de estudar e aplicar conceitos de Clean Architecture e Domain-Driven Design (DDD). A proposta do projeto é criar uma enciclopedia sobre as entidades e itens do jogo Tibia, que é um MMORPG.

Sobre os itens. É realizada uma busca dos valores de compra e venda dos itens no mercado interno do jogo. Essa ação é realizada ao, cadastrar um novo item, ou buscar por aquele item.

Para a estrutura de persistencia, foi utilizado o Mongo.

## Tecnologias Utilizadas

-   .NET Core
-   ASP.NET Core WebAPI
-   MongoDB
-   RestAPI
-   SOLID
-   Clean Architecture
-   Domain-Driven Design (DDD)
-   Mediator
-   CrossCutting
-   AutoMapper
-   Docker
-   XUnit
-   Testes Unitários

## Estrutura do Projeto

O projeto segue a estrutura de Clean Architecture, separando responsabilidades em diferentes camadas:

-   **Domain**: Contém as entidades e interfaces de repositório.
-   **Application**: Contém os UseCases de Itens e Monstros, BaseOutput.
-   **Infrastructure-MongoDb**: Implementa os repositórios e serviços para acessar o MongoDB.
-   **Infrastructure-CrossCutting**: Implementa os serviços de conexão com API externa. Atualmente é utilizada uma API gratuita que retorna um número aleatório. Serve apenas para demonstrar a funcionalidade esperada caso uma API real estivesse disponível.
-   **API**: Exposição dos endpoints REST para o gerenciamento de itens e monstros.
-   **Tests**: Implementação de testes unitários para a Controller, Application, Domain e Infrastructure(Crosscutting e Mongo) de itens e monstros.


## Testes Unitários

- O projeto está com cobertura de testes em 80% das linhas de código validado pelo ReportGenerator.


## Funcionalidades

-   **CRUD de Itens**: Permite a criação, leitura, atualização e exclusão de itens.
-   **CRUD de Monsters**: Permite a criação, leitura, atualização e exclusão de monstros.


## Docker

- Foi disponibilizado um arquivo docker para que a aplicação seja testada. Para iniciar o arquivo, utilize o comando  docker-compose up -d --build dentro da pasta Tibia.Ciclopedia.API