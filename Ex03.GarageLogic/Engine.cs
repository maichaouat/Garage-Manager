

namespace Ex03.GarageLogic
{
    public enum ePowerType { Soler, Octan95, Octan96, Octan98, Electric }

    internal abstract class Engine
    {
        internal abstract void ChargeUp(float i_AmountToCharge, ePowerType i_FuelType);
        internal abstract float PrecentageEnergyLeft();
        public abstract override string ToString();
    }
}
