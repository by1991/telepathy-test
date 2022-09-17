using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace TL.Question2.Tests;

public class TestPrintData
{
    [Fact]
    public void TestNotEmotyCase()
    {
        var tree = new AVL();
        tree.AddData(5);
        tree.AddData(3);
        tree.AddData(6);
        tree.AddData(7);
        tree.AddData(2);

        var nodes = tree.Print();

        var result = new int[5] { 2, 3, 5, 6, 7 };

        Assert.Equal(nodes, result);
    }

    [Fact]
    public void TestEmptyCase()
    {
        var tree = new AVL();

        var nodes = tree.Print();

        Assert.Equal(nodes, null);
    }
}
