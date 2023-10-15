using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDthRecharge
{
    public class RechargeHistory
    {
        private static int s_id=100;
        public string RechargeId { get; set; }
        public string UserId { get; set; }
        public string PackId { get; set; }
        public DateTime RechargeDate { get; set; }
        public double RechargeAmount { get; set; }
        public DateTime ValidTill { get; set; }
        public int NumberOfChannels { get; set; }

        public RechargeHistory(string userId,string packId,DateTime rechargeDate,double rechargeAmount,DateTime validTill,int noOfChannels){
            RechargeId="RP"+(++s_id);
            UserId=userId;
            PackId=packId;
            RechargeDate=rechargeDate;
            RechargeAmount=rechargeAmount;
            ValidTill=validTill;
            NumberOfChannels=noOfChannels;
        }
    }
}