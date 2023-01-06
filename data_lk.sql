drop DATABASE lkshop 
GO
CREATE DATABASE lkshop
GO
use lkshop
GO
CREATE TABLE ncc(
    id int IDENTITY(1,1) PRIMARY key,
    ten_ncc NVARCHAR(255),
    dia_Chi ntext,
    sdt VARCHAR(12),
    email VARCHAR(100),
    ten_NH VARCHAR(100),
    stk VARCHAR(20),
    trang_Thai bit
)
go
CREATE TABLE nhan_Vien(
    id int IDENTITY(1,1) PRIMARY KEY,
    ho_Ten NVARCHAR(255),
    ngay_Sinh DATE,
    gioi_Tinh bit,
    sdt VARCHAR(12),
    email VARCHAR(100),
    dia_Chi NVARCHAR(2000),
    cccd VARCHAR(20),
    chuc_Vu NVARCHAR(50),
    ten_NH VARCHAR(100),
    stk VARCHAR(20),
    trang_thai bit
)
CREATE TABLE tai_Khoan(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_NV int ,
    username VARCHAR(100),
    password VARCHAR(100),
    trang_thai BIT
)
--CONSTRAINT fk_tai_khoan_nhanvien FOREIGN KEY REFERENCES nhan_Vien(id)
go
CREATE TABLE loai_sp(
    id int IDENTITY(1,1) PRIMARY KEY,
    ten_loai NVARCHAR(255),
    mo_ta ntext,
    trang_thai bit
)
go
CREATE TABLE dong_sp(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_loai int,
    ten_dong NVARCHAR(255),
    nam_sx int,
    hang_sx NVARCHAR(255),
    trang_thai BIT
)
go
CREATE TABLE sp(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_dong int,
    ten_SP NVARCHAR(255),
    thong_so_KT ntext,
    mo_ta ntext,
    trang_Thai BIT
)
go
CREATE TABLE kho(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_SP int,
    tinh_Trang TINYINT,
    trang_Thai BIT
)
go
CREATE TABLE khach_hang(
    id int IDENTITY(1,1) PRIMARY KEY,
    ho_Ten NVARCHAR(255),
    nam_Sinh smallint,
    sdt VARCHAR(20),
    email VARCHAR(100),
    gioi_Tinh bit,
    trang_Thai bit
)
go
CREATE TABLE tai_KhoanKH(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_KH int CONSTRAINT fk_tai_khoan_khachhang FOREIGN KEY REFERENCES khach_hang(id),
    username VARCHAR(100),
    password VARCHAR(100),
    trang_thai BIT
)
go
CREATE TABLE dia_chi(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_KH int, 
    ho_ten NVARCHAR(100),
    sdt VARCHAR(12),
    tinh NVARCHAR(100),
    huyen NVARCHAR(100),
    xa NVARCHAR(100),
    chi_tiet NVARCHAR(255),
    trang_thai bit)
go

SELECT * FROM khach_hang
CREATE TABLE gio_hang(
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_KH int,
    ngay_Dat date,
    trang_thai BIT)
go
CREATE TABLE ct_gio_hang(
    id int IDENTITY(1,1) PRIMARY key,
    id_gio_hang int,
    id_kho int,
    gia int,
    trang_thai BIT)
go
ALTER TABLE ct_gio_hang add id_Sp int
CREATE TABLE anh_sp(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_SP int, 
    duong_dan VARCHAR(255),
    trang_thai bit)
go
CREATE TABLE hoa_don_ban(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_KH int,
    id_dia_chi int,
    ngay_dat date,
    tinh_trang_dh SMALLINT,
    trang_thai bit)
go
CREATE TABLE ct_hoa_don_ban(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_hoa_don_ban int,
    id_kho int,
    gia int,
    trang_thai bit)
go
ALTER TABLE ct_hoa_don_ban add id_SP int
CREATE TABLE hoa_don_nhap(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_ncc int,
    id_nhan_vien int,
    ngay_nhap date,
    trang_thai BIT)
go
CREATE TABLE ct_hoa_don_nhap(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_hoa_don_nhap int,
    id_kho int,
    gia_Nhap int,
    trang_thai bit)
go
CREATE TABLE gia(
    id int IDENTITY(1,1) PRIMARY KEY,
    id_SP INT,
    gia_ban int,
    ngay_AD date,
    ngay_KT DATE,
    trang_thai bit)
go



ALTER TABLE dong_sp ADD CONSTRAINT fk_dong_sp_loai_sp FOREIGN KEY (id_loai) REFERENCES loai_sp(id)
go
ALTER TABLE sp ADD CONSTRAINT fk_sp_dong_sp FOREIGN KEY (id_dong) REFERENCES dong_sp(id)
go
ALTER TABLE anh_sp ADD CONSTRAINT fk_anh_sp_sp FOREIGN KEY (id_SP) REFERENCES sp(id)
go
ALTER TABLE kho ADD CONSTRAINT fk_kho_sp FOREIGN KEY (id_SP) REFERENCES sp(id)
go
ALTER TABLE gio_hang ADD CONSTRAINT fk_kh_gio_hang FOREIGN KEY (id_KH) REFERENCES khach_hang(id)
go
ALTER TABLE dia_Chi ADD CONSTRAINT fk_dia_chi_kh FOREIGN KEY (id_KH) REFERENCES khach_hang(id)
go
ALTER TABLE ct_gio_hang ADD CONSTRAINT fk_ctgh_gio_hang FOREIGN KEY (id_gio_hang) REFERENCES gio_hang(id)
go
ALTER TABLE hoa_don_ban ADD CONSTRAINT fk_hoa_don_ban_kh FOREIGN KEY (id_KH) REFERENCES khach_hang(id)
go
ALTER TABLE hoa_don_ban ADD CONSTRAINT fk_hoa_don_ban_dia_chi FOREIGN KEY (id_dia_chi) REFERENCES dia_chi(id)
go
ALTER TABLE ct_hoa_don_ban ADD CONSTRAINT fk_cthdb_hoa_don_ban FOREIGN KEY (id_hoa_don_ban) REFERENCES hoa_don_ban(id)
go
ALTER TABLE hoa_don_nhap ADD CONSTRAINT fk_hoa_don_nhap_ncc FOREIGN KEY (id_ncc) REFERENCES ncc(id)
go
ALTER TABLE hoa_don_nhap ADD CONSTRAINT fk_hoa_don_nhap_nhan_vien FOREIGN KEY (id_nhan_vien) REFERENCES nhan_Vien(id)
go
ALTER TABLE ct_hoa_don_nhap ADD CONSTRAINT fk_cthdn_hoa_don_nhap FOREIGN KEY (id_hoa_don_nhap) REFERENCES hoa_don_nhap(id)
go
ALTER TABLE ct_hoa_don_nhap ADD CONSTRAINT fk_cthdn_kho FOREIGN KEY (id_kho) REFERENCES kho(id)
go
ALTER TABLE gia ADD CONSTRAINT fk_gia_sp FOREIGN KEY (id_SP) REFERENCES sp(id)
go



insert loai_sp (ten_loai,mo_ta,trang_thai)
values 
(N'Kit phát triển',N'',1),
(N'cảm biến',N'',1),
(N'Thiết bị chế tạo',N'',1),
(N'Dụng cụ, phụ kiện',N'',1),
(N'Module ứng dụng',N'',1),
(N'Dụng cụ cẩm tay',N'',1),
(N'Nguồn điện',N'',1)
go
--Đã chạy
insert dong_sp(id_loai,ten_dong,hang_sx,trang_thai) VALUES
--(1,N'AVR',N'Atmel',1),
(1,N'Arduino',N'',1),
(1,N'Raspberry',N'',1),
(1,N'PIC',N'',1),
-------------------------
(2,N'Cảm Biến Nhiệt Độ',N'',1),
(2,N'Cảm Biến Độ Ẩm',N'',1),
(2,N'Cảm Biến Chuyển Động',N'',1),
(2,N'Cảm Biến Ánh Sáng',N'',1),
(2,N'Cảm Biến Khí',N'',1),
(2,N'Cảm Biến Siêu Âm',N'',1),
(2,N'Cảm Biến Âm Thanh',N'',1),
(2,N'Cảm Biến Nước',N'',1),
(2,N'Cảm Biến Áp Suất',N'',1),
(2,N'Cảm Biến Khoảng Cách',N'',1),
(2,N'Cảm Biến Rung',N'',1),
-------------------------
(3,N'Thiết Bị Hàn',N'',1),
(3,N'Động Cơ ',N'',1),
(3,N'PCB/BOARD TEST',N'',1),
-------------------------
(4,N'Kính Lúp',N'',1),
(4,N'Kìm/Tua Vít',N'',1),
(4,N'Đồng Hồ đo',N'',1),
----------------------------
(5,N'Module Etherlet/Wifi',N'',1),
(5,N'Module Camera',N'',1),
(5,N'Module Bluetooth',N'',1),
(5,N'Module Sim GPRS/3G',N'',1),
(5,N'Module VGA',N'',1),
(5,N'Module Vân Tay',N'',1),
----------------------------
(7,N'Nguồn Adpter',N'',1),
(7,N'Biến Áp',N'',1),
(7,N'Biến Áp',N'',1),
(7,N'Pin/Ắc Quy',N'',1),
(7,N'Bộ Chuyển Đổi Điện',N'',1)
GO
insert sp (id_dong,ten_SP,thong_so_KT,mo_ta,trang_Thai) VALUES
(1,N'KIT AVR ATmega16/32 Socket (BH 06 Tháng)',N'Chip hỗ trợ: ATmega16 / ATmega32 và chip tương thích với các chip trên,
Chế độ cung cấp điện: cung cấp nguồn cho đầu nối bộ chuyển đổi nguồn hoặc nguồn cấp pin mở rộng bên ngoài (không hỗ trợ cung cấp điện cho giao diện tải xuống của ISP),
Sử dụng đầu jack Dc 5.5*2.1,
Mở rộng ra bên ngoài 4 kênh VCC, GND.,
Reset: đặt lại bật nguồn và đặt lại nút,
Chỉ báo nguồn (D1) và chỉ báo hoạt động của chương trình (D2),Trọng lượng: 45g,Kích thước: 9x 4x2.5 cm',N'Kit AVR ATmega 16/32 Socket được sử dụng nạp chương trình cho IC. Mạch nạp sử dụng IC ATmega 16 và ATmega32, tương thích với mạch nạp USBisp. KIT có hệ thống jump nổi tạo điều kiện thuận lợi cho việc kết nối linh hoạt các thiết bị với nhau.',1),

(1,N'KIT AVR ATmega8 Socket ( BH 06 Tháng)',N'Sử dụng cho các dòng:ATMEGA8, ATMEGA48, ATMEGA88, ATMEGA328, ATMEGA168;Nạp mạch qua USBisp (hoặc các chuẩn nạp khác có hỗ trợ ISP);Socket 28P;Nguồn: 5VDC;Các 23 chân IO là tất cả các rút ra;Cổ điển ATmega8 hệ thống, loại bỏ những rắc rối của hàn;Tinh thể dao động: sử dụng vòng ổ cắm lỗ phương pháp hàn, đó là thuận tiện cho người mua để thay thế tinh thể dao động, và mặc định là 8 m tinh thể dao động;Hỗ trợ chip: ATmega8;Nguồn cung cấp: ISP tải về cung cấp điện và mở rộng cung cấp điện pin 2 chọn một 6. mở rộng 3 VCC, GND, như thể hiện trong Hình pin;Thiết lập lại: điện trên thiết lập lại và nút reset;Bên ngoài các mở rộng của 4 đèn LED, dễ dàng để gỡ lỗi và sử dụng;Chỉ số sức mạnh (DS1);ISP tiêu chuẩn giao diện tải về, các sử dụng của cửa hàng của chúng tôi 51/avr downloader có thể được tải về để các hệ thống chương trình để tạo thuận lợi cho tải về (hội đồng quản trị không cần phải điện một mình, hỗ trợ ISP tải về giao diện cung cấp điện).',N'',1),

(2,N'Kit EASY 8051',N'Sử dụng Socket, dễ dàng tháo lắp chíp 8051.;Mức điện áp: 3,3V, 5V có IC ổn áp AMS 1117-3.3V, LM7805;Nguồn cung cấp: Adapter, USB hoặc sử dụng trực tiếp nguồn từ mạch nạp;Giao tiếp máy tính dùng RS232;Hỗ trợ màn hình LCD1602 và LCD12864;Đo nhiệt độ DS18b20;Sử dụng hồng ngoại H1838;Kit 8051 sử dụng còi chíp 5V;Chống ngắn mạch;Relay 5VDC-220VAC;Trọng lượng: 120g',N'Kit EASY 8051 là board mạch lý tưởng để học lập trình 8051 cho những người mới bắt đầu, chưa có nhiều kinh nghiệm trong lập trình vi điều khiển. Nó có đầy đủ ngoại vi phần cứng cho phép nghiên cứu tất cả các tính năng của vi điều khiển 8051. Ngoài ra, board mạch cũng đưa ra các jump cắm giúp dễ dàng thực hiện các dự án mở rộng về sau.',1),
(2,N'Kit Arduino Pro Mini Atmega328 5V/16M (BH 06 Tháng)',N'- ATmega328-AU;- Nguồn vào đề nghị : 6-9V;- Dòng tối đa chân 5V : 500mA;- Dòng tối đa chân 3.3V : 50mA;- Dòng tối đa chân I/O : 40mA;- 14 chân Digital I/O  (6 chân PWM);- 8 chân Analog Inputs;- 32k Flash Memory;- 16Mhz Clock Speed',N'Kit Arduino Pro Mini là Kit Phát triển được sử dụng nhiều trong các mạch điều khiển ứng dụng vì giá thành rẻ và thiết kế rất nhỏ gọn',1),

(2,N'Kit Arduino Nano CH340 (BH 06 Tháng)',N'IC chính: ATmega328P;IC nạp và giao tiếp UART: CH340;Điện áp hoạt động: 5V - DC;Điện áp đầu vào khuyên dùng: 7-12V - DC;Điện áp đầu vào giới hạn: 6-20V - DC;Số chân Digital I/O: 14 (trong đó có 6 chân PWM);Số chân Analog: 8 (độ phân giải 10bit, nhiều hơn Arduino Uno 2 chân);Dòng tiêu thụ: 30mA;Dòng tối đa trên mỗi chân I/O: 40mA;Dòng ra tối đa (5V): 500 mA;Dòng ra tối đa (3.3V):50 mA;Bộ nhớ flash : 32KB với 2KB dùng bởi bootloader;SRAM: 2KB;EEPROM: 1KB;Xung nhịp: 16MHz;Kích thước: 0.73" x 1.70" (1.85cm x 4.3cm);Trọng lượng: 5g',N'Board Arduino Nano là một trong những phiên bản nhỏ gọn của board Arduino. Arduino Nano có đầy đủ các chức năng và chương trình có trên Arduino Uno do cùng sử dụng MCU ATmega328P. Nhờ việc sử dụng IC dán của ATmega328P thay vì IC chân cắm nên Arduino Nano có thêm 2 chân Analog so với Arduino Uno. Arduino Nano được kết nối với máy tính qua cổng Mini USB và sử dụng chip CH340 để chuyển đổi USB sang UART thay vì dùng chip ATmega16U2 để giả lập cổng COM như trên Arduino Uno hay Arduino Mega, nhờ vậy giá thành sản phẩm được giảm mà vẫn giữ nguyên được tính năng, giúp Arduino giao tiếp được với máy tính, từ đó thực hiện việc lập trình.Lưu ý: Mạch chưa hàn sẵn',1),

(2,N'KIT Arduino Pro Micro 5V/16Mhz ATmega32U4 (BH 06 Tháng)',N'Chíp: Atmega32U4;Nguồn vào: 5~9V;Bộ nhớ Flash: 32Kb;SRAM: 2Kb;EEPROM: 1kb;Tần số hoạt động: 16MHz;Số chân I/O: 14 chân (4 chân PWM);Số chân Analog: 4 chân;Kích thước: 33 x 18x 6mm;Khối lượng: 15g',N'KIT Arduino Pro Micro là kit cải tiển của kit Arduino Pro mini, kit sử dụng chíp Atmega32U4 giống như Aruino Leonardo được tích hợp sẵn giao tiếp usb nên tối ưu được kích thước mà không cần sử dụng chip USB khác. Kit bao gồm 20 chân Input /Output (trong đó có 7 chân PWM và 12 chân Analog), tần số hoạt động 16MHZ, Micro USB, Chân ICSP, và nút reset. Kit có tất cả các chức năng của vi xử lý. Bên cạnh đó kit có thể sử dụng các chức năng như giả lập bàn phím, chuột vitual Serial/ COM port mà các loại kit thông dụng như Arduino Uno hay Arduino Mega không có. Ngoài ra chức năng chống ngược điện áp giúp kit sử dụng bền hơn các phiên bản khác.',1),

(2,N'Kit Arduino Leonardo (BH 06 Tháng)',N'Vi điều khiển: ATmega32u4 (họ 8bit);Điện áp hoạt động: 5V – DC;Tần số hoạt động: 16 MHz;Dòng tiêu thụ ở các chân I/O: 40mA;Điện áp vào khuyên dùng: 7-12V – DC;Điện áp vào giới hạn: 6-20V – DC;Số chân Digital I/O: 14 (7 chân PWM);Số chân Analog: 12 (các chân PWM có thể dùng như chân Analog bình thường - nghĩa là có thể dùng Analog read) (độ phân giải 10bit);Dòng tối đa trên mỗi chân I/O: 40 mA;Dòng ra tối đa (5V): 500 mA;Dòng ra tối đa (3.3V): 50 mA;Bộ nhớ flash: 32 KB (ATmega32u4) với 4KB dùng bởi bootloader;SRAM: 2.5 KB (ATmega32u4);EEPROM: 1 KB (ATmega32u4);Kích thước: 68.6mm x 53.3mm',N'Nếu bạn đã sử dụng Arduino Uno R3 thành thạo thì sử dụng kit này không thể nào là khó khăn với bạn. Với cấu hình mạnh mẽ hơn, có 7 các chân PWM có thể dùng như chân Analog bình thường - nghĩa là có thể dùng Analog read, SRAM cũng lớn hơn 0.5 KB và điện áp tối đa trên các chân I/O cũng tăng lên thành 40 mA. Như vậy nó rất phù hợp cho bạn sử dụng trong những dự án IoT như Smart Home.Với Kit này bạn có thể có nhiều dự án thú vi như:;Chế tạo ô tô điều khiển từ xa.;Chế tạo ra trung tâm điều khiển nhà thông minh.;Chế tạo 1 mạch điều khiển dây led trang trí ngày tết.;Và còn nhiều dự án thú vị đang đợi bạn khám phá với arduino leonardo.',1)
-----------------------------
--Đã thêm

insert anh_sp(id_SP,duong_dan,trang_thai) VALUES
(1,'avratmega16-32socket-1.JPG',1),
(1,'avratmega16-32socket-2.JPG',1),
(1,'avratmega16-32socket-3.JPG',1),
(1,'avratmega16-32socket-4.JPG',1),
(1,'avratmega16-32socket-5.JPG',1),
(1,'avratmega16-32socket-6.JPG',1),
(2,'avr-atmega8-socket-1.JPG',1),
(2,'avr-atmega8-socket-2.JPG',1),
(2,'avr-atmega8-socket-3.JPG',1),
(2,'avr-atmega8-socket-4.JPG',1)
INSERT kho (id_SP,tinh_Trang,trang_Thai) VALUES
(1,1,1),
(1,1,1),
(1,1,1),
(1,1,1),
(1,1,1),
(1,1,1),
(1,1,1)
INSERT gia (id_SP,gia_ban,ngay_AD,trang_thai) VALUES
(1,250000,'12/22/2022',1),
(2,200000,'12/22/2022',1)
-------------------đã chạy
insert nhan_Vien (ho_Ten,ngay_Sinh,gioi_Tinh,sdt,email,cccd,chuc_Vu,ten_NH,stk,dia_Chi,trang_thai)
VALUES
(N'Hoàng Qúy Quỳnh','07-15-2001','1','0979641743','anhninh111111@gmail.com','033201003377','ql','','',N'Văn Giang - Hưng Yên',1)
insert tai_khoan(id_NV,username,password,trang_thai)
VALUES
(1,'hqquynh','123456',1)

INSERT khach_hang (ho_Ten,nam_Sinh,sdt,email,gioi_Tinh,trang_Thai)
VALUES
(N'Hoàng Qúy Quỳnh',2001,'0979641743','anhninh111111@gmail.com',1,1)
GO
INSERT tai_KhoanKH (id_KH,username,[password],trang_thai) VALUES
(1,'hqquynh123','123456',1)

INSERT dia_chi(id_KH,ho_ten,sdt,tinh,huyen,xa,chi_tiet,trang_thai) VALUES
(1,N'Hoàng Sỹ Quý','0979386029',N'Hưng Yên',N'Văn Giang',N'Tân Tiến',N'Đội 13, thôn Đa Ngưu',1)