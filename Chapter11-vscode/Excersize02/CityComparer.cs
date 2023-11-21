

namespace Packt.Shared;

public class CityComparer : IEqualityComparer<Customer>
{
    public bool Equals(Customer x, Customer y)
    {
        if(x == null || y == null){
            return false;
        }
        return x.City == y.City;
    }

    public int GetHashCode(Customer obj)
    {
        if(obj == null)
        {
            return 0;
        }
        return obj.City.GetHashCode();
    }
}
