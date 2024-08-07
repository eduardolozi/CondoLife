﻿using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Boleto
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool FoiPago { get; set; }
        public double Preco {  get; set; }
        public string? Arquivo {  get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
