namespace Services.TapPayment
{
    public class TapPaymentModel
    {
    }

    public class Metadata
    {
        public string udf1 { get; set; }
        public string udf2 { get; set; }
    }
    public class Transaction
    {
        public string authorization_id { get; set; }
        public string timezone { get; set; }
        public string created { get; set; }
        public string url { get; set; }
    }
    public class Reference
    {
        public string track { get; set; }
        public string payment { get; set; }
        public string gateway { get; set; }
        public string acquirer { get; set; }
        public string transaction { get; set; }
        public string order { get; set; }
    }
    public class Response
    {
        public string code { get; set; }
        public string message { get; set; }
    }
    public class Receipt
    {
        public string id { get; set; }
        public bool email { get; set; }
        public bool sms { get; set; }
    }

    public class Phone
    {
        public string country_code { get; set; }
        public string number { get; set; }
    }

    public class Customer
    {
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Phone phone { get; set; }
    }

    public class Source
    {
        public string id { get; set; }
      
      
    }

    public class Post
    {
        public string url { get; set; }
    }

    public class Redirect
    {
        public string url { get; set; }
    }

    public class RootObject
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public bool threeDSecure { get; set; }
        public bool save_card { get; set; }
        public string description { get; set; }
        public string statement_descriptor { get; set; }
        public Metadata metadata { get; set; }
        public Reference reference { get; set; }
        public Receipt receipt { get; set; }
        public Customer customer { get; set; }
        public Source source { get; set; }
        public Post post { get; set; }
        public Redirect redirect { get; set; }
        public string @object { get; set; }
        public bool live_mode { get; set; }
        public string api_version { get; set; }
        public string id { get; set; }
        public string status { get; set; }

        public Transaction transaction { get; set; }

        public Response response { get; set; }

        public string RedirectUrl { get; set; }

        public string Posturl { get; set; }
    }

  

}
