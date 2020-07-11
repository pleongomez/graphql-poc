using graphql.poc.core.Repository;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace graphql.poc.server.middleware
{
    public class GraphQLRequest
    {
        private JObject _variables;
        public string OperationName { get; set; }
        public string Query { get; set; }

        public JObject Variables
        {
            get => _variables ?? new JObject(new JObject { });
            set => _variables = value;
        }
    }

    public static class GraphQLMiddlewareExtension
    {
        public static void UseGraphQLMiddleware<T>(this IApplicationBuilder builder) where T : ISchema
        {
            builder.UseMiddleware<GraphQLMiddleware<T>>();
        }
    }

    public class GraphQLMiddleware<T> where T: ISchema
    {
        private readonly RequestDelegate _next;
        private T _schema { get; }
        private readonly IDocumentExecuter _executer;
        private readonly IDocumentWriter _writer;

        public GraphQLMiddleware(RequestDelegate next, T schema, IDocumentExecuter executer, IDocumentWriter writer)
        {
            _next = next;
            _schema = schema;
            _executer = executer;
            _writer = writer;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Method.ToLower() != "post" && context.Request.Path != "/graphql")
            {
                await _next(context);
                return;
            }

            var request = Deserialize<GraphQLRequest>(context.Request.Body);

            var result = await _executer.ExecuteAsync(new ExecutionOptions
            {
                Schema = _schema,
                Query = request.Query,
                OperationName = request.OperationName,
                Inputs = request.Variables.ToInputs()
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)(result.Errors?.Any() == true ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
            await context.Response.WriteAsync(_writer.Write(result));
        }

        private static S Deserialize<S>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                using (var jsonreader = new JsonTextReader(reader))
                {
                    return new JsonSerializer().Deserialize<S>(jsonreader);
                }
            }
        }
    }
}
