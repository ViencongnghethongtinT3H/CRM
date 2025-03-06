namespace FDS.CRM.Application.Contact.DTOs;

public class SearchContactDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public LeadStatusEnum LeadStatus { get; set; }
    public int LeadScored { get; set; }

}
