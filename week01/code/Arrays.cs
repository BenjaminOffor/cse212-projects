public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
public static double[] MultiplesOf(double number, int length)
{
    // TODO Problem 1 Start
    // Step-by-step plan:
    // 1. Create a new array of type double with size equal to 'length'.
    //    This array will store the multiples of the given number.
    //
    // 2. Use a loop that runs from index 0 up to length - 1.
    //    Each loop iteration will calculate one multiple.
    //
    // 3. For each index i:
    //    - The multiple should be: number * (i + 1)
    //    - We use (i + 1) because:
    //         i = 0 → first multiple = number * 1
    //         i = 1 → second multiple = number * 2
    //         i = 2 → third multiple = number * 3
    //         etc.
    //
    // 4. Store each calculated multiple in the array at index i.
    //
    // 5. After the loop finishes, return the filled array.

    // Step 1: Create the array
    double[] multiples = new double[length];

    // Step 2–4: Fill the array with multiples
    for (int i = 0; i < length; i++)
    {
        multiples[i] = number * (i + 1);
    }

    // Step 5: Return the result
    return multiples;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
public static void RotateListRight(List<int> numbers, int rotations)
{
    int count = numbers.Count;

    // No rotation needed for empty list
    if (count == 0)
        return;

    // Normalize rotations
    rotations = rotations % count;

    if (rotations == 0)
        return;

    // Store rotated result temporarily
    List<int> result = new List<int>();

    // Add last 'rotations' elements
    result.AddRange(numbers.GetRange(count - rotations, rotations));

    // Add remaining elements
    result.AddRange(numbers.GetRange(0, count - rotations));

    // Modify original list in place
    numbers.Clear();
    numbers.AddRange(result);
}
}