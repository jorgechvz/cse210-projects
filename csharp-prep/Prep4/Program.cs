using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int finished = -1;
        int sum = 0;
        List<int> numbers = new List<int>();
        while (finished != 0){
            Console.Write("Enter a list of numbers, type 0 when finished: ");
            finished = int.Parse(Console.ReadLine());
            if (finished != 0){
                numbers.Add(finished);
            }
        }
        foreach (int number in numbers){
            sum += number;
        }
        Console.WriteLine($"The sum is {sum}");
        float average = ((float)sum / numbers.Count);
        Console.WriteLine($"The average is {average}");
        int max = numbers[0];
        int min = numbers[0];
        foreach (int number in numbers){
            if (number > max){
                max = number;
            }
            if (number > 0){
                if (min > number){
                min = number;
                }
            }
        }
        Console.WriteLine($"The largest number is {max}");
        Console.WriteLine($"The smallest positive number is {min}");
        numbers.Sort();
        foreach (int number in numbers){
            Console.WriteLine(number);
        }
    }
}