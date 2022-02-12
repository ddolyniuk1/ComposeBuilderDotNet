using System.Collections;
using System.Collections.Generic;

namespace Aviationexam.DockerComposeBuilder.Model.Infrastructure;

public interface IValueCollection<T> : IValueCollection, ICollection<T> where T : class
{
}

public interface IValueCollection : IEnumerable
{
}
