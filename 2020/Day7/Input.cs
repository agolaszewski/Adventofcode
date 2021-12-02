using System.Collections.Generic;

namespace Day7
{
    public class Input
    {
        public string Name { get; set; }

        public List<Contains> Contains { get; set; }
    }

    public class Contains
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}