using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace cxmHandler
{
    public class Function
    {
        public APIGatewayProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest apigProxyEvent, ILambdaContext context)
        {
            Console.WriteLine($"Processing request data for request {apigProxyEvent.RequestContext.RequestId}.");
            Console.WriteLine($"Body size = {apigProxyEvent.Body.Length}.");
            var headerNames = string.Join(", ", apigProxyEvent.Headers.Keys);
            Console.WriteLine($"Specified headers = {headerNames}.");

            return new APIGatewayProxyResponse
            {
                Body = apigProxyEvent.Body,
                StatusCode = 200,
            };
        }
    }
}
