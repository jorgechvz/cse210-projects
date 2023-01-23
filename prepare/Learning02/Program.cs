using System;

class Program
{
    static void Main(string[] args)
    {
        Jobs job1 = new Jobs();
        job1._jobTitle = "Software Enginner";
        job1._company = "Apple";
        job1._startYear = 2017;
        job1._endYear = 2019;

        Jobs job2 = new Jobs();
        job2._jobTitle = "Manager";
        job2._company = "Microsoft";
        job2._startYear = 2019;
        job2._endYear = 2022;

        Resume resume = new Resume();
        resume._name = "Jorge Chavez";

        resume._jobs.Add(job1);    
        resume._jobs.Add(job2);

        resume.Display();    
    }
}