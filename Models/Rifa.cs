using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RifaVirtual.Models
{
    public class Rifa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título da rifa é obrigatório")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A data do sorteio é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataSorteio { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório")]
        [StringLength(500)]
        public string Produto { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; } = true;

        public ICollection<Numero> Numeros { get; set; } = new List<Numero>();

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int NumerosVendidos 
        { 
            get { return Numeros.Count(n => n.Vendido); }
        }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal ReceitaTotal 
        { 
            get { return NumerosVendidos * Valor; }
        }
    }
}