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

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            var output = new List<CustomerModel>()
            {
                 new CustomerModel() { FirstName = "User05", LastName = "005" },
                 new CustomerModel() { FirstName = "User06", LastName = "006" },
                 new CustomerModel() { FirstName = "User07", LastName = "007" },
                 new CustomerModel() { FirstName = "User08", LastName = "008" },
                 new CustomerModel() { FirstName = "User09", LastName = "009" },
            };

            foreach (var customer in output)
            {
                // Write each item into response stream.
                await responseStream.WriteAsync(customer);
            }
        }

        public override Task<CustomersResponse> GetAllCustomers(Empty request, ServerCallContext context)
        {
            var customers = new List<CustomerModel>()
            {
                 new CustomerModel() { FirstName = "User11", LastName = "011" },
                 new CustomerModel() { FirstName = "User12", LastName = "012" },
                 new CustomerModel() { FirstName = "User13", LastName = "013" },
                 new CustomerModel() { FirstName = "User14", LastName = "014" },
                 new CustomerModel() { FirstName = "User15", LastName = "015" },
            };

            return Task.FromResult(new CustomersResponse() { Customers = { customers } });
        }
    }
}

