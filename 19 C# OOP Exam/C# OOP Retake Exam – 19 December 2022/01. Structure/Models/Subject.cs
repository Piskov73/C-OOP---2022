using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;
        public Subject(int subjectId, string subjectName, double subjectRate)
        { 
            this.Id = subjectId;
            this.Name = subjectName;
            this.Rate = subjectRate;

        }
        public int Id { get =>id;private set => id = value; }

        public string Name
        {
            get { return name; }
           private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }


        public double Rate { get => rate;private set=> rate = value; }
    }
}
