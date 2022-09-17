using System.Runtime.Intrinsics.X86;

namespace TL.Question2.Tests;

public class TestSearchData
{
    [Fact]
    public void TestNotFoundCase()
    {
        var tree = new AVL();
        tree.AddData(5);
        tree.AddData(3);
        tree.AddData(6);
        tree.AddData(7);
        tree.AddData(2);

        var node = tree.SearchData(11);
        Assert.Equal(node, null);
    }

    [Fact]
    public void TestFoundCase()
    {
        var tree = new AVL();
        tree.AddData(5);
        tree.AddData(3);
        tree.AddData(6);
        tree.AddData(7);
        tree.AddData(2);

        var node = tree.SearchData(6);
        Assert.Equal(node.Data, 6);
        Assert.Equal(node.Left, null);
        Assert.Equal(node.Right.Data, 7);
    }
}
