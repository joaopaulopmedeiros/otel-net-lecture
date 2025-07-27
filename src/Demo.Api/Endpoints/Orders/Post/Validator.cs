namespace Demo.Api.Endpoints.Orders.Post;

public class OrderPostRequestValidator : AbstractValidator<OrderPostRequest>
{
    public OrderPostRequestValidator()
    {
        RuleFor(x => x.Price)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("O preço não pode ser negativo");
    }
}