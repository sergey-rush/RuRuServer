﻿using Newtonsoft.Json;
using RuRuServer.Base;

namespace RuRuServer.Models
{
    public class Notification
    {
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("account_id")]
        public string AccountId { get; set; }


        [JsonProperty("phone")]
        public string Phone { get; set; }


        [JsonProperty("period")]
        public Period Period { get; set; }


        [JsonProperty("user_ids")]
        public string UserIds { get; set; }


        [JsonProperty("state")]
        public int State { get; set; }


        [JsonProperty("state_reason")]
        public StateReason StateReason { get; set; }


        [JsonProperty("state_updated")]
        public DateTime StateUpdated { get; set; }


        [JsonProperty("prolongation_number")]
        public int ProlongationNumber { get; set; }


        [JsonProperty("payment_number")]
        public int PaymentNumber { get; set; }


        [JsonProperty("payment_succeeded")]
        public DateTime PaymentSucceeded { get; set; }


        [JsonProperty("payment_failed")]
        public DateTime PaymentFailed { get; set; }


        [JsonProperty("next_payment")]
        public DateTime NextPayment { get; set; }


        [JsonProperty("total_payment_amount")]
        public float TotalPaymentAmount { get; set; }


        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }


        [JsonProperty("transaction_error")]
        public string TransactionError { get; set; }


        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}