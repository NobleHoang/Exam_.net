using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using baseNetApi.models.basic;

namespace baseNetApi.models;

public class Contacts : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string name { get; set; }
    public string number { get; set; }
    public int group_id { get; set; } = 1;
}