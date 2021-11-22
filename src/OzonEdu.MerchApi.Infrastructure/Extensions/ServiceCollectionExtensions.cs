using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Handlers;
using OzonEdu.MerchApi.Infrastructure.Repositories.Implementation;
using OzonEdu.MerchApi.Infrastructure.Services;
using OzonEdu.MerchApi.Infrastructure.Stubs;

namespace OzonEdu.MerchApi.Infrastructure.Extensions
{
    /// <summary>
    /// Класс расширений для типа <see cref="IServiceCollection"/> для регистрации инфраструктурных сервисов
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetEmployeeHandler).Assembly);
            
            return services;
        }
        
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConfiguratorRepository, ConfiguratorStubMemoryRepository>();
            services.AddScoped<IMerchConfigurator, MerchConfigurator>();
            services.AddScoped<IMerchService, MerchService>();
            services.AddScoped<IEmployeeRepository, EmployeeStubRepository>();
            services.AddScoped<IMerchRepository, MerchRepository>();
            
            return services;
        }
    }
}