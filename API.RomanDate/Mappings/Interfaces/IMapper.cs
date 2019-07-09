namespace API.RomanDate.Mappings.Interfaces
{
    public interface IMapper
    {
        T Map<T>(object source);
    }
}
