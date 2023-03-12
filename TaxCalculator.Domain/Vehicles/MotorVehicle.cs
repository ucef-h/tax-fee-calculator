namespace TaxCalculator.Domain.Vehicles
{
    public abstract class MotorVehicle : Vehicle
    {
        public virtual string GetVehicleType()
        {
            return GetType().Name;
        }
    }
}
