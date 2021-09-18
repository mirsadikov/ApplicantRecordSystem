using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightJob.DAL
{
    public class ApplicantList
    {
        public List<Applicant> GetAllApplicants()
        {
            return new ApplicantManager().GetAll();
        }

        public List<Applicant> Sort(ByAttribute attribute)
        {
            switch (attribute)
            {
                // Sorting logics
                case ByAttribute.Name:
                    return GetAllApplicants().OrderBy(a => a.Name).ToList();
                case ByAttribute.ScoreAscending:
                    return GetAllApplicants().OrderBy(a => a.Score).ToList();
                case ByAttribute.ScoreDescending:
                    return GetAllApplicants().OrderByDescending(a => a.Score).ToList();
            }

            return null;
        }


        public List<Applicant> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {
                // Searching logics
                case ByAttribute.Id:
                    return GetAllApplicants().Where(a => a.Id.ToString().Contains(value)).ToList();
                case ByAttribute.Name:
                    return GetAllApplicants().Where(a => a.Name.ToLower().Contains(value.ToLower())).ToList();
                case ByAttribute.Score:
                    return GetAllApplicants().Where(a => a.Score.ToString().Contains(value)).ToList();
                case ByAttribute.TestsTaken:
                    return GetAllApplicants().Where(a => a.TestsTaken.ToLower().Contains(value.ToLower())).ToList();
            }

            return null;
        }

    }
}
