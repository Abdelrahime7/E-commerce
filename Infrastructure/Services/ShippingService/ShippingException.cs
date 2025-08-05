
namespace Infrastructure.Services.ShippingService
{
    [Serializable]
    internal class ShippingException : Exception
    {
        public ShippingException()
        {
        }

        public ShippingException(string? message) : base(message)
        {
        }

        public ShippingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}