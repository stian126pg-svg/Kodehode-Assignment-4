## Digimon Database Explorer V1.0


A C# console application that reads a Digimon CSV database, maps each row to a C# object, and allows users to search and explore the dataset using LINQ.
It could be expanded upon, and I might just do so.


## Features

- Read Digimon data from a CSV file
- Convert each CSV row into a `Digimon` object
- Search Digimon by name
- Filter Digimon by attribute
- Display all Rookie Digimon
- Display the Top 10 Digimon by Memory usage
- Interactive console menu
- Clean project structure using Models, Services, and Controllers


## Project Structure

```
Kodehode_Assignment_4
│
├── Models
│   └── Digimon.cs
│
├── Services
│   └── CsvReader.cs
│
├── Controllers
│   └── DigimonController.cs
│
├── Data
│   └── Digimonlist.csv
│
└── Program.cs
```


## Example Menu

```
==== DIGIMON DATABASE ====

1. Show all Rookies
2. Search by Name
3. Filter by Attribute
4. Top 10 Memory
5. Exit
```


## Learning Goals

This project was created to practice

- Reading CSV files
- Object-oriented programming
- Separating application logic into Models, Services, and Controllers
- Working with collections using LINQ
- Building an interactive console application

## Future Improvements

- Add sorting by HP, Attack, Defense, and Speed?
- Add search by stage and type?
- Display stage statistics using `GroupBy()`?
- Export filtered results to a new CSV?
- Replace manual CSV parsing with CsvHelper?
