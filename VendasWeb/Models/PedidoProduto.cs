namespace VendasWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoProduto")]
    public partial class PedidoProduto
    {
        public int Id { get; set; }

        public int? PedidoID { get; set; }

        public int? ProdutoID { get; set; }

        public double? Valor { get; set; }

        public int? Quantidade { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
