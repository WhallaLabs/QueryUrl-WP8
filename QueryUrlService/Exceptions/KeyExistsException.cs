using System;

namespace WhallaLabs.Services.QueryUrlService.Exceptions
{
    public class KeyExistsException : Exception
    {
        public KeyExistsException()
            : base("Dictionary contains this key")
        {
        }
    }
}
