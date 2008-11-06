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
    }
}