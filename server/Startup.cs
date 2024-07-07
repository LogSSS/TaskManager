using Microsoft.EntityFrameworkCore;
using Todo.Services;
using Todo.Repositories;
using Todo.Models;
using Todo.ModelsDTO;
using System.Reflection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        services.AddControllers();
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<Card, CardDTO>();
            cfg.CreateMap<CardDTO, Card>();
            cfg.CreateMap<CardList, CardListDTO>();
            cfg.CreateMap<CardListDTO, CardList>();
        }, Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(Startup));
        services.AddScoped<CardService>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ListService>();
        services.AddScoped<IListRepository, ListRepository>();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        dbContext.Database.Migrate();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}