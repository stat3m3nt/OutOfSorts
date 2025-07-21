///<summary>
///I, Andrew Evboifo, 000909727 certify that this material is my original work. No other person's work has been used without due acknowledgement.
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace OutOfSorts
{
    /// <summary>
    /// Class represents a single employee
    /// </summary>
    internal class Employee
    {
        private string name;
        private int number;
        private decimal rate;
        private double hours;

        /// <summary>
        /// Employee constructor
        /// </summary>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        ///<summary>
        ///Getter method to get hours
        /// </summary>
        public double GetHours() { return hours; }

        ///<summary>
        ///Getter method to get name
        /// </summary>
        public string GetName() { return name; }

        ///<summary>
        ///Getter method to get number
        /// </summary>
        public int GetNumber() { return number; }

        ///<summary>
        ///Getter method to get rate
        /// </summary>
        public decimal GetRate() { return rate; }

        ///<summary>
        ///Getter method to get gross pay
        /// </summary>
        public decimal GetGross()
        {
            if (hours <= 40)
            {
                return rate * (decimal)hours;// formula to calculate gross pay without overtime
            }
            else
            {
                return (rate * (decimal)hours) + (decimal)(hours - 40) * (1.5m * rate); //formula to calculate gross pay including overtime
            }
        }

        public override string ToString()
        {
            return $"{name,-20} {number,10} {rate,8:C} {hours,6:F2} {GetGross(),20:C}";
        }

        ///<summary>
        ///Setter method for hours
        /// </summary>
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        ///<summary>
        ///Setter method for name
        /// </summary>
        public void SetName(string name)
        {
            this.name = name;
        }

        ///<summary>
        ///Setter method for number
        /// </summary>
        public void SetNumber(int number)
        {
            this.number = number;
        }

        ///<summary>
        ///Setter method for rate
        /// </summary>
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }

    }
}

   
