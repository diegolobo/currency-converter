namespace currency_converter.Modules.Domain.Utils
{
    public static class DomainConstants
    {
        public static string DEFAULT_SUCCESS_MESSAGE = "Operation performed successfully.";

        public static string DEFAULT_ERROR_MESSAGE = "Error performing operation.";

        public static string GET_NOT_NULL_MESSAGE(string propertyName)
        {
            return $"The '{propertyName}' cannot be null.";
        }

        public static string GET_MIN_VALUE_MESSAGE(string propertyName, int value)
        {
            return $"The Minimum character value for property '{propertyName}' is {value}.";
        }

        public static string GET_MAX_VALUE_MESSAGE(string propertyName, int value)
        {
            return $"The Maximum character value for property '{propertyName}' is {value}.";
        }
    }
}
