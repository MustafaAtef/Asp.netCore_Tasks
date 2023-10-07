namespace Middleware_task.CustomMiddlewares {
    public static class ExtensionMethods {

        public static IApplicationBuilder UseCustomLogin(this IApplicationBuilder app) {
            return app.UseMiddleware<LoginMiddleware>();
        }

    }
}
