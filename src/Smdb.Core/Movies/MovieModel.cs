namespace Smdb.Core.Movies;

//Clase que representa una Pelicula
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }

    // Constructor que inicializa todos los campos de la película
    public Movie(int id, string title, int year, string description)
    {
        Id = id;
        Title = title;
        Year = year;
        Description = description;
    }

    // Sobrescribe el método ToString para imprimir la película de forma legible
    public override string ToString()
    {
        return $"Movie[Id={Id}, Title={Title}, Year={Year}, Description={Description}]";
    }
}
