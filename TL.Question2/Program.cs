using TL.Question2;

Console.WriteLine("-----------------------------");
Console.WriteLine("---------- Welcome ----------");
Console.WriteLine("-----------------------------");
Console.WriteLine();
Console.WriteLine("How Many Initial Numbers?");
GenerateAVLTree();

void GenerateAVLTree()
{
    var input = Console.ReadLine();
    var count = 0;

    if (input == null)
    {
        Console.WriteLine("Please Type A Valid Number (An Integer Greater Than 0):");
        GenerateAVLTree();
    }
    else
    {
        count = Int32.Parse(input.Replace(" ", ""));
    }

    Console.WriteLine("Initializing...");

    var tree = new AVL();
    var random = new Random();

    for (var i = 0; i < count; i++)
    {
        tree.AddData(random.Next());
    }

    Console.WriteLine("Done. Here are the random data:");

    tree.Print();

    Console.WriteLine("Please Select An Action Below:");

    ShowMenu(tree);
}

void ShowMenu(AVL tree)
{
    Console.WriteLine("-- Insert, Please Type 1");
    Console.WriteLine("-- Search, Please Type 2");
    Console.WriteLine("-- Print, Please Type 3");

    var action = Console.ReadLine();

    if (action == null)
    {
        Console.WriteLine("Please Type A Valid Action:");
        ShowMenu(tree);
    }
    else
    {
        action = action.Replace(" ", "");
    }

    switch (action)
    {
        case "1":
            Console.WriteLine("Please provide an integer:");
            var number = Console.ReadLine();

            if (number != null)
            {
                tree.AddData(Int32.Parse(number.Replace(" ", "")));
                tree.Print();
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step1 = Console.ReadLine();

                if (step1 != null && step1.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu(tree);
                }
                else if (step1 != null && step1.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu(tree);
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step1 = Console.ReadLine();

                if (step1 != null && step1.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu(tree);
                }
                else if (step1 != null && step1.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu(tree);
                }
            }
            break;
        case "2":
            Console.WriteLine("Please provide an integer:");
            var numberToSearch = Console.ReadLine();

            if (numberToSearch != null)
            {
                tree.SearchData(Int32.Parse(numberToSearch.Replace(" ", "")));
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu(tree);
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu(tree);
                }
            }
            else
            {
                Console.WriteLine("-- Type 1 To Continue");
                Console.WriteLine("-- Type 2 To Exit");

                var step2 = Console.ReadLine();

                if (step2 != null && step2.Replace(" ", "") == "1")
                {
                    Console.WriteLine("Please Select An Action Below:");
                    ShowMenu(tree);
                }
                else if (step2 != null && step2.Replace(" ", "") == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Type A Valid Action:");
                    ShowMenu(tree);
                }
            }
            break;
        case "3":
            tree.Print();
            Console.WriteLine("-- Type 1 To Continue");
            Console.WriteLine("-- Type 2 To Exit");

            var step3 = Console.ReadLine();

            if (step3 != null && step3.Replace(" ", "") == "1")
            {
                Console.WriteLine("Please Select An Action Below:");
                ShowMenu(tree);
            }
            else if (step3 != null && step3.Replace(" ", "") == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please Type A Valid Action:");
                ShowMenu(tree);
            }
            break;
        default:
            break;
    }
}