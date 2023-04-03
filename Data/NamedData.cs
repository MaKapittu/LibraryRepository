namespace HW_01_Eurich_Kapitonova.Data
{
    public abstract class NamedData : UniqueData
    {
        public string Name { get; set; }
        public string? Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}