namespace Mass.Notification.Shared
{
    public class OrderNotification
    {
        public OrderNotification(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
