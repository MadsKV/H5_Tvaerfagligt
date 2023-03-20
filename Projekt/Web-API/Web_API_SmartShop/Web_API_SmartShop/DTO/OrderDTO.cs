namespace Web_API_SmartShop.DTO
{
        public class OrderDTO
        {
            public int OrderId { get; set; }
            public DateTime? orderDate { get; set; }
            public string? orderStatus { get; set; }

            public List<OrderDetailDTO>? Details { get; set; } = new();

        }
        //public class OrderDTO2
        //{
        //    public int OrderId { get; set; }
        //    public DateTime? orderDate { get; set; }
        //    public string? orderStatus { get; set; }
        //    public CustomerDTO { get; set; }
        //}
}
