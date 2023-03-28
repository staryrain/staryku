using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp管理订单
{
    public class Goods//商品类
    {
        public string toothpaste;
        public string toothbrush;
        public string toothcup;
    }
    public class Order//订单类
    {
        public string Id;
        public string Productname;
        public string Client;
        public double Price;
        public OrderDetails orderDetail;
        public Order (string id, string productname, string client,OrderDetails orderDetail) //创建一个订单
        {
            this.Id = id;
            this.Productname = productname;
            this.Client = client;
            this.orderDetail = orderDetail;
        }

       

        public double Getprice(string productName, double unitprice, int quantity)
        {
            OrderDetails orderDetails=new OrderDetails(productName, unitprice, quantity);
            this.Price = unitprice*quantity;
            return this.Price;
        }

        public override string ToString()//重写ToString
        {
            return "订单信息：" + "  "+"ID:"+Id +  "     " +"Client:"+ Client + "     " +"Orderdetail:"+ orderDetail + "    " +"Price:"+ Price;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   Id == order.Id &&
                   Productname == order.Productname &&
                   Client == order.Client &&
                   EqualityComparer<OrderDetails>.Default.Equals(orderDetail, order.orderDetail);
        }//重写Equal

        public override int GetHashCode()
        {
            int hashCode = 1316889819;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Productname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Client);
            hashCode = hashCode * -1521134295 + EqualityComparer<OrderDetails>.Default.GetHashCode(orderDetail);
            return hashCode;
        }

    }
    public class OrderDetails//订单明细类
    {
        public string ProductName { get; set; }
        public double unitPrice { get; set; }
        public int Quantity { get; set; }
        public OrderDetails (string productName,double unitprice,int quantity) //创建一个订单明细
        { 
            this.ProductName = productName;
            this.unitPrice = unitprice;
            this.Quantity = quantity;
        }

        public override string ToString()//重写ToString
        {
            return "Productname:"+ProductName + "     " + "Unitprice:" + unitPrice + "     " +"Quantity:"+Quantity ;
        }

        public override bool Equals(object obj)//重写Equal
        {
            return obj is OrderDetails details &&
                   ProductName == details.ProductName &&
                   unitPrice == details.unitPrice &&
                   Quantity == details.Quantity;
        }

        public override int GetHashCode()
        {
            int hashCode = 52684111;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + unitPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }

    public class OrderComparer : IComparer<Order>
    {

        public int Compare(Order p1, Order p2)
        {
            return Convert.ToInt32(p1.Id) - Convert.ToInt32(p2.Id);
        }
    }

    public class OrderService//订单服务类
    {
        List<Order> orders = new List<Order>(); //订单集合
        public void AddOrder() //添加订单
        {
            Console.WriteLine("请输入你的订单ID");
            string id=Console.ReadLine();
            Console.WriteLine("请输入你的产品名称");
            string productname = Console.ReadLine();
            Console.WriteLine("请输入你的称呼");
            string client = Console.ReadLine();
            Console.WriteLine("请输入当前产品的单价");
            double unitprice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入你要购买的数量");
            int quantity = Convert.ToInt32(Console.ReadLine());
            OrderDetails orderDetail=new OrderDetails(productname,unitprice,quantity);
            Order order=new Order(id, productname, client, orderDetail);
            order.Getprice(productname,unitprice,quantity);
            orders.Add(order);
        }

        public void DeleteOrder()  //根据订单号删除订单
        {
            Console.WriteLine("请输入你要删除订单的ID");
            string id= Console.ReadLine();
            for(int i=0;i<orders.Count;i++)
            {
                if (orders[i].Id == id) { orders.Remove(orders[i]); break; }
                if(i==orders.Count-1) 
                { 
                    Console.WriteLine("找不到对应订单");
                    throw new Exception("找不到对应订单"); 
                }
            }
        }

        public void Modifyorder()  //根据订单号修改订单信息
        {
            Console.WriteLine("请输入要修改的信息（输入数字）");
            Console.WriteLine("1.Productname  2.Client 3.Quantity");
            int modifyitem=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入你的订单ID");
            string id=Console.ReadLine();
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == id)
                {
                    switch (modifyitem)
                    {
                        case 1:
                            Console.WriteLine("请输入想要修改的内容");
                            string modifyproductname=Console.ReadLine();
                            orders[i].Productname= modifyproductname;
                            break;
                        case 2:
                            Console.WriteLine("请输入想要修改的内容");
                            string modifyclient = Console.ReadLine();
                            orders[i].Client = modifyclient;
                            break;
                        case 3:
                            Console.WriteLine("请输入想要修改的内容");
                            int modifyquantity = Convert.ToInt32(Console.ReadLine());
                            orders[i].orderDetail.Quantity = modifyquantity;
                            break;
                        default:
                            Console.WriteLine("输入错误，请输入正确数字");
                            break;
                    }
                    break;
                }
                else if (i == orders.Count - 1) 
                { 
                    Console.WriteLine("找不到对应订单");
                    throw new Exception("找不到对应订单"); 
                }
            }
           
        }

        public void Inquire()  //根据信息进行订单查询
        {
            Console.WriteLine("请输入要查询的信息（输入数字）");
            Console.WriteLine("1.ID 2.Productname  3.Client 4.Quantity 5.Unitprice");
            int modifyitem = Convert.ToInt32(Console.ReadLine());
            switch (modifyitem)
            {
               
                case 1:
                    Console.WriteLine("请输入想要查询的内容");
                    string SearchID = Console.ReadLine();
                    var SearchOrderID =
                           from order in orders
                           where SearchID == order.Id
                           orderby order.Price
                           select order;
                    if(SearchOrderID==null) { Console.WriteLine("没有此结果或输入错误"); }
                    else 
                        foreach (var x in SearchOrderID)
                        {
                            Console.WriteLine(x);
                        }
                    break;
                case 2:
                    Console.WriteLine("请输入想要查询的内容");
                    string SearchProductname = Console.ReadLine();
                    var SearchOrderProductname =
                           from order in orders
                           where SearchProductname == order.Productname
                           orderby order.Price
                           select order;
                    if (SearchOrderProductname == null) { Console.WriteLine("没有此结果或输入错误"); }
                    else
                        foreach (var x in SearchOrderProductname)
                        {
                            Console.WriteLine(x);
                        }
                    break;
                case 3:
                    Console.WriteLine("请输入想要查询的内容");
                    string SearchClient = Console.ReadLine();
                    var SearchOrderClient =
                           from order in orders
                           where SearchClient == order.Client
                           orderby order.Price
                           select order;
                    if (SearchOrderClient == null) { Console.WriteLine("没有此结果或输入错误"); }
                    else
                        foreach (var x in SearchOrderClient)
                        {
                            Console.WriteLine(x);
                        }
                    break;
                case 4:
                    Console.WriteLine("请输入想要查询的内容");
                    int SearchQuantity = Convert.ToInt32(Console.ReadLine());
                    var SearchOrderQuantity =
                           from order in orders
                           where SearchQuantity == order.orderDetail.Quantity
                           orderby order.Price
                           select order;
                    if (SearchOrderQuantity == null) { Console.WriteLine("没有此结果或输入错误"); }
                    else
                        foreach (var x in SearchOrderQuantity)
                        {
                            Console.WriteLine(x);
                        }
                    break;
                case 5:
                    Console.WriteLine("请输入想要查询的内容");
                    double SearchUnitprice = Convert.ToDouble(Console.ReadLine());
                    var SearchOrderUnitprice =
                           from order in orders
                           where SearchUnitprice == order.orderDetail.unitPrice
                           orderby order.Price
                           select order;
                    if (SearchOrderUnitprice == null) { Console.WriteLine("没有此结果或输入错误"); }
                    else
                        foreach (var x in SearchOrderUnitprice)
                        {
                            Console.WriteLine(x);
                        }
                    break;
                default:
                    Console.WriteLine("输入错误，请输入正确数字");
                    break;
            }
            }

        public List<Order> ordersSort() //根据ID进行排序
        {
            this.orders.Sort(new OrderComparer());
            return this.orders;
        }
        
        public OrderService()
        {
            while (true)
            {
                Console.WriteLine("当前的订单情况为：");
                if(this.orders.Count == 0) { Console.WriteLine("空"); }
                else
                    foreach(var order in this.orders) { Console.WriteLine(order); }
                Console.WriteLine("请输入需要的服务");
                Console.WriteLine("1.添加订单  2.删除订单  3.修改订单  4.查询订单  5.结束本次服务");
                int NeedService=Convert.ToInt32(Console.ReadLine());
                switch (NeedService)
                {
                    case 1:
                        AddOrder();
                        break;
                    case 2:
                        DeleteOrder();
                        break;
                    case 3:
                        Modifyorder();
                        break;
                    case 4:
                        Inquire();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("输入错误，请输入正确数字");
                        break;
                }
                if(NeedService==5) break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
        }
    }
}
