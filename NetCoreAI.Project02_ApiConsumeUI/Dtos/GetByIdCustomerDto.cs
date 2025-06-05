namespace NetCoreAI.Project02_ApiConsumeUI.Dtos
{
    public class GetByIdCustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public decimal CustomerBalance { get; set; }
    }
}
