﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC2Toets2
{
    public abstract class Animal : IComparable<Animal>, ISellable
    {
        public int ChipRegistrationNumber { get; private set; }
        public SimpleDate DateOfBirth { get; private set; }
        public string Name { get; private set; }
        public bool IsReserved { get; set; }
        public abstract decimal Price { get; set; }



        public Animal(int chipRegistrationNumber, SimpleDate dateOfBirth, string name)
        {
            ChipRegistrationNumber = chipRegistrationNumber;
            DateOfBirth = dateOfBirth;
            Name = name;
            IsReserved = false;
        }

        public abstract decimal GetPrice();

        public int CompareTo(Animal compare)
        {
            int Value;
            if (ChipRegistrationNumber > compare.ChipRegistrationNumber)
                Value = 1;
            else
                if (ChipRegistrationNumber < compare.ChipRegistrationNumber)
                Value = -1;
            else
                Value = 0;
            return Value;
        }

        public override string ToString()
        {
            string IsReservedString = "not reserved";
            if (IsReserved)
            {
                IsReservedString = "reserved";
            }

            string info = ChipRegistrationNumber
                          + ", " + DateOfBirth
                          + ", " + Name
                          + ", " + IsReservedString
                          + ", " + Price;
            return info;
        }
    }
}