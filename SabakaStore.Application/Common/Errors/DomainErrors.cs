using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Common.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new("User.NotFound", "User not found.");
    public static readonly Error EmailAlreadyExists = new("User.EmailAlreadyExists", "A user with this email already exists.");
    public static readonly Error InvalidCredentials = new("User.InvalidCredentials", "Invalid email or password.");
}

public static class ProductErrors
{
    public static readonly Error NotFound = new("Product.NotFound", "Product not found.");
}

public static class StoreErrors
{
    public static readonly Error NotFound = new("Store.NotFound", "Store not found.");
}

public static class CartErrors
{
    public static readonly Error NotFound = new("Cart.NotFound", "Cart not found.");
    public static readonly Error ProductNotInCart = new("Cart.ProductNotInCart", "Product is not in the cart.");
}

public static class OrderErrors
{
    public static readonly Error NotFound = new("Order.NotFound", "Order not found.");
    public static readonly Error CartIsEmpty = new("Order.CartIsEmpty", "Cannot create order from an empty cart.");
}
