namespace API_Admin_ElecShop.Controllers
{
    internal class ResponseListMessage
    {
        public int page { get; set; }
        public object totalItem { get; set; }
        public int pageSize { get; set; }
        public object data { get; set; }
    }
}