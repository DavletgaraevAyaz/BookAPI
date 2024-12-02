using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextApi;
using WebApplication1.Interface;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddScoped<IHistoryBookRentalService, HistoryBookRentalService>();
builder.Services.AddScoped<IReadersService, ReadersService>();
// ��������� ������� � ���������.

// ����������� Swagger/OpenAPI ��� ������������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ����������� ����������� � ���� ������
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")),
    ServiceLifetime.Scoped);

var app = builder.Build();

// ����������� �������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// ����������� ������������� ��� ������������
app.MapControllers();

app.Run();
