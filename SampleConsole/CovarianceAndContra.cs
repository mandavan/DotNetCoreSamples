using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    internal class CovarianceAndContra
    {
        public CovarianceAndContra() {
            //Covariance
            object[] array = new String[10];
            // The following statement produces a run-time exception.  
            array[0] = 10;

            //Contravariance
            string[] array1 = (string[])new object[10];
            // The following statement produces a run-time exception.  
            array1[0] = "10";
        }
    }
}
