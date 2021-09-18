using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightJob.DAL
{
    public class Test
    {
        private string name;
        private string q1;
        private string q1_answer;
        private string q2;
        private string q2_answer;
        private string q3;
        private string q3_answer;

        public int Id { get; set; }

        /// Validation 
        public string Name
        {
            get => name; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Name cannot be empty");
                name = value;
            }
        }
        public string Q1
        {
            get => q1; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question cannot be empty");
                q1 = value;
            }
        }
        public string Q1_answer
        {
            get => q1_answer; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question answer cannot be empty");
                q1_answer = value;
            }
        }
        public string Q2
        {
            get => q2; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question cannot be empty");
                q2 = value;
            }
        }
        public string Q2_answer
        {
            get => q2_answer; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question answer cannot be empty");
                q2_answer = value;
            }
        }
        public string Q3
        {
            get => q3; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question cannot be empty");
                q3 = value;
            }
        }
        public string Q3_answer
        {
            get => q3_answer; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Question answer cannot be empty");
                q3_answer = value;
            }
        }

        public Test()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
