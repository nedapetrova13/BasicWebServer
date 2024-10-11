using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }
        public string Url { get; private set; }
        public HeaderCollection Headers { get; private set; }
        public string Body { get; private set; }

    }
    public static Request Parse(string request)
    {
        var lines = request.Split(new[] { "\r\n" }, StringSplitOptions.None);
        var startLine = lines.First().Split(' ');
        var method = ParseMethod(startLine[0]);
        var url = startLine[1];
        return new Request()
        {
            Method = method,
            Url = url,
            Headers = headers,
            Body = body
        };
    }
    private static Method ParseMethod(string method)
    {
        try
        {
            return Enum.Parse<Method>(method);
        }
        catch (Exception)
        {
            throw new InvalidOperationException($"Method '{method}' is not supported");
        }
    }
    private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
    {
        var headerCollection = new HeaderCollection();
        foreach (var headerLine in headerLines)
        {
            if (headerLine == string.Empty)
            {
                break;
            }
            var headerParts = headerLine.Split(":", 2);
            if (headerParts.Length != 2)
            {
                throw new InvalidOperationException("Request is not valid.");
            }
            var headerName = headerParts[0];
            var headerValue = headerParts[1].Trim();

            headerCollection.Add(headerName, headerValue);
        }
        return headerCollection;
    }
}
