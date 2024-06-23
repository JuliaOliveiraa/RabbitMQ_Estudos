# Projeto de Exemplo - Sistema de Gestão de Alunos

Este projeto foi desenvolvido com fins didáticos para demonstrar conceitos de processamento de dados e integração de sistemas utilizando C#, RabbitMQ e MongoDB. O objetivo é simular um sistema de gestão de alunos, onde os dados dos alunos são processados em arquivos CSV, enviados para uma fila RabbitMQ e consumidos para serem armazenados em um banco de dados MongoDB.

## Estrutura do Projeto

O projeto é dividido em dois componentes principais: **Producer** e **Consumer**.

### Producer

O Producer é responsável por processar arquivos CSV contendo dados de notas e frequências dos alunos. Os dados são então enviados para uma fila RabbitMQ para serem consumidos pelo Consumer. O Producer utiliza C# e as seguintes ferramentas:

- **CsvHelper**: para processamento de arquivos CSV.
- **RabbitMQ.Client**: para integração com a fila RabbitMQ.
- **Newtonsoft.Json**: para serialização de objetos para JSON.

### Consumer

O Consumer é responsável por consumir os dados da fila RabbitMQ e armazená-los em um banco de dados MongoDB. O Consumer utiliza C# e as seguintes ferramentas:

- **RabbitMQ.Client**: para integração com a fila RabbitMQ.
- **MongoDB.Driver**: para integração com o banco de dados MongoDB.

## Como Executar

Para executar o projeto, siga as etapas abaixo:

1. Certifique-se de ter o RabbitMQ e o MongoDB instalados e em execução em sua máquina.
2. Clone este repositório em sua máquina local.
3. Abra o projeto em seu ambiente de desenvolvimento preferido (Visual Studio, Visual Studio Code, etc.).
4. Execute o Producer e o Consumer em instâncias separadas.
5. Siga as instruções de uso fornecidas em cada componente para processar os arquivos CSV e consumir os dados da fila RabbitMQ.

Este projeto é apenas para fins educacionais e pode ser modificado e estendido conforme necessário para atender a diferentes requisitos e cenários de uso.

**Desenvolvimento em andamento**

![image](https://github.com/JuliaOliveiraa/RabbitMQ_Estudos/assets/95725288/02234bd2-2324-426a-867a-635cf1c8fd35)

![image](https://github.com/JuliaOliveiraa/RabbitMQ_Estudos/assets/95725288/29a84b90-f623-4acb-91eb-c187f0aed9cf)
