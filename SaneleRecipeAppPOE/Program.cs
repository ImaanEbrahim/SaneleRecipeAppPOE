// See https://aka.ms/new-console-template for more information


using System;

class Program
{
    static void Main(string[] args)                     //main code 
    {
        Recipe recipe = new Recipe();

        while (true)
        {
            Console.WriteLine("Welcome To Sanele's Recipe Application!"); //first line welcomes the user to the app
            Console.WriteLine("1. Add Ingredient");     //choices 1 to 7 
            Console.WriteLine("2. Add Step");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Display Recipe");
            Console.WriteLine("7. Exit Application");
            Console.Write("Please Enter your choice (1-7): "); // prompts user to choose from above
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)//references the above choices
            {
                case 1:
                    Console.Write("Please Enter The Ingredient's name: ");
                    string ingredient = Console.ReadLine();
                    Console.Write("Please Enter quantity: ");//how much of something has to be added e.g. 200/50/150 etc...
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please Enter The unit of measurement: ");//example: grams/mls/tablespoon etc.
                    string unit = Console.ReadLine();
                    recipe.AddIngredient(ingredient, quantity, unit);//adds all above prompt together e.g. 200 grams of flour 
                    Console.WriteLine("Ingredient added!");
                    break;
                case 2:
                    Console.Write("Please Enter The Step Description: ");//describes the step in the recipe e.g. mix the dry ingredients
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                    Console.WriteLine("Step added!");
                    break;
                case 3:
                    Console.Write("Please Enter The scale factor (0.5, 2, or 3): ");
                    double factor = Convert.ToDouble(Console.ReadLine());//converts the scale to users liking
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine("Recipe scaled!");
                    break;
                case 4:
                    recipe.ResetQuantities();
                    Console.WriteLine("Quantities reset!");
                    break;
                case 5:
                    recipe.ClearRecipe();
                    Console.WriteLine("Recipe cleared!");
                    break;
                case 6:
                    recipe.DisplayRecipe();//shows the user how the end result of the recipe will look with all that they have added 
                    break;
                case 7:
                    Console.WriteLine("Exiting Applicaction...Come Back Soon!");// exits the app (choice 7)
                    return;
                default:
                    Console.WriteLine("Choice not valid. Please try again");//if user types something that was not a choice 
                    break;
            }

            Console.WriteLine();
        }
    }
}

class Recipe                          //Recipe class to showcase all the elements
{
    private string[] ingredients;
    private double[] quantities;
    private string[] units;
    private string[] steps;

    // Constructor
    public Recipe()
    {
        ingredients = new string[0];
        quantities = new double[0];
        units = new string[0];
        steps = new string[0];
    }

    // To Add ingredient to the recipe (choice 1)
    public void AddIngredient(string ingredient, double quantity, string unit)
    {
        Array.Resize(ref ingredients, ingredients.Length + 1);
        Array.Resize(ref quantities, quantities.Length + 1);
        Array.Resize(ref units, units.Length + 1);

        ingredients[ingredients.Length - 1] = ingredient;
        quantities[quantities.Length - 1] = quantity;
        units[units.Length - 1] = unit;
    }

    // To Add step to the recipe (choice 2)
    public void AddStep(string step)
    {
        Array.Resize(ref steps, steps.Length + 1);
        steps[steps.Length - 1] = step;
    }

    // Scale the recipe by a factor (choice 3)
    public void ScaleRecipe(double factor)
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] *= factor;
        }
    }

    // Reset quantities to original values (choice 4)
    public void ResetQuantities()
    {
        // Implements the logic to reset quantities to original values in recipe
    }

    // Clear the recipe (choice 5)
    public void ClearRecipe()
    {
        ingredients = new string[0];
        quantities = new double[0];
        units = new string[0];
        steps = new string[0];
    }
    // Display the recipe and its details (choice 6)
    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe Details:");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");//the ingredient details and what the user will need 
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Length; i++)//numbers the steps so they are easy to follow
        {
            Console.WriteLine($"Step {i + 1}: {steps[i]}");//the steps for the recipe
        }
    }
}
