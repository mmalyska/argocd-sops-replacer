namespace ReplacerE2ETests;

using System.IO;
using System.Threading.Tasks;
using Utils;
using Xunit;

[Collection("SopsEnv")]
public class SopsJsonE2ETests
{
    [Fact]
    public async Task TestSimpleReplacement()
    {
        var inputText = "A<secret:secretKey1>B";
        var expectedOutput = "AsecretValue1B";
        using var consoleOutput = new ConsoleOutput();
        using var consoleInput = ConsoleInput.FromString(inputText);

        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        var options = new[] { "sops", $"-f sops{Path.DirectorySeparatorChar}sops.sec.json" };
        var returnObject = entryPoint.Invoke(null, new object[] { options });
        if (returnObject is Task returnTask)
        {
            await returnTask;
        }

        Assert.Equal(expectedOutput, consoleOutput.GetOuput());
    }
}
