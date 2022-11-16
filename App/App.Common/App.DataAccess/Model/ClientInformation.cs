namespace App.Common.Models
{
    public class ClientInformation
    {
        public Guid UserID { get; set; }
        public Guid Token { get; set; }
        public string IPAddress { get; set; } = string.Empty;
        public string Application  { get; set; } = string.Empty;
    }
}
