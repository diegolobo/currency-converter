namespace currency_converter.Modules.Domain.Entities
{
    public class Rate : Entity
    {
        public int CurrencyId { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
