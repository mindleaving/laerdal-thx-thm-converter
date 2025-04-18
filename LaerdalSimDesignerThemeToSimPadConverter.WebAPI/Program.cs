using LaerdalSimDesignerThemeToSimPadConverter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<ThxFileReader>();
builder.Services.AddSingleton<ThmFileWriter>();
builder.Services.AddSingleton<ThxToThmConverter>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("content-disposition")
            .AllowCredentials();
    });
});

// -----

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseCors();
}

app.MapControllers();
app.Run();
