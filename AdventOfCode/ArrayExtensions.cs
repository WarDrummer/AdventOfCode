namespace AdventOfCode;

public static class ArrayExtensions
{
    public static bool AreSame<T>(this T[] arr1, T[] arr2)
    {
        if(arr1.Length != arr2.Length) 
            return false;

        for (var i = 0; i < arr1.Length; i++)
        {
            if (!arr1[i].Equals(arr2[i])) 
                return false;
        }

        return true;
    }
}