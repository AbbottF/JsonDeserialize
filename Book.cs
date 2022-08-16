using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserializeTest
{
    /// <summary>
    /// Although this is part of BookGenieData in KBO.Book.Genie
    /// It is used in queries so is part of shared
    /// </summary>
    public class Book
    {
        public Book(string ageId,
                        string isbn,
                        decimal price,
                        int productId,
                        int quantity,
                        string title)
        {
            var tempAgeId = 0;
            int.TryParse(ageId, out tempAgeId);
            AgeId = tempAgeId;
            ImageURL = ""; // generated in display grid on client
            ISBN = isbn;
            Price = price;
            ProductId = productId;
            Quantity = quantity;
            Title = title;
        }           
        public int AgeId { get; set; }
        public string ImageURL { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
    }
}
