using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JsonDeserializeTest
{
    public class AllocatedBooks : List<AllocatedBook>
    {
        public AllocatedBooks()
        {
        }
        public decimal SubTotal
        {
            get
            {
                return this.Sum(ab => ab.SubTotal);
            }
        }
        public int RemoveBook(Book book)
        {
            var returnAge = 0;
            foreach(var allocatedBook in this)
            {
                if(allocatedBook.AgeId == book.AgeId)
                {
                    returnAge = book.AgeId; 
                    allocatedBook.Books.Remove(book);
                }
            }
            return returnAge;
        }
        
        public int AddBook(Book book)
        {
            AllocatedBook allocatedBook = null;
            foreach (var checkAllocatedBook in this)
            {
                if(checkAllocatedBook.AgeId == book.AgeId)
                {
                    allocatedBook = checkAllocatedBook;
                }
            }
            if(allocatedBook == null)
            {
                //var ageCategory = DataAccessStatic.GetCategory(book.AgeId);
                allocatedBook =new AllocatedBook();
                allocatedBook.AgeId = book.AgeId;
                allocatedBook.Name = "Name For " + book.AgeId;
                this.Add(allocatedBook);
            }
            allocatedBook.Books.Add(book);
            return allocatedBook.AgeId;
        }

    }
    public class AllocatedBook
    { 
        public AllocatedBook ()
        {
        }
        public List<Book> Books = new List<Book>();
        public int AgeId { get; set; }
        public string Name { get; set; }
        public int Titles
        {
            get
            {
                var count = 0;
                foreach (Book book in this.Books)
                {
                    count++;
                }
                return count;
            }
        }
        public decimal SubTotal
        {
            get
            {
                decimal subTotal = 0;
                foreach (Book book in this.Books)
                {
                    subTotal += book.Price * book.Quantity;
                }
                return subTotal;
            }
        }
        public int Quantity
        {
            get
            {
                var quantity = 0;
                foreach (Book book in this.Books)
                {
                    quantity += book.Quantity;
                }
                return quantity;
            }
        }
    }
    
}
