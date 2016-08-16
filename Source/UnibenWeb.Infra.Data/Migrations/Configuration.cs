using System;
using System.Data.Entity.Migrations;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UnibenWeb.Infra.Data.Context.UnibenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UnibenWeb.Infra.Data.Context.UnibenContext context)
        {
            context.EstadoCivis.AddOrUpdate(p => p.EstadoCivilId
                , new EstadoCivil() { Descricao = "Solteiro(a)", Obs = "Estado Civil Solteiro(a) da Pessoa" }
                , new EstadoCivil() { Descricao = "Casado(a)", Obs = "Estado Civil Casado(a) da Pessoa" });

            context.Bancos.AddOrUpdate(b => b.BancoId
                , new Banco() { Nome = "Banco do Brasil" }
                , new Banco() { Nome = "Santander" }
                );

            context.PessoaSexos.AddOrUpdate(b => b.PessoaSexoId
            , new PessoaSexo() { Descricao = "Masculino" }
            , new PessoaSexo() { Descricao = "Feminino" }
            );

            context.PessoaTipos.AddOrUpdate(x => x.PessoaTipoId
                , new PessoaTipo() { Descricao = "Pessoa Jur�dica", Obs = "Pessoa Jur�dica Geral" }
                , new PessoaTipo() { Descricao = "Operadora", Obs = "Operadoras que disponibilizam os servi�os" }
                , new PessoaTipo() { Descricao = "Empresa", Obs = "Empresa" }
                , new PessoaTipo() { Descricao = "Institui��o", Obs = "Institui��o" }
                , new PessoaTipo() { Descricao = "Associa��o", Obs = "Associa��o" }
                , new PessoaTipo() { Descricao = "PessoaF�sica", Obs = "PessoaF�sica" }
                , new PessoaTipo() { Descricao = "Benefici�rio", Obs = "Benefici�rio" }
                , new PessoaTipo() { Descricao = "Titular", Obs = "Titular" }
                , new PessoaTipo() { Descricao = "Benefici�rioTemp", Obs = "Benefici�rios com cadastros incompletos (campos n�o obrigat�rios)" }
                , new PessoaTipo() { Descricao = "Institui��o", Obs = "Institui��o" }
                , new PessoaTipo() { Descricao = "Fornecedor", Obs = "Fornecedores da Uniben" }
                );

            context.SegmentoAssistenciais.AddOrUpdate(x => x.SegmentoAssistencialId
                , new SegmentoAssistencial() { Descricao = "Ambulatorial/Coparticipa��o/Regional com limitador em reais por procedimento.", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Coparticipativo/Regional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Coparticipa��o/Enfermaria/Regional/ com limitador", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Sem coparticipa��o/Regional.", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Nacional/Sem Coparticipa��o", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Com coparticipa��o/Nacional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Regional/Maior coparticipa��o/Com limitador", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Odontol�gica", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Enfermaria/Coparticipativo/Local", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Enfermaria/Coparticipativo/Estadual", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Coparticipativo/Estadual", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Enfermaria/Sem coparticipa��o/Estadual", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Sem Coparticipa��o/Estadual", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Ambulatorial/Coparticipativo/Nacional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Hospitalar/Coparticipativo/Regional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Enfermaria/Sem coparticipa��o/Regional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Coparticipativo/Local", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/Sem Coparticipa��o/Local", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Enfermaria/Sem Coparticipa��o/Local", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Completo/Apartamento/sem coparticipa��o/Nacional", Obs = "" }
                , new SegmentoAssistencial() { Descricao = "Ambulatorial/Coparticipativo/Estadual", Obs = "" });

            context.TipoContratacaoProdutos.AddOrUpdate(x => x.TipoContratacaoProdutoId
                            , new TipoContratacaoProduto() { Descricao = "Ades�o", Obs = "" }
                            , new TipoContratacaoProduto() { Descricao = "Empresarial", Obs = "" });

            context.AbrangenciaPlanos.AddOrUpdate(x => x.AbrangenciaPlanoId
                , new AbrangenciaPlano() { Descricao = "Estadual", Obs = "" }
                , new AbrangenciaPlano() { Descricao = "Nacional", Obs = "" });

            context.FatorModeradores.AddOrUpdate(x => x.FatorModeradorId
    , new FatorModerador() { Descricao = "Com Coparticipa��o", Obs = "" }
    , new FatorModerador() { Descricao = "Sem Coparticipa��o", Obs = "" });

            context.AcomodacaoTipos.AddOrUpdate(x => x.AcomodacaoTipoId
            , new AcomodacaoTipo() { Descricao = "Apartamento", Obs = "" }
            , new AcomodacaoTipo() { Descricao = "Enfermaria", Obs = "" });

            context.CentroCustos.AddOrUpdate(x => x.CentroCustoId
                , new CentroCusto() { Descricao = "Assessoria Contabilidade", Obs = "" }
                , new CentroCusto() { Descricao = "Assessoria Recursos Humanos", Obs = "" }
                , new CentroCusto() { Descricao = "Assessoria Tecnologia da Informa��o", Obs = "" }
                , new CentroCusto() { Descricao = "Assessoria Jur�dica", Obs = "" }
                , new CentroCusto() { Descricao = "Benef�cios", Obs = "" }
                , new CentroCusto() { Descricao = "Cobran�a", Obs = "" }
                , new CentroCusto() { Descricao = "Cadastro", Obs = "" }
                , new CentroCusto() { Descricao = "Comercial", Obs = "" }
                , new CentroCusto() { Descricao = "Diretoria", Obs = "" }
                , new CentroCusto() { Descricao = "Financeiro", Obs = "" }
                , new CentroCusto() { Descricao = "Guia de Recolhimento - GRRF", Obs = "" }
                , new CentroCusto() { Descricao = "Impostos", Obs = "" }
                , new CentroCusto() { Descricao = "Inform�tica", Obs = "" }
                , new CentroCusto() { Descricao = "Manuten��o / Limpeza Matriz e Filial", Obs = "" }
                , new CentroCusto() { Descricao = "Marketing", Obs = "" }
                , new CentroCusto() { Descricao = "Patroc�nio", Obs = "" }
                , new CentroCusto() { Descricao = "Recibos", Obs = "" }
                , new CentroCusto() { Descricao = "Recursos Humanos", Obs = "" }
                , new CentroCusto() { Descricao = "Uniben Filial", Obs = "" }
                , new CentroCusto() { Descricao = "Uniben Matriz", Obs = "" }
                , new CentroCusto() { Descricao = "Unimed Cataguases", Obs = "" }
                , new CentroCusto() { Descricao = "Uniben Juiz de Fora", Obs = "" }
                , new CentroCusto() { Descricao = "Uniodonto Cataguases", Obs = "" }
                , new CentroCusto() { Descricao = "Uniodonto Juiz de Fora", Obs = "" }
                );


        }
    }
}