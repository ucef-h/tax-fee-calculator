using System;
using System.Collections.Generic;
using System.Linq;
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

        int totalFee = 0;
        if (dates.Length == 0)
            return totalFee;

        foreach(IEnumerable<DateTime> group in dates.ToList().GroupBy(x => x.Date))
        {
            int dayTotalFee = 0;
            var intervalStart = group.First();
            foreach (var date in group)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (dayTotalFee > 0) dayTotalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    dayTotalFee += tempFee;
                }
                else
                {
                    dayTotalFee += nextFee;
                }
                if (dayTotalFee > 60) dayTotalFee = 60;
            }

            totalFee += dayTotalFee;

        }


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