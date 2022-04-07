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
    internal class DataAccessObject
    {
        static string DBConnectionString = "DataSource = 127.0.0.1;port = 3306; username=root; password=;database=company";
        static MySqlConnection connection = new MySqlConnection(DBConnectionString);

        /// exist
       
        public  bool WorkerExist(Worker worker)
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
        public bool WorkerExist(int workerID)
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.name, worker.salary, position.id FROM worker, position WHERE worker.pos_id = position.id AND worker.id=" + workerID + ";";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    return true;
                }
                return false;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
                return false;
            }
        }

        public bool DepartmentExist(Department department)
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
        public bool DepartmentExist(string depName)
        {
            try
            {
                connection.Open();

                String sql = "SELECT department.tytle  FROM department WHERE department.title= '" + depName + "' ;";

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
        
        ///

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
        public Worker GetWorker(int ID)
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.name, worker.age,  worker.salary, position.id  FROM worker, position WHERE worker.pos_id = position.id AND worker.id= "+ID;

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Worker worker = null;
                while (reader.Read())
                {

                    worker = new FixedWorker(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2));
                    return worker;

                    //if (reader.GetInt32(3)==1)
                    //{
                    //    worker = new FixedWorker(reader.GetString(0),reader.GetInt32(1),reader.GetDouble(2));
                    //    return worker;
                    //}
                    //else if (reader.GetInt32(3)==2)
                    //{
                    //    worker = new HourlyWorker(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2),);
                    //}
                    //Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));

                }
               
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }
            return null;
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

        public void UpdateWorker(int ID, Worker worker)
        {
            try
            {
                if (WorkerExist(ID))
                {
                    connection.Open();
                    String sql = "UPDATE worker SET worker.name = '" + worker.Name + "', worker.age =" + worker.Age + ", worker.salary = "+ worker.CalculateSalary()+" WHERE worker.id =" + ID + "; ";
                    
                        MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                    connection.Close();
                }

            }
            catch (Exception ex)
            { Console.WriteLine("Error: " + ex); }

        }

        public void DeleteWorker(int workerId)
        {
            try
            {
                if (WorkerExist(workerId)) { 
                connection.Open();
                String sql = "DELETE FROM  worker WHERE worker.id = '" + workerId + "';";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
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

        public void GetTrainees()
        {
            try
            {
                connection.Open();

                String sql = "SELECT w2.name AS employee, w1.name AS teamLead FROM worker w1 INNER JOIN worker w2 ON w1.id = w2.parent_id GROUP BY w2.name";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1}", reader.GetString(0), reader.GetString(1));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }
        }

        public void GetWorkersTotalCartPrice()
        {
            try
            {
                connection.Open();

                String sql = "SELECT worker.id, worker.name,position.title, department.title,(product.price*buyitem_id.quantity) AS totalprice " +
                    "FROM shopping_cart " +
                    "INNER JOIN worker " +
                    "ON shopping_cart.worker_id=worker.id " +
                    "INNER JOIN position " +
                    "ON worker.pos_id = position.id " +
                    "INNER JOIN department " +
                    "ON worker.dep_id= department.id " +
                    "INNER JOIN buyitem_id " +
                    "ON shopping_cart.buyitem_id=buyitem_id.id " +
                    "INNER join product " +
                    "ON buyitem_id.product_id=product.id " +
                    "GROUP BY worker.name " +
                    "ORDER BY `totalprice`;";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} , {1} - {2}, {3} - {4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDouble(4));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }
        }

        public void GetMentorTraineesInfo(Worker mentor)
        {
            try
            {
                connection.Open();

                String sql = "SELECT w1.name, w1.age, position.title FROM worker AS w1 INNER JOIN worker AS w2 ON w1.id = w2.parent_id INNER JOIN position ON w1.pos_id = position.id HAVING w1.name IN('" + mentor.Name +"')";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1} , {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }

            

        }

        public void GetCatCountByDep()
        {
            try
            {
                connection.Open();

                String sql = "SELECT department.title, category.title,COUNT(category.id) AS count FROM department " +
                    "INNER JOIN worker ON worker.dep_id = department.id" +
                    "INNER JOIN workerorders" +
                    "ON  worker.id = workerorders.worker_id" +
                    "INNER JOIN product" +
                    "ON workerorders.product_id = product.id" +
                    "INNER JOIN category" +
                    "ON product.cat_id = category.id" +
                    "GROUP BY category.title";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1}, {2}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
            }
        }


        



    }
}
