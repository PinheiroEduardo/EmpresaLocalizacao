using System.Data.Entity;
using EmpresaLocalizacao.Models;

namespace EmpresaLocalizacao.Context
{
    public class EmpresaLocalizacaoContext : DbContext
    {
        public EmpresaLocalizacaoContext()
            : base("EmpresaLocalizacao")
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
    }
}