using Data;
using Entities.Studant;
using Entities.Studants;
using Microsoft.EntityFrameworkCore;
using Studants.Model.Add;
using Studants.Model.Update;

namespace Studants.Endpoint;

public static class Studants
{
    public static void AddRoutesStudants(this WebApplication app)
    {
        app.MapPost("studants", async (AddStutantRequest request, AppDbContext context, CancellationToken ct) =>
        {

            var isExist = await context.Stutants.AnyAsync(studant => studant.Name == request.Name, ct);

            if (isExist)
            {
                return Results.Conflict(error: "Estudante já cadastrado");
            }

            var NewStutant = new Studant(request.Name);

            await context.Stutants.AddAsync(NewStutant, ct);

            await context.SaveChangesAsync(ct);

            var studantAdded = new StudantDto(NewStutant.Id, NewStutant.Name);

            return Results.Ok(studantAdded);

        });

        app.MapGet("studants/all", async (AppDbContext context, CancellationToken ct) =>
        {
            var studants = await context.Stutants.Select(studants => new StudantDto(studants.Id, studants.Name)).ToListAsync(ct);

            return studants;
        });

        app.MapGet("studants/active", async (AppDbContext context, CancellationToken ct) =>
        {
            var studants = await context.Stutants.Where(studants => studants.isActive).Select(studants => new StudantDto(studants.Id, studants.Name)).ToListAsync(ct);

            return studants;
        });

        app.MapPut("studant/{id}", async (Guid id, UpdateStudantRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var studant = await context.Stutants.SingleOrDefaultAsync(studant => studant.Id == id, ct);

            if (studant == null)
            {
                return Results.NotFound();
            }

            studant.UpdateName(request.Name);

            await context.SaveChangesAsync(ct);

            return Results.Ok(new StudantDto(studant.Id, studant.Name));
        });

        app.MapDelete("studants/desactive/{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var studant = await context.Stutants.SingleOrDefaultAsync(studant => studant.Id == id, ct);

            if (studant == null)
            {
                return Results.NotFound();
            }

            studant.Desactive();

            await context.SaveChangesAsync(ct);

            return Results.Ok("Aludo desativado!");
        });

        app.MapPut("studants/active/{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var studant = await context.Stutants.SingleOrDefaultAsync(studant => studant.Id == id, ct);

            if (studant == null)
            {
                return Results.NotFound();
            }

            studant.Active();

            await context.SaveChangesAsync(ct);

            return Results.Ok("Aludo ativado!");
        });

    }
}