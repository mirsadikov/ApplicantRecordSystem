using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightJob.DAL
{
    public class ApplicantManager : DbManager
    {
        public void Create(Applicant a)
        {
            var connection = Connection;
            try
            {
                // Creating applicant
                var sql = $@"INSERT INTO ap_applicant_12860 
(ap_name_12860,
ap_score_12860,
ap_tests_taken_12860)
     VALUES
('{a.Name}',
'{a.Score}',
'{a.TestsTaken}')";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public void Update(Applicant a)
        {
            // Updating applicant
            var connection = Connection;
            try
            {
                var sql = $@"
UPDATE ap_applicant_12860
SET    ap_name_12860 = '{a.Name}', 
       ap_score_12860 = {a.Score}, 
       ap_tests_taken_12860 = '{a.TestsTaken}'
WHERE ap_id_12860 = {a.Id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public void Delete(int id)
        {
            // Deleting applicant
            var connection = Connection;
            try
            {
                var sql = $@"DELETE FROM ap_applicant_12860 WHERE ap_id_12860 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        
        public Applicant GetById(int id)
        {
            // Getting Applicant by id passed to function
            var connection = Connection;
            try
            {
                var sql = $@"
SELECT ap_id_12860,
       ap_name_12860,
       ap_score_12860,
       ap_tests_taken_12860
FROM ap_applicant_12860
WHERE ap_id_12860 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var a = GetFromReader(reader);
                    return a;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return null;
        }

        public List<Applicant> GetAll()
        {
            // Getting all applicants
            var connection = Connection;
            var result = new List<Applicant>();
            try
            {
                var sql = @"
SELECT ap_id_12860,
       ap_name_12860,
       ap_score_12860,
       ap_tests_taken_12860
FROM ap_applicant_12860";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var a = GetFromReader(reader); 
                    result.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            return result;
        }


        private Applicant GetFromReader(SqlCeDataReader reader) // Function to get info from reader
        {
            var idsOfTests = reader.GetValue(3).ToString(); // gets ids of tests applicant taken
            string TestTakenNames;
            if (string.IsNullOrWhiteSpace(idsOfTests))
            {
                TestTakenNames = ""; // if no tests id then value is empty string
            } else
            {
                TestTakenNames = new TestManager().GetNamesByIds(idsOfTests); // converts comma separated ids to comma separated Test names
            }
            var a = new Applicant
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                Score = Convert.ToInt32(reader.GetValue(2)),
                TestsTaken = TestTakenNames
            };
            return a;
        }
    }
}
