import React from 'react';
import CategoryProductList from './components/CategoryProductList';
import ProductList from './components/ProductList';
import PostList from './components/PostList';
import BlogCategoryList from './components/BlogCategoryList';
import './App.css';

function App() {
    return (
        <div className="container mt-4">
            {/* Header */}
            <header className="navbar navbar-dark bg-dark px-4 mb-4 rounded">
                <span className="navbar-brand fw-bold fs-4 text-uppercase letter-spacing-2">
                    🪑 FurniHome
                </span>
                <span className="text-white-50 small fst-italic">
                    Kiến tạo không gian sống hoàn hảo
                </span>
            </header>

            {/* Shop Section */}
            <div className="row g-4 mb-5">
                <div className="col-12">
                    <span className="badge bg-secondary text-uppercase ls-1">Danh mục & Sản phẩm</span>
                    <hr />
                </div>
                <div className="col-md-3">
                    <div className="card border-0 bg-light h-100">
                        <div className="card-body">
                            <h6 className="card-title text-uppercase text-muted small fw-bold mb-3">Lọc danh mục</h6>
                            <CategoryProductList />
                        </div>
                    </div>
                </div>
                <div className="col-md-9">
                    <h4 className="text-uppercase fw-bold mb-4" style={{ color: '#2C1810' }}>
                        Bộ sưu tập mới nhất
                    </h4>
                    <ProductList />
                </div>
            </div>

            <hr className="my-5" />

            {/* Blog Section */}
            <div className="row g-4 mb-5">
                <div className="col-12">
                    <span className="badge bg-secondary text-uppercase">Nội dung & Blog</span>
                    <hr />
                </div>
                <div className="col-md-3">
                    <div className="card border-0 bg-light h-100">
                        <div className="card-body">
                            <h6 className="card-title text-uppercase text-muted small fw-bold mb-3">Chủ đề blog</h6>
                            <BlogCategoryList />
                        </div>
                    </div>
                </div>
                <div className="col-md-9">
                    <h4 className="text-uppercase fw-bold mb-4" style={{ color: '#2C1810' }}>
                        Bài viết nổi bật
                    </h4>
                    <PostList />
                </div>
            </div>

            {/* Footer */}
            <footer className="border-top pt-3 mt-4 text-muted text-center small">
                <p>© 2026 — Đồ án thực hành ASP.NET Core Web API kết hợp ReactJS</p>
            </footer>
        </div>
    );
}

export default App;