var builder = WebApplication.CreateBuilder(args);

// 🔥 Controllers ekle (API için gerekli)
builder.Services.AddControllers();

// 🔥 CORS (frontend bağlantı için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// 🔥 CORS aktif et
app.UseCors("AllowAll");

// (İstersen sonra açarız, şimdilik kapalı olabilir)
app.UseHttpsRedirection();

// 🔥 Controller'ları aktif et
app.MapControllers();

app.Run();
