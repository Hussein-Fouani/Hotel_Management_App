# Hotel Management App

A hotel booking application with a Dapper-based data access library and an ASP.NET Core Razor Pages front end. The library covers searching available room types, booking guests, searching bookings and checking guests in, using SQL Server stored procedures.

## Tech Stack

- .NET 8 (`net8.0`)
- ASP.NET Core Razor Pages with Bootstrap
- Dapper 2.1 with `System.Data.SqlClient` (SQL Server)
- `Microsoft.Extensions.Configuration` for connection strings

## Project Structure

| Project | Description |
| --- | --- |
| `HotelAppLibrary` | Class library with the models (`RoomTypeModel`, `RoomModel`, `GuestModel`, `BookingFullModel`), the generic Dapper data access class `SqlDataAccess`, and `SqlData`, which implements the hotel operations on top of it. |
| `HotelWebApp` | ASP.NET Core Razor Pages app. Registers `IDatabaseData`/`ISqlDataAccess` in DI and contains a Room Search page with start and end date inputs. |
| `HotelAppDB` | SQL Server database project referenced by `HotelApp.sln`. It is not included in this repository. |

## Features

`HotelAppLibrary` (`SqlData`):

- Get the room types available between two dates (`dbo.spRoomTypes_GetAvailableTypes`).
- Book a guest: insert the guest, pick an available room of the chosen type and save the booking with the total cost (nights x room price) (`dbo.spGuests_Insert`, `dbo.spRooms_GetAvailableRooms`, `dbo.spBookings_Insert`).
- Search today's bookings by guest last name (`dbo.spBookings_Search`).
- Check a guest in (`dbo.spBookings_CheckIn`).

`HotelWebApp`:

- Home and Privacy pages.
- Room Search page with a start/end date form. The search is not wired to the data library yet.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server with a database that contains the `RoomTypes` table and the stored procedures listed above (the `HotelAppDB` project that defines them is not part of this repository)

### Configuration

`SqlData` reads a connection string named `SqlDb`. Add it to `HotelWebApp/appsettings.json`, for example:

```json
"ConnectionStrings": {
  "SqlDb": "Server=.;Database=HotelAppDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Run

```bash
cd HotelWebApp
dotnet run
```

Then open `http://localhost:5195` (or `https://localhost:7294` with `dotnet run --launch-profile https`).

## License

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt).
