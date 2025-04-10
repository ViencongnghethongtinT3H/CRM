using FDS.CRM.CrossCuttingConcerns.Helper;
using FDS.CRM.Domain.Entities;

namespace FDS.CRM.Application.Supplier.Commands;

public class AddSupplierCommand : ICommand
{
    public SupplierDto SupplierDto { get; set; }
}

public class AddSupplierValidator
{
    public static void Validate(AddSupplierCommand request)
    {
        ValidationException.NotNullOrWhiteSpace(request.SupplierDto.Name, "Tên nhà cung cấp không được để trống.");
        ValidationException.NotNullOrWhiteSpace(request.SupplierDto.Code, "Mã nhà cung cấp không được để trống.");
        ValidationException.LengthInRange(request.SupplierDto.Name, 0, 200, "Độ dài của chuỗi nhập vào không vượt quá 200 ký tự");
        ValidationException.LengthInRange(request.SupplierDto.Code, 0, 200, "Độ dài của chuỗi nhập vào không vượt quá 200 ký tự");
        ValidationException.LengthInRange(request.SupplierDto.Tax, 0, 15, "Độ dài của chuỗi nhập vào không vượt quá 15 ký tự");
        ValidationException.LengthInRange(request.SupplierDto.Address, 0, 200, "Độ dài chuỗi nhập vào không vượt quá 200 ký tự");
        ValidationException.ValidEmail(request.SupplierDto.Email, "Email không đúng định dạng");
    }
}
internal class AddSupplierCommandHandler : ICommandHandler<AddSupplierCommand>
{
    private readonly ICrudService<Domain.Entities.Supplier> _supplierService;
    private readonly IUnitOfWork _unitOfWork;
    public AddSupplierCommandHandler(IUnitOfWork unitOfWork = null, 
        ICrudService<Domain.Entities.Supplier> supplierService = null)
    {
        _unitOfWork = unitOfWork;
        _supplierService = supplierService;
    }
    public async Task HandleAsync(AddSupplierCommand command, CancellationToken cancellationToken = default)
    {
        AddSupplierValidator.Validate(command);

        // Khi chúng ta thao tác vs CSDL
        // Mở 1 kết nối tới sql server
        // Khai báo các đối tượng để thao tác vs CSDL , command, query
        // Thực thi các câu lệnh - insert, update, truy vấn
        // Giải phóng các đối tượng command, query
        // Đóng kêt nốii


        // Sử dụng Using cho việc thao tác với CSDL nhằm mục đích tự động giải phóng các đối tượng sau khi thực thi câu lệnh xong
        // _unitOfWork, _categoryService, Repository
        // và Using sẽ tự động đóng kết nối
        // 
        using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
        {
            var supplier = Domain.Entities.Supplier.Create(command.SupplierDto.Name, command.SupplierDto.Code, command.SupplierDto.Tax, command.SupplierDto.Address,
                command.SupplierDto.PhoneNumber, command.SupplierDto.Email);

            var filterField = new List<string> { command.SupplierDto.Name, command.SupplierDto.Code, command.SupplierDto.Address };
            
            supplier.SetFilter(StringHelpers.SetFilterField(filterField));

            await _supplierService.AddAsync(supplier);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }
}
