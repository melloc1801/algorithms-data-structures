namespace Helpers;

public class StringCaseIgnoreComparer: IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }

        return x.ToLower().Equals(y.ToLower());
    }

    public int GetHashCode(string str)
    {
        if (str == null)
        {
            return 0;
        }
        
        return str.ToLower().GetHashCode();
    }
}