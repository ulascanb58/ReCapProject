using DataAccess.CoreLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class NCreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int Cvv { get; set; }
        public string CardType { get; set; }
        public int CardLimit { get; set; }
    }
}
