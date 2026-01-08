using S00250043_ClassLibrary;
using System.Net.Security;


static bool Validate_Order(Order order)
{
    var context = new S00250043_ConsoleApp.ConsoleEcommerceContext();
    double totalPrice = 0;
    if (order.Total_price < 0)
    {
        Console.WriteLine("False");
        return false;
    }
    var OrderData = from o in context.OrderData
                    where o.Order_id == order.Order_id
                    select o;

    foreach (double unit_price in OrderData.Select(od => od.Unit_price))
    {
        totalPrice += unit_price;
    }
    if (totalPrice != order.Total_price)
    {
        Console.WriteLine("False");
        return false;
    }
    else
    {
        Console.WriteLine("True");
        return true;
    }
}
static void User_Items(string name)
{
    var context = new S00250043_ConsoleApp.ConsoleEcommerceContext();
    var user = from u in context.Users
               where u.Name == name
               select u as User;
    if (user == null)
    {
        Console.WriteLine("User not found.");
        return;
    }
    var items = from o in context.Orders
                join od in context.OrderData
                on o.Order_id equals od.Order_id
                join p in context.Products
                on od.Collectible_id equals p.Collectible_id
                where o.User_id == 1
                select p.Name.ToString().ToList();

  
}

Order o1 = new Order
{
    Order_id = 1,
    User_id = 1,
    Total_price = 59.98,
    Payment_status = "Paid",
    Order_status = "Shipped"
};
Validate_Order(o1);
User_Items("Alice Carter");