const grpc = require("@grpc/grpc-js");
const protoLoader = require("@grpc/proto-loader");

const PROTO_PATH = "./protos/greet.proto"; // Replace with the actual path

const packageDefinition = protoLoader.loadSync(PROTO_PATH, {
  keepCase: true,
  longs: String,
  enums: String,
  defaults: true,
  oneofs: true,
});

// Disable ssl
process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = 0;

const greet = grpc.loadPackageDefinition(packageDefinition).greet;
const client = new greet.Greeter(
  "localhost:7069",
  grpc.credentials.createSsl()
);

// Make a gRPC call
client.SayHello({ name: "Your Name" }, (error, response) => {
  if (!error) {
    console.log("Response:", response.message);
  } else {
    console.error(error);
  }
});
