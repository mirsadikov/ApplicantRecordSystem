using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightJob.DAL
{
    public class TestList
    {
        public List<Test> GetAllTests()
        {
            return new TestManager().GetAll();
        }

        public List<Test> Sort(ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Name:
                    return GetAllTests().OrderBy(a => a.Name).ToList();  // Sorting by name
            }

            return null;
        }


        public List<Test> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Name:
                    return GetAllTests().Where(a => a.Name.ToLower().Contains(value.ToLower())).ToList();  // searching by name
            }

            return null;
        }
    }
}
