using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.Logger
{
    public class GlobalCoolingVariantCounter
    {
        int counter;
        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public GlobalCoolingVariantCounter()
        {
            counter = 0;
        }

        public void Increment()
        {
            counter = counter + 1;
        }

    }
}
