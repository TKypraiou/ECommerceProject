using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Dto
{
    public class ReturnData<T>
    {
        public T Data { get; set; }
        public int Error { get; set; }
        public string Description { get; set; }
    }
}
