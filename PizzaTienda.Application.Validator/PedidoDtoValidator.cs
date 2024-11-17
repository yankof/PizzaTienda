namespace PizzaTienda.Application.Validator;

public class PedidoDtoValidator : AbstractValidator<PedidoDto>
{
    public PedidoDtoValidator()
    {
        RuleFor(x => x.IdCliente).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.idProducto).NotNull().NotEmpty().GreaterThan(0);
    }
}
