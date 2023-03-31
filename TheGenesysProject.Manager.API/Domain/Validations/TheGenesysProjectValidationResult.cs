namespace TheGenesysProject.Manager.API.Domain.Validations
{
    internal class TheGenesysProjectValidationResult
    {
        public bool IsValid { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
