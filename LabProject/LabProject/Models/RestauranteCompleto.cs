using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabProject.Models
{
    public class RestauranteCompleto
    {

        public int Id { get; set; }
        public int UtilizadorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Imagem { get; set; }

        public bool Bloqueado { get; set; }

        public string Motivo { get; set; }

        public bool Notificacao { get; set; }

        public int? Telefone { get; set; }

        public string Morada { get; set; }

        public string HoraAbertura { get; set; }

        public string HoraFecho { get; set; }

        public string DiaDescanso { get; set; }
        public bool Aprovado { get; set; }

        public void RestauranteCompletoSet(Restaurante _res, Utilizador _util)
        {
            Id = _res.Id;
            UtilizadorId = (int)_res.UtilizadorId;
            Name = _util.Name;
            Email = _util.Email;
            Username = _util.Username;
            Password = _util.Password;
            Imagem = _util.Imagem;
            Bloqueado = _util.Bloqueado;
            Motivo = _util.Motivo;
            Notificacao = _util.Notificacao;
            Telefone = _res.Telefone;
            Morada = _res.Morada;
            HoraAbertura = _res.HoraAbertura;
            HoraFecho = _res.HoraFecho;
            DiaDescanso = _res.DiaDescanso;
            Aprovado = _res.Aprovado;
        }

        public Restaurante GetRestaurante()
        {
            return (new Restaurante
            {
                Id = Id,
                UtilizadorId = UtilizadorId,
                Telefone = Telefone,
                Morada = Morada,
                HoraAbertura = HoraAbertura,
                HoraFecho = HoraFecho,
                DiaDescanso = DiaDescanso,
                Aprovado = Aprovado,
            });
        }

        public Utilizador GetUtilizador()
        {
            return (new Utilizador
            {
                Id = UtilizadorId,
                Name = Name,
                Email = Email,
                Username = Username,
                Password = Password,
                Imagem = Imagem,
                Bloqueado = Bloqueado,
                Motivo = Motivo,
                Notificacao = Notificacao,
            });
        }


    }
}
