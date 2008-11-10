using System;

namespace GitSharp
{
    public static class Extensions
    {
        public static byte[] ToByteArray(this string content)
        {
            return new System.Text.ASCIIEncoding().GetBytes(content);
        }

        public static string ToAsciiString(this byte[] bytes)
        {
            return new System.Text.ASCIIEncoding().GetString(bytes);
        }

        public static string ToHexString(this byte[] bytes)
        {
            var hexString = "";
            
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            
            return hexString;
        }

        public static int ToInt32(this byte[] bytes)
        {
            // nasty
            string value = "";

            foreach (var b in bytes)
            {
                value += b.ToString();
            }

            return Convert.ToInt32(value);
        }
    }
}