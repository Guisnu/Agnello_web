# Agnello - README (instrução de credenciais)

Antes de iniciar o projeto, é obrigatório atualizar as credenciais e strings de conexão nos arquivos de configuração. Caso contrário a aplicação não iniciará corretamente.

## O que ajustar
1. Abra `appsettings.json` (ou `appsettings.Development.json`) e localize:
   - `ConnectionStrings` (ex.: `DefaultConnection`)
   - Seções sensíveis como `Smtp`, `ApiKeys`, `OAuth`, etc.# Agnello - README (instrução de credenciais)

Antes de iniciar o projeto, é obrigatório atualizar as credenciais e strings de conexão nos arquivos de configuração. Caso contrário a aplicação não iniciará corretamente.

## O que ajustar
1. Abra `appsettings.json` (ou `appsettings.Development.json`) e localize:
   - `ConnectionStrings` (ex.: `DefaultConnection`)
   - Seções sensíveis como `Smtp`, `ApiKeys`, `OAuth`, etc.

2. Substitua valores placeholder pelos valores reais do seu ambiente. Exemplo:

```Json
{ "ConnectionStrings": { "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;" }}
```

3. Recomendações de segurança:
   - Não comite credenciais reais no repositório.
