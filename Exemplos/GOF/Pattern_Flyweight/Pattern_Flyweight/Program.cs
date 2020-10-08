using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Flyweight
{
    public class Student
    {
        String name;
        int id;
        int score;
        double averageScore;
        public Student(double a) { averageScore = a; }
        public void setName(String n) { name = n; }
        public void setId(int i) { id = i; }
        public void setScore(int s) { score = s; }
        public String getName() { return name; }
        public int getID() { return id; }
        public int getScore() { return score; }
        public double getStanding()
        {
            return (((double)score) / averageScore - 1.0) * 100.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String[] names = { "Ralph", "Alice", "Sam" };
            int[] ids = { 1001, 1002, 1003 };
            int[] scores = { 45, 55, 65 };
            double total = 0;
            for (int loopIndex = 0; loopIndex < scores.Length; loopIndex++)
            {
                total += scores[loopIndex];
            }
            double averageScore = total / scores.Length;
            Student student = new Student(averageScore);
            for (int loopIndex = 0; loopIndex < scores.Length; loopIndex++)
            {
                student.setName(names[loopIndex]);
                student.setId(ids[loopIndex]);
                student.setScore(scores[loopIndex]);
                Console.WriteLine("Name: " + student.getName());
                Console.WriteLine("Standing: " + Math.Round(student.getStanding()));
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}
