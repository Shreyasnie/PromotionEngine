namespace PromotionEngine
{
    public interface ICartEngine<T>
    {
        int Calculate(T productCombination);
    }
}