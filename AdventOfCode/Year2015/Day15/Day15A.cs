using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day15;

public class Ingredient
{
    public long Capacity { get; set; }
    public long Durability { get; set; }
    public long Flavor { get; set; }
    public long Texture { get; set; }
    public long Calories { get; set; }
}
    
public class Day15A : ProblemWithInput<Day15A>
{
    public override string Solve()
    {
        var ingredients = GetIngredients();

        long highScore = 0;
        foreach (var portion in GeneratePortions())
        {
            var recipe = GetRecipe(ingredients, portion);

            var score = 
                Math.Max(0, recipe.Capacity) * 
                Math.Max(0, recipe.Durability) * 
                Math.Max(0, recipe.Flavor) * 
                Math.Max(0, recipe.Texture);
                
            if (score > highScore)
            {
                highScore = score;
            }
        }
            
        return highScore.ToString();
    }

    protected static Ingredient GetRecipe(IEnumerable<Ingredient> ingredients, dynamic portion)
    {
        var recipe = new Ingredient();
        var portionIndex = 0;
        foreach (var ingredient in ingredients)
        {
            var p = portion[portionIndex];
            recipe.Capacity += ingredient.Capacity * p;
            recipe.Durability += ingredient.Durability * p;
            recipe.Flavor += ingredient.Flavor * p;
            recipe.Texture += ingredient.Texture * p;
            recipe.Calories += ingredient.Calories * p;
            portionIndex++;
        }

        return recipe;
    }

    protected IEnumerable<Ingredient> GetIngredients()
    {
        return ParserFactory.CreateMultiLineStringParser()
            .GetData()
            .Select(d => d.Split(","))
            .Select(d => new Ingredient
            {
                Capacity = int.Parse(d[0].Split(" ")[^1]),
                Durability = int.Parse(d[1].Split(" ")[^1]),
                Flavor = int.Parse(d[2].Split(" ")[^1]),
                Texture = int.Parse(d[3].Split(" ")[^1]),
                Calories = int.Parse(d[4].Split(" ")[^1])
            })
            .ToList();
    }

    protected IEnumerable<dynamic> GeneratePortions()
    {
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j <= 100 - i; j++)
            {
                for (var k = 0; k <= 100 - i - j; k++)
                {
                    var l = 100 - i - j - k;
                    yield return new [] {i, j, k, l};
                }
            }
        }
    }
}