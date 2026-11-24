\# FastXBusBooking



FastXBusBooking is a bus ticket booking backend application built using ASP.NET Core Web API, Entity Framework Core, SQL Server, Repository Pattern, Service Layer, JWT Authentication, Role-Based Authorization, Validation, Global Exception Middleware, and BCrypt Password Hashing.



\## Technologies Used



\- ASP.NET Core Web API

\- Entity Framework Core

\- SQL Server LocalDB

\- Code First Approach

\- Repository Pattern

\- Service Layer

\- DTOs

\- JWT Authentication

\- Role-Based Authorization

\- BCrypt Password Hashing

\- Swagger



\## Modules



1\. User

2\. Admin

3\. BusOperator

4\. Bus

5\. Route

6\. Booking

7\. Payment



\## Roles



\- User

\- Admin

\- BusOperator



\## Security



\- JWT token-based authentication

\- Role-based authorization

\- BCrypt password hashing

\- Protected APIs using `\[Authorize]`



\## API Modules



\### User

\- POST /api/User/register

\- POST /api/User/login

\- GET /api/User

\- GET /api/User/{id}

\- PUT /api/User/{id}

\- DELETE /api/User/{id}



\### Admin

\- POST /api/Admin/login

\- POST /api/Admin

\- GET /api/Admin

\- GET /api/Admin/{id}

\- PUT /api/Admin/{id}

\- DELETE /api/Admin/{id}



\### BusOperator

\- POST /api/BusOperator/register

\- POST /api/BusOperator/login

\- GET /api/BusOperator

\- GET /api/BusOperator/{id}

\- PUT /api/BusOperator/{id}

\- DELETE /api/BusOperator/{id}



\### Bus

\- POST /api/Bus

\- GET /api/Bus

\- GET /api/Bus/{id}

\- PUT /api/Bus/{id}

\- DELETE /api/Bus/{id}



\### Route

\- POST /api/Route

\- GET /api/Route

\- GET /api/Route/{id}

\- PUT /api/Route/{id}

\- DELETE /api/Route/{id}



\### Booking

\- POST /api/Booking

\- GET /api/Booking

\- GET /api/Booking/{id}

\- PUT /api/Booking/{id}

\- DELETE /api/Booking/{id}



\### Payment

\- POST /api/Payment

\- GET /api/Payment

\- GET /api/Payment/{id}

\- PUT /api/Payment/{id}

\- DELETE /api/Payment/{id}



\## How to Run



```powershell

dotnet build

dotnet run --project .\\FastXBusBooking.API\\



## 🎥 FastX Project Demo

The video below demonstrates the FastX Bus Booking application.

[**Open / Download FastX Bus Booking Demo (MP4)**](https://media.githubusercontent.com/media/MEENAKSHI300804/FastXBusBooking-Backend/main/Demo-Video/FastX%20Bus%20Booking.mp4)
