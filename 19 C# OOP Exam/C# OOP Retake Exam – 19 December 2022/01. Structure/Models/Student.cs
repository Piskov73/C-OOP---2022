using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;
        public Student(int studentId, string firstName, string lastName)
        {
            this.Id= studentId;
            this.FirstName= firstName;
            this.LastName= lastName;
            this.coveredExams= new List<int>();
        }

        public int Id { get => id; private set => id = value; }


        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                lastName = value;
            }
        }



        public IReadOnlyCollection<int> CoveredExams => this.coveredExams.AsReadOnly();

        public IUniversity University { get => university;private set =>university= value; }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.university=university;
        }
    }
}
