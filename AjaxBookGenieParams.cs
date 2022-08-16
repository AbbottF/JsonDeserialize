using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonDeserializeTest
{
    /// <summary>
    /// Used in Ajax returns to hold both data (json or html)
    /// Along with the request method name which is
    /// used by js success to select return function
    /// </summary>
    public class AjaxBookGenieParams
    {
        public AgeCandidates AgeCandidates = new AgeCandidates();
        public Book BookToDelete = new Book("0","",0,0,0,"");
        public AllocatedBooks AllocatedBooks = new AllocatedBooks();
        public BookGenieParams BookGenieParams = new BookGenieParams();
        public object Data = "";  // legacy ???
        // Removed for Serialize test
        //public ProductFilterParams ProductFilterParams = null;
        public string Request = "";

        public AjaxBookGenieParams() { }
        public AjaxBookGenieParams(string allocationState)
        {
            /// <param name="allocationState"></param>
            /// Contains the state of AjaxCallParams PRIOR to the activity request return
            var state = JsonConvert.DeserializeObject<BookGenieState>(allocationState);
            this.AgeCandidates = state.AgeCandidates;
            this.BookGenieParams = state.BookGenieParams;
            this.AllocatedBooks = state.AllocatedBooks;
            //this.ProductFilterParams = state.ProductFilterParams;
            this.Request = state.Request;
        }

        public string GetState()
        {
            var state = new BookGenieState(this);
            var stateJson = JsonConvert.SerializeObject(state);
            return stateJson;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    internal class BookGenieState
    {
        public BookGenieState(AjaxBookGenieParams ajaxBookGenieParams)
        {
            AgeCandidates = ajaxBookGenieParams.AgeCandidates;
            BookGenieParams = ajaxBookGenieParams.BookGenieParams;
            AllocatedBooks = ajaxBookGenieParams.AllocatedBooks;
            //ProductFilterParams = ajaxBookGenieParams.ProductFilterParams;
            Request = ajaxBookGenieParams.Request;
        }
        public AgeCandidates AgeCandidates = null;
        public BookGenieParams BookGenieParams = null;
        public AllocatedBooks AllocatedBooks = null;
        //public ProductFilterParams ProductFilterParams = null;
        public string Request = "";
    }
    public class BookGenieParams
    {
        public BookGenieParams()
        {
            AllocatedQuantity = 0;
            AllocatedSubTotal = 0;
            AllocatedTitles = 0;
            AllocationBudget = 200;
            BooksPerTitle = 3;
            CustomerGuid = "";
            CustomerId = 0;
            DefaultBooksPerTitle = 5;
            MinimumBudget = 200;
            ReDisplayBreak = 10;
            SelectedCategories = new List<int>();
            UserBooksPerTitle = 0;
        }
        public int AllocatedQuantity;
        public decimal AllocatedSubTotal;
        public int AllocatedTitles;
        public int AllocationBudget;
        public int BooksPerTitle;
        public string CustomerGuid;
        public int CustomerId;
        public int DefaultBooksPerTitle;
        public int MinimumBudget;
        public decimal MoveToCartSubTotal;
        public int MoveToCartCount;
        public int ReDisplayBreak;
        public List<int> SelectedCategories; // These include selected ages
        public int UserBooksPerTitle;
        
        private List<int> GetAllAgeCategories()
        {
            //var ageParent = DataAccessStatic.GetCategoryIdForAges();
            //var ages = DataAccessStatic.GetChildCategoryIds(ageParent);
            List<int> ageCategories = new List<int>();
            //ageCategories.Add(ageParent);
            //foreach(int ageId in ages)
            //{
            //    ageCategories.Add(ageId);
            //}
            return ageCategories;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
