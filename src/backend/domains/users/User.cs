
// Models/User.cs
namespace whoknows_c_sharp.domains.users;

public class User
{
    public int Id { get; set; }  // PK
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }  // note: for prod need hashing here
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
