namespace Domain
{
    public static class ErrorMessages
    {
        public static string TaskNotFound { get{ return GetErrorMessage("Task"); } } 
        private static string GetErrorMessage(string name)
        {
            return $"{name} is not found!";
        }
    }
}
