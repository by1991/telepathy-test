using TL.Question2;

Console.WriteLine("Hello, World!");

AVL tree = new AVL();
tree.AddData(5);
tree.AddData(3);
tree.AddData(6);
tree.AddData(7);
tree.AddData(2);
tree.AddData(7);
tree.AddData(1);
tree.AddData(9);
tree.Print();
tree.SearchData(2);
tree.SearchData(7);