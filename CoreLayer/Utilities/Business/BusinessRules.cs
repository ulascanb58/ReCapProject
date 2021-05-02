using CoreLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Utilities
{
    public class BusinessRules
    {

        public static IResult Run(params IResult[] logics)
        {
            foreach(var logic in logics)
            {
                if(!logic.Success==true)

                {
                    return logic;
                }
            }


            return null;
        }

        
    }
}


