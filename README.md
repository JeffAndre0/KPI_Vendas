# Projeto de Importação de Dados

Este projeto é responsável por importar dados de arquivos Excel para um banco de dados utilizando C# e Entity Framework Core.

## Configuração

Antes de executar o projeto, é necessário configurar o arquivo `appSettings.json` com as informações de conexão do banco de dados PostgreSQL e o diretório onde os arquivos Excel serão localizados.

Exemplo de `appSettings.json`:
```
{
    "folder" : "in",
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;"
      }
}
```
Onde 'folder' é a pasta de entrada dos arquivos que servirão de base

Certifique-se de substituir os valores dentro das aspas duplas pelos valores correspondentes ao seu ambiente.

## Requisitos

- .NET Core 3.1 ou superior
- Banco de dados PostgreSQL
- Arquivos Excel contendo os dados a serem importados

## Funcionalidades

- Importa dados de arquivos Excel para um banco de dados PostgreSQL.
- Suporta múltiplos arquivos Excel no mesmo diretório.

## Visualização de Dados

Os dados importados podem ser visualizados e analisados utilizando o arquivo do Power BI fornecido neste projeto. O arquivo do Power BI contém dashboard que mostra KPIs e insights a partir dos dados importados.

Para utilizar o arquivo do Power BI:
1. Abra o arquivo `Relatorio.pbix` no Power BI Desktop.
2. Atualize os dados para carregar os dados mais recentes do banco de dados.
3. Explore o dashboard para visualizar KPIs e análises dos dados.
