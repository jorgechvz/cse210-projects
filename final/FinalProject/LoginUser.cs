using System;
using Newtonsoft.Json;

public class LoginUser{
    private string _userFilePath;
    private string _nameUser;
    private string _newUserName;
    private List<User> _usersList;
    public LoginUser(){
        _userFilePath = "users.json";
    }
   
    public string GetNombrer(){
        return _nameUser;
    }
    public string GetNombreNew(){
        return _newUserName;
    }
    public void Run() {
        Console.WriteLine("Welcome to the authentication system");

        _usersList = ReadUsersFromFile();

        while (true) {
            Console.Write("Enter your username: ");
            _nameUser = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User user = _usersList.Find(u => u.NameUser == _nameUser && u.PasswordUser == password);
            Console.WriteLine(user);
            if (user != null) {
                Console.WriteLine("Welcome, " + user.NameUser + "!");
                break;
            } else {
                Console.WriteLine("Username or password incorrect. Please try again.");
                Console.WriteLine(_usersList.Count);
                
            }
        }

        Console.WriteLine(GetNombrer());

        Console.Write("Do you want to create a new user? (y/n): ");
        string respuesta = Console.ReadLine();
        if (respuesta == "y") {
            CreateUser();
        }
    }

    private List<User> ReadUsersFromFile() {
        if (!File.Exists(_userFilePath)) {
            File.Create(_userFilePath).Close();
            return new List<User>();
        }

        string jsonString = File.ReadAllText(_userFilePath);

        if (jsonString == "") {
            return new List<User>();
        }

        return JsonConvert.DeserializeObject<List<User>>(jsonString);
    }

    private void CreateUser() {
        Console.Write("Enter username: ");
        _newUserName = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        string folderName = $@"Inventarios\{_newUserName}";
        string fileName = "inventario.json";
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
            string fullPath = Path.Combine(folderName,fileName);
            File.Create(fullPath);

            User newUser = new User {
                NameUser = _newUserName,
                PasswordUser = password
            };

            _usersList.Add(newUser);

            WriteUsersToFile(_usersList);

            Console.WriteLine("New user added successfully!");
            Console.WriteLine(GetNombreNew()); 
        } else{
            Console.WriteLine("This user already exist, please create another user");
        }
           
    }

    private void WriteUsersToFile(List<User> users) {
        string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(_userFilePath, jsonString);
    }
}

