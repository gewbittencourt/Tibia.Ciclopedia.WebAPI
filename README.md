# Tibia Ciclopedia

Este é um projeto de WebAPI criado com o objetivo de estudar e aplicar conceitos de Clean Architecture e Domain-Driven Design (DDD). A proposta do projeto é criar uma enciclopedia sobre as entidades e itens do jogo Tibia. Onde é realizado um crosscutting realizando interações com uma api externa que retorna o valor de compra/venda de mercado dos itens do jogo. Atualmente está sendo utilizada uma API gratuita que retorna o valor atual da moeda Bitcoin, mas isso é apenas para demonstração.

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
-   **Application**: Contém as interfaces de serviços, serviços de aplicação, BaseOutput, Input e Outputs.
-   **Infrastructure**: Implementa os repositórios e serviços para acessar o MongoDB.
-   **CrossCutting**: Conexão e busca do valor do Bitcoin em API externa para atualização dos valores de Compra/Venda.
-   **API**: Exposição dos endpoints REST para o gerenciamento das tarefas, BaseResponses para exposição de dados e respostas.
-   **Tests**: Implementação de testes unitários para a Controller, Service e Repository.



## Testes Unitários

- O projeto está com cobertura de testes em 80% das linhas de código.


## Funcionalidades

-   **CRUD de Tarefas**: Permite a criação, leitura, atualização, finalização e exclusão de itens e monstros.