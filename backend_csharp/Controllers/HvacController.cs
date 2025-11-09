namespace DormClimateBackend.Controllers
{
    public class HvacController
    {
        public enum HvacAction
        {
            HighestCooling,
            Cooling_075,
            Cooling_050,
            Cooling_025,
            DoNothing,
            Heating_025,
            Heating_050,
            Heating_075,
            HighestHeating
        }

        public HvacAction GetHvacAction(double roomTemp, double desiredTemp, double externalTemp)
        {
            double ttd = desiredTemp - roomTemp;
            double ntd = externalTemp - roomTemp;

            int baseLevel = GetBaseLevel(ttd);

           // Console.WriteLine($"BaseLevel: {baseLevel} → Mode: {(baseLevel < 4 ? "Cooling" : baseLevel > 4 ? "Heating" : "DoNothing")}");

            int influence = baseLevel == 4 ? 0 : GetNaturalInfluence(ttd, ntd);

            int adjustedLevel = baseLevel + influence;
            adjustedLevel = Math.Max(0, Math.Min(8, adjustedLevel)); // Clamp between 0 and 8

            return (HvacAction)adjustedLevel;
        }

        private int GetBaseLevel(double ttd)
        {
            if (Math.Abs(ttd) < 0.5) return 4; // DoNothing
            if (ttd < -20) return 0; // HighestCooling
            if (ttd < -15) return 1;
            if (ttd < -10) return 2;
            if (ttd < -2) return 3;
            if (ttd <= 2) return 4; // DoNothing
            if (ttd <= 10) return 5;
            if (ttd <= 15) return 6;
            if (ttd <= 20) return 7;
            return 8; // HighestHeating
        }

        private int GetNaturalInfluence(double ttd, double ntd)
        {
            bool helping = (ttd > 0 && ntd > 0) || (ttd < 0 && ntd < 0);
            double absNtd = Math.Abs(ntd);

            if (absNtd < 5) return 0;
            if (absNtd < 10) return helping ? -1 : 1;
            return helping ? -2 : 2;
        }
    }

}
