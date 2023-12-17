// See https://aka.ms/new-console-template for more information

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


Console.ReadLine();