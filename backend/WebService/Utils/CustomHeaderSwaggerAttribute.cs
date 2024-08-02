// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Jbd.Gjs.WebService
{
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Token",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}