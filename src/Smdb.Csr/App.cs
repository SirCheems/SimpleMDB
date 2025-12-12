namespace Smdb.Csr;

using Shared.Http;

// Servidor para el cliente (CSR – Client-Side Rendering)
public class App : HttpServer
{
    public App()
    {
    }

    // Inicializa el servidor CSR y configura el enrutamiento y middleware
    public override void Init()
    {
        // Middleware para logging estructurado de las peticiones
        router.Use(HttpUtils.StructuredLogging);

        // Middleware para manejo centralizado de errores
        router.Use(HttpUtils.CentralizedErrorHandling);

        // Middleware para agregar cabeceras CORS
        router.Use(HttpUtils.AddResponseCorsHeaders);

        // Middleware para responder con NotFound si ninguna ruta coincide
        router.Use(HttpUtils.DefaultResponse);

        // Middleware para parsear la URL de la petición
        router.Use(HttpUtils.ParseRequestUrl);

        // Middleware para parsear la query string de la petición
        router.Use(HttpUtils.ParseRequestQueryString);

        // Middleware para servir archivos estáticos (HTML, CSS, JS)
        router.Use(HttpUtils.ServeStaticFiles);

        // Middleware para coincidencia simple de rutas
        router.UseSimpleRouteMatching();

        // Redirección de la ruta raíz a index.html
        router.MapGet("/", async (req, res, props, next) =>
        {
            res.Redirect("/index.html");
            await next();
        });

        // Redirección de /movies a la página de movies del cliente
        router.MapGet("/movies", async (req, res, props, next) =>
        {
            res.Redirect("/movies/index.html");
            await next();
        });
    }
}
