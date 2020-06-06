using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public interface IAlgorithm
    {
        string Name { get; }
        List<int> Search(string text, string pattern);
    }
}
