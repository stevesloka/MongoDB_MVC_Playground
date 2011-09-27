using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDB_MVC_Playground.Models
{
    public class HomeModel
    {
        public string _id { get; set; }
        public Guid SeqNum { get; set; }
        public DateTime DateInserted { get; set; }
        public string Reference { get; set; }

        public HomeModel(string p_id, Guid pSeqNum, DateTime pDateInserted, string pReference)
        {
            _id = p_id;
            SeqNum = pSeqNum;
            DateInserted = pDateInserted;
            Reference = pReference;
        }
    }
}