using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baseNetApi.models;

public class GroupName
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public string name { get; set; } = "";
}