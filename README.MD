# CRUD de Estudantes com Entity Framework e SQLite

Este projeto é uma API para gerenciar estudantes (CRUD - Create, Read, Update, "Delete") usando o Entity Framework como ORM e SQLite como banco de dados.

### Tecnologias utilizadas

- **C#**
- **Entity Framework Core**
- **SQLite**
- **Minimal APIs** do ASP.NET Core

---

## Funcionalidades Implementadas

1. **Criar Estudante**:
   - Endpoint: `POST /studants`
   - Descrição: Adiciona um novo estudante. Verifica se o estudante já existe pelo nome antes de adicioná-lo.
   - Retorna o estudante criado.

2. **Listar Todos os Estudantes**:
   - Endpoint: `GET /studants/all`
   - Descrição: Retorna uma lista de todos os estudantes cadastrados.

3. **Listar Estudantes Ativos**:
   - Endpoint: `GET /studants/active`
   - Descrição: Retorna uma lista de estudantes que estão ativos.

4. **Atualizar Nome do Estudante**:
   - Endpoint: `PUT /studant/{id}`
   - Descrição: Atualiza o nome de um estudante pelo seu ID.

5. **Desativar Estudante**:
   - Endpoint: `DELETE /studants/desactive/{id}`
   - Descrição: Desativa um estudante pelo ID.

6. **Ativar Estudante**:
   - Endpoint: `PUT /studants/active/{id}`
   - Descrição: Reativa um estudante que foi desativado.

---