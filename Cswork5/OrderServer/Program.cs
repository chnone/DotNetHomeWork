using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServer
{
    class Item
    {
        public string ItemName { set; get; }
        public double ItemPrice { set; get; }
        public Item(string name, double price)
        {
            ItemName = name;
            ItemPrice = price;
        }
        public override string ToString()
        {
            return "ItemName:" + ItemName + " ItemPrice:" + ItemPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   ItemName == item.ItemName &&
                   ItemPrice == item.ItemPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = -1707792828;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
            hashCode = hashCode * -1521134295 + ItemPrice.GetHashCode();
            return hashCode;
        }
    }

    class Client
    {
        public string ClientName { set; get; }
        public Client(string name)
        {
            ClientName = name;
        }
        public override string ToString()
        {
            return "ClientName:" + ClientName;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   ClientName == client.ClientName;
        }

        public override int GetHashCode()
        {
            return -1215057659 + EqualityComparer<string>.Default.GetHashCode(ClientName);
        }
    }

    class Order
    {
        [Serializable]
        public int OrderNum { set; get; }
        public Client Client { set; get; }
        public OrderDetails[] OrderList { set; get; }
        public double Sum { set; get; }
        public Order() { }
        public Order(int orderNum, Client client, OrderDetails[] orderList)
        {
            OrderNum = orderNum;
            Client = client;
            OrderList = orderList;
        }
        
        public void Calculate()
        {
            foreach (OrderDetails orderItem in OrderList)
            {
                Sum += (orderItem.Items.ItemPrice) * (orderItem.ItemsNum);
            }
        }
        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            foreach (OrderDetails orderItem in OrderList)
            {
                details.Append(orderItem.ToString());
            }
            return "\norderNum:" + OrderNum + "\tClientName:" + Client.ClientName + "\tSum:￥" + Sum + details;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderNum == order.OrderNum &&
                   EqualityComparer<Client>.Default.Equals(Client, order.Client) &&
                   EqualityComparer<OrderDetails[]>.Default.Equals(OrderList, order.OrderList) &&
                   Sum == order.Sum;
        }

        public override int GetHashCode()
        {
            int hashCode = 1962522138;
            hashCode = hashCode * -1521134295 + OrderNum.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
            hashCode = hashCode * -1521134295 + EqualityComparer<OrderDetails[]>.Default.GetHashCode(OrderList);
            hashCode = hashCode * -1521134295 + Sum.GetHashCode();
            return hashCode;
        }
    }
    
    class OrderDetails
    {
        public Item Items { set; get; }
        public int ItemsNum { set; get; }
        public OrderDetails(Item items, int itemsNum)
        {
            Items = items;
            ItemsNum = itemsNum;
        }

        public override string ToString()
        {
            return "\n\tItemName:" + Items.ItemName + "\tItemsNum:" + ItemsNum + "\tItemsPrice:" + Items.ItemPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Item>.Default.Equals(Items, details.Items) &&
                   ItemsNum == details.ItemsNum;
        }

        public override int GetHashCode()
        {
            int hashCode = -1718268268;
            hashCode = hashCode * -1521134295 + EqualityComparer<Item>.Default.GetHashCode(Items);
            hashCode = hashCode * -1521134295 + ItemsNum.GetHashCode();
            return hashCode;
        }
    }

    class OrderService
    {
        public List<Order> Orders { set; get; }
        public OrderService()
        {
            Orders = new List<Order>();
        }
        public OrderService(List<Order> orders)
        {
            Orders = orders;
        }
        
        public void SortByNum()
        {
            Orders.Sort((p1, p2) => p1.OrderNum - p2.OrderNum);
        }
        
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        
        public void RemoveOrder(int id)
        {
            int i = -1;
            int j = -1;
            try
            {
                foreach (Order order in Orders)
                {
                    i++;
                    if (order.OrderNum == id)
                    {
                        j = i;
                    }
                }
                Orders.RemoveAt(j);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("订单删除失败，请检查输入的订单号!");
            }
        }
        
        public void ModifyOrder(int id, Order neworder)
        {
            int i = -1;
            int j = -1;
            try
            {
                foreach (Order order in Orders)
                {
                    i++;
                    if (order.OrderNum == id)
                    {
                        j = i;
                    }
                }
                Orders[j] = neworder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("订单修改失败，请检查输入的订单号!");
            }
        }
        
        public Order OrderByNum(int id)
        {
            var query = Orders.Where(o => o.OrderNum == id);
            Order order = (Order)query;
            return order;
        }

        public List<Order> OrderByClient(String name)
        {
            var query = Orders.Where(o => o.Client.ClientName == name).OrderBy(o => o.Sum);
            return query.ToList();
        }
        
        public void ShowOrders()
        {
            foreach (Order order in Orders)
            {
                Console.Write("\norderNum:" + order.OrderNum + "\tClientName:" + order.Client.ClientName + "\tSum:￥" + order.Sum);
            }
        }

        public void Export

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("大英", 1);
            Item item2 = new Item("物理", 2);
            Item item3 = new Item("高数", 3);
            Item item4 = new Item("软基", 4);
            Item item5 = new Item("计组", 5);

            Client client1 = new Client("陈博宇");
            Client client2 = new Client("博宇陈");
            Client client3 = new Client("宇陈博");

            OrderDetails orderItem1 = new OrderDetails(item1, 1);
            OrderDetails orderItem2 = new OrderDetails(item2, 2);
            OrderDetails orderItem3 = new OrderDetails(item3, 3);
            OrderDetails orderItem4 = new OrderDetails(item4, 4);
            OrderDetails orderItem5 = new OrderDetails(item5, 5);

            OrderDetails[] orderItems1 = { orderItem1, orderItem2 };
            OrderDetails[] orderItems2 = { orderItem2, orderItem3 };
            OrderDetails[] orderItems3 = { orderItem3, orderItem4 };
            OrderDetails[] orderItems4 = { orderItem4, orderItem5 };

            Order order1 = new Order(10001, client1, orderItems1);
            order1.Calculate();
            Order order2 = new Order(10002, client2, orderItems2);
            order2.Calculate();
            Order order3 = new Order(10003, client3, orderItems3);
            order3.Calculate();
            Order order4 = new Order(10002, client3, orderItems4);
            order4.Calculate();

            OrderService orderService = new OrderService();
            orderService.AddOrder(order2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order3);
            
            Console.Write("当前订单序列: ");
            orderService.ShowOrders();
            Console.WriteLine();
            
            Console.Write("按订单号排序后的订单序列: ");
            orderService.SortByNum();
            orderService.ShowOrders();
            Console.WriteLine();
            
            Console.WriteLine("删除订单编号为10000的订单");
            orderService.RemoveOrder(10000);

            Console.Write("修改订单序号为10002的订单: ");
            orderService.ModifyOrder(10002, order4);

            Console.Write("当前订单序列: ");
            orderService.ShowOrders();
            Console.WriteLine();

            Console.WriteLine("查询宇陈博的订单");
            List<Order> porders = orderService.OrderByClient("宇陈博");
            foreach (Order order in porders)
            {
                Console.Write(order);
            }
            Console.ReadKey();
        }
    }
}
