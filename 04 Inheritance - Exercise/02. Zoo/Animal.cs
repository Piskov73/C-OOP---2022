﻿namespace Zoo
{
    public class Animal
    {
		private string name;
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
