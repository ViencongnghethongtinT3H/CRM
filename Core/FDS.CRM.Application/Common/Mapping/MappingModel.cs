using AutoMapper;

namespace FDS.CRM.Application.Common.Mapping
{
    public class MappingModel : Profile
    {
        public MappingModel() 
        {
            MappingEntityToViewModel();
            MappingDtoToEntity();
        }   

        // Get data from Entity map to View Model
        private void MappingEntityToViewModel() 
        {
            // Get data
            CreateMap<Domain.Entities.Supplier, SupplierDetailViewModel>();
        }

        private void MappingDtoToEntity()
        {

        }
    }
}
