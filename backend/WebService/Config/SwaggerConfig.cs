// *******************************************************************
// �Ɩ����́@: �ݏ��h�u�V�X�e��
// �@�\�T�v�@: 
//
// �쐬���@�@: 2024.07.17
// �쐬�ҁ@�@: AIPlus
// �ύX�����@:
// *******************************************************************
using JBD.GJS.Common;
using Microsoft.OpenApi.Models;

namespace JBD.GJS.WebService.Config;

public static class SwaggerConfig
{
    private const string TokenHeaderName = "token";

    public static void ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition(TokenHeaderName, new OpenApiSecurityScheme
            {
                Name = TokenHeaderName,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            option.AddSecurityDefinition(nameof(DaRequestBase.userid), new OpenApiSecurityScheme
            {
                Name = nameof(DaRequestBase.userid),
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            option.AddSecurityDefinition(nameof(DaRequestBase.regsisyo), new OpenApiSecurityScheme
            {
                Name = nameof(DaRequestBase.regsisyo),
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            var tokenScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = TokenHeaderName }
            };
            var userIdScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = nameof(DaRequestBase.userid) }
            };
            var regsisyoScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = nameof(DaRequestBase.regsisyo) }
            };
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                [tokenScheme] = Array.Empty<string>(),
                [userIdScheme] = Array.Empty<string>(),
                [regsisyoScheme] = Array.Empty<string>()
            });
        });
    }
}