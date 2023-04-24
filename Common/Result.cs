namespace Common
{
    /// <summary>
    /// Model to return results.
    /// If isSuccess attribute is true, Errors attribute is empty.
    /// If isSuccess attribute is false, Errors attribute contains list of errors ocurred.
    /// </summary>
    public class Result
    {
        private bool isSuccess;

        private string errors;

        public bool IsSuccess { get => isSuccess; set => isSuccess = value; }
        public string Errors { get => errors; set => errors = value; }
    }
}
