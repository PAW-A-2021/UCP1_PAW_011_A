using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_011_A.Models
{
    public partial class TableTransaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdPembeli { get; set; }
        public int? IdProduk { get; set; }
        public int? IdAdmin { get; set; }
        public decimal TotalTransaksi { get; set; }
    }
}
