using System.Drawing;

namespace ProductService.Model
{
    public class ProductView
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public List<string> Sizes { get; set; }
        public string Description { get; set; }
    }
}
