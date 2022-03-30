using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace WorkersControl
{
    internal class DatabaseOptions
    {
        static string DBConnectionString = "DataSource = 127.0.0.1;port = 3306; username=root; password=;database=company";
        static MySqlConnection connection = new MySqlConnection(DBConnectionString);


        public static bool WorkerExist(Worker worker)
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.name, worker.salary, position.id FROM worker, position WHERE worker.pos_id = position.id AND worker.name= '" + worker.Name + "', position.id = '" +worker.pos_id + "' , worker.id=" +worker.worker_id +";";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    return true;
                return false;
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
                return false;
            }
        }

        public static bool DepartmentExist(Department department)
        {
            try
            {
                connection.Open();

                String sql = "SELECT department.tytle  FROM department WHERE department.title= '" + department.DepartmentName + "' ;";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                { 
                    connection.Close();
                    return true;
                }
                else { 
                    connection.Close();
                    return false;
                }
                
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
                return false;
            }
        }

        public bool MentorExist(Mentor mentor)
        {
            try
            {
                connection.Open();

                String sql = "SELECT mentor.name  FROM mentor WHERE mentor.name= '" + mentor.Name +"' AND mentor.id = "+ mentor.Mentor_Id +" ;";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
                return false;
            }
        }


        public void AddWorkerToDB(Worker worker)
        {
            try
            {
                if (!WorkerExist(worker))
                {
                    connection.Open();
                    String sql = "INSERT INTO worker (name, age, salary, pos_id, dep_id) " +
                        "values('" + worker.Name + "', " + worker.Age + ", " + worker.Rate + "," + worker.CalculateSalary() + ", " + worker.pos_id + ", " + worker.dep_id + " );";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    //MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    command.ExecuteNonQuery();


                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Worker already exist.");
                }

            
            }
            catch (Exception ex) {
                Console.WriteLine("Query error: "+ex);
            };

        }


        public void GetAllWorkers()
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.name, worker.salary, position.title FROM worker, position WHERE worker.pos_id = position.id";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }

        }


        public void GetWorker(string name)
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.name, worker.salary, position.title FROM worker, position WHERE worker.pos_id = position.id AND worker.name="+name;

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }

        }

        public void AddToDepartment(Department department, Worker worker)
        {
            try
            {
                if(WorkerExist(worker))
                {
                    connection.Open();
                    String sql = "UPDATE worker SET worker.dep_id = "+department.depIndx+" WHERE worker.name = '"+worker.Name+"' AND worker.id= "+ worker.worker_id+";";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                    connection.Close();
                }

            }
            catch(Exception ex)
            { Console.WriteLine("Error: "+ ex);}
        }

        public void DeleteWorker(Worker worker)
        {
            try
            {
                if (WorkerExist(worker))
                {
                    connection.Open();
                    String sql = "DELETE FROM  worker WHERE worker.name = '" + worker.Name + "';";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Worker not found.");
                }
            }
            catch(Exception ex)
            { Console.WriteLine("Error: "+ ex); }

        }


        public void AddDepartment(Department department) 
        {
            try
            {
                if (!DepartmentExist(department))
                {
                    connection.Open();
                    String sql = "INSERT INTO department (id, title)  values (" + department.depIndx + ", '" + department.DepartmentName + "' );";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Worker already exist.");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            };
        }

        public void AddMentor(Mentor mentor)
        {
            try
            {
                if (!MentorExist(mentor))
                {
                    connection.Open();
                    String sql = "INSERT INTO mentor (id, name)  values (" + mentor.Mentor_Id + ", '" + mentor.Name + "' );";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Worker already exist.");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            };


        }

        public void UpdateWorkerMentor(Mentor mentor,Worker worker)
        {
            try
            {
                if (WorkerExist(worker) && MentorExist(mentor))
                {
                    connection.Open();
                    String sql = "INSERT INTO workermentor(workerId, mentorId) values(" + worker.worker_id + ", " + mentor.Mentor_Id + " );";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                    connection.Close();
                }

            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex); }

        }



    }
}
