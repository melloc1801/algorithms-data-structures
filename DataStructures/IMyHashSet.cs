using System.Collections;
using System.Runtime.Serialization;

namespace DataStructures;

public interface IMyHashSetGeneric<T>: 
    ICollection<T>, 
    IEnumerable<T>, 
    IReadOnlyCollection<T>, 
    ISet<T>,
    IEnumerable,
    IReadOnlySet<T>
{
}