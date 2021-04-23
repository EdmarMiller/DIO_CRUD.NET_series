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