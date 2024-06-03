using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashForFieldsAttribute;

public class HashFieldAttribute : Attribute
{
    public int Position { get; set; }

    public HashFieldAttribute(int position)
    {
        Position = position;
    }
}
