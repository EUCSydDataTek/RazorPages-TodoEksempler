using TodoLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITodoRepository,TodoRepository>();

var app = builder.Build();

var repo = app.Services.GetRequiredService<ITodoRepository>();
repo.CreateTodoItem(new TodoLibrary.Objects.TodoItem { Name = "Do something on startup", Created = DateTime.Now, IsCompleted = false });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
