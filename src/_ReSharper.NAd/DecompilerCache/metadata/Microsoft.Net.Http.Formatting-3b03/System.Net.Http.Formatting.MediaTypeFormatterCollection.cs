// Type: System.Net.Http.Formatting.MediaTypeFormatterCollection
// Assembly: Microsoft.Net.Http.Formatting, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Projects\Workshop\NAd\packages\HttpClient.0.6.0\lib\40\Microsoft.Net.Http.Formatting.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Net.Http.Formatting
{
    public class MediaTypeFormatterCollection : Collection<MediaTypeFormatter>
    {
        public MediaTypeFormatterCollection();
        public MediaTypeFormatterCollection(IEnumerable<MediaTypeFormatter> formatters);
        public XmlMediaTypeFormatter XmlFormatter { get; }
        public JsonMediaTypeFormatter JsonFormatter { get; }
        public JsonValueMediaTypeFormatter JsonValueFormatter { get; }
        public FormUrlEncodedMediaTypeFormatter FormUrlEncodedFormatter { get; }
    }
}
