namespace AkademickaBazaDanych.Domain.Students
{
    public record IndexNumber
    {
        public string Value { get; }

        public IndexNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 5 || !int.TryParse(value, out _))
                throw new ArgumentException("Index number must be a 5-digit number.");

            this.Value = value;
        }

        public static IndexNumber CreateNew(IEnumerable<string> takenIndexNumbers)
        {
            var takenIndices = takenIndexNumbers.Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            int newIndex = 1;

            foreach (var index in takenIndices)
            {
                if (index != newIndex)
                {
                    break;
                }
                newIndex++;
            }

            return new IndexNumber(newIndex.ToString("D5"));
        }

        public override string ToString() => Value;
    }
}
