using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Prototype.Models;

namespace Prototype.Services
{
    public class UserDataService
    {
        //this is deserialized in the LoadUsersFromFile()
        List<User> _users = new List<User>();

        // the name of the file
        private readonly string _fileName = "Users.json";

        public UserDataService()
        {
            // Load existing users from file
            LoadUsersFromFile();
        }


        //brings the loaded users from the existing file
        private void LoadUsersFromFile()
        {
            try
            {
                //Users.json
                if (File.Exists(_fileName))
                {
                    //reads the information on the file
                    var json = File.ReadAllText(_fileName);

                    //deserializes the information to the list
                    _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                //the exception if the users fail to load
                System.Diagnostics.Debug.WriteLine("Error loading users: " + ex.Message);
            }
        }


        //saves the user information
        public void SaveUsersToFile() // make public so ForgotPassword can call it
        {
            try
            {
                //saves the user to the user.json, what is where the database stores the information
                var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_fileName, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error saving users: " + ex.Message);
            }
        }


        //register for the user
        public async Task<bool> RegisterUser(string email, string password, string phoneNumber = "")
        {
            //doesnt let you create a user with the same email
            if (_users.Exists(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return false;

            //hashes the password
            var hashedPassword = UserDataService.HashPassword(password);

            //adds the new user to the database including their email, password, phone number
            var newUser = new User
            {
                Email = email,
                PasswordHash = hashedPassword,
                PhoneNumber = phoneNumber
            };

            _users.Add(newUser);
            SaveUsersToFile();
            await Task.CompletedTask;
            return true;
        }



        //login for the user
        public async Task<bool> LoginUser(string email, string password)
        {
            //finds users email
            var user = GetUserByEmail(email);
            if (user == null) return false;

            //finds the hashed password
            var hashedPassword = UserDataService.HashPassword(password);
            await Task.CompletedTask; //gets the task thats already completed
            return user.PasswordHash == hashedPassword;
        }


        // user is found in the database and ignores capitals
        public User GetUserByEmail(string email)
        {
            return _users.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }


        //hashes the password to hide information inside the users database
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
