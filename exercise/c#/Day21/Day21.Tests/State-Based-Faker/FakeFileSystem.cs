using Day21.State_Based_Faker;

namespace Day21.Tests.State_Based_Faker;

public class FakeFileSystem : IFileSystem
{
    private readonly Dictionary<string, List<string>> _files = new();

    public string[] GetFiles(string directoryName) =>
        FilePaths()
            .Where(filePath => Path.GetDirectoryName(filePath) == directoryName)
            .ToArray();

    public void WriteAllText(string filePath, string content) =>
        _files[filePath] = content.Split(Environment.NewLine).ToList();

    public IEnumerable<string> ReadAllLines(string filePath) => _files[filePath];

    public void AddFile(string filePath, List<string> content) =>
        _files.Add(
            filePath,
            [..content]);

    private Dictionary<string, List<string>>.KeyCollection FilePaths() => _files.Keys;
}