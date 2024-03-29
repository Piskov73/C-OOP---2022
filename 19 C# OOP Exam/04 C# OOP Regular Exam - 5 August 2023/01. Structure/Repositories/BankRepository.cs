﻿using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> models;
        public BankRepository() 
        { 
            this.models = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models => this.models.AsReadOnly();

        public void AddModel(IBank model)
        {
            this.models.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return this.models.FirstOrDefault(n => n.Name == name);
        }

        public bool RemoveModel(IBank model)
        {
           return this.models.Remove(model);
        }
    }
}
