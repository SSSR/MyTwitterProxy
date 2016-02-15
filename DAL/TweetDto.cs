using BLToolkit.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TweetDto
    {
        [MapField("id")]
        public long Id { get; set; }

        [MapField("date")]
        public string CreatedAt { get; set; }
        [MapField("author")]
        public string Author { get; set; }
        [MapField("text")]
        public string Text { get; set; }

    }
}
