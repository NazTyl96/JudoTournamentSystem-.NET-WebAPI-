namespace JTS.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<Context>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }
        }
    }
}