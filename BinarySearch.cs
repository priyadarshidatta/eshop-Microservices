using System;

public class BinarySearch
{
    // Iterative Binary Search function
    public static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Check if target is present at mid
            if (arr[mid] == target)
            {
                return mid;
            }

            // If target greater, ignore left half
            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            // If target smaller, ignore right half
            else
            {
                right = mid - 1;
            }
        }

        // If we reach here, then the element was not present
        return -1;
    }

    // Example Usage:
    // public static void Main(string[] args)
    // {
    //     int[] arr = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
    //     int target = 23;
    //     int result = Search(arr, target);
    //     if (result == -1)
    //         Console.WriteLine("Element not present in array");
    //     else
    //         Console.WriteLine("Element found at index " + result); // Output: Element found at index 5

    //     target = 77;
    //     result = Search(arr, target);
    //     if (result == -1)
    //         Console.WriteLine("Element not present in array"); // Output: Element not present in array
    //     else
    //         Console.WriteLine("Element found at index " + result);
    // }
}