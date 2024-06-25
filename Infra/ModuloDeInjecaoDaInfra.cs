using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ModuloDeInjecaoDaInfra
    {
        public static void RegistrarServicos(IServiceCollection services)
        {

            services.AddDbContext<CondoLifeContext>();
        }
    }
}
