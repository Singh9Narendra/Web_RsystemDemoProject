namespace Web_RsystemDemoProject.Model
{
    /// <summary>
    /// Common Response Class
    /// </summary>
    public class ResponseDto
    {

        public object? Result { get; set; }
        public bool IsSucess { get; set; }
        public string? Message { get; set; }
    }
}
