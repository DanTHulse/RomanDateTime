using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public struct RomanSetDays
    {
        public SetDays SetDay { get; }
        public string Short { get; }
        public string Accusative { get; }
        public string Ablative { get; }

        public static RomanSetDays Kalendae => new RomanSetDays(SetDays.Kalendae, "Kalendas", "Kalendis", "Kal.");
        public static RomanSetDays Nonae => new RomanSetDays(SetDays.Nonae, "Nonas", "Nonis", "Non.");
        public static RomanSetDays Idus => new RomanSetDays(SetDays.Idus, "Idus", "Idibus", "Id.");

        public RomanSetDays(SetDays setDay, string accV, string ablV, string shortV)
        {
            SetDay = setDay;
            Accusative = accV;
            Ablative = ablV;
            Short = shortV;
        }
    }
}
