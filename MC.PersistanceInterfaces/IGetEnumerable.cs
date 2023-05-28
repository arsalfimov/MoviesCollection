namespace MC.PersistanceInterfaces
{
    public interface IGetEnumerable <T, TKey> where T: class
    {
        Task<IEnumerable<T>> GetRangeById(TKey id);
    }
}
