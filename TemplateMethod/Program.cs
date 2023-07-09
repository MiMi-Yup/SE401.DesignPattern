using System;

namespace TemplateMethod
{
    abstract class Unit
    {
        public void Move()
        {
            SelectDestination();
            CalculatePath();
            FollowPath();
            UpdatePosition();
            Display();
        }

        protected abstract void SelectDestination();

        protected abstract void CalculatePath();

        protected virtual void FollowPath()
        {
            Console.WriteLine("Following path for " + GetType().Name);
        }

        protected virtual void UpdatePosition()
        {
            Console.WriteLine("Updating position for " + GetType().Name);
        }

        protected virtual void Display()
        {
            Console.WriteLine("Displaying " + GetType().Name);
        }
    }


    class CavalryUnit : Unit
    {
        protected override void SelectDestination()
        {
            Console.WriteLine("Selecting destination for CavalryUnit");
            // Select destination for cavalry unit
        }

        protected override void CalculatePath()
        {
            Console.WriteLine("Calculating path for CavalryUnit");
            // Calculate path for cavalry unit
        }
    }

    class ArcherUnit : Unit
    {
        protected override void SelectDestination()
        {
            Console.WriteLine("Selecting destination for ArcherUnit");
            // Select destination for archer unit
        }

        protected override void CalculatePath()
        {
            Console.WriteLine("Calculating path for ArcherUnit");
            // Calculate path for archer unit
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Unit cavalry = new CavalryUnit();
            Unit archer = new ArcherUnit();

            cavalry.Move();
            archer.Move();
        }
    }
}
