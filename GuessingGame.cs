//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Random random = new Random();
//bool playAgain = true;
//int minVal = 1;
//int maxVal = 100;
//int guess;
//int number;
//int guesses;
//String response;

//while (playAgain)
//{
//    guess = 0;
//    guesses = 0;
//    number = random.Next(minVal, maxVal + 1);
//    Console.WriteLine(number);

//    while (guess != number)
//    {

//        Console.WriteLine("Guess a number between " + minVal + " - " + maxVal + ": ");
//        guess = Convert.ToInt32(Console.ReadLine());

//        if (guess > number)
//        {
//            Console.WriteLine(guess + " is to high!");
//        }
//        else if (guess < number)
//        {
//            Console.WriteLine(guess + " is to low!");
//        }
//        guesses++;

//    }
//    Console.WriteLine("Number: " + number);
//    Console.WriteLine("YOU WIN: " + guess);
//    Console.WriteLine("guesses: " + guesses);

//    Console.WriteLine("Would you like to play again? (Y/N): ");
//    response = Console.ReadLine();
//    response = response.ToUpper();

//    if (response == "Y")
//    {
//        playAgain = true;
//    }
//    else
//    {
//        playAgain = false;
//    }


//}