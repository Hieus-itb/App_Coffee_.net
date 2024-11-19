# LD - Peoples
Quản lý quán cà phê  bằng ngôn ngữ C# Dưới đây là đề cương chi tiết cho từng thành viên, mô tả chức năng modules và layout draft cho các chức năng cần quản lý trong hệ thống
## Thành viên 1(Văn Đăng Hiếu): Đăng nhập, Đặt bàn, Báo cáo doanh thu, Quản lý nhân sự

### **Nhiệm vụ:** Quản lý thông tin hệ thống, đặt bàn, báo cáo tài chính, và nhân sự trong quán cà phê.
Chức năng Modules:
- Đăng nhập
  - **Đăng nhập hệ thống:** Người dùng nhập tài khoản và mật khẩu để truy cập.
  - **Phân quyền truy cập:** Quy định quyền hạn dựa trên vai trò (quản lý, nhân viên...).
- Đặt bàn
  - **Quản lý sơ đồ bàn:** Hiển thị trạng thái bàn (trống, đã đặt) theo thời gian thực.
  - **Đặt bàn:** Hỗ trợ nhân viên đặt bàn cho khách.
  - **Hủy đặt bàn:** Cho phép thay đổi thông tin đặt bàn khi cần.
- Báo cáo doanh thu
  - **Thống kê doanh thu:** Tổng hợp số lượng, chi phí và lãi thu.
  - **Xuất báo cáo:** Hiển thị doanh thu theo theo thời gian.
- Quản lý nhân sự
  - **Thêm mới nhân viên:** Lưu thông tin nhân viên (họ tên, chức vụ, ngày sinh, ngày vào làm).
  - **Cập nhật thông tin:** Chỉnh sửa hoặc vô hiệu hóa thông tin nhân sự.
- Layout Draft:
  - **Trang Đăng nhập:** Giao diện đơn giản với form đăng nhập.
  - **Trang Quản lý Đặt bàn:** Hiển thị sơ đồ bàn, trạng thái và chức năng đặt bàn.
  - **Trang Báo cáo doanh thu:** Giao diện biểu đồ và danh sách chi tiết doanh thu theo thời gian.
  - **Trang Quản lý Nhân sự:** Danh sách nhân viên với các nút Thêm, Sửa, Xóa.
## Thành viên 2(Lê Văn Đức): Đăng ký, Thanh toán, Gọi món
###   **Nhiệm vụ:** Phụ trách các chức năng chính liên quan đến phục vụ khách hàng, bao gồm đăng ký tài khoản, gọi món và thanh toán hóa đơn.
Chức năng Modules:
- Đăng ký
  - **Đăng ký tài khoản:** Hỗ trợ nhân viên mới hoặc khách hàng đăng ký tài khoản.
  - **Xác thực thông tin:** Kiểm tra thông tin đăng ký (tài khoản, mật khẩu, thông tin cá nhân).
- Gọi món
  - **Xem thực đơn:** Hiển thị danh sách đồ uống và giá cả.
  - **Thêm món vào đơn hàng:** Hỗ trợ chọn món ăn, số lượng.
- Thanh toán
  - **Tạo hóa đơn:** Tự động tính tổng giá trị đơn hàng.
- Layout Draft:
  - **Trang Đăng ký:** Form đăng ký tài khoản với các trường cơ bản (họ tên, tài khoản, mật khẩu,...).
  - **Trang Gọi món:** Hiển thị thực đơn, nút chọn món, và bảng tổng đơn hàng.
  - **Trang Thanh toán:** Hiển thị hóa đơn với chi tiết món, tổng tiền.
##Tóm lại:
### Thành viên 1(Văn Đăng Hiếu):
Đăng nhập,
Đặt bàn,
Báo cáo doanh thu,
Quản lý nhân sự.

### Thành viên 2(Lê Văn Đức:
Đăng ký,
Thanh toán,
Gọi món.
