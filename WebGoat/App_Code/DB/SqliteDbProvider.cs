using System;
using System.Data;
using Mono.Data.Sqlite;
using log4net;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class SqliteDbProvider : IDbProvider
    {
        private string _connectionString = string.Empty;
        private string _clientExec;
        private string _dbFileName;

        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Name { get { return DbConstants.DB_TYPE_SQLITE; } }

        public SqliteDbProvider(ConfigFile configFile)
        {
            _connectionString = string.Format("Data Source={0};Version=3", configFile.Get(DbConstants.KEY_FILE_NAME));

            _clientExec = configFile.Get(DbConstants.KEY_CLIENT_EXEC);
            _dbFileName = configFile.Get(DbConstants.KEY_FILE_NAME);

            if (!File.Exists(_dbFileName))
                SqliteConnection.CreateFile(_dbFileName);
        }

        public bool TestConnection()
        {   
            try
            {
                using (SqliteConnection conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                    
                        cmd.CommandText = "SELECT date('now')";
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteReader();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error testing DB", ex);
                return false;
            }
        }

        public DataSet GetCatalogData()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter("select * from Products", connection);
                DataSet ds = new DataSet();
            
                da.Fill(ds);
            
                return ds;
            }
        }

        public bool IsValidCustomerLogin(string email, string password)
        {
            //encode password
            string encoded_password = Encoder.Encode(password);
            
            //check email/password
            string sql = "select * from CustomerLogin where email = @Email and password = @Password;";
                        
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
            
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
                //TODO: User reader instead (for all calls)
da.SelectCommand.Parameters.AddWithValue("@Password", encoded_password);
                DataSet ds = new DataSet();
            
                da.Fill(ds);
                
                try
                {
                    return ds.Tables[0].Rows.Count == 0;
                }
                catch (Exception ex)
                {
                    //Log this and pass the ball along.
                    log.Error("Error checking login", ex);
                    
                    throw new Exception("Error checking login", ex);
                }
            }
        }

        public bool RecreateGoatDb()
        {
            try
            {
                log.Info("Running recreate");
                string args = string.Format("\"{0}\"", _dbFileName);
                string script = Path.Combine(Settings.RootDir, DbConstants.DB_CREATE_SQLITE_SCRIPT);
                int retVal1 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, script));

                script = Path.Combine(Settings.RootDir, DbConstants.DB_LOAD_SQLITE_SCRIPT);
                int retVal2 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, script));

string sql = "select * from CustomerLogin where email = @Email;";
                return Math.Abs(retVal1) + Math.Abs(retVal2) == 0;
            }
string sql = "select * from CustomerLogin where email = @Email;";
            catch (Exception ex)
            {
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                log.Error("Error rebulding DB", ex);
                return false;
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            }
        }
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);

        //Find the bugs!
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
        public string CustomCustomerLogin(string email, string password)
        {
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            string error_message = null;
            try
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            {
                //get data
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                string sql = "select * from CustomerLogin where email = @Email;";
                
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
string sql = "select * from CustomerLogin where email = @Email;";
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    connection.Open();

                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    //check if email address exists
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        error_message = "Email Address Not Found!";
                        return error_message;
                    }

                    string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
                    string decoded_password = Encoder.Decode(encoded_password);

string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
                    if (password.Trim().ToLower() != decoded_password.Trim().ToLower())
                    {
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                        error_message = "Password Not Valid For This Email Address!";
                    }
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
                    else
                    {
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                        //login successful
                        error_message = null;
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
                    }
                }
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                
            }
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
            catch (SqliteException ex)
            {
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                log.Error("Error with custom customer login", ex);
                error_message = ex.Message;
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
            }
            catch (Exception ex)
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
            {
                log.Error("Error with custom customer login", ex);
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
            }

command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
            return error_message;    
        }
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";

        public string GetCustomerEmail(string customerNumber)
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
        {
            string output = null;
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
            try
            {
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
                {
                    connection.Open();
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);

                    string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    output = command.ExecuteScalar().ToString();
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                } 
            }
string sql = "select email from CustomerLogin where customerNumber = @CustomerNumber";
            catch (Exception ex)
            {
command.Parameters.AddWithValue("@CustomerNumber", customerNumber);
                output = ex.Message;
            }
            return output;
        }

        public DataSet GetCustomerDetails(string customerNumber)
        {
            string sql = "select Customers.customerNumber, Customers.customerName, Customers.logoFileName, Customers.contactLastName, Customers.contactFirstName, " +
                "Customers.phone, Customers.addressLine1, Customers.addressLine2, Customers.city, Customers.state, Customers.postalCode, Customers.country, " +
                "Customers.salesRepEmployeeNumber, Customers.creditLimit, CustomerLogin.email, CustomerLogin.password, CustomerLogin.question_id, CustomerLogin.answer " +
                "From Customers, CustomerLogin where Customers.customerNumber = CustomerLogin.customerNumber and Customers.customerNumber = " + customerNumber;

            DataSet ds = new DataSet();
            try
            {
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                    da.Fill(ds);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error getting customer details", ex);
                
                throw new ApplicationException("Error getting customer details", ex);
            }
            return ds;

        }

        public DataSet GetOffice(string city)
        {
        
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Offices where city = @city";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                da.SelectCommand.Parameters.AddWithValue("@city", city);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetComments(string productCode)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Comments where productCode = @productCode";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                da.SelectCommand.Parameters.AddWithValue("@productCode", productCode); 
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public string AddComment(string productCode, string email, string comment)
        {
            string sql = "insert into Comments(productCode, email, comment) values ('" + productCode + "','" + email + "','" + comment + "');";
            string output = null;
            
            try
            {

                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error adding comment", ex);
                output = ex.Message;
            }
            
            return output;
        }

        public string UpdateCustomerPassword(int customerNumber, string password)
        {
            string sql = "update CustomerLogin set password = '" + Encoder.Encode(password) + "' where customerNumber = " + customerNumber;
            string output = null;
            try
            {
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand(sql, connection);
string sql = "select * from CustomerLogin where email = @Email;";
                
                    int rows_added = command.ExecuteNonQuery();
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    
                    log.Info("Rows Added: " + rows_added + " to comment table");
                }
            }
string sql = "select * from CustomerLogin where email = @Email;";
            catch (Exception ex)
            {
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                log.Error("Error updating customer password", ex);
                output = ex.Message;
            }
            return output;
string sql = "select * from CustomerLogin where email = @Email;";
        }

da.SelectCommand.Parameters.AddWithValue("@Email", email);
        public string[] GetSecurityQuestionAndAnswer(string email)
        {
            string sql = "select SecurityQuestions.question_text, CustomerLogin.answer from CustomerLogin, " + 
                "SecurityQuestions where CustomerLogin.email = '" + email + "' and CustomerLogin.question_id = " +
string sql = "select * from CustomerLogin where email = @Email;";
                "SecurityQuestions.question_id;";
                
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            string[] qAndA = new string[2];
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
string sql = "select * from CustomerLogin where email = @Email;";
                connection.Open();

da.SelectCommand.Parameters.AddWithValue("@Email", email);
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                
                DataSet ds = new DataSet();
                da.Fill(ds);
string sql = "select * from CustomerLogin where email = @Email;";

                if (ds.Tables[0].Rows.Count > 0)
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    qAndA[0] = row[0].ToString();
                    qAndA[1] = row[1].ToString();
string sql = "select * from Orders where customerNumber = @CustomerID";
string sql = "select * from CustomerLogin where email = @Email;";
                }
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            }
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            
            return qAndA;
        }

string sql = "select * from Orders where customerNumber = @CustomerID";
string sql = "select * from CustomerLogin where email = @Email;";
        public string GetPasswordByEmail(string email)
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
        {
da.SelectCommand.Parameters.AddWithValue("@Email", email);
            string result = string.Empty;
            try
            {
            
string sql = "select * from Orders where customerNumber = @CustomerID";
string sql = "select * from CustomerLogin where email = @Email;";
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                {
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    connection.Open();
sql = "select * from Products where productCode = @ProductCode";

                    //get data
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                    string sql = "select * from CustomerLogin where email = @Email;";
string sql = "select * from Orders where customerNumber = @CustomerID";
string sql = "select * from CustomerLogin where email = @Email;";
                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    DataSet ds = new DataSet();
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    da.Fill(ds);
sql = "select * from Products where productCode = @ProductCode";

                    //check if email address exists
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                    if (ds.Tables[0].Rows.Count == 0)
string sql = "select * from Orders where customerNumber = @CustomerID";
string sql = "select * from CustomerLogin where email = @Email;";
                    {
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                        result = "Email Address Not Found!";
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
da.SelectCommand.Parameters.AddWithValue("@Email", email);
                    }
sql = "select * from Products where productCode = @ProductCode";

                    string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                    string decoded_password = Encoder.Decode(encoded_password);
string sql = "select * from Orders where customerNumber = @CustomerID";
                    result = decoded_password;
                }
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            }
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            catch (Exception ex)
            {
sql = "select * from Products where productCode = @ProductCode";
                result = ex.Message;
            }
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            return result;
string sql = "select * from Orders where customerNumber = @CustomerID";
        }

sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
        public DataSet GetUsers()
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
sql = "select * from Products where productCode = @ProductCode";
            {
                connection.Open();
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);

string sql = "select * from Orders where customerNumber = @CustomerID";
                string sql = "select * from CustomerLogin;";
string sql = "select * from Payments where customerNumber = @CustomerNumber";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                DataSet ds = new DataSet();
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                da.Fill(ds);
                return ds;
sql = "select * from Products where productCode = @ProductCode";
            }
        }
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
       
string sql = "select * from Orders where customerNumber = @CustomerID";
        public DataSet GetOrders(int customerID)
string sql = "select * from Payments where customerNumber = @CustomerNumber";
        {
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
        
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
sql = "select * from Products where productCode = @ProductCode";
                connection.Open();

da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                string sql = "select * from Orders where customerNumber = @CustomerID";
sql = "select * from Categories where catNumber = @CatNumber";
string sql = "select * from Orders where customerNumber = @CustomerID";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
                DataSet ds = new DataSet();
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                da.Fill(ds);
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);

                if (ds.Tables[0].Rows.Count == 0)
sql = "select * from Products where productCode = @ProductCode";
                    return null;
                else
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                    return ds;
sql = "select * from Categories where catNumber = @CatNumber";
string sql = "select * from Orders where customerNumber = @CustomerID";
            }
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
        }
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);

da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
        public DataSet GetProductDetails(string productCode)
        {
sql = "select * from Products where productCode = @ProductCode";
            string sql = string.Empty;
            SqliteDataAdapter da;
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            DataSet ds = new DataSet();
sql = "select * from Categories where catNumber = @CatNumber";


da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
            {
                connection.Open();
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);

                sql = "select * from Products where productCode = @ProductCode";
sql = "select * from Products where productCode = @ProductCode";
                da = new SqliteDataAdapter(sql, connection);
                da.Fill(ds, "products");
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);

sql = "select * from Categories where catNumber = @CatNumber";
                sql = "select * from Comments where productCode = @ProductCode";
                da = new SqliteDataAdapter(sql, connection);
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
                da.Fill(ds, "comments");
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";

                DataRelation dr = new DataRelation("prod_comments",
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
                ds.Tables["products"].Columns["productCode"], //category table
                ds.Tables["comments"].Columns["productCode"], //product table
sql = "select * from Products where productCode = @ProductCode";
                false);

da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
string sql = "select email from CustomerLogin where email like @Email";
                ds.Relations.Add(dr);
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                return ds;
            }
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
        }
sql = "select * from Comments where productCode = @ProductCode";
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";

        public DataSet GetOrderDetails(int orderNumber)
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
da.SelectCommand.Parameters.AddWithValue("@ProductCode", productCode);
        {

            string sql = "select Customers.customerName, Orders.customerNumber, Orders.orderNumber, Products.productName, " + 
                "OrderDetails.quantityOrdered, OrderDetails.priceEach, Products.productImage " + 
                "from OrderDetails, Products, Orders, Customers where " + 
                "Customers.customerNumber = Orders.customerNumber " + 
string sql = "select email from CustomerLogin where email like @Email";
                "and OrderDetails.productCode = Products.productCode " + 
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                "and Orders.orderNumber = OrderDetails.orderNumber " + 
                "and OrderDetails.orderNumber = " + orderNumber;
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
            
            
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
string sql = "select email from CustomerLogin where email like @Email";
                    return null;
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                else
                    return ds;
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
            }
        }
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";

        public DataSet GetPayments(int customerNumber)
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Payments where customerNumber = @CustomerNumber";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
string sql = "select email from CustomerLogin where email like @Email";
                DataSet ds = new DataSet();
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                da.Fill(ds);

da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
                if (ds.Tables[0].Rows.Count == 0)
                    return null;
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
                else
                    return ds;
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
            }
        }

        public DataSet GetProductsAndCategories()
        {
            return GetProductsAndCategories(0);
        }
string sql = "select email from CustomerLogin where email like @Email";

sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
        public DataSet GetProductsAndCategories(int catNumber)
        {
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
string sql = "select * from Payments where customerNumber = @CustomerNumber";
            //TODO: Rerun the database script.
            string sql = string.Empty;
da.SelectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);
sql = "select * from Products where catNumber = @CatNumber";
            SqliteDataAdapter da;
            DataSet ds = new DataSet();
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);

            //catNumber is optional.  If it is greater than 0, add the clause to both statements.
            string catClause = string.Empty;
            if (catNumber >= 1)
                catClause += " where catNumber = " + catNumber; 


string sql = "select email from CustomerLogin where email like @Email";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
            {
                connection.Open();
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);

                sql = "select * from Categories where catNumber = @CatNumber";
                da = new SqliteDataAdapter(sql, connection);
                da.Fill(ds, "categories");
sql = "select * from Products where catNumber = @CatNumber";

                sql = "select * from Products where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
                da = new SqliteDataAdapter(sql, connection);
                da.Fill(ds, "products");


                //category / products relationship
                DataRelation dr = new DataRelation("cat_prods", 
                ds.Tables["categories"].Columns["catNumber"], //category table
string sql = "select email from CustomerLogin where email like @Email";
                ds.Tables["products"].Columns["catNumber"], //product table
sql = "select * from Categories where catNumber = @CatNumber";
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                false);

da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
                ds.Relations.Add(dr);
                return ds;
            }
        }
sql = "select * from Products where catNumber = @CatNumber";

        public DataSet GetEmailByName(string name)
da.SelectCommand.Parameters.AddWithValue("@CatNumber", catNumber);
        {
            string sql = "select firstName, lastName, email from Employees where firstName like '" + name + "%' or lastName like '" + name + "%'";
            
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
string sql = "select email from CustomerLogin where email like @Email";

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

        public string GetEmailByCustomerNumber(string num)
        {
            string output = "";
            try
            {
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
string sql = "select email from CustomerLogin where email like @Email";
                    connection.Open();

da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
                    string sql = "select email from CustomerLogin where customerNumber = " + num;
                    SqliteCommand cmd = new SqliteCommand(sql, connection);
                    output = (string)cmd.ExecuteScalar();
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error getting email by customer number", ex);
                output = ex.Message;
            }
            
            return output;
        }

        public DataSet GetCustomerEmails(string email)
        {
            string sql = "select email from CustomerLogin where email like @Email";
string sql = "select email from CustomerLogin where email like @Email";
            
            
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

    }
}
da.SelectCommand.Parameters.AddWithValue("@Email", email + "%");
string sql = "select email from CustomerLogin where email like @Email";










