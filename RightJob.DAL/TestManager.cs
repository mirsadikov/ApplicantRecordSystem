using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;


namespace RightJob.DAL
{
    public class TestManager : DbManager
    {
        public void Create(Test t)
        {
            var connection = Connection;
            try
            {
                // create test
                var sql = $@"INSERT INTO ts_test_12860 
(ts_name_12860, 
ts_q1_12860, 
ts_q1_answer_12860, 
ts_q2_12860, 
ts_q2_answer_12860, 
ts_q3_12860, 
ts_q3_answer_12860)
     VALUES
('{t.Name}',
'{t.Q1}', 
'{t.Q1_answer}', 
'{t.Q2}', 
'{t.Q2_answer}', 
'{t.Q3}', 
'{t.Q3_answer}')";
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

        public void Update(Test t)
        {
            // update test
            var connection = Connection;
            try
            {
                var sql = $@"
UPDATE ts_test_12860 
SET    ts_name_12860 = '{t.Name}', 
       ts_q1_12860 = '{t.Q1}', 
       ts_q1_answer_12860 = '{t.Q1_answer}', 
       ts_q2_12860 = '{t.Q2}', 
       ts_q2_answer_12860 = '{t.Q2_answer}', 
       ts_q3_12860 = '{t.Q3}', 
       ts_q3_answer_12860 = '{t.Q3_answer}'
WHERE ts_id_12860={t.Id}";
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

        public void Delete(int id) {
            //Delete test
            var connection = Connection;
            try
            {
                var sql = $@"DELETE FROM ts_test_12860 WHERE ts_id_12860 = {id}";
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

        public Test GetById(int id) { // get test by given id
            var connection = Connection;
            try
            {
                var sql = $@"
SELECT ts_id_12860,
       ts_name_12860,
       ts_q1_12860,
       ts_q1_answer_12860,
       ts_q2_12860,
       ts_q2_answer_12860,
       ts_q3_12860,
       ts_q3_answer_12860
FROM ts_test_12860
WHERE ts_id_12860 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var t = GetFromReader(reader);
                    return t;
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

        public List<Test> GetAll() // get all tests 
        {
            var connection = Connection;
            var result = new List<Test>();
            try
            {
                var sql = @"
SELECT ts_id_12860,
       ts_name_12860,
       ts_q1_12860,
       ts_q1_answer_12860,
       ts_q2_12860,
       ts_q2_answer_12860,
       ts_q3_12860,
       ts_q3_answer_12860
FROM ts_test_12860";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var t = GetFromReader(reader);
                    result.Add(t);
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

        private Test GetFromReader(SqlCeDataReader reader)
        {
            var t = new Test
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                Q1= reader.GetValue(2).ToString(),
                Q1_answer= reader.GetValue(3).ToString(),
                Q2 = reader.GetValue(4).ToString(),
                Q2_answer = reader.GetValue(5).ToString(),
                Q3 = reader.GetValue(6).ToString(),
                Q3_answer = reader.GetValue(7).ToString(),
            };
            return t;
        }




        // This function takes comma separated names of tests as an argument, then returns comma separated ids of tests
        public string GetIdsByNames(string Names) { 
            string[] TestsTakenNames = Names.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            List<string> TestTakenIds = new List<string>();
            foreach (string name in TestsTakenNames)
            {
                var connection = Connection;
                try
                {
                    var sql = $@"
SELECT ts_id_12860
  FROM ts_test_12860
 WHERE ts_name_12860 = '{name}'";
                    var command = new SqlCeCommand(sql, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader.GetValue(0).ToString();
                        TestTakenIds.Add(id);
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
            }

            return String.Join(", ", TestTakenIds);
        }


        // This function takes comma separated ids of tests as an argument, then returns comma separated names of tests
        public string GetNamesByIds(string Ids)
        {
            string[] TestsTakenIds = Ids.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
            List<string> TestsTakenNames = new List<string>();
            foreach (string id in TestsTakenIds)
            {
                var _id = Convert.ToInt32(id);
                var TestManager = new TestManager();
                string testName = TestManager.GetById(_id)!=null ? TestManager.GetById(_id).Name : null;
                if (testName!=null)
                    TestsTakenNames.Add(testName);

            }
            return string.Join(", ", TestsTakenNames);
        }
    }
}
