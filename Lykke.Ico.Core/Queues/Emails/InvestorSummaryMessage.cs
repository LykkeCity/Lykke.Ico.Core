﻿namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorSummary)]
    public class InvestorSummaryMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public string TokenAddress { get; set; }
        public string RefundBtcAddress { get; set; }
        public string RefundEthAddress { get; set; }
        public string PayInBtcAddress { get; set; }
        public string PayInEthAddress { get; set; }

        public static InvestorSummaryMessage Create(string email, string tokenAddress, string refundBtcAddress,
            string refundEthAddress, string payInBtcAddress, string payInEthAddress)
        {
            return new InvestorSummaryMessage
            {
                EmailTo = email,
                Attempts = 0,
                TokenAddress = tokenAddress,
                RefundBtcAddress = refundBtcAddress,
                RefundEthAddress = refundEthAddress,
                PayInBtcAddress = payInBtcAddress,
                PayInEthAddress = payInEthAddress
            };
        }
    }
}   
