using System;
#nullable enable


namespace PlayInThirdPerson.Settings
{
    public interface ISettableSetting
    {
        string FieldName { get; }
        string GroupName { get; }
        object TrueValue { get; }
        void SetTemporary(object? tempValue);
    }

    public class SettableSetting<T> : ISettableSetting where T : struct
    {
        private T? _tempValue;
        private T _value;

        public SettableSetting(string groupName, string fieldName)
        {
            GroupName = groupName;
            FieldName = fieldName;
        }

        public string GroupName { get; }
        public string FieldName { get; }

        public T Value
        {
            get => _tempValue ?? _value;
            set => _value = value;
        }

        public object TrueValue => _value;

        public void SetTemporary(object? tempValue)
        {
            _tempValue = (T?)tempValue;
        }
    }
}
