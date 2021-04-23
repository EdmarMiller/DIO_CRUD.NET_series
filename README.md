# DIO_CRUD.NET_series


## Objetivos do projeto

1. Implementação de CRUD de séries
2. Utilização de classes abstratas
3. Utilização de interfaces

****

### CRUD
* **C**reate/ Criar
* **R**ead/ Ler
* **U**pdate/ Atualizar
* **D**eleter/ Excluir
	
****
## Classes Abstratas

- Classes que podem conter métodos abstratos
	- um método abstrato é um método que é declarado, porém não contém implementação
- Não pode ser instanciada
- Exige subclasses que tenham implementação dos 
métodos abstratos
****
## Interfaces

- Interface é muito semelhante a uma classe abstrata, 
mas não possui atributos e não pode definir como os 
métodos devem ser implementados

- Em vez disso, é simplesmente uma lista de métodos 
que **devem** ser implementados

****
****
# Iniciando o projeto


> Comando para iniciar o projeto CMD
```shell
dotnet new console -n DIO.Series
```

> criar duas pastas na raiz, Classes e Interfaces 

```shell

│   DIO.Series.csproj
│   Program.cs
│
├───bin
│   
├───Classes
│       EntidadeBase.cs
│
├───Interfaces
└───obj
        
```

> Como queremos que todo programa tenha acesso a essa classe, deixamos o namespace... sem a Classes referente a pasta. Ficando so DIO.Series
```C#
namespace DIO.Series.Classes
namespace DIO.Series
        
```
> Criamos uma crasse abstract, somente com Id
```C#
namespace DIO.Series.Classes
namespace DIO.Series
        
```

> se tentarmos criar a classe abaixo no programa principal, recebereos o aviso que não
> podemos instanciar uma Classes abstrata ou interface
```C#
using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
          EntidadeBase minhaClasse = new EntidadeBase();
          Console.WriteLine("Hello World!");
        }
    }
}
```
        
>Vamos criar a classes Series que vai herdar da Classe EntidadeBase, usamos : como abaixo
```C#
    public class Series : EntidadeBase
    {
        
    }
        
```
Nesse caso abaixo conseguimos usar o Id sem causar erros.
```C#
using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
          Serie meuObjeto = new Serie();
          Console.WriteLine("Hello World!");
        }
    }
}
```

Genero dentro de Series é um Enum

> Add o Metodo Construtor
```C#
   public Serie(int id, Genero genero, string titulo, string descricao, int ano)
	{
		this.Id = id;
		this.Genero = genero;
		this.Titulo = titulo;
		this.Descricao = descricao;
		this.Ano = ano;
        this.Excluido = false;
	}
        
```

> Abaixo vamos sobrescrever o método ToString
```C#
    public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
        
```

> Colocaremos dos métodos encapsulado retorna titulo e retorna id, fazemos isso por os atrubutos titulo e id estão com private.
```C#
   public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        
```



Vamos criar uma Interface que vai se chamar IRepositorio.cs

```c#
using System.Collections.Generic;

namespace DIO.Series.Interfaces
{   // <T> na proxima linha diz, que essa Classes inpremente um repositorio, dessa outra classes T 
    public interface IRepositorio<T>
    {// Método que se chma lista e retorna lista de T
        List<T> Lista();
      // RetornaId que passamos por parametro id e ele retorna um T
        T RetornaPorId(int id);   
      // Teremos outros métodos como abaixo   
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
```
Criaremos uma Classes que vai se chamar SerieRepositorio

```c#
using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  // Aqui estamos falando que essa classe implementa uma inteface de Series
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}

```