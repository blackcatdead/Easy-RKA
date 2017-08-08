using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_RKA
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        public DBConnect(string h, string u, string p)
        {
            Initialize(h,u,p);
        }

        //Initialize values
        private void Initialize()
        {
            server = Properties.Settings.Default.host;
            database = "easyrka";
            uid = Properties.Settings.Default.user;
            password = Properties.Settings.Default.password;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Convert Zero Datetime=True";

            connection = new MySqlConnection(connectionString);
        }

        private void Initialize(string h, string u, string p)
        {
            server = h;
            database = "easyrka";
            uid = u;
            password = p;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }



        public void TestConnection() 
        {
            if (this.OpenConnection())
            {
                MessageBox.Show("Connected to database.");
                
            }
            else 
            {
                MessageBox.Show("Can not be connected to database.");
            }
            this.CloseConnection();
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally 
            {
                connection.Close();
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO `easyrka`.`user` (`username`, `password`, `name`, `role`, `timestamp`, `user_status`) VALUES ('admin', 'admin', 'Rakhmad Ikhsan', '1', '2017-06-06 21:59:52', '1');";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }



        public void addUser(User usr) 
        {
            string query = "INSERT INTO `easyrka`.`user` (`username`, `password`, `name`, `role`, `user_status`) VALUES ('" +
                usr.username + "', '" +
                usr.password + "', '" +
                usr.name + "', '" +
                usr.role + "', '" +
                usr.user_status + "');";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }
        public bool addRekening(Rekening rek)
        {
            bool result = false;
            string query = "INSERT INTO `easyrka`.`rekening` (`d1`, `d2`, `d3`, `d4`, `d5`, `rekening`, `status`) VALUES ('" +
                rek.d1 + "', '" +
                rek.d2 + "', '" +
                rek.d3 + "', '" +
                rek.d4 + "', '" +
                rek.d5 + "', '" +
                rek.rekening + "', '" +
                rek.status + "');";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    result= true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }

        public bool addT_urusan(T_urusan rek)
        {
            bool result = false;
            string query = "INSERT INTO `easyrka`.`t_urusan` (`id_urusan`, `id_parent`, `urusan`, `status`) VALUES ('" +
                rek.id_urusan + "', '" +
                rek.id_parent + "', '" +
                rek.urusan + "', '" +
                rek.status + "');";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message + " (" + query + ")");
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }

        public bool addT_rekening(T_rekening rek)
        {
            bool result = false;
            string query = "INSERT INTO `easyrka`.`t_rekening` (`id_rekening`, `id_parent`, `rekening`, `status`) VALUES ('" +
                rek.id_rekening + "', '" +
                rek.id_parent + "', '" +
                rek.rekening + "', '" +
                rek.status + "');";
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message + " (" + query + ")");
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }


        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UbahUser(String id_user, User user) 
        {
            string query = "UPDATE `easyrka`.`user` SET `username`='"+
                user.username+"', `password`='" +
                user.password+"', `name`='" +
                user.name+"', `role`='" +
                user.role+"', `user_status`='" +
                user.user_status+"' WHERE  `id_user`=" +
                id_user + ";";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        public bool UbahRekening(Rekening rek)
        {
            bool result = false;
            string query = "UPDATE `easyrka`.`rekening` SET"
                + " `rekening`='" + rek.rekening + "', "
                + " `status`=" + rek.status 
                + " WHERE `d1`=" + rek.d1 + " AND `d2`=" + rek.d2 + " AND `d3`=" + rek.d3 + " AND `d4`=" + rek.d4 + " AND `d5`=" + rek.d5 + " ;";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    result = false;
                    Console.WriteLine(query);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }

            return result;
        }


        public bool ubahT_rekening(string id_rekening, T_rekening rek)
        {
            bool result = false;
            string query = "UPDATE `easyrka`.`t_rekening` SET"
                + " `id_parent`='" + rek.id_parent + "', "
                + " `rekening`='" + rek.rekening + "', "
                + " `status`=" + rek.status
                + " WHERE `id_rekening`='" + id_rekening + "' ";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    result = false;
                    Console.WriteLine(query);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }

            return result;
        }

        public bool ubahT_urusan(string id_urusan, T_urusan rek)
        {
            bool result = false;
            string query = "UPDATE `easyrka`.`t_urusan` SET"
                + " `id_parent`='" + rek.id_parent + "', "
                + " `urusan`='" + rek.urusan + "', "
                + " `status`=" + rek.status
                + " WHERE `id_urusan`='" + id_urusan + "' ";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    result = false;
                    Console.WriteLine(query);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }

            return result;
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void HapusUser(string id_user) 
        {
            string query = "DELETE FROM user WHERE id_user='"+id_user+"'";

            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        public bool HapusRekening(Rekening r)
        {
            bool result = false;
            string query = "DELETE FROM rekening WHERE d1='" + r.d1 + "' AND "
                +"d2='" + r.d2 + "' AND "
                +"d3='" + r.d3 + "' AND "
                +"d4='" + r.d4 + "' AND "
                +"d5='" + r.d5 + "'"
                ;

            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }

        public bool HapusT_rekening(T_rekening r)
        {
            bool result = false;
            string query = "DELETE FROM t_rekening WHERE id_rekening='" + r.id_rekening + "' AND "
                + "id_parent='" + r.id_parent + "' AND "
                + "rekening='" + r.rekening + "' AND "
                + "status='" + r.status + "'"
                ;

            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }
        public bool HapusT_urusan(T_urusan r)
        {
            bool result = false;
            string query = "DELETE FROM t_urusan WHERE id_urusan='" + r.id_urusan + "' AND "
                + "id_parent='" + r.id_parent + "' AND "
                + "urusan='" + r.urusan + "' AND "
                + "status='" + r.status + "'"
                ;

            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    result = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return result;
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public User Login(string username, string password) 
        {
            string query = "select * from user where user.username = '" + username + "' and user.password = '" + password + "' and user.user_status=1";
            User user = new User();
            user = null;
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    User usr = new User();
                    usr.id_user = dataReader["id_user"] + "";
                    usr.username = dataReader["username"] + "";
                    usr.password = dataReader["password"] + "";
                    usr.name = dataReader["name"] + "";
                    usr.role = dataReader["role"] + "";
                    usr.timestamp = dataReader["timestamp"] + "";
                    usr.user_status = dataReader["user_status"] + "";
                    user = usr;
                }
                return user;
            }
            else
            {
                return user;
            }
        }

        public List<User> SelectAllUser()
        {
            string query = "SELECT * FROM User";

            //Create a list to store the result
            List<User> list = new List<User>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    User user = new User();
                    user.id_user = dataReader["id_user"] + "";
                    user.username = dataReader["username"] + "";
                    user.password = dataReader["password"] + "";
                    user.name = dataReader["name"] + "";
                    user.role = dataReader["role"] + "";
                    user.timestamp = dataReader["timestamp"] + "";
                    user.user_status = dataReader["user_status"] + "";
                    list.Add(user);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public DataTable Data_T_rekening()
        {

            DataTable _acountsTb = new DataTable();
            _acountsTb.Clear();
            MySqlDataAdapter _da = new MySqlDataAdapter();
            string query = "SELECT * FROM t_rekening";

            //Create a list to store the result
            List<T_rekening> list = new List<T_rekening>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                _da = new MySqlDataAdapter(cmd);
                _da.Fill(_acountsTb);

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return _acountsTb;
            }
            else
            {
                return _acountsTb;
            }
        }

        public DataTable Data_T_urusan()
        {

            DataTable _acountsTb = new DataTable();
            _acountsTb.Clear();
            MySqlDataAdapter _da = new MySqlDataAdapter();
            string query = "SELECT * FROM t_urusan";

            //Create a list to store the result
            List<T_rekening> list = new List<T_rekening>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                _da = new MySqlDataAdapter(cmd);
                _da.Fill(_acountsTb);

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return _acountsTb;
            }
            else
            {
                return _acountsTb;
            }
        }

        public List<Rekening> SelectAllRekening()
        {
            string query = "SELECT * FROM Rekening";

            //Create a list to store the result
            List<Rekening> list = new List<Rekening>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Rekening rek = new Rekening();
                    rek.d1 = dataReader["d1"] + "";
                    rek.d2 = dataReader["d2"] + "";
                    rek.d3 = dataReader["d3"] + "";
                    rek.d4 = dataReader["d4"] + "";
                    rek.d5 = dataReader["d5"] + "";
                    rek.rekening = dataReader["rekening"] + "";
                    rek.timestamp = dataReader["timestamp"] + "";
                    rek.status = dataReader["status"] + "";
                    list.Add(rek);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }


}
