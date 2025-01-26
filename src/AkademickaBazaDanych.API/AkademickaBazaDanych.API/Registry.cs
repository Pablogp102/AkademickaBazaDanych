using AkademickaBazaDanych.Application.Core;

namespace AkademickaBazaDanych.API
{
    public static class Registry
    {
        public static async Task InitializeAndRun(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            foreach (var initializer in scope.ServiceProvider.GetServices<IApplicationInitializer>())
            {
                await initializer.Initialize();
            }

            await app.RunAsync();
        }
    }
}
