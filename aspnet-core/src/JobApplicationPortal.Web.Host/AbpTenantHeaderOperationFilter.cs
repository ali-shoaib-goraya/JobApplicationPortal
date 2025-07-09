using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class AbpTenantHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Abp.TenantId",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Tenant Id (e.g. 1 for Default)",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}
