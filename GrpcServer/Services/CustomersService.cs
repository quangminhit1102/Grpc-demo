using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = request.UserId switch
            {
                1 => new CustomerModel() { FirstName = "User01", LastName = "001" },
                2 => new CustomerModel() { FirstName = "User02", LastName = "002" },
                3 => new CustomerModel() { FirstName = "User03", LastName = "003" },
                4 => new CustomerModel() { FirstName = "User04", LastName = "004" },
                5 => new CustomerModel() { FirstName = "User05", LastName = "005" },
                _ => new CustomerModel()
            };
            return Task.FromResult(output);
        }
    }
}
