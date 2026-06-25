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
* Giỏ hàng (**Cart** + **CartItem**)
* Đơn hàng (**Order**)
* Chi tiết đơn hàng (**OrderDetail**)
* Người dùng (**User**)
* Quan hệ danh mục – sản phẩm (**CategoryProduct**)

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
* Xây dựng luồng mua hàng thực tế: Giỏ hàng → Thanh toán → Đơn hàng → Trừ tồn kho

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
* Transaction (đảm bảo toàn vẹn dữ liệu khi đặt hàng)

## 🔹 Frontend

* ReactJS
* React Router DOM
* Axios (axiosClient)
* Hooks (`useState`, `useEffect`, `useContext`)
* React Context API (CartContext — đồng bộ badge giỏ hàng toàn app)

## 🔹 Database

* SQL Server
* EF Core Migration

## 🔹 Công cụ

* Visual Studio 2022
* Node.js
* SQL Server Management Studio 21
* Git / GitHub

---

# 📦 5. Cấu trúc dự án

```text
CMS Solution
│
├── CMS.Backend (ASP.NET Core MVC + Web API)
│   ├── Controllers
│   │   ├── CartsController.cs
│   │   ├── CategoryController.cs
│   │   ├── CategoryProductController.cs
│   │   ├── CustomerController.cs
│   │   ├── HomeController.cs
│   │   ├── OrdersController.cs
│   │   ├── OrderDetailsController.cs
│   │   ├── PostController.cs
│   │   ├── ProductController.cs
│   │   └── UserController.cs
│   │
│   ├── Models
│   ├── Views
│   ├── wwwroot
│   ├── appsettings.json
│   └── Program.cs
│
├── CMS.Data
│   ├── Entities
│   │   ├── Cart.cs
│   │   ├── CartItem.cs
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
│   ├── public
│   ├── src
│   │   ├── api
│   │   │   └── axiosClient.js
│   │   ├── components
│   │   │   ├── Header.jsx
│   │   │   └── Footer.jsx
│   │   ├── context
│   │   │   └── CartContext.js
│   │   ├── pages
│   │   │   ├── Cart
│   │   │   ├── Checkout
│   │   │   ├── MyOrders
│   │   │   ├── ProductDetail
│   │   │   └── ...
│   │   └── services
│   │       ├── cartService.js
│   │       ├── orderService.js
│   │       └── productService.js
│   ├── package.json
│   └── package-lock.json
│
└── README.md
```

---

# ⚙️ 6. Chức năng hệ thống

## 🟦 6.1 Quản trị (Admin - ASP.NET MVC)

### 🔐 Quản lý người dùng
* Thêm / sửa / xóa người dùng
* Quản lý tài khoản hệ thống

### 📂 Quản lý danh mục (Category)
* Thêm / sửa / xóa danh mục

### 📦 Quản lý sản phẩm (Product)
* Thêm / sửa / xóa sản phẩm
* Quản lý tồn kho (`StockQuantity`)
* Upload ảnh sản phẩm

### 📝 Quản lý bài viết (Post)
* Thêm / sửa / xóa bài viết

### 👥 Quản lý khách hàng (Customer)
* Thêm / sửa / xóa khách hàng

### 🧾 Quản lý đơn hàng (Order)
* Xem danh sách đơn hàng
* Cập nhật trạng thái đơn hàng

---

## 🟩 6.2 Web API (Backend Service)

### Sản phẩm & Danh mục

| Method | Endpoint | Mô tả |
|--------|----------|-------|
| GET | `/api/products` | Danh sách sản phẩm |
| GET | `/api/products/{id}` | Chi tiết sản phẩm |
| GET | `/api/categories` | Danh sách danh mục |

### Giỏ hàng

| Method | Endpoint | Mô tả |
|--------|----------|-------|
| GET | `/api/carts/{customerId}` | Lấy giỏ hàng |
| POST | `/api/carts/add` | Thêm sản phẩm vào giỏ |
| PUT | `/api/carts/increase/{id}` | Tăng số lượng |
| PUT | `/api/carts/decrease/{id}` | Giảm số lượng |
| DELETE | `/api/carts/item/{id}` | Xóa 1 sản phẩm |
| DELETE | `/api/carts/clear/{customerId}` | Xóa toàn bộ giỏ |

### Đơn hàng

| Method | Endpoint | Mô tả |
|--------|----------|-------|
| POST | `/api/orders` | Tạo đơn hàng (tự trừ tồn kho) |
| GET | `/api/orders/{id}` | Chi tiết đơn hàng |
| GET | `/api/orders/customer/{customerId}` | Đơn hàng theo khách |
| GET | `/api/orderdetails/order/{orderId}` | Chi tiết sản phẩm trong đơn |

---

## 🟨 6.3 Frontend ReactJS (SPA)

* Trang chủ — danh sách sản phẩm
* Trang chi tiết sản phẩm — xem thông tin, chọn số lượng, thêm vào giỏ
* Trang giỏ hàng — tăng/giảm/xóa sản phẩm, xem tổng tiền, phí ship
* Trang thanh toán — nhập thông tin giao hàng, xem lại đơn hàng, đặt hàng
* Trang lịch sử đơn hàng — xem các đơn đã đặt, bấm mở chi tiết từng đơn
* Badge giỏ hàng trên Header tự cập nhật sau mỗi thao tác (React Context)

---

# 🔄 7. Luồng mua hàng

```text
Khách hàng đăng nhập
        ↓
Xem sản phẩm → Thêm vào giỏ hàng
        ↓
Trang giỏ hàng → Kiểm tra, điều chỉnh số lượng
        ↓
Trang thanh toán → Nhập thông tin giao hàng
        ↓
Bấm "Xác nhận đặt hàng"
        ↓
Backend: Tạo Order + OrderDetail + Trừ StockQuantity (1 Transaction)
        ↓
Frontend: Xóa giỏ hàng → Chuyển về trang chủ
        ↓
Khách hàng xem lại đơn tại "Đơn hàng của tôi"
```

---

# 🚀 8. Hướng dẫn cài đặt & chạy dự án

## Yêu cầu

| Công cụ | Phiên bản |
|---------|-----------|
| .NET SDK | 7.0+ |
| SQL Server | 2019+ hoặc LocalDB |
| Node.js | 18+ |
| npm | 9+ |

## 🔹 Bước 1 — Clone project

```bash
git clone <repository-url>
```

## 🔹 Bước 2 — Chạy Backend

1. Mở file `CMS.Backend/appsettings.json`, cập nhật chuỗi kết nối:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TÊN_SERVER;Database=CMS_DB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

2. Chạy migration để tạo database:

```bash
cd CMS.Backend
dotnet ef database update
```

3. Nhấn **F5** trong Visual Studio, hoặc:

```bash
dotnet run
```

> Backend chạy tại: `https://localhost:7077`

## 🔹 Bước 3 — Chạy Frontend

```bash
cd cms.frontend
npm install      # chỉ cần chạy lần đầu
npm start
```

> Frontend chạy tại: `http://localhost:3000`

> ⚠️ **Lưu ý:** Khởi động Backend trước, Frontend sau.

---

# 🗄️ 9. Database Design

## Bảng Cart
* Id (PK), CustomerId (FK), CreatedAt

## Bảng CartItem
* Id (PK), CartId (FK), ProductId (FK), Quantity

## Bảng Product
* Id (PK), Name, Price, Description, ImageUrl, StockQuantity, CategoryId (FK)

## Bảng Order
* Id (PK), CustomerId (FK), OrderDate, Status, Notes

## Bảng OrderDetail
* Id (PK), OrderId (FK), ProductId (FK), Quantity, UnitPrice

## Bảng Customer
* Id (PK), FullName, Phone, Address, Email, Password

## Bảng Category
* Id (PK), Name, Description

## Bảng Post
* Id (PK), Title, Content, Image, CategoryId (FK), CreatedDate

## Bảng User
* Id (PK), Username, Password, Role

---

# 📌 10. Hướng phát triển

* Thêm JWT Authentication cho API
* Tích hợp upload ảnh Cloud (Cloudinary / Azure Blob)
* Dashboard thống kê doanh thu cho Admin
* Tích hợp thanh toán online (VNPay / MoMo)
* Tối ưu SEO với Next.js
* Triển khai Docker & CI/CD

---

# 👨‍💻 11. Kết luận

Dự án CMS là một hệ thống full-stack hoàn chỉnh giúp sinh viên nắm vững kiến trúc phần mềm hiện đại, từ thiết kế database, xây dựng API đến tích hợp giao diện ReactJS và xử lý nghiệp vụ thực tế như quản lý giỏ hàng, đặt hàng và kiểm soát tồn kho.

---

# ⭐ 12. Tác giả

* **Sinh viên:** Trần Thị Kim Quí
* **Môn học:** ASP.NET Core Advanced
* **Năm học:** 2026
