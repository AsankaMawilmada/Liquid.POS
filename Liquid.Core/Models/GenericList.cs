using System.Collections.Generic;
namespace Liquid.Core.Models
{
    public class GenericList<T>
    {
        public List<T> Items { get; set; } = new();

        public int Count { get; set; }
    }
}
