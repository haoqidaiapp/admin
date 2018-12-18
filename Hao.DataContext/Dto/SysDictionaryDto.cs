using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hao.Infrastructure.Dto
{
    public class SysDictionaryDto
    {
        public int Id { get; set; }
        public int Sort { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public string  CreateTime { get; set; }
    }
}
