public record Pesel
{
    public string Value { get; }

    public Pesel(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidatePESEL(value))
            throw new ArgumentException("Invalid PESEL number.");

        Value = value;
    }
    public static Pesel Create(string value) => new Pesel(value);
    private static bool ValidatePESEL(string pesel)
    {
        if (pesel.Length != 11 || !long.TryParse(pesel, out _))
            return false;

        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += weights[i] * (pesel[i] - '0');
        }

        int controlDigit = (10 - (sum % 10)) % 10;

        return controlDigit == (pesel[10] - '0');
    }

    public override string ToString() => Value;
}
