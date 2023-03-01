internal class Program
{
	private static void Main(string[] args)
	{
		WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

		WebApplication app = builder.Build();

		_ = app.MapGet("/", () => "Hello World!");

		app.Run();
	}
}