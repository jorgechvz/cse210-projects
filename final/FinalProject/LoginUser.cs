using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

public class LoginUser{
    private string _userFilePath;
    private string _nameUser;
    private string _newUserName;
    private bool _loginIsComplete;
    private byte[] key;
    private byte[] iv;
    private string _storeName;
    private List<User> _usersList;
    public LoginUser()
    {
        _userFilePath = "users.json";
        _loginIsComplete = false;
        key = Encoding.UTF8.GetBytes("mysecretkey12345");
        iv = Encoding.UTF8.GetBytes("myiv123456789012");
        _storeName = "";
    }
   
    public string GetNameUser()
    {
        return _nameUser;
    }
    public string GetNewNameUser()
    {
        return _newUserName;
    }
    public bool GetLoginIsComplete()
    {
        return _loginIsComplete;
    }
    public string GetStoreName()
    {
        return _storeName;
    }
    // Run Login
    public void RunLogin() 
    {
        Console.WriteLine("Welcome to Inventory Systemy\n");
        Console.WriteLine(" 1. Login Up");
        Console.WriteLine(" 2. Sign Up");
        Console.WriteLine(" 3. Exit");
        Console.Write("\nPlease choose a option: ");
        string option = Console.ReadLine().ToLower();
        switch(option)
        {
            case "1":
                _usersList = ReadUsersFromFile();
                bool loginSuccesfull = false;
                while (!loginSuccesfull) 
                {
                    // Prompt user for login information
                    Console.Clear();
                    Console.WriteLine("Welcome to the authentication system\n");
                    Console.Write(" Enter your username or email: ");
                    _nameUser = Console.ReadLine();
                    Console.Write(" Enter your password: ");
                    string password = ReadPassword();
                    string encryptPassword = EncryptString(password, key, iv);
                    // Find user with matching credentials
                    User user = _usersList.Find(u => u.NameUser == _nameUser || u.UserEmail == _nameUser && u.PasswordUser == encryptPassword);
                    if (user != null) {
                        // Display welcome message and store user information
                        Console.WriteLine($"\nWelcome, {user.FirstName}!");
                        _nameUser = user.NameUser;
                        _storeName = user.StoreName;
                        loginSuccesfull = true;
                        Thread.Sleep(3000);
                        Console.Clear();
                    } else {
                        // Display error message and try again
                        Console.WriteLine("\nUsername or password incorrect. Please try again.");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                _loginIsComplete = true;
                break;
            case "2":
                // Read users from file and create a new user
                _usersList = ReadUsersFromFile();
                CreateUser();
                break;
        }
    }
    // Read users from file
    private List<User> ReadUsersFromFile() 
    {
        // If the user file doesn't exist, create an empty one and return an empty list
        if (!File.Exists(_userFilePath)) {
            File.Create(_userFilePath).Close();
            return new List<User>();
        }
        // Read the file and deserialize the JSON data to a list of users
        string jsonString = File.ReadAllText(_userFilePath);
        if (jsonString == "") {
            return new List<User>();
        }
        return JsonConvert.DeserializeObject<List<User>>(jsonString);
    }
    // Create a new user
    private void CreateUser() 
    {
        // Prompt user for information and create a new user
        Console.Clear();
        Console.WriteLine("Sign Up\n");
        Console.Write("Enter username: ");
        _newUserName = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = ReadPassword();
        string encryptPassword = EncryptString(password, key, iv);
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Email (xxxx@xxx.xxx): ");
        string userEmail = Console.ReadLine();
        Console.Write("Enter Store Name: ");
        string storeName = Console.ReadLine();
        string folderName = $@"Inventories\{_newUserName}";
        string fileName = "inventory.json";
        if (!Directory.Exists(folderName))
        {
            // If the user's folder doesn't exist, create it and add the user to the list
            Directory.CreateDirectory(folderName);
            string fullPath = Path.Combine(folderName,fileName);
            File.Create(fullPath);
            User newUser = new User {
                FirstName = firstName,
                LastName = lastName,
                UserEmail = userEmail,
                StoreName = storeName,
                NameUser = _newUserName,
                PasswordUser = encryptPassword
            };
            _usersList.Add(newUser);
            WriteUsersToFile(_usersList);
            Console.WriteLine("New user added successfully!");
        } else{
            Console.WriteLine("This user already exist, please create another user");
        } 
    }
    private void WriteUsersToFile(List<User> users) 
    {
        // Convert the list of users to a JSON string with indented formatting
        string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
        // Write the JSON string to a file located at _userFilePath
        File.WriteAllText(_userFilePath, jsonString);
    }

    public static string ReadPassword() 
    {
        // Initialize an empty password string
        string password = "";
        // Read key inputs from the console until the Enter or Escape key is pressed
        ConsoleKeyInfo key;
        do {
            key = Console.ReadKey(true);
            // Check if the Backspace key is pressed and remove the last character of the password if it's not empty
            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape) 
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0) 
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else // Append the typed character to the password string and replace it with an asterisk
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
        // Print a new line and return the password string
        Console.WriteLine();
        return password;
    }
    public static string EncryptString(string plainText, byte[] key, byte[] iv)
    {
        byte[] encrypted;
        // Create an AES object with the specified key and initialization vector
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            // Create an encryptor with the AES object
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            // Write the encrypted data to a MemoryStream using a CryptoStream and a StreamWriter
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }
        // Convert the encrypted byte array to a Base64-encoded string and return it
        return Convert.ToBase64String(encrypted);
    }
}


