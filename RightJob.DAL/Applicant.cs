using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightJob.DAL
{
    public class Applicant
    {
        private string name;

        public Applicant()
        {
            // Default values upon creation
            Score = 0;
            TestsTaken = ""; // Ids of tests stored here not names
        }

        public int Id { get; set; }
        public string Name
        {
            get => name; set
            {
                //Name validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Applicant name cannot be empty");
                name = value;
            }
        }
        public int Score { get; set; }
        public string TestsTaken { get; set; }

    }
}
        