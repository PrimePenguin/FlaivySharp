using System;

namespace FlaivySharp.Infrastructure
{
    public class RequestUri
    {
        public RequestUri(Uri uri)
        {
            Url = uri;
        }

        private Uri Url;

        public Uri ToUri()
        {
            return new UriBuilder(Url).Uri;
        }

        public override string ToString() => ToUri().ToString();
    }
}