using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashForFieldsAttribute;

public class UnprocessableHashObjectException : Exception
{
    private const string ErrorMessage = "Object must contain at least one HashField attribute";

    public UnprocessableHashObjectException() : base(ErrorMessage)
    {
    }
}
