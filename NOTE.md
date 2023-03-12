# NOTE

while converting the config of hours and amounts:

I realised that for the config
8:30 to 14:59, it was translated to the following code

```c#
if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
```
However, for the config 15:30 to 16:59
the following code was used
```c#
if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
```
These are different rules for different numbers.

`hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59`: does not allow  for time like 9:15

`hour >= 8 && hour <= 14` applies to 9

`minute >= 30 && minute <= 59` does not allow 15

Should have been hour==8 && min >=30 || hour>8 && hour<=14 && min between 0 and 59
