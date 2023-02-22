
namespace MyDonor.Domain.Types
{
    public class ServiceResponse<TResult>
    {
        private Dictionary<string, List<string>> _errors;

        public bool IsValid => _errors.Any();

        public Dictionary<string, List<string>> Errors => _errors;

        public TResult Result { get; set; }

        public ServiceResponse()
        {
            _errors = new();
        }

        public void AddError(string Key, string ErrorMessage)
        {
            if (!Errors.ContainsKey(Key))
            {
                _errors[Key] = new List<string>();
            }

            _errors[Key].Add(ErrorMessage);
        }
    }
}

