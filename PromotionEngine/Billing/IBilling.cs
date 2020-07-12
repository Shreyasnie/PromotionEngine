namespace PromotionEngine
{
    public interface IBilling<T>
    {
        int CalculateTotalPrice(T products);
    }
}
