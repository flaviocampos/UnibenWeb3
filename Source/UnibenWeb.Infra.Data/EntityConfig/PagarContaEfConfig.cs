using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class PagarContaEfConfig : EntityTypeConfiguration<PagarConta>
    {
        public PagarContaEfConfig()
        {
            ToTable("PagarContas");
            HasKey(p => p.PagarContaId);

            Ignore(c => c.ResultadoValidacao);

            // Relacionamento CentroCusto (1) para PagarConta (0..1) em CentroCustoId
            //HasRequired(s => s.CentroCusto).WithOptional().Map(x => x.MapKey("CentroCustoId"));
            HasRequired(s => s.CentroCusto).WithMany().HasForeignKey(x=>x.CentroCustoId);

            // Relacionamento de Pessoa (1) para PagarConta (0..1) em FornecedorId
            //HasRequired(s => s.Fornecedor).WithOptional().Map(x => x.MapKey("FornecedorId"));
            HasRequired(s => s.Fornecedor).WithMany().HasForeignKey(x=>x.FornecedorId);

        }
    }
}
