namespace FLIGHTLoyaltyCard
{
    internal class LoyaltyAccount
    {
        internal string Email;
        internal string Contact;
        internal string FlightNumber;
        internal int Points;
        internal object PointsHistory;
        internal object UsedVouchers;

        public string Name { get; internal set; }
    }
}