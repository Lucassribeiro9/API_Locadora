<h1 align="center">
API_Locadora
</h1>


![image](https://user-images.githubusercontent.com/57766036/183265562-90a2228c-dfeb-4ffe-ae2b-36f125980ad4.png)

# 📖 Descrição do projeto
O projeto consiste em ter uma API simples, porém funcional, de uma locadora de filmes. Sua primeira versão traz apenas o registro dos filmes, que podem ser cadastrados contendo nome e gênero. No decorrer do documento, será mostrado as funcionalidades do projeto e as ferramentas necessárias para sua execução, junto com as ferramentas utilizadas para seu desenvolvimento. Esta é sua primeira versão e serão incrementadas mais funcionalidades no futuro.

# ✔️ Tecnologias utilizadas
[![My Skills](https://skills.thijs.gg/icons?i=cs,mysql&theme=dark)](https://skills.thijs.gg)
<img width="48" src="https://static.wikia.nocookie.net/logopedia/images/e/ec/Microsoft_Visual_Studio_2022.svg" alt="vs-logo"/>

## 📁 Acesso ao projeto
O código fonte está disponibilizado neste repositório. Você pode cloná-lo ou baixá-lo. Caso não esteja habituado a usar o Git e GitHub, <a href="https://github.com/rafaballerini/GitTutorial">clique aqui</a>

## 🛠️ Abrir e rodar o projeto
Após baixar o projeto, você pode abrir com o Visual Studio. Com o programa aberto, clique em:

- Open a project or solution (ou algo similar)
- Procure o local onde o projeto está salvo (caso esteja zipado, extraia o arquivo primeiro antes de procurar)
- Clique em Ok

O Visual Studio irá carregar o projeto e logo após, poderá ser executado.

⚠️ Antes de executar o projeto, verifique o arquivo <b>Program.cs</b> e <b>appsettings.json</b> caso faça uso do banco de dados. Altere a connectionString de acordo com seu banco, pois a migration será gerada conforme o banco utilizado. Caso seja na memória, altere no arquivo <b>FilmeController.cs</b> os métodos conforme o exemplo:

~~~csharp
 public async Task<ActionResult<IEnumerable<Filme>>> GetFilmeGenero(string genero)
        {
            if (_context.Filmes == null)
            {
                return NotFound();
            }
            var filme = await _context.Filmes.Where(x => x.Genero.Equals(genero)).AsNoTracking().ToListAsync(); // aqui
            
            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }
~~~

<h4>Program.cs</h4>

~~~csharp
var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<LocadoraDbContext>(option => option.UseMySql(connectionStringMySql, ServerVersion.Parse("MySQL 5.7.37")
~~~

<h4>appsettings.json</h4>

```json
"ConnectionStrings": {
    "ConnectionMySql": "Server=localhost;Port=3306;initial catalog=nomedobanco;uid=root;pwd=senhadobanco" // modifique conforme o banco que irá usar
  }
```

<a href="https://juniorb2s.medium.com/migrations-o-porque-e-como-usar-12d98c6d9269">O que são Migrations?</a>

<h4>Adicionando Migration</h4>

```
 Add-Migration inicial
```
Após a criação da migration, para a criação das tabelas e adaptação do CRUD, atualize sua base com o seguinte comando: 

```
 update-database
```

Para remover:

```
remove-migration "nome da migration"
```

# 🔨 Funcionalidades
- Retorna os filmes por ordem do ID (GET)

![get](https://user-images.githubusercontent.com/57766036/183537264-257066af-c570-4ea1-b460-50d415f41668.gif)

- Adiciona os filmes (POST)

![post](https://user-images.githubusercontent.com/57766036/183537300-ca991387-b473-4b00-9469-7ee8ec0e7e64.gif)


- Retorna os filmes por gênero (Busca por gênero)

![getbygenero](https://user-images.githubusercontent.com/57766036/183538059-a52908bd-a2c7-4210-8c8c-a66b7dda99f7.gif)


- Atualiza os filmes selecionados (PUT)
- Exclui os filmes selecionados (DELETE)




