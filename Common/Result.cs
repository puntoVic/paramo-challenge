using System;

namespace Common
{
    public class Result
    {
        private bool isSuccess;

        private string errors;

        public bool IsSuccess { get => isSuccess; set => isSuccess = value; }
        public string Errors { get => errors; set => errors = value; }
    }
}
