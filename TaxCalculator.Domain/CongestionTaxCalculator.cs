using System;
using TaxCalculator.Domain;
using TaxCalculator.Domain.Vehicles;

public class CongestionTaxCalculator
{
    private readonly TollFreeVehicles _tollFreeVehicles;
    private readonly TollCalendar _tollCalendar;
    private readonly TollFee _tollFee;

    public CongestionTaxCalculator(TaxConfig config)
    {
        _tollFreeVehicles = new TollFreeVehicles(config.TollFreeVehicles);
        _tollCalendar = new TollCalendar(config.CalendarConfig);
        _tollFee = new TollFee(config.FeeConfigs);
    }

    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        var intervalStart = dates[0];
        int totalFee = 0;
        foreach (var date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }

        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;
        return _tollFee.GetFee(date);
    }

    private bool IsTollFreeDate(DateTime date)
    {
        return _tollCalendar.IsTollFreeDate(date);
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        return _tollFreeVehicles.IsTollFree(vehicle);
    }
}