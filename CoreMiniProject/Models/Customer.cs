namespace CoreMiniProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Customer
{
    [Key] //Marks the property as the primary key of the entity.
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //Controls how EF generates or expects values:
                                                      //None → You must provide the Custid value manually(EF won’t auto-generate it).
    public int Custid { get; set; }
    [Required(ErrorMessage = "This field is mandatory")]


    [MaxLength(100)]
    [Column(TypeName = "Varchar")]
   
    public string? Name { get; set; }


    [Column(TypeName = "Money")]
    [Required(ErrorMessage = "This field is mandatory")]
    public decimal? Balance { get; set; }



    [MaxLength(100)]
    [Column(TypeName = "Varchar")]
    [Required(ErrorMessage = "This field is mandatory")]
    public string? City { get; set; }

    [Required(ErrorMessage = "This field is mandatory")]
    public bool Status { get; set; }


}


