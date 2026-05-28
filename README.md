# 📘 ĐỒ ÁN MÔN ASP.NET CORE + REACTJS

# Hệ thống quản lý nội dung (CMS - Content Management System)

---

# 👨‍🎓 1. Giới thiệu đề tài

Dự án **CMS (Content Management System)** là một hệ thống quản lý nội dung website được xây dựng theo mô hình **Fullstack hiện đại**, kết hợp:

* **Backend:** ASP.NET Core MVC + Web API
* **Frontend:** ReactJS (Single Page Application)
* **Database:** SQL Server
* **ORM:** Entity Framework Core

Hệ thống cho phép quản lý:

* Danh mục sản phẩm (**Category**)
* Sản phẩm (**Product**)
* Bài viết (**Post**)
* Khách hàng (**Customer**)
* Đơn hàng (**Order**)
* Chi tiết đơn hàng (**OrderDetail**)
* Người dùng (**User**)
* Quan hệ danh mục – sản phẩm (**CategoryProduct**)

Ngoài ra hệ thống còn cung cấp API để frontend ReactJS hiển thị dữ liệu động từ backend.

---

# 🎯 2. Mục tiêu đề tài

Đề tài được xây dựng nhằm:

* Nắm vững kiến trúc **3-Layer Architecture**
* Hiểu và sử dụng **Entity Framework Core + Migration**
* Thành thạo truy vấn dữ liệu với **LINQ**
* Xây dựng hệ thống **CRUD hoàn chỉnh**
* Phát triển **Web API RESTful**
* Tích hợp frontend bằng **ReactJS**
* Áp dụng **Authentication & Authorization**
* Xây dựng hệ thống quản lý dữ liệu thực tế theo mô hình doanh nghiệp

---

# 🧱 3. Kiến trúc hệ thống

```text
Frontend (ReactJS - SPA)
        ↓ HTTP (Axios)
Backend API (ASP.NET Core Web API)
        ↓
Business Logic (Service + LINQ)
        ↓
Data Access Layer (Entity Framework Core)
        ↓
Database (SQL Server - CMS_DB)
```

---

# 🧰 4. Công nghệ sử dụng

## 🔹 Backend

* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* LINQ
* ASP.NET Core Identity
* Dependency Injection

## 🔹 Frontend

* ReactJS
* React Router DOM
* Axios
* Hooks (`useState`, `useEffect`)

## 🔹 Database

* SQL Server
* EF Core Migration

## 🔹 Công cụ

* Visual Studio 2022
* Node.js
* SQL Server Management Studio 21
* Git/GitHub

---

# 📦 5. Cấu trúc dự án

```text
CMS Solution
│
├── CMS.Backend (ASP.NET Core MVC + Web API)
│   ├── Controllers
│   │   ├── CategoryController.cs
│   │   ├── CategoryProductController.cs
│   │   ├── CustomerController.cs
│   │   ├── HomeController.cs
│   │   ├── OrderController.cs
│   │   ├── OrderDetailController.cs
│   │   ├── PostController.cs
│   │   ├── ProductController.cs
│   │   └── UserController.cs
│   │
│   ├── Models
│   │
│   ├── Views
│   │   ├── Category
│   │   ├── CategoryProduct
│   │   ├── Customer
│   │   ├── Home
│   │   ├── Order
│   │   ├── OrderDetail
│   │   ├── Post
│   │   ├── Product
│   │   ├── User
│   │   └── Shared
│   │
│   ├── wwwroot
│   ├── appsettings.json
│   └── Program.cs
│
├── CMS.Data
│   ├── Entities
│   │   ├── Category.cs
│   │   ├── CategoryProduct.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   ├── OrderDetail.cs
│   │   ├── Post.cs
│   │   ├── Product.cs
│   │   └── User.cs
│   │
│   ├── Migrations
│   └── ApplicationDbContext.cs
│
├── cms.frontend (ReactJS)
│   ├── node_modules
│   ├── public
│   ├── src
│   ├── package.json
│   └── package-lock.json
│
└── Database (SQL Server - CMS_DB)
```

---

# ⚙️ 6. Chức năng hệ thống

## 🟦 6.1 Quản trị (Admin - ASP.NET MVC)

### 🔐 Quản lý người dùng

* Thêm / sửa / xóa người dùng
* Quản lý tài khoản hệ thống

### 📂 Quản lý danh mục (Category)

* Thêm / sửa / xóa danh mục
* Phân loại nội dung và sản phẩm

### 📦 Quản lý sản phẩm (Product)

* Thêm / sửa / xóa sản phẩm
* Liên kết sản phẩm với danh mục

### 🔗 Quản lý CategoryProduct

* Quản lý quan hệ giữa danh mục và sản phẩm

### 📝 Quản lý bài viết (Post)

* Thêm / sửa / xóa bài viết
* Hiển thị nội dung động

### 👥 Quản lý khách hàng (Customer)

* Thêm / sửa / xóa khách hàng

### 🧾 Quản lý đơn hàng (Order)

* Tạo / cập nhật / xóa đơn hàng

### 📄 Quản lý chi tiết đơn hàng (OrderDetail)

* Quản lý sản phẩm trong đơn hàng

### ✅ Chức năng bổ sung

* Validate dữ liệu form
* Razor View + Bootstrap UI
* Điều hướng MVC rõ ràng

---

# 🟩 6.2 Web API (Backend Service)

Hệ thống cung cấp API RESTful:

| Method | Endpoint          | Mô tả                  |
| ------ | ----------------- | ---------------------- |
| GET    | `/api/posts`      | Lấy danh sách bài viết |
| GET    | `/api/posts/{id}` | Chi tiết bài viết      |
| GET    | `/api/categories` | Danh sách danh mục     |
| GET    | `/api/products`   | Danh sách sản phẩm     |
| GET    | `/api/orders`     | Danh sách đơn hàng     |
| POST   | `/api/posts`      | Thêm bài viết          |
| PUT    | `/api/posts/{id}` | Cập nhật bài viết      |
| DELETE | `/api/posts/{id}` | Xóa bài viết           |

---

# 🟨 6.3 Frontend ReactJS (SPA)

* Hiển thị danh sách bài viết dạng card
* Hiển thị danh sách sản phẩm
* Trang chi tiết bài viết
* Trang chi tiết sản phẩm
* Điều hướng bằng React Router
* Gọi API bằng Axios
* Render dữ liệu động từ backend

---

# 🧠 7. Công nghệ & kỹ thuật áp dụng

* MVC Pattern
* RESTful API Design
* Dependency Injection (DI)
* Entity Framework Core + Migration
* LINQ to Entities
* SPA (Single Page Application)
* Authentication & Authorization
* Separation of Concerns (SoC)
* CRUD Operations
* Razor View Engine

---

# 🗄️ 8. Database Design

## 🔹 Bảng Category

* Id (PK)
* Name
* Description

## 🔹 Bảng Product

* Id (PK)
* Name
* Price
* Description
* Image
* CategoryId (FK)

## 🔹 Bảng Post

* Id (PK)
* Title
* Content
* Image
* CategoryId (FK)
* CreatedDate

## 🔹 Bảng Customer

* Id (PK)
* FullName
* Phone
* Address
* Email

## 🔹 Bảng Order

* Id (PK)
* CustomerId (FK)
* OrderDate
* TotalAmount

## 🔹 Bảng OrderDetail

* Id (PK)
* OrderId (FK)
* ProductId (FK)
* Quantity
* Price

## 🔹 Bảng User

* Id (PK)
* Username
* Password
* Role

## 🔹 Bảng CategoryProduct

* CategoryId (FK)
* ProductId (FK)

---

# 🔄 9. Quy trình hoạt động hệ thống

1. Admin đăng nhập hệ thống
2. Quản lý dữ liệu:

   * Category
   * Product
   * Post
   * Customer
   * Order
3. Dữ liệu được lưu vào SQL Server
4. Web API lấy dữ liệu từ Database
5. ReactJS gọi API bằng Axios
6. Dữ liệu hiển thị trên giao diện người dùng

---

# 🚀 10. Hướng dẫn cài đặt & chạy dự án

## 🔹 10.1 Clone project

```bash
git clone <repository-url>
```

## 🔹 10.2 Backend (.NET Core)

```bash
cd CMS.Backend
dotnet restore
dotnet ef database update
dotnet run
```

## 🔹 10.3 Frontend (ReactJS)

```bash
cd cms.frontend
npm install
npm start
```

---

# 🔐 11. Bảo mật hệ thống

* ASP.NET Core Identity
* Phân quyền Admin
* Validate dữ liệu đầu vào
* Chống truy cập trái phép API
* Kiểm tra dữ liệu form phía server

---

# 📊 12. Ưu điểm của hệ thống

* Kiến trúc rõ ràng, dễ mở rộng
* Tách biệt frontend & backend
* Dễ bảo trì và nâng cấp
* Áp dụng công nghệ thực tế doanh nghiệp
* Hỗ trợ SPA giúp trải nghiệm mượt
* Quản lý dữ liệu đa chức năng
* Có thể mở rộng thành hệ thống thương mại điện tử

---

# 📌 13. Hướng phát triển

* Thêm JWT Authentication cho API
* Tích hợp upload ảnh Cloud (Cloudinary/Azure)
* Thêm dashboard thống kê admin
* Tích hợp thanh toán online
* Thêm comment cho bài viết
* Tối ưu SEO React (SSR/Next.js)
* Triển khai Docker & CI/CD

---

# 👨‍💻 14. Kết luận

Dự án CMS là một hệ thống full-stack hoàn chỉnh giúp sinh viên:

* Hiểu kiến trúc phần mềm hiện đại
* Nắm vững ASP.NET Core + EF Core
* Thành thạo mô hình MVC + Web API
* Kết hợp backend API với frontend ReactJS
* Xây dựng tư duy phát triển hệ thống thực tế
* Làm quen quy trình phát triển phần mềm doanh nghiệp

---

# ⭐ 15. Tác giả

* **Sinh viên:** Trần Thị Kim Quí
* **Môn học:** ASP.NET Core Advanced
* **Năm học:** 2026
