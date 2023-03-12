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



