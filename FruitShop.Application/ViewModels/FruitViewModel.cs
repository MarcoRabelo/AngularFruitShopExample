namespace FruitShop.Application.ViewModels
{
    public class FruitViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public long? Stock { get; set; }

        public decimal Price { get; set; }
    }
}
