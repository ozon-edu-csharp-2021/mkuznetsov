using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchApi.Infrastructure.Handlers;
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
            services.AddSingleton<IConfiguratorRepository, ConfiguratorStubMemoryRepository>();
            services.AddSingleton<IMerchConfigurator, MerchConfigurator>();
            services.AddSingleton<IMerchService, MerchService>();
            services.AddSingleton<IEmployeeRepository, EmployeeStubRepository>();
            services.AddSingleton<IMerchRepository, MerchStubRepository>();
            
            return services;
        }
    }
}