class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RemainingStock { get; set; }
    public string Category { get; set; }
}
class Order
{
    public string ReceiptNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public double FinalTotal { get; set; }
}
