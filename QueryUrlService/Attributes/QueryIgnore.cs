using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QponyWP.Services.QueryUrlService
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryIgnore : Attribute
    {
    }
}
