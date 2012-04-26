
using System.Linq;
using System.Net.Http;
using NAd.Framework.Persistence.Abstractions;

//using NAd.Querying.Core.Domain;

namespace NAd.Querying.Host.Infrastructure
{
    public static class RequestExtensions
    {
        public static bool IsNotModified(this HttpRequestMessage requestMessage, IHaveVersion versionable)
        {
            if (!requestMessage.Headers.IfNoneMatch.Any()) return false;
            var etag = requestMessage.Headers.IfNoneMatch.First().Tag;
            return string.Format("\"{0}\"", versionable.Version) == etag;
        }
    }
}