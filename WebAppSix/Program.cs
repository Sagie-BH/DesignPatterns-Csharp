//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); //Finds all the end points
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My Api", Description = " Simple Mini Api" });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello/{name}", (string name) => $"Hello {name}");
app.MapGet("/person", () => new { FirstName = "Jona", LastName = "James" });

var todos = new List<Todo>();
app.MapGet("/todos", () => todos);
for (int i = 0; i < 10; i++)
{
    todos.Add(new Todo(i, "Title " + i, i % 2 == 0 ? true : false));
}
app.MapGet("/todos/{id}", (int id) => todos[id]);


app.MapPost("/todos", (Todo todo) =>
{
    var newTodo = todo with { Id = todos.Count };
    todos.Add(newTodo);
    return Results.Created($"todo/{newTodo.Id}", newTodo);
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.Run();

record Todo(int Id, string Title, bool IsDone);
