# Projeto de Exemplo - Sistema de Gest�o de Alunos

Este projeto foi desenvolvido com fins did�ticos para demonstrar conceitos de processamento de dados e integra��o de sistemas utilizando C#, RabbitMQ e MongoDB. O objetivo � simular um sistema de gest�o de alunos, onde os dados dos alunos s�o processados em arquivos CSV, enviados para uma fila RabbitMQ e consumidos para serem armazenados em um banco de dados MongoDB.

## Estrutura do Projeto

O projeto � dividido em dois componentes principais: **Producer** e **Consumer**.

### Producer

O Producer � respons�vel por processar arquivos CSV contendo dados de notas e frequ�ncias dos alunos. Os dados s�o ent�o enviados para uma fila RabbitMQ para serem consumidos pelo Consumer. O Producer utiliza C# e as seguintes ferramentas:

- **CsvHelper**: para processamento de arquivos CSV.
- **RabbitMQ.Client**: para integra��o com a fila RabbitMQ.
- **Newtonsoft.Json**: para serializa��o de objetos para JSON.

### Consumer

O Consumer � respons�vel por consumir os dados da fila RabbitMQ e armazen�-los em um banco de dados MongoDB. O Consumer utiliza C# e as seguintes ferramentas:

- **RabbitMQ.Client**: para integra��o com a fila RabbitMQ.
- **MongoDB.Driver**: para integra��o com o banco de dados MongoDB.

## Como Executar

Para executar o projeto, siga as etapas abaixo:

1. Certifique-se de ter o RabbitMQ e o MongoDB instalados e em execu��o em sua m�quina.
2. Clone este reposit�rio em sua m�quina local.
3. Abra o projeto em seu ambiente de desenvolvimento preferido (Visual Studio, Visual Studio Code, etc.).
4. Execute o Producer e o Consumer em inst�ncias separadas.
5. Siga as instru��es de uso fornecidas em cada componente para processar os arquivos CSV e consumir os dados da fila RabbitMQ.

Este projeto � apenas para fins educacionais e pode ser modificado e estendido conforme necess�rio para atender a diferentes requisitos e cen�rios de uso.

**Desenvolvimento em andamento**