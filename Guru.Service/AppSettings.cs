using System;

namespace Guru.Service
{
    public class AppSettings
    {
        public string KeyToken { get; set; }

        public byte[] ByteToken => Convert.FromBase64String(KeyToken);
    }
}