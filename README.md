# 💼 Job Application Portal (ABP + Angular)

A **multi-tenant job application management system** built using:

- ✅ ASP.NET Core 9 (ABP Boilerplate Architecture)
- ✅ Angular (Auto-generated frontend)
- ✅ Entity Framework Core + SQL Server
- ✅ Swagger for API testing


---

## 📌 Project Status

- ✅ **Backend Features Implemented:**
  - `JobPosition` CRUD (with tenant-based isolation)
  - `Candidate` creation with file upload (PDF, DOCX, JPG/PNG)
  - Role-based permission scaffold (HR, Recruiter, etc.)
  - Tenant custom setting: `App.Job.MaxApplicantsPerPosition`
  - Swagger integrated and documented

- 🟨 **Frontend (Angular):**
  - Not customized yet
  - Default ABP UI works but does not handle multi-tenancy headers like `Abp.TenantId`

> ℹ️ This was my **first experience using Angular with ABP**, so frontend changes were not applied. However, backend is ready and testable.

---

## ⚙️ Backend Setup Instructions

### 1. Clone the Repository

git clone https://github.com/ali-shoaib-goraya/JobApplicationPortal.git
cd JobApplicationPortal/aspnet-core

### 2. Configure Database Connection
Open src/JobApplicationPortal.Web.Host/appsettings.json:
"ConnectionStrings": {
  "Default": "Server=localhost; Database=JobApplicationPortalDb; Trusted_Connection=True; TrustServerCertificate=True;"
}

### 3. Restore Dependencies
bash
Copy
Edit
dotnet restore
4. Apply Migrations
dotnet ef database update \
  --project src/JobApplicationPortal.EntityFrameworkCore \
  --startup-project src/JobApplicationPortal.Web.Host
5. Run the Application
cd src/JobApplicationPortal.Web.Host
dotnet run


## 📚 API Testing (via Swagger)
Once backend is running, open:

📎 https://localhost:44311/swagger

🔐 Default Admin Login

Tenant: Default
Username: admin
Password: 123qwe
⚠️ Note: Some endpoints (like JobPosition and Candidate create) may return TenantId is null in Swagger. This is because ABP expects the Abp.TenantId header, which the Angular UI usually provides.

## 🔧 Known Limitations
❌ Swagger cannot simulate multi-tenancy properly (missing Abp.TenantId)

❌ Angular frontend not integrated with custom backend logic yet

## 🚀 What's Next (Future Work)
### 🛠️ Add Angular UI integration

PrimeNG modal dialogs for Create/Edit JobPositions

Dashboard card for Top 5 Job Positions

Table with search, filter, pagination

📥 Resume download/view per candidate

🧠 Enable Hangfire job to notify inactive job postings

🎯 Set Abp.TenantId in Angular HTTP headers during API calls

## 📂 Folder Structure
JobApplicationPortal/
├── aspnet-core/          # Backend (.NET 9 ABP)
│   ├── src/
│   └── appsettings.json
├── angular/              # Frontend (Angular - default scaffold)
├── README.md             # Project documentation

## 📄 License
This project uses the MIT License.
