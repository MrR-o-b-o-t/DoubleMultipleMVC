namespace DoubleMultiplesMVC.Models
{
    public class DoubleMultiple
    {
        public int DoubleValue { get; set; }
        public int MultipleValue { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
