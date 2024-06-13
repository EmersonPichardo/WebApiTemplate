using Presentation._Common.Endpoints;

namespace Presentation.Endpoints;

public class TestEndpoints : BaseEndpointCollection
{
    public TestEndpoints()
        : base("helloWorld")
    {
        DefineEndpoint(HttpVerbose.Get, "/", () => Results.Ok("Hello World"), 200, null);
    }
}
