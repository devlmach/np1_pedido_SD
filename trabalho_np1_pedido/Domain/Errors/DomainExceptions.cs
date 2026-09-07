namespace trabalho_np1_pedido.Domain.Errors
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions(string message) : base(message) { }
    }

    public class NotFoundException : DomainExceptions
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class BadRequestException : DomainExceptions
    {
        public BadRequestException(string message) : base(message) { }
    }

    public class ForbiddenException : DomainExceptions
    {
        public ForbiddenException(string messase) : base(messase) { }
    }

    public class NullException : DomainExceptions
    {
        public NullException(string message) : base(message) { }
    }
}