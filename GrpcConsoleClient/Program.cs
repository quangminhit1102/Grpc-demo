// See https://aka.ms/new-console-template for more information

using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

//// Hellp Request Model
//var input = new HelloRequest { Name = "Remote Procedure Call With Grpc" };

//// Create Grpc channel
//var channel = GrpcChannel.ForAddress("https://localhost:7069");
//// Create new client For Greeter Service
//var client = new Greeter.GreeterClient(channel);

//// Call Say hello Async
//var reply = await client.SayHelloAsync(input).ConfigureAwait(false);
//Console.WriteLine(reply);

// -------------------------------------------------------

var input = new CustomerLookupModel { UserId = 2};

// Create Grpc channel
var channel = GrpcChannel.ForAddress("https://localhost:7069");
// Create new client For Greeter Service
var client = new Customer.CustomerClient(channel);
var reply = await client.GetCustomerInfoAsync(input).ConfigureAwait(false);
Console.WriteLine(reply);

Console.WriteLine("==============================================");
Console.WriteLine("Get new Customers:");

using (var call = client.GetNewCustomers(new NewCustomerRequest()))
{
    // Get each customer from response stream.
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine(currentCustomer);
    }
};

Console.WriteLine("==============================================");
Console.WriteLine("Get all Customers:");

using (var call = client.GetAllCustomersAsync(new Empty() { }))
{
    Console.WriteLine(call.ResponseAsync.Result);
};


Console.ReadLine();