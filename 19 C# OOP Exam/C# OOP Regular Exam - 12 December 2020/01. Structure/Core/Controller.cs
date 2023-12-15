using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalSum;
        public Controller()
        {
            this.bakedFoods=new List<IBakedFood>();
            this.drinks=new List<IDrink>();
            this.tables=new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood baked ;
            if (type == nameof(Bread))
            {
                baked=new Bread(name, price);
            }
            else if(type==nameof(Cake)) 
            {
                baked=new Cake(name,price); 
            }
            else
            {
                return null;
            }

            this.bakedFoods.Add(baked);

            return string.Format(OutputMessages.FoodAdded, name,type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;
            if(type == nameof(Water))
            {
                drink=new Water(name, portion,brand);
            }
            else if (type == nameof(Tea))
            {
                drink=new Tea(name, portion,brand); 
            }
            else
            {
                return null;
            }
          
            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }


        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            if (type == nameof(InsideTable))
            {
                table=new InsideTable(tableNumber, capacity);
            }
            else if(type==nameof(OutsideTable))
            {
                table=new OutsideTable(tableNumber, capacity);
            }
            else
            {
                return null;
            }

            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded,tableNumber);
        }
        public string ReserveTable(int numberOfPeople)
        {
            var table =this.tables.FirstOrDefault(t=>t.Capacity>=numberOfPeople&&t.IsReserved==false);
            if(table == null)
                return string.Format(OutputMessages.ReservationNotPossible,numberOfPeople);

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved,table.TableNumber,numberOfPeople);
        }
        public string OrderFood(int tableNumber, string foodName)
        {
            var table=this.tables.FirstOrDefault(t=>t.TableNumber==tableNumber);    
            if(table == null)
                return string.Format(OutputMessages.WrongTableNumber,tableNumber);

            var food=this.bakedFoods.FirstOrDefault(f=>f.Name==foodName);
            if(food==null)
                return string.Format(OutputMessages.NonExistentFood,foodName);

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful,tableNumber,foodName);
        }
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            var drink=this.drinks.FirstOrDefault(d=>d.Name==drinkName&&d.Brand==drinkBrand);

            if(drink==null)
                return string.Format(OutputMessages.NonExistentDrink,drinkName,drinkBrand);

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }
        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.Price + table.GetBill();
            this.totalSum += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables=this.tables.Where(t=>t.IsReserved==false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo() );
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            

            return string.Format(OutputMessages.TotalIncome,totalSum);

        }




    }
}
