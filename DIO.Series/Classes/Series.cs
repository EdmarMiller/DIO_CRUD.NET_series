namespace DIO.Series
{
    public class Series
    {
        // Atributos
        private Genero Genero {get; set; }
        private string Titulo {get; set; }
        private string Descricao {get; set; }
        private int Ano {get; set; }

        // Métodos Contrutor
    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
	{
		this.Id = id;
		this.Genero = genero;
		this.Titulo = titulo;
		this.Descricao = descricao;
		this.Ano = ano;
        this.Excluido = false;
	}


    }
}