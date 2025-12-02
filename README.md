# IKEA Company Management

Simple ASP.NET Core MVC web app for managing Departments and Employees (Razor views).

## Summary
A small three-layer (DAL / BLL / PL) ASP.NET Core 9 application that demonstrates:
- Employee and Department CRUD
- ASP.NET Identity authentication (register/login, password reset)
- Email (MailKit) and SMS (Twilio) integrations
- File uploads for employee images
- AutoMapper and EF Core (with migrations)

## Tech
- .NET 9, C#
- ASP.NET Core MVC (Razor views)
- Entity Framework Core (SQL Server)
- ASP.NET Identity
- MailKit (SMTP email)
- Twilio (SMS)
- AutoMapper, Repository + Unit of Work patterns

## Quick start
1. Clone the repo
2. Update appsettings.json:
   - ConnectionStrings: DefaultConnection -> your SQL Server
   - MailSettings: SMTP credentials (Gmail needs app password)
   - Twilio: AccountSID / AuthToken / TwilioPhoneNumber
   - Authentication: Google ClientId/ClientSecret (optional)
3. Apply migrations and update DB:
   - dotnet ef database update --project MVC04.DAL --startup-project MVC04.PL
4. Run the app:
   - cd MVC04.PL
   - dotnet run
5. Open browser: https://localhost:5001 (or printed URL)

## Important files
- MVC04.DAL: EF models, DbContext, migrations
- MVC04.BLL: services, DTOs, AutoMapper profiles
- MVC04.PL: controllers, views, helpers (Email/SMS), Program.cs, appsettings.json

## Notes
- Password policy: min 8 characters (configured in Program.cs)
- Images typically stored under wwwroot/uploads
- Use environment secrets for production (do not commit credentials)

## License
Use as you like. No warranty.
