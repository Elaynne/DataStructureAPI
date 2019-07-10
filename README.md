# DataStructureAPI
Learning .net core API

This API uses the SortLib.dll from [DataStructurelib](https://github.com/Elaynne/DataStructureLib) project which contains search, ordering  and collections algorithms.

## TO-DO

* [ ] Sorting integers [WIP]
* [ ] Sorting array of Strings
* [ ] Show step-by-step of each ordering and the execution time.
* [ ] Accept text file as input
* [ ] Allow download of ordered file

## Request example

* Json input request exemple for rout [/api/sort]:
* Algorithm options: "mergesort", "heapsort", "quicksort" and "all".

```json
{
	"algorithm": "mergesort",
	"items":
		["15", "18", "16", "14","63", "12", "62", "58","66", "26", "6", "65","46", "11", "7"]
}
````
* Your output should be:
```json
[
   {
      "time":"00:00:00.0096113",
      "complexity":"n log(n)",
      "items":[
         6,7,11,12,14,15,16,18,26,46,58,62,63,65,66
      ],
      "algorithm":"mergesort"
   }
]
````
* If you choose all, you'll get: 

```json
[{"Time":"00:00:00.0032634","Complexity":"n log(n)","Itens":[6,7,11,12,14,15,16,18,26,46,58,62,63,65,66],"Algorithm":"mergesort"},{"Time":"00:00:00.0011829","Complexity":"Ω(n log(n))\tO(n²)","Itens":[6,7,11,12,14,15,16,18,26,46,58,62,63,65,66],"Algorithm":"quicksort"},{"Time":"00:00:00.0022788","Complexity":"Ω(n log(n))\tO(n log(n))","Itens":[6,7,11,12,14,15,16,18,26,46,58,62,63,65,66],"Algorithm":"heapsort"}]
````
