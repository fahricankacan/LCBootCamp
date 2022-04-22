using FluentValidation.AspNetCore;
using Week2.Application;
using Week2.Application.Features.Commands.CategoryCommands.CreateCategory;
using Week2.Application.Features.Commands.ProductCommands.CreateProduct;
using Week2.Application.Features.Commands.ProductCommands.DeleteProduct;
using Week2.Application.Features.Commands.ProductCommands.UpdateProduct;
using Week2.Infrastructure.Attributes;
using Week2.Persistence;
using static Week2.Application.Features.Queries.ProductQueries.GetByIdProduct.GetByIdProductQuery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(configuration => configuration
                    .RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<DeleteProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<GetByIdProductQueryValidator>()
                    .RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>())          
                .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
