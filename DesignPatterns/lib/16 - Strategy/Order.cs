namespace lib._16___Strategy
{
    public class Order
    {
        private List<string> orders;
        public Order()
        {
            orders = new List<string>();
        }

        public void AddOrder(string item)
        {
            orders.Add(item);
        }

        public void SendReceipt(ISendMessage messageSenderService)
        {
            messageSenderService.SendMessage(string.Join(',', orders));
        }
    }
}
