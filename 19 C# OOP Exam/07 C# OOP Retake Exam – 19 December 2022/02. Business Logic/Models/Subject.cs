using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int subjectId;
        private string subjectName;
        private double subjectRate;
        public Subject(int subjectId, string subjectName, double subjectRate)
        { 
            this.Id=subjectId;
            this.Name=subjectName;
            this.Rate = subjectRate;
        }
        public int Id { get => subjectId;private set => subjectId = value; }

        public string Name
        {
            get => subjectName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));

                subjectName = value;
            }
        }

        public double Rate { get => subjectRate; private set => subjectRate = value; }
    }
}
