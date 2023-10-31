﻿using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;
        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            this.Id=universityId;
            this.Name=universityName;
            this.Category=category;
            this.Capacity=capacity;
            this.requiredSubjects = new List<int>(requiredSubjects);
        }

        public int Id { get => id; private set => id = value; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }
      


        public string Category
        {
            get { return category; }
            private set
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }


        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityNegative));
                }
                capacity = value;
            }
        }



        public IReadOnlyCollection<int> RequiredSubjects => this.requiredSubjects.AsReadOnly();
    }
}
