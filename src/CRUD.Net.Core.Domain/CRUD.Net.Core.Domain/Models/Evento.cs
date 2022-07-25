using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Net.Core.Domain.Models
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        public int IdTipoEvento { get; set; }

        public string? Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}
