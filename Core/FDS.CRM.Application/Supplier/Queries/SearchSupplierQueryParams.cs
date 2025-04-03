namespace FDS.CRM.Application.Supplier.Queries;

public class SearchSupplierQueryParams
{
    public string? Name { get; set; }
    public int Status { get; set; }  // Mặc định Status này sẽ có giá trị là tất cả = 0
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public bool IsDescending { get; set; }

    public SearchRequestModel ToSearchRequest()
    {
        var conditions = new List<SearchCondition>();

        if (!string.IsNullOrEmpty(Name))
        {
            conditions.Add(new SearchCondition
            {
                Field = "Name",
                Operator = "contains",
                Value = Name
            });
        }

        conditions.Add(new SearchCondition
        {
            Field = "Status",
            Operator = "==",
            Value = Status
        });

        return new SearchRequestModel
        {
            PageNumber = PageNumber,
            PageSize = PageSize,
            SortField = SortField,
            IsDescending = IsDescending,
            Conditions = conditions
        };
    }
}
