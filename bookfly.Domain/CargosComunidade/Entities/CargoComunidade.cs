
using System;

namespace bookfly.Domain.CargosComunidade.Entities
{
    public class CargoComunidade
    {
        public virtual int Id { get; protected set; }
        public virtual int ComunidadeId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual bool PodeDeletar { get; protected set; }
        public virtual bool PodeBanir { get; protected set; }
        public virtual bool PodeFixarPost { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }
        public virtual bool CargoPadrao { get; protected set; }

        protected CargoComunidade() { }

        public CargoComunidade(int comunidadeId, string nome, bool podeDeletar, bool podeBanir, bool podeFixarPost, bool cargoPadrao)
        {
            SetComunidadeId(comunidadeId);
            SetNome(nome);
            SetPodeDeletar(podeDeletar);
            SetPodeBanir(podeBanir);
            SetPodeFixarPost(podeFixarPost);
            SetCargoPadrao(cargoPadrao);
            CriadoEm = DateTime.UtcNow;
        }

        public virtual void SetComunidadeId(int comunidadeId)
        {
            if (comunidadeId <= 0)
                throw new ArgumentException("O ID da comunidade deve ser maior que zero.", nameof(comunidadeId));
            ComunidadeId = comunidadeId;
        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cargo não pode ser nulo ou vazio.", nameof(nome));
            Nome = nome;
        }

        public virtual void SetPodeDeletar(bool podeDeletar)
        {
            PodeDeletar = podeDeletar;
        }

        public virtual void SetPodeBanir(bool podeBanir)
        {
            PodeBanir = podeBanir;
        }


        public virtual void SetPodeFixarPost(bool podeFixarPost)
        {
            PodeFixarPost = podeFixarPost;
        }
        public virtual void SetCargoPadrao(bool cargoPadrao)
        {
            CargoPadrao = cargoPadrao;
        }
        
        public virtual void SetCriadoEM(DateTime criadoEm)
        {
            if (criadoEm > DateTime.UtcNow)
                throw new ArgumentException("A data de criação não pode ser no futuro.", nameof(criadoEm));
            CriadoEm = criadoEm;
        }

    }
}