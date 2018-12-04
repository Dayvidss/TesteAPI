namespace Cencosud.TesteAPI.Data
{
    using System.Data.Entity;

    public partial class AGP : DbContext
    {
        public AGP()
            : base("name=AGP")
        {
        }

        public virtual DbSet<Acao> Acao { get; set; }
        public virtual DbSet<Ambiente> Ambiente { get; set; }
        public virtual DbSet<Aplicativo> Aplicativo { get; set; }
        public virtual DbSet<Aplicativo_Ambiente> Aplicativo_Ambiente { get; set; }
        public virtual DbSet<Arquivo_Ticket> Arquivo_Ticket { get; set; }
        public virtual DbSet<Autorizante_App> Autorizante_App { get; set; }
        public virtual DbSet<Bandeira> Bandeira { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Colecao> Colecao { get; set; }
        public virtual DbSet<Constrinfo> Constrinfo { get; set; }
        public virtual DbSet<Conteudo> Conteudo { get; set; }
        public virtual DbSet<Funcao> Funcao { get; set; }
        public virtual DbSet<Grupo_Atendimento> Grupo_Atendimento { get; set; }
        public virtual DbSet<GrupoAtendimento_Usuario> GrupoAtendimento_Usuario { get; set; }
        public virtual DbSet<Inf_Adicional> Inf_Adicional { get; set; }
        public virtual DbSet<Inf_Adicional_Tipo_Colecao> Inf_Adicional_Tipo_Colecao { get; set; }
        public virtual DbSet<Log_Sistema> Log_Sistema { get; set; }
        public virtual DbSet<Loja> Loja { get; set; }
        public virtual DbSet<Marco_Tramitacao> Marco_Tramitacao { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Perfil_App> Perfil_App { get; set; }
        public virtual DbSet<Perfil_App_Conteudo> Perfil_App_Conteudo { get; set; }
        public virtual DbSet<Perfil_Usuario> Perfil_Usuario { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoa_Solicitacao> Pessoa_Solicitacao { get; set; }
        public virtual DbSet<Registro_Massivo> Registro_Massivo { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<Status_Ticket> Status_Ticket { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Tipo_Banner> Tipo_Banner { get; set; }
        public virtual DbSet<Tipo_Colecao> Tipo_Colecao { get; set; }
        public virtual DbSet<Tipo_Inf_Adicional> Tipo_Inf_Adicional { get; set; }
        public virtual DbSet<Tramitacao> Tramitacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Valor_Informacao> Valor_Informacao { get; set; }
        public virtual DbSet<Video_Tela_Inicial> Video_Tela_Inicial { get; set; }
        public virtual DbSet<Acesso> Acesso { get; set; }
        public virtual DbSet<AdTable> AdTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acao>()
                .Property(e => e.Aco_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Acao>()
                .HasMany(e => e.Permissao)
                .WithRequired(e => e.Acao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ambiente>()
                .Property(e => e.Ame_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Ambiente>()
                .HasMany(e => e.Aplicativo_Ambiente)
                .WithRequired(e => e.Ambiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aplicativo>()
                .Property(e => e.Apo_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicativo>()
                .Property(e => e.Apo_Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicativo>()
                .Property(e => e.Apo_Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicativo>()
                .HasMany(e => e.Aplicativo1)
                .WithOptional(e => e.Aplicativo2)
                .HasForeignKey(e => e.Apo_IdPai);

            modelBuilder.Entity<Aplicativo>()
                .HasMany(e => e.Aplicativo_Ambiente)
                .WithRequired(e => e.Aplicativo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aplicativo>()
                .HasMany(e => e.Grupo_Atendimento)
                .WithMany(e => e.Aplicativo)
                .Map(m => m.ToTable("Grupo_Atendimento_Aplicativo").MapLeftKey("Apo_Id").MapRightKey("Gra_Id"));

            modelBuilder.Entity<Aplicativo_Ambiente>()
                .HasMany(e => e.Perfil_App)
                .WithRequired(e => e.Aplicativo_Ambiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Arquivo_Ticket>()
                .Property(e => e.Att_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bandeira>()
                .Property(e => e.Bna_Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Bandeira>()
                .Property(e => e.Bna_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Bandeira>()
                .HasMany(e => e.Loja)
                .WithRequired(e => e.Bandeira)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Banner>()
                .Property(e => e.Bnr_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Banner>()
                .Property(e => e.Bnr_Link)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Cta_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Conteudo)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colecao>()
                .Property(e => e.Clo_Chave)
                .IsUnicode(false);

            modelBuilder.Entity<Colecao>()
                .Property(e => e.Clo_Valor)
                .IsUnicode(false);

            modelBuilder.Entity<Colecao>()
                .Property(e => e.Clo_ValorOculto1)
                .IsUnicode(false);

            modelBuilder.Entity<Colecao>()
                .Property(e => e.Clo_ValorOculto2)
                .IsUnicode(false);

            modelBuilder.Entity<Colecao>()
                .Property(e => e.Clo_ValorOculto3)
                .IsUnicode(false);

            modelBuilder.Entity<Constrinfo>()
                .Property(e => e.Ctr_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Constrinfo>()
                .Property(e => e.Ctr_Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Constrinfo>()
                .Property(e => e.Ctr_Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Conteudo>()
                .Property(e => e.Cto_Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Conteudo>()
                .Property(e => e.Cto_Conteudo)
                .IsUnicode(false);

            modelBuilder.Entity<Conteudo>()
                .HasMany(e => e.Perfil_App_Conteudo)
                .WithRequired(e => e.Conteudo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcao>()
                .Property(e => e.Fno_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Funcao>()
                .Property(e => e.Fno_Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Funcao>()
                .Property(e => e.Fno_CssClassIcon)
                .IsUnicode(false);

            modelBuilder.Entity<Funcao>()
                .HasMany(e => e.Acao)
                .WithRequired(e => e.Funcao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo_Atendimento>()
                .Property(e => e.Gra_Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo_Atendimento>()
                .Property(e => e.Gra_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo_Atendimento>()
                .HasMany(e => e.Tramitacao)
                .WithOptional(e => e.Grupo_Atendimento)
                .HasForeignKey(e => e.Gra_IdDestino);

            modelBuilder.Entity<Inf_Adicional>()
                .Property(e => e.Iad_Label)
                .IsUnicode(false);

            modelBuilder.Entity<Inf_Adicional>()
                .Property(e => e.Iad_ValorDefault)
                .IsUnicode(false);

            modelBuilder.Entity<Inf_Adicional>()
                .Property(e => e.Iad_Explicacao)
                .IsUnicode(false);

            modelBuilder.Entity<Inf_Adicional>()
                .HasMany(e => e.Inf_Adicional_Tipo_Colecao)
                .WithRequired(e => e.Inf_Adicional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inf_Adicional>()
                .HasMany(e => e.Valor_Informacao)
                .WithRequired(e => e.Inf_Adicional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Log_Sistema>()
                .Property(e => e.Lsa_TabelaOrigem)
                .IsUnicode(false);

            modelBuilder.Entity<Log_Sistema>()
                .Property(e => e.Lsa_Acao)
                .IsUnicode(false);

            modelBuilder.Entity<Log_Sistema>()
                .Property(e => e.Lsa_Pagina)
                .IsUnicode(false);

            modelBuilder.Entity<Log_Sistema>()
                .Property(e => e.Lsa_Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Loja>()
                .Property(e => e.Lja_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Loja>()
                .HasMany(e => e.Pessoa)
                .WithRequired(e => e.Loja)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marco_Tramitacao>()
                .Property(e => e.Mto_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Marco_Tramitacao>()
                .HasMany(e => e.Grupo_Atendimento)
                .WithRequired(e => e.Marco_Tramitacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marco_Tramitacao>()
                .HasMany(e => e.Tramitacao)
                .WithRequired(e => e.Marco_Tramitacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modulo>()
                .Property(e => e.Mdo_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Modulo>()
                .Property(e => e.Mdo_CssClassIcon)
                .IsUnicode(false);

            modelBuilder.Entity<Modulo>()
                .HasMany(e => e.Funcao)
                .WithRequired(e => e.Modulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parametro>()
                .Property(e => e.Pro_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Parametro>()
                .Property(e => e.Pro_Valor)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.Prl_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.Perfil_Usuario)
                .WithRequired(e => e.Perfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.Permissao)
                .WithRequired(e => e.Perfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil_App>()
                .Property(e => e.Pap_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil_App>()
                .HasMany(e => e.Autorizante_App)
                .WithRequired(e => e.Perfil_App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil_App>()
                .HasMany(e => e.Inf_Adicional)
                .WithRequired(e => e.Perfil_App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil_App>()
                .HasMany(e => e.Perfil_App_Conteudo)
                .WithRequired(e => e.Perfil_App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil_App>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Perfil_App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_NomeApresentacao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_NumRG)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_OrgaoExpRG)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_UfRG)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_CargoRH)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Setor)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_Departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Psa_UnidadeNegocio)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Pessoa_Solicitacao)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(e => e.Usuario)
                .WithRequired(e => e.Pessoa);

            modelBuilder.Entity<Registro_Massivo>()
                .Property(e => e.Reg_Valor)
                .IsUnicode(false);

            modelBuilder.Entity<Registro_Massivo>()
                .Property(e => e.Reg_Retorno)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Slo_InfAdicional)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Slo_CentroCusto)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Slo_NotaPesqSatisfacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .Property(e => e.Slo_ObsPesqSatisfacao)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitacao>()
                .HasMany(e => e.Pessoa_Solicitacao)
                .WithRequired(e => e.Solicitacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitacao>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Solicitacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status_Ticket>()
                .Property(e => e.Stt_Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Status_Ticket>()
                .Property(e => e.Stt_Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Tct_InfAdicional)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Tct_NumTicket)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Arquivo_Ticket)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Registro_Massivo)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Ticket1)
                .WithOptional(e => e.Ticket2)
                .HasForeignKey(e => e.Tct_IdPai);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Tramitacao)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Banner>()
                .Property(e => e.Tbr_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Banner>()
                .HasMany(e => e.Banner)
                .WithRequired(e => e.Tipo_Banner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Colecao>()
                .Property(e => e.Tco_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Colecao>()
                .HasMany(e => e.Colecao)
                .WithRequired(e => e.Tipo_Colecao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Colecao>()
                .HasMany(e => e.Inf_Adicional_Tipo_Colecao)
                .WithRequired(e => e.Tipo_Colecao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Inf_Adicional>()
                .Property(e => e.Tia_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Inf_Adicional>()
                .HasMany(e => e.Inf_Adicional)
                .WithRequired(e => e.Tipo_Inf_Adicional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tramitacao>()
                .Property(e => e.Tro_Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Tramitacao>()
                .HasMany(e => e.Status_Ticket)
                .WithRequired(e => e.Tramitacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Uso_Login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Uso_Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Autorizante_App)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Log_Sistema)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Perfil_Usuario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Solicitacao)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Psa_IdCadastro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Status_Ticket)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tramitacao)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.Psa_IdDestino);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tramitacao1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.Psa_idOrigem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Valor_Informacao>()
                .Property(e => e.Vin_Valor)
                .IsUnicode(false);

            modelBuilder.Entity<Video_Tela_Inicial>()
                .Property(e => e.Vdo_Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Acesso>()
                .Property(e => e.Acs_Login)
                .IsUnicode(false);

            modelBuilder.Entity<Acesso>()
                .Property(e => e.Acs_IP)
                .IsUnicode(false);

            modelBuilder.Entity<AdTable>()
                .Property(e => e.Uso_Login)
                .IsUnicode(false);

            modelBuilder.Entity<AdTable>()
                .Property(e => e.Uso_Senha)
                .IsUnicode(false);
        }
    }
}
