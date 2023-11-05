﻿using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Models
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;
        public HotelRepository() 
        { 
            this.hotels= new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => this.hotels.AsReadOnly();
       

        public IHotel Select(string criteria)
        {
           return All().FirstOrDefault(h=>h.FullName == criteria);
        }
    }
}
