
// Models/User.cs
namespace whoknows_c_sharp.Models;

public class User
{
    public int Id { get; set; }  // PK
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }  // note: for prod need hashing here
}

/*

DROP TABLE IF EXISTS users;

CREATE TABLE IF NOT EXISTS users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  username TEXT NOT NULL UNIQUE,
  email TEXT NOT NULL UNIQUE,
  password TEXT NOT NULL
);


*/
