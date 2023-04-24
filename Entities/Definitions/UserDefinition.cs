namespace Entities.Definitions
{
    /// <summary>
    /// UserDefinition model to set params in API
    /// </summary>
    public class UserDefinition
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal Money { get; set; }
    }
}
