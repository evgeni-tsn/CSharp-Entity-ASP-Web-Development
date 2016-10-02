namespace _04.StudentClass
{
    public class PropertyChangedEventArgs
    {
        public PropertyChangedEventArgs(string propertyName, dynamic oldValue, dynamic newValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string PropertyName { get; set; }

        public dynamic OldValue { get; set; }

        public dynamic NewValue { get; set; }
    }
}