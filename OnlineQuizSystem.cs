using System;
using System.Collections.Generic;

//This is a basic structure for an Online Quiz System. 
//    You can further enhance it by adding features like scoring, timer functionality, 
//    randomization of questions, user feedback, and more,
//    based on your requirements and creativity.

// Base class for different types of quiz questions
public abstract class Question
{
    public string Prompt { get; set; }

    // Method to display the question (to be implemented in derived classes)
    public abstract void DisplayQuestion();

    // Additional properties and methods...
}

public class MultipleChoiceQuestion : Question
{
    public List<string> Choices { get; set; }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"{Prompt}\nChoices: {string.Join(", ", Choices)}");
    }
}

public class TrueFalseQuestion : Question
{
    public override void DisplayQuestion()
    {
        Console.WriteLine($"True or False: {Prompt}");
    }
}

public class ShortAnswerQuestion : Question
{
    public override void DisplayQuestion()
    {
        Console.WriteLine($"Short Answer: {Prompt}");
    }
}

public class QuizSession
{
    private List<Question> questions;

    public QuizSession(List<Question> questions)
    {
        this.questions = questions;
    }

    public void TakeQuiz()
    {
        foreach (var question in questions)
        {
            question.DisplayQuestion();
            // Get user's answer and provide feedback...
            // Add logic for scoring, timer, randomization, etc.
        }
    }
}

class Program
{
    static void Main()
    {
        var multipleChoiceQuestion = new MultipleChoiceQuestion
        {
            Prompt = "What is the capital of France?",
            Choices = new List<string> { "Paris", "Berlin", "London", "Rome" }
        };

        var trueFalseQuestion = new TrueFalseQuestion
        {
            Prompt = "The Earth orbits the Moon. (True/False)"
        };

        var shortAnswerQuestion = new ShortAnswerQuestion
        {
            Prompt = "Name one of Shakespeare's plays."
        };

        var quizSession = new QuizSession(new List<Question>
        {
            multipleChoiceQuestion,
            trueFalseQuestion,
            shortAnswerQuestion
        });

        quizSession.TakeQuiz();
    }
}
