using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int studentId;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;
        public Student(int studentId, string firstName, string lastName)
        {
            this.Id=studentId;
            this.FirstName=firstName;
            this.LastName=lastName;
            this.coveredExams = new List<int>();
        }
        public int Id { get=>studentId;private set=>studentId = value; }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string .Format(ExceptionMessages.NameNullOrWhitespace));

                firstName =value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));

                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => this.coveredExams.AsReadOnly();

        public IUniversity University => this.university;

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
