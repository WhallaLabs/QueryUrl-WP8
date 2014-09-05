using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QponyWP.Services.QueryUrlService
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryProperty : Attribute
    {
        public string Name { get; set; }
        public QueryProperty() { }
        public QueryProperty(string name)
        {
            Name = name;
        }
    }
}
