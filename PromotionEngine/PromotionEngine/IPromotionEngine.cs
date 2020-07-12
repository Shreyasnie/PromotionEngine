namespace PromotionEngine
{
    public interface IPromotionEngine<T>
    {
        int ApplyPromotion(T productCombination);

        T GetNonPromotedItems(T productCombination);
    }
}