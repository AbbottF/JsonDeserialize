
using System;


public class Ajaxbookgenieparams
{
    public Agecandidate[] AgeCandidates { get; set; }
    public Booktodelete BookToDelete { get; set; }
    public Allocatedbook[] AllocatedBooks { get; set; }
    public Bookgenieparams BookGenieParams { get; set; }
    public string Data { get; set; }
    public Productfilterparams ProductFilterParams { get; set; }
    public string Request { get; set; }
}

public class Agecandidate
{
    public Allocationcandidate[] AllocationCandidates { get; set; }
    public int AgeId { get; set; }
}  

public class Allocationcandidate
{
    public int ProductID { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Inventory { get; set; }
    public DateTime DataLastTouched { get; set; }
    public string AgeId { get; set; }
}

public class Booktodelete
{
    public string ISBN { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int AgeId { get; set; }
}

public class Bookgenieparams
{
    public int AllocatedQuantity { get; set; }
    public int AllocatedSubTotal { get; set; }
    public int AllocatedTitles { get; set; }
    public int AllocationBudget { get; set; }
    public int BooksPerTitle { get; set; }
    public string CustomerGuid { get; set; }
    public int CustomerId { get; set; }
    public int DefaultBooksPerTitle { get; set; }
    public int MinimumBudget { get; set; }
    public int MoveToCartSubTotal { get; set; }
    public int MoveToCartCount { get; set; }
    public int ReDisplayBreak { get; set; }
    public int[] SelectedCategories { get; set; }
    public int UserBooksPerTitle { get; set; }
}

public class Productfilterparams
{
    public Rootnode[] RootNodes { get; set; }
    public string FilterGuid { get; set; }
    public Agerange AgeRange { get; set; }
    public int[] SelectedAges { get; set; }
    public int[] FilterCategories { get; set; }
    public string ResetFilter { get; set; }
}

public class Agerange
{
    public int Min { get; set; }
    public int Max { get; set; }
    public int From { get; set; }
    public int FromInit { get; set; }
    public int To { get; set; }
    public int ToInit { get; set; }
}

public class Rootnode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GroupType { get; set; }
    public Nodecategory[] NodeCategories { get; set; }
    public string Description { get; set; }
    public string ToolTip { get; set; }
    public string Selected { get; set; }
    public bool __expanded__ { get; set; }
}

public class Nodecategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public string Selected { get; set; }
    public string Description { get; set; }
}

public class Allocatedbook
{
    public Agebook[] AgeBooks { get; set; }
    public int AgeId { get; set; }
    public string Name { get; set; }
    public int Titles { get; set; }
    public int Quantity { get; set; }
    public float SubTotal { get; set; }
}

public class Agebook
{
    public string ISBN { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public int AgeId { get; set; }
}
