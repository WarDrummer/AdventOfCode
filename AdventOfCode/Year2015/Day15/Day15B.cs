using System;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day15
{
    public class Day15B : Day15A
    {
        public override string Solve()
        {
            var ingredients = GetIngredients();

            long highScore = 0;
            foreach (var portion in GeneratePortions())
            {
                var recipe = GetRecipe(ingredients, portion);

                if (recipe.Calories == 500)
                {
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
            }
            
            return highScore.ToString();
        }
    }
}