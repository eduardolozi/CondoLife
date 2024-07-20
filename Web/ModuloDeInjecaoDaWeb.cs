using Dominio.Enums;

namespace Web
{
    public class ModuloDeInjecaoDaWeb
    {
        public static void RegistrarPolicies(IServiceCollection servicos)
        {
            servicos.AddAuthorization(options =>
            {
                options.AddPolicy("SINDICO_OU_SECRETARIO", policy =>
                {
                    policy.RequireClaim("tipo_de_usuario", TipoDeUsuarioEnum.Sindico.ToString(), TipoDeUsuarioEnum.Secretario.ToString());
                });
            });
        }
    }
}
