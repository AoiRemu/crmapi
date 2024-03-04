namespace CRM.Models.View
{
    public class CommonOption<T>
    {
        public string Label { get; set; }

        public T Value { get; set; }
    }

    public class CommonOption
    {
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
