namespace Smdb.Core.Movies;

using Shared.Http;

// Interfaz que define los métodos del servicio de películas
// Cada método retorna un Result<T> para manejar errores y payload de manera tipada
public interface IMovieService
{
    // Devuelve un resultado paginado de películas
    // page y size controlan la paginación
    public Task<Result<PagedResult<Movie>>> ReadMovies(int page, int size);

    // Crea una nueva película y retorna un Result<Movie>
    public Task<Result<Movie>> CreateMovie(Movie movie);

    // Retorna una película específica por ID envuelta en Result<Movie>
    public Task<Result<Movie>> ReadMovie(int id);

    // Actualiza los datos de una película existente y retorna el resultado
    public Task<Result<Movie>> UpdateMovie(int id, Movie newData);

    // Elimina una película por ID y retorna el resultado
    public Task<Result<Movie>> DeleteMovie(int id);
}
