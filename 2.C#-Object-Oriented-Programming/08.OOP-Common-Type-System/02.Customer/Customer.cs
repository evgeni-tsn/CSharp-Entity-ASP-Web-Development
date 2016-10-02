using System;
using System.Collections.Generic;

namespace _02.Customer
{
    public class Customer: IComparable, IEquatable<Customer>, ICloneable
    {
        /*Define a class Customer, which contains data about a customer – first name, 
        middle name and last name, ID (EGN), permanent address, mobile phone, e-mail, 
        list of payments and customer type. */

        public Customer(string firstName, string middleName, string lastName, string id, string permanentAddress, string mobilePhone, string email)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
        }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string PermanentAddress { get; }
        public string MobilePhone { get; }
        public string Email { get; }
        

        public bool Equals(Customer other)
        {
            return string.Equals(this.FirstName, other.FirstName)
                   && string.Equals(this.MiddleName, other.MiddleName)
                   && string.Equals(this.LastName, other.LastName)
                   && string.Equals(this.Id, other.Id)
                   && string.Equals(this.PermanentAddress, other.PermanentAddress)
                   && string.Equals(this.MobilePhone, other.MobilePhone)
                   && string.Equals(this.Email, other.Email);
////                && Equals(this.Payments, other.Payments) 
////                && Equals(this.CustomerTypes, other.CustomerTypes);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.FirstName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (this.MiddleName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.LastName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.Id?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.PermanentAddress?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.MobilePhone?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (this.Email?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public int CompareTo(object obj)
        {
            var other = obj as Customer;
            string first = string.Format($"{this.FirstName} {this.LastName}");
            string second = string.Format($"{other.FirstName} {other.LastName}");

            if (first == second)
            {
                return string.Compare(this.Id, other.Id);
            }
            return string.Compare(first, second);
        }

        public object Clone()
        {
            var clone = new Customer(this.FirstName,this.MiddleName,this.LastName,this.Id,this.PermanentAddress,this.MobilePhone,this.Email);
            return clone;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer)obj);
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {MiddleName} {LastName} - {PermanentAddress} - {Id}");
        }
    }
}