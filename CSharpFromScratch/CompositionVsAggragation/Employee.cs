using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionVsAggragation
{
    public class Employee
    {
        public string name { get; set; }

        public AddressInfo Address { get; set; }

        public InsuranceInfo Insurance { get; set; }


        public Employee()
        {

        }

        public Employee(string name, string street, string city, string state, string zipcode)
        {
            this.name = name;
            Address = new AddressInfo() 
            {
                city = city,
                state = state,
                street = street,
                zipcode = zipcode
            };
  
        }

        public override string ToString()
        {
            string retVal = string.Format("{0},{1},{2},{3},{4}", name, Address.city, Address.state, Address.state, Address.zipcode);

            if (Insurance != null)
            {
                retVal += string.Format("{0},{1}", Insurance.policyid, Insurance.policyname);
            }

            return retVal;
        }

    }
}
