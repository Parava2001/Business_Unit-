namespace businessUnit.Model
{
    public class businessUnitModel
    {
        // these details are used to communication whem we make a http request to API
        public int id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string BusinessUnit { get; set; } = string.Empty;

        public string BusinessUnitName { get; set; } = string.Empty;

        public string Vertical { get; set; } = string.Empty;

        public string Channel { get; set; } = string.Empty;

        public string SynapseCustomer { get; set; } = string.Empty;

        public bool Status { get; set; }

        public string InactiveDate { get; set; } = string.Empty;




    }
}
