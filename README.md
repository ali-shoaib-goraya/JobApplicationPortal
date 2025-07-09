<<<<<<< HEAD
# Job Application Portal

This project is a **multi-tenant job application management system** built using:

- ✅ ASP.NET Core 9 (ABP Boilerplate Architecture)
- ✅ Angular (auto-generated frontend)
- ✅ Entity Framework Core + SQL Server
- ✅ Swagger API documentation

---

## 🔧 Project Status

This solution includes:

- ✅ Complete backend setup with working:
  - JobPosition CRUD endpoints
  - Candidate creation (with file upload logic)
  - Swagger integration for testing
  - Custom Tenant Setting support
  - Role and permission support scaffolded
- 🟨 Frontend (Angular) UI is **not customized yet**

Due to this being my **first experience with Angular and ABP’s UI structure**, I was unable to make modifications confidently in the frontend. However:

- All backend features are complete
- APIs are documented and testable via Swagger (with token)

---

## ⚙️ Backend Setup Instructions

1. **Clone the Repo & Navigate**
   ```bash
   git clone <your_repo_url>
   cd aspnet-core
Configure SQL Connection
Edit src/JobApplicationPortal.Web.Host/appsettings.json

json
Copy
Edit
"ConnectionStrings": {
  "Default": "Server=localhost; Database=JobApplicationPortalDb; Trusted_Connection=True;"
}
Restore Dependencies

bash
Copy
Edit
dotnet restore
Apply Migrations

bash
Copy
Edit
dotnet ef database update --project src/JobApplicationPortal.EntityFrameworkCore --startup-project src/JobApplicationPortal.Web.Host
Run the Backend

bash
Copy
Edit
cd src/JobApplicationPortal.Web.Host
dotnet run
Access Swagger
https://localhost:44311/swagger

🔐 Default Admin Login
vbnet
Copy
Edit
Tenant: Default
Username: admin
Password: 123qwe
🚫 Known Limitations
Swagger cannot test some endpoints due to TenantId being null — since it's normally sent from the Angular UI as a header (Abp.TenantId).

This affects testing endpoints like:

JobPosition Create

Candidate Create

✅ Once the Angular UI is implemented or updated to send the correct Abp.TenantId header, the backend will behave as expected.

🔜 What’s Next (Future Work)
Customize the Angular UI to consume the backend

Inject Abp.TenantId from logged-in user’s tenant in Angular HTTP headers

Use PrimeNG dialogs and table for UI interactivity

=======
# JobApplicationPortal
>>>>>>> c08a2bc2cc197679e4c187fa054b2b5147758b9e
