using System;
using System.Collections.Generic;

public class Activity
{
    public string ActivityId { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public double Duration { get; set; }
    public double Distance { get; set; }
    public int CaloriesBurned { get; set; }

    // Additional properties and methods...
}

public class Running : Activity
{
    public string Terrain { get; set; }

    // Additional properties and methods specific to running...
}

public class Cycling : Activity
{
    public string Route { get; set; }

    // Additional properties and methods specific to cycling...
}

public class Weightlifting : Activity
{
    public int Sets { get; set; }
    public int Reps { get; set; }

    // Additional properties and methods specific to weightlifting...
}

public class User
{
    public string UserName { get; set; }
    public List<Activity> Activities { get; set; } = new List<Activity>();
    public FitnessGoal Goal { get; set; }

    // Additional properties and methods...
}

public class FitnessGoal
{
    public string GoalId { get; set; }
    public double TargetSteps { get; set; }
    public double TargetDistance { get; set; }
    public int TargetCalories { get; set; }

    // Additional properties and methods...
}

class Program
{
    static void Main()
    {
        // Sample usage of the Fitness Tracker system
        User user = new User { UserName = "FitUser" };

        Running runningActivity = new Running { Type = "Running", Duration = 30, Distance = 5, Terrain = "Trail" };
        Cycling cyclingActivity = new Cycling { Type = "Cycling", Duration = 45, Distance = 15, Route = "City Streets" };

        user.Activities.Add(runningActivity);
        user.Activities.Add(cyclingActivity);

        // Implement goal setting, progress tracking, and display activity history...
    }
}


//Exercise 11: Fitness Tracker - Instructions and Code

//In this exercise, you will create a Fitness Tracker system that allows users to track their activities and monitor their progress. Follow the instructions below and use the provided code as a starting point:

//Activity Types:

//Create classes to represent different types of fitness activities (e.g., running, cycling, weightlifting).
//Implement properties and methods specific to each activity type.
//User Activities:

//Modify the User class to include a list of fitness activities.
//Implement methods for users to add new activities, view their activity history, and calculate their total calories burned.
//Goal Setting:

//Allow users to set fitness goals, such as a target number of steps, distance, or calories to burn.
//Implement methods to track users' progress towards their goals.
//Code Framework:

//Use the following code as a starting point for your Fitness Tracker system:


//Enhance this code by implementing the suggested features. Add methods like AddActivity, SetFitnessGoal, and properties like Terrain to the Activity subclasses and User and FitnessGoal classes to fulfill the requirements.