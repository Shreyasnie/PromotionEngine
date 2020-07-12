namespace PromotionEngine
{
    public abstract class PromotionBaseType<T>
    {
        public abstract PromotionType PromotionType
        {
            get;
        }

        public T NonPromotedItems { get; protected set; }

        public bool IsPromotionApplied { get; protected set; }

        public int GetPromotionValue(T productCombination)
        {
            return GetCountofMatchingValue(productCombination) * (int)PromotionType;
        }

        public abstract int GetCountofMatchingValue(T productCombination);
    }
}
