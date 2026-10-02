### Câu 1: Sự khác nhau giữa Value Types và Reference Types trong C# về cơ chế lưu trữ vùng nhớ (Stack vs Heap)
- **Value Types (Kiểu giá trị):**
  - Gồm: `int`, `float`, `double`, `bool`, `char`, `struct`, `enum`,...
  - **Vùng nhớ:** Thường được cấp phát và lưu trữ trực tiếp trên bộ nhớ **Stack** (khi là biến cục bộ). Biến lưu trực tiếp giá trị thực tế của dữ liệu.
  - **Đặc điểm:** Tốc độ truy xuất nhanh, tự động giải phóng khi rời khỏi phạm vi (scope). Khi gán biến này cho biến khác, dữ liệu sẽ được sao chép nguyên bản (copy-by-value).
- **Reference Types (Kiểu tham chiếu):**
  - Gồm: `class`, `interface`, `delegate`, `string`, `array`, `object`,...
  - **Vùng nhớ:** Dữ liệu thực tế của đối tượng được lưu trên vùng nhớ **Heap**. Biến thực chất chỉ là một con trỏ/tham chiếu được lưu trên **Stack** trỏ tới địa chỉ ô nhớ tương ứng trên Heap.
  - **Đặc điểm:** Quản lý việc thu hồi bộ nhớ tự động bởi Garbage Collector (GC). Khi gán biến này cho biến khác, chỉ địa chỉ tham chiếu được sao chép (cả hai cùng trỏ tới một đối tượng).


### Câu 2: Tính năng Init-only Properties (init) trong C# 9/10 khác gì so với set thông thường? Trường hợp sử dụng thực tế
- **Khác biệt:**
  - `set`: Cho phép gán hoặc thay đổi giá trị của thuộc tính bất kỳ lúc nào trong suốt vòng đời của đối tượng.
  - `init`: Chỉ cho phép gán giá trị tại thời điểm khởi tạo đối tượng (qua Constructor hoặc Object Initializer `{ Prop = value }`). Sau khi đối tượng được tạo xong, thuộc tính trở thành `read-only` và không thể bị sửa đổi.
- **Trường hợp sử dụng thực tế:**
  - Thiết kế các đối tượng bất biến (**Immutable Objects**) hoặc **Data Transfer Objects (DTO)**.
  - Đảm bảo tính toàn vẹn dữ liệu: ví dụ các trường định danh như `Id`, `MaSinhVien`, `NgaySinh` chỉ được gán đúng 1 lần khi tạo và không được phép sửa đổi trong quá trình xử lý tiếp theo.


### Câu 3: Phân biệt phương thức virtual ở lớp cha và phương thức override ở lớp con khi triển khai tính Đa hình (Polymorphism)
- **`virtual` (Lớp cha):**
  - Đánh dấu một phương thức có thể bị ghi đè bởi lớp dẫn xuất (lớp con).
  - Phương thức này vẫn có thân hàm mặc định để lớp cha có thể tự thực thi nếu lớp con không ghi đè.
- **`override` (Lớp con):**
  - Dùng để định nghĩa lại (ghi đè) logic xử lý của phương thức `virtual` (hoặc `abstract`) từ lớp cha.
- Khi gọi phương thức thông qua con trỏ/tham chiếu của lớp cha trỏ tới đối tượng lớp con, phương thức `override` ở lớp con sẽ được ưu tiên thực thi tại thời điểm chạy (Runtime Polymorphism).


### Câu 4: Tại sao thành phần static trong Lớp không thể truy xuất thông qua thể hiện (Object Instance) tạo bằng toán tử new?
- **Thuộc phạm vi Lớp (Class-level):** Thành phần `static` (biến, phương thức) gắn liền trực tiếp với bản thân Lớp (kiểu dữ liệu) chứ không thuộc về bất kỳ đối tượng cụ thể nào. Bộ nhớ cho thành phần `static` được cấp phát duy nhất một lần khi Lớp được nạp vào bộ nhớ.
- **Tính độc lập:** Các thể hiện tạo bằng `new` sở hữu trạng thái và bộ nhớ riêng biệt (Instance State), trong khi `static` là dữ liệu dùng chung cho toàn bộ chương trình.
- **Quy tắc thiết kế ngôn ngữ C#:** C# cố tình cấm truy cập thành phần `static` qua `instance` (khác với Java) để:
  - Tránh hiểu lầm rằng thành phần đó thuộc về riêng đối tượng đó.
  - Làm rõ nghĩa code: buộc lập trình viên phải gọi tường minh qua tên lớp (ví dụ: `ClassName.StaticMethod()`).
