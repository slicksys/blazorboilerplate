using System;
using System.IO;
using System.Threading.Tasks;

namespace MudBlazor
{
    public interface IMudFileUploadEntry
    {
        DateTime LastModified {get; }
        string Name {get; }
        long Size { get; }
        string Type { get; }
        Task WriteToStreamAsync(Stream stream);
    }
}