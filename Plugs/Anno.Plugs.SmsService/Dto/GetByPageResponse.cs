using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.SmsService.Dto
{
    public class GetByPageResponse<TItem>
    {
        public IEnumerable<TItem> List { get; set; }
        public int Total { get; set; }
        public String UserName { get; set; }
    }
}
