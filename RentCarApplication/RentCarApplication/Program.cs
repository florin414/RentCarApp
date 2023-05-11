using AspNetCoreHero.ToastNotification.Extensions;
using RentCarApplication.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();



var connectionString =
    builder.Configuration.GetConnectionString("RentCarDBConnection")
    ?? throw new InvalidOperationException("Connection string 'RentCarDBConnection' not found.");

builder.Services.AddDbContext<RentCarContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity();
builder.Services.AddRepositories();

builder.Services.AddEndpointDefinitions();
builder.Services.AddNotification();
builder.Services.AddMediatR(typeof(EntryPointRequestHandlers));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();
app.MapRazorPages();
app.UseErrorHandler();

app.UseNotyf();

app.Run();
