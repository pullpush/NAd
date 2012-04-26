// Type: Microsoft.ApplicationServer.Http.WebApiConfiguration
// Assembly: Microsoft.ApplicationServer.HttpEnhancements, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Projects\Workshop\NAd\packages\WebApi.Enhancements.0.6.0\lib\40-Full\Microsoft.ApplicationServer.HttpEnhancements.dll

using Microsoft.ApplicationServer.Http.Description;

namespace Microsoft.ApplicationServer.Http
{
    public class WebApiConfiguration : HttpConfiguration
    {
        public WebApiConfiguration(bool useMethodPrefixForHttpMethod = true);
        protected override void OnConfigureServiceHost(HttpServiceHost serviceHost);
        protected override void OnConfigureEndpoint(HttpEndpoint endpoint);
    }
}
