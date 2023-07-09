using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        public interface IDepartmentMediator
        {
            void RegisterUser(User user);
            void SendAcknowledgement(string mssg, User user);
            void SendMultipleAcknowledgement(string mssg, User user);
        }

        public class DepartmentroupMediator : IDepartmentMediator
        {
            private List<User> _usersList = new List<User>();

            public void RegisterUser(User user)
            {
                _usersList.Add(user);
            }

            public void SendAcknowledgement(string mssg, User user)
            {
                if (!user.IsExaminer)
                {
                    var examiner = _usersList.Find(j => j.IsExaminer == true);
                    examiner.Receive(mssg, user);
                }
                else
                {
                    user.Receive(mssg, user);
                }
            }

            public void SendMultipleAcknowledgement(string message, User user)
            {
                foreach (var person in _usersList)
                {
                    if (person.Department == user.Department && !person.IsExaminer)
                    {
                        person.Receive(message, person);
                    }
                }
            }

        }

        public abstract class User
        {
            protected IDepartmentMediator _mediator;

            public bool IsExaminer;
            public string Name { get; set; }
            public string Department { get; set; }

            public User(IDepartmentMediator mediator,
                        string name,
                        string department,
                        bool isExaminer)
            {
                _mediator = mediator;
                Name = name;
                IsExaminer = isExaminer;
                Department = department;
            }

            public abstract void SendAcknowledgement(string message, User user);
            public abstract void SendNoticeToStudents(string message, User user);
            public abstract void Receive(string message, User user);
            public abstract void RegisterSubjects(string[] subject, User user);
        }

        public class SchoolMember : User
        {
            public SchoolMember(IDepartmentMediator mediator,
                                string name,
                                string department,
                                bool isExaminer) : base(mediator, name, department, isExaminer)
            {
            }
            public override void Receive(string message, User user)
            {
                Console.WriteLine(user?.Name + ": Received Message: " + message);
            }

            public override void RegisterSubjects(string[] subject, User user)
            {
                Console.WriteLine(this.Name + ": Submitting Subjects: " + subject.Length +
                    " subjects submitted to the department of " + this.Department + "\n");

                var message = subject.Length + " subjects submitted by " + this.Name +
                    " and received by " + user.Name;
                _mediator.SendAcknowledgement(message, user);
            }

            public override void SendAcknowledgement(string message, User user)
            {
                Console.WriteLine(this.Name + ": Sending Message: " + message + "\n");
                _mediator.SendAcknowledgement(message, user);
            }

            public override void SendNoticeToStudents(string message, User user)
            {
                Console.WriteLine(this.Name + ": Sending Message: " + message + "\n");
                _mediator.SendMultipleAcknowledgement(message, user);
            }
        }

        static void Main(string[] args)
        {
            DepartmentroupMediator departmentMediator = new DepartmentroupMediator();
            //Instantiate students
            User Student1 = new SchoolMember(departmentMediator, "Bob", "Computer", false);
            User Student2 = new SchoolMember(departmentMediator, "Mary", "Mechanics", false);
            User Student3 = new SchoolMember(departmentMediator, "Frank", "Mechanics", false);

            //Instantiate Examiners
            User Examinar1 = new SchoolMember(departmentMediator, "Philip", "Computer", true);
            User Examinar2 = new SchoolMember(departmentMediator, "Sarah", "Mechanics", true);

            departmentMediator.RegisterUser(Student1);
            departmentMediator.RegisterUser(Student2);
            departmentMediator.RegisterUser(Student3);
            departmentMediator.RegisterUser(Examinar1);
            departmentMediator.RegisterUser(Examinar2);

            Student1.SendAcknowledgement("Hello sir, I would like to register my class subjects today", Examinar1);
            Console.WriteLine();
            Examinar2.SendNoticeToStudents("June 30th is the deadline to submit all class subjects. ", Examinar2);
            Console.WriteLine();
            Examinar1.SendAcknowledgement("Go ahead, its about time you did.", Student1);
            Student3.SendAcknowledgement("Alright Ma. I'll be submitting mine right away", Examinar2);

            //list of subjects to register
            string[] computerSubjects = { "Java", "C#", "Phython", "MS Sql" };
            Student1.RegisterSubjects(computerSubjects, Examinar1);
            string[] mechanicSubjects = { "English", "CAD", "Mathematics" };
            Student3.RegisterSubjects(mechanicSubjects, Examinar2);
        }
    }
}
