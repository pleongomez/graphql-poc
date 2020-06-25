using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using graphql.poc.core.Repository;
using graphql.poc.core.Services;
using graphql.poc.repository;
using graphql.poc.repository.Repository;
using graphql.poc.schema;
using graphql.poc.schema.Types;
using graphql.poc.server.Helper;
using graphql.poc.server.middleware;
using graphql.poc.services.Services;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace graphql.poc.server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerService, PlayerService>();

            var assemblyname = typeof(NbaContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<NbaContext>(options =>
            {
                options.UseSqlServer(
                Configuration.GetConnectionString("nbadatabase"),
                sqlServer => sqlServer.MigrationsAssembly(assemblyname));
            });

            services.AddScoped<IDependencyResolver>(servicesProvider =>
            {
                return new FuncDependencyResolver(servicesProvider.GetService);
            });

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddScoped<TeamType>();
            services.AddScoped<PlayerType>();
            services.AddScoped<QueryType>();
            services.AddScoped<NbaSchema>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseMigrationDatabase<NbaContext>();
            app.UseGraphQLMiddleware<NbaSchema>();
            app.UsePlayground();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
