using System;
using Newtonsoft.Json;
public class User {
    private string _name;
    private string _password;

    public string NameUser {
        get { return _name; }
        set { _name = value; }
    }

    public string PasswordUser {
        get { return _password; }
        set { _password = value; }
    }
}