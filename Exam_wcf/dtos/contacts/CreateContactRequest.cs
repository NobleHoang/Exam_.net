namespace baseNetApi.models.products;

public class CreateContactRequest
{
    public string name { get; set; } = "";
    public string number { get; set; }
    public int group_id { get; set; } = 1;
}