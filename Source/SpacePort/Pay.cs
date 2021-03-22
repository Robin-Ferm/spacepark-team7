using System.ComponentModel.DataAnnotations.Schema;

public class Pay
{
    public int ID { get; set; }
    public int Invoice { get; set; }
    [ForeignKey("ParkID")]
    public int ParkID { get; set; }
    public Park Park { get; set; }
}