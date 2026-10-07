using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IDeveloper : IComparable<IDeveloper>
    {
        string Tool { get; }

        void Create();

        void Destroy();
    }


}
