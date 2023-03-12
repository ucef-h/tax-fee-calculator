# Fee Calcularor

## Dependencies

`NET 5` 

 The enviroment was previously setup on my machine


 ## Description

 Three additional projects has been added to the solution while the original has left intact

 Running the solution would open a Swagger API

 ### Sample Payloads


 ```json
 //Holidays
{
  "city": "Gothenburg",
  "vehicle": "Car",
  "dates": [
    "2023-03-11T18:24:25.801Z",
    "2023-03-12T19:24:25.801Z"
  ]
}
```

```json
//thursday to friday
{
  "city": "Gothenburg",
  "vehicle": "Car",
  "dates": [
    "2023-03-09T05:24:25.801Z",
    "2023-03-10T18:24:25.801Z",
    "2023-03-10T19:24:25.801Z"
  ]
}
```


```json
//Assignment example
{
  "city": "Gothenburg",
  "vehicle": "Car",
  "dates": [
    "2013-01-14T01:00:00",
    "2013-01-15T21:00:00",
    "2013-02-07T06:23:27",
    "2013-02-07T15:27:00",
    "2013-02-08T06:27:00",
    "2013-02-08T06:20:27",
    "2013-02-08T14:35:00",
    "2013-02-08T15:29:00",
    "2013-02-08T15:47:00",
    "2013-02-08T16:01:00",
    "2013-02-08T16:48:00",
    "2013-02-08T17:49:00",
    "2013-02-08T18:29:00",
    "2013-02-08T18:35:00",
    "2013-03-26T14:25:00",
    "2013-03-28T14:07:27"
  ]
}
```


