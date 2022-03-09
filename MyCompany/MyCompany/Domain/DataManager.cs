using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public IOrdersRepository Orders { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, 
            IServiceItemsRepository serviceItemsRepository, IOrdersRepository ordersRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            Orders = ordersRepository;
        }
    }
}
