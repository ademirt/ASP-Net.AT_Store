using System;
using System.ComponentModel.DataAnnotations;

namespace AT.StoreNet.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.Now;
    }
}