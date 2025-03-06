namespace FDS.CRM.Application.OrderConfig.DTOs;

public class OrderConfigDto
{
    public string BankName { get; set; }
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public bool AllowPayment { get; set; }
    public SendEmailType SendEmailType { get; set; }
}

public class OrderConfigDetailDto
{
    public string BankName { get; set; }
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public bool AllowPayment { get; set; }
    public string SendEmailType { get; set; }
}
