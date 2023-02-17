using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baseNetApi.models;

public class ContactNumber
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int phone { get; set; } = "";
    
}