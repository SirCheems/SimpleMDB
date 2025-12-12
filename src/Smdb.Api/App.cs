namespace Smdb.Api;

using Shared.Http;
using Smdb.Api.Movies;
using Smdb.Core.Movies;
using Smdb.Core.Db;

public class App : HttpServer
{
    // Este método se llama al inicializar el servidor y configura todos los routers y servicios
    public override void Init()
    {
        // ---------------------------
        // Configuración del Core
        // ---------------------------
        var db = new MemoryDatabase(); // Base de datos en memoria
        var movieRepo = new MemoryMovieRepository(db); // Repositorio de películas usando la DB en memoria
        var movieServ = new DefaultMovieService(movieRepo); // Service layer que maneja la lógica de películas
        var movieCtrl = new MoviesController(movieServ); // Controller que expone métodos de CRUD
        var movieRouter = new MoviesRouter(movieCtrl); // Router que define endpoints HTTP
        var apiRouter = new HttpRouter(); // Router base para la API

        // ---------------------------
        // Middlewares globales
        // ---------------------------
        router.Use(HttpUtils.StructuredLogging); // Loguea cada request con información estructurada
        router.Use(HttpUtils.CentralizedErrorHandling); // Manejo centralizado de errores
        router.Use(HttpUtils.AddResponseCorsHeaders); // Agrega headers CORS a las respuestas
        router.Use(HttpUtils.DefaultResponse); // Envía 404 si ninguna ruta fue atendida
        router.Use(HttpUtils.ParseRequestUrl); // Parsea la URL de la request y guarda info en props
        router.Use(HttpUtils.ParseRequestQueryString); // Parsea query strings y guarda info en props
        router.UseParametrizedRouteMatching(); // Habilita rutas con parámetros (/:id)

        // ---------------------------
        // Montaje de routers
        // ---------------------------
        router.UseRouter("/api/v1", apiRouter); // Monta el router principal de la API en /api/v1
        apiRouter.UseRouter("/movies", movieRouter); // Monta el router de películas en /api/v1/movies
    }
}
