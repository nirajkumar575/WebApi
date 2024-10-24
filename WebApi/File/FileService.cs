using System.IO;
using System.Threading.Tasks;

public class FileService
{
    private readonly string _filePath = "C:/Users/kumniraj/Documents/Web_api/git/WebApi/WebApi/File/file.txt";

    public async Task WriteToFileAsync(string content)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, append: true))
        {
            await writer.WriteLineAsync(content);
        }
    }
}
