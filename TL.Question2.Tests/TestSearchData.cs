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
        Assert.Null(node);
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
        if (node != null)
        {
            Assert.Equal(6, node.Data);
            Assert.Null(node.Left);
            Assert.Equal(7, node.Right.Data);
        }
    }
}
