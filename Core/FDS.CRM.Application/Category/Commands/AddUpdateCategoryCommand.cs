using FDS.CRM.Application.Category.DTOs;

namespace FDS.CRM.Application.Category.Commands;

public class AddUpdateCategoryCommand : ICommand
{
    public CategoryDto CategoryDto { get;set; }
}
public class AddUpdateCategoryValidator
{
    public static void Validate(AddUpdateCategoryCommand request)
    {
        ValidationException.NotNullOrWhiteSpace(request.CategoryDto.Name, "Tên không được để trống.");
    }
}

internal class AddUpdateCategoryCommandHandler : ICommandHandler<AddUpdateCategoryCommand>
{
    private readonly ICrudService<Domain.Entities.Category> _categoryService;
    private readonly IUnitOfWork _unitOfWork;

    public AddUpdateCategoryCommandHandler(ICrudService<Domain.Entities.Category> categoryService, IUnitOfWork unitOfWork)
    {
        _categoryService = categoryService;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(AddUpdateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        AddUpdateCategoryValidator.Validate(command);

        using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
        {
            var cate = Domain.Entities.Category.Create(command.CategoryDto.Name, command.CategoryDto.Code, command.CategoryDto.Description);

            await _categoryService.AddAsync(cate);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }
}

