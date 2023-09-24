using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApi.Models;
[Table("users")]
public class User{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

     public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}