using Collections;

int[] arr = { 1, 5, 3, 8, 6, 7, 2, 9, 4 };
SortAlgorithms.BubbleSort(arr); // OpCount = 39
//SortAlgorithms.SelectionSrot(arr); // OpCount = 44
//SortAlgorithms.InsertionSort(arr); // OpCount = 53
Console.WriteLine(SortAlgorithms.OpCount);

for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]}, ");
}

