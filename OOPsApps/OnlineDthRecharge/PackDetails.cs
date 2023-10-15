using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDthRecharge
{
    public class PackDetails
    {
        public string PackId { get; set; }
        public string PackName { get; set; }
        public double Price { get; set; }
        public int Validity { get; set; }
        public int NoOfChannels { get; set; }

        public PackDetails(string packId,string packName,double price,int validity,int noOfChannels){
            PackId=packId;
            PackName=packName;
            Price=price;
            Validity=validity;
            NoOfChannels=noOfChannels;
        }
    }
}