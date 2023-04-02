using System;

public class User {
    // Attributes
    private string _name;
    private string _password;
    private string _email;
    private string _firstname;
    private string _lastname;
    private string _storeName;

    // Properties
    public string NameUser 
    {
        get { return _name; }
        set { _name = value; }
    }

    public string PasswordUser 
    {
        get { return _password; }
        set { _password = value; }
    }
    public string FirstName
    {
        get { return _firstname; }
        set { _firstname = value; }
    }
    public string LastName 
    {
        get { return _lastname; }
        set { _lastname = value; }
    }
    public string UserEmail 
    {
        get { return _email; }
        set { _email = value; }
    }
    public string StoreName 
    {
        get { return _storeName; }
        set { _storeName = value; }
    }
}