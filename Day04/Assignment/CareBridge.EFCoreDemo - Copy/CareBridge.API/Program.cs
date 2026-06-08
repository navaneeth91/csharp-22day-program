using CareBridge.EFCoreDemo.Models.Generated;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext.
// ASP.NET Core will automatically create and inject it when needed.
builder.Services.AddDbContext<CareBridgeScaffoldContext>();

// Add Swagger support.
// Swagger gives us a testing screen for APIs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow Vue.js running on another port
// to call this API from the browser.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable Swagger.
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS.
app.UseCors();

// Simple health-check endpoint.
app.MapGet("/", () =>
{
    return "CareBridge API is running";
});

// Return first 20 patients.
// EF Core converts this LINQ query into SQL.
app.MapGet("/api/analytics/department-load",
    async (CareBridgeScaffoldContext db) =>
    {
        var result = await db.Encounters
            .Join(db.Departments,
                e => e.DepartmentId,   // FK in Encounters
                d => d.DepartmentId,             // PK in Departments
                (e, d) => new { e, d }) // project both
            .GroupBy(x => x.d.Name)    // group by department name
            .Select(g => new
            {
                Department = g.Key,
                InpatientCount = g.Count(x => x.e.EncounterType == "Inpatient"),
                OutpatientCount = g.Count(x => x.e.EncounterType == "Outpatient"),
                EDCount = g.Count(x => x.e.EncounterType == "ED"),
                Total = g.Count()
            })
            .Take(60)
            .ToListAsync();

        return result;
    });

app.Run();



