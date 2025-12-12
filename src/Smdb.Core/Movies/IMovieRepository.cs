namespace Smdb.Core.Movies;

using Shared.Http;

// Interfaz que define las operaciones CRUD para almacenar y recuperar películas
// Separa la lógica de almacenamiento (repositorio) del servicio y los controladores
public interface IMovieRepository
{
    // Retorna un conjunto paginado de películas, útil para endpoints con paginación
    public Task<PagedResult<Movie>?> ReadMovies(int page, int size);

    // Crea una nueva película en el repositorio y retorna el objeto creado
    public Task<Movie?> CreateMovie(Movie newMovie);

    // Recupera una película específica por ID
    public Task<Movie?> ReadMovie(int id);

    // Actualiza los datos de una película existente y retorna la película actualizada
    public Task<Movie?> UpdateMovie(int id, Movie newData);

    // Elimina una película por ID y retorna la película eliminada (o null si no existe)
    public Task<Movie?> DeleteMovie(int id);
}
