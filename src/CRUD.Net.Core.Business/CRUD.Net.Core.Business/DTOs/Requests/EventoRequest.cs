using CRUD.Net.Core.Domain.Models;

namespace CRUD.Net.Core.Business.DTOs.Requests
{
    public class EventoRequest
    {
        public int Id { get; set; }
        public int IdTipoEvento { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }

        public static implicit operator Evento(EventoRequest dados)
        {
            return new Evento()
            {
                Id = dados.Id,
                Data = dados.Data,
                IdTipoEvento = dados.IdTipoEvento,
                Descricao = dados.Descricao
            };
        }
    }
}
