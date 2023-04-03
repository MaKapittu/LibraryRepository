namespace HW_01_Eurich_Kapitonova.Aids
{
    public static class GetNamespace
    {
        public static string? OfType(object? obj)
            => Safe.Run(() => obj?.GetType()?.Namespace ?? string.Empty, string.Empty);
    }
}
