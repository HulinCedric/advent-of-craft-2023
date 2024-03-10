using Day21.State_Based_Faker;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.State_Based_Faker;

public class AuditManagerTests
{
    private const string DirectoryName = "audits";
    private readonly AuditManager _audit;
    private readonly FakeFileSystem _fileSystem = new();

    public AuditManagerTests() => _audit = new AuditManager(3, DirectoryName, _fileSystem);

    [Fact]
    public void A_New_File_Is_Created_When_No_Files()
    {
        _audit.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        _fileSystem.ReadAllLines(File("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Alice;2019-04-06 18:00:00"
            ]);
    }

    [Fact]
    public void Append_To_Current_File_When_Current_File_Not_Full()
    {
        _fileSystem.AddFile(
            File("audit_1.txt"),
            [
                "Peter;2019-04-06 16:30:00",
                "Jane;2019-04-06 16:40:00"
            ]);

        _audit.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        _fileSystem.ReadAllLines(File("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Peter;2019-04-06 16:30:00",
                "Jane;2019-04-06 16:40:00",
                "Alice;2019-04-06 18:00:00"
            ]);
    }

    [Fact]
    public void A_New_File_Is_Created_When_The_Current_File_Overflows()
    {
        _fileSystem.AddFile(File("audit_1.txt"), []);
        _fileSystem.AddFile(
            File("audit_2.txt"),
            [
                "Peter;2019-04-06 16:30:00",
                "Jane;2019-04-06 16:40:00",
                "Jack;2019-04-06 17:00:00"
            ]);

        _audit.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        _fileSystem.ReadAllLines(File("audit_3.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Alice;2019-04-06 18:00:00"
            ]);
    }


    private static string File(string fileName) => Path.Combine(DirectoryName, fileName);
}