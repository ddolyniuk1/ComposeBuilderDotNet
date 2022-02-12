using System.Collections.Generic;

namespace DockerComposeBuilder.Model.Infrastructure;

public class ValueCollection<T> : List<T>, IValueCollection<T> where T : class
{
    public ValueCollection(IEnumerable<T> collection) : base(collection)
    {
    }
}
