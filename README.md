# Projeto - API de Cadastro de Empresas com Autenticação JWT e ReceitaWS

## Visão Geral

Esta API permite o cadastro e consulta de empresas a partir do CNPJ utilizando a API pública da ReceitaWS, com autenticação via JWT (com suporte a refresh token). O sistema também implementa controle de usuários, garantindo que cada empresa cadastrada esteja vinculada a um usuário autenticado.

---

## Funcionalidades

- ✅ Cadastro de usuários
- ✅ Login com geração de JWT (válido por 1 minuto)
- ✅ Geração de Refresh Token (válido por 10 minutos)
- ✅ Cadastro de empresa via CNPJ, consultando dados da **ReceitaWS**
- ✅ Consulta paginada das empresas cadastradas pelo **usuário logado**
- ✅ Autorização por Bearer Token
- ✅ Padrão arquitetural **CQRS** com uso de `Handlers`, `Commands` e `Queries`

---

## Endpoints

### 🔐 Autenticação

- `POST /User/Cadastrar`  
  ➝ Cadastro de novo usuário

- `POST /User/Login`  
  ➝ Autenticação e geração de JWT + Refresh Token

- `POST /login/refreshToken`  
  ➝ Geração de novo JWT a partir do Refresh Token

---

### 🏢 Empresa

- `POST /Empresa/CadastroDeEmpresa/{cnpj}`  
  ➝ Consulta CNPJ na ReceitaWS e cadastra empresa no sistema  
  🔐 Requer autenticação

- `GET /Empresa/PesquisaEmpresa?page=1&pageSize=10`  
  ➝ Lista empresas cadastradas pelo usuário logado (paginado)  
  🔐 Requer autenticação

---

## Cadastro via ReceitaWS

Ao cadastrar uma empresa com o CNPJ, os seguintes dados são preenchidos automaticamente a partir da API pública da ReceitaWS:

- Nome empresarial  
- Nome fantasia  
- CNPJ  
- Situação  
- Data de abertura  
- Tipo  
- Natureza jurídica  
- Atividade principal  
- Endereço (logradouro, número, complemento, bairro, município, UF, CEP)

---

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- JWT Bearer Authentication
- CQRS (Command Query Responsibility Segregation)
- API Pública ReceitaWS

---

## Observações

- Os tokens JWT têm validade de **1 minuto**.
- Os tokens de refresh têm validade de **10 minutos**.
- Apenas usuários autenticados podem cadastrar e visualizar empresas.

- ## Autor
Leonardo Pagni

