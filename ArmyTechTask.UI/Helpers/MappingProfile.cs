using AutoMapper;
using ArmyTechTask.Core.Entities;
using ArmyTechTask.UI.Models.Invoice;
using ArmyTechTask.UI.Models.CashierVM;

namespace ArmyTechTask.UI.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<InvoiceDetailsVm, InvoiceDetail>().ReverseMap();
        CreateMap<InvoiceHeaderVm, InvoiceHeader>().ReverseMap();
        CreateMap<CashierVm, Cashier>().ReverseMap();
    }
}