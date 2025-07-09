using System.Collections.Generic;

namespace JobApplicationPortal.Net.MimeTypes
{
    public static class MimeTypeMap
    {
        private static readonly Dictionary<string, string> Mappings = new()
        {
            { ".pdf", "application/pdf" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" }
        };

        public static string GetMimeType(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                return "application/octet-stream";

            return Mappings.TryGetValue(extension.ToLower(), out var mime)
                ? mime
                : "application/octet-stream";
        }
    }
}
