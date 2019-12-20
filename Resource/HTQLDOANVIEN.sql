CREATE DATABASE HTDIEMDANH


USE HTDIEMDANH


CREATE TABLE DOANVIEN(
	MASODV UNIQUEIDENTIFIER PRIMARY KEY,
	CMND VARCHAR(10),
	HOLOT NVARCHAR(100),
	TEN NVARCHAR(50),
	NAM BIT,
	NAMSINH VARCHAR(10),
	NGUYENQUAN NVARCHAR(300),
	DANTOC NVARCHAR(50),
	TONGIAO NVARCHAR(100),
	CMNV NVARCHAR(100),
	LLCT NVARCHAR(100),
	DONVI NVARCHAR(100),
	NGAYVAODOAN DATE,
	NGAYVAODANG DATE,
	GHICHU NVARCHAR(300),
	HASHING NVARCHAR(128),
	NGAYTAO DATE,
	NGAYCAPNHAT DATE
)


CREATE TABLE DAIHOI(
	MASODH UNIQUEIDENTIFIER PRIMARY KEY,
	CHUDE NVARCHAR(300),
	NGAY DATETIME,
	TRANGTHAI BIT,
	NGAYTAO DATE,
	NGAYCAPNHAT DATE
)


CREATE TABLE THAMDUDAIHOI(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	MASODV UNIQUEIDENTIFIER NOT NULL,
	MASODH UNIQUEIDENTIFIER NOT NULL,
	THOIGIANCOMAT DATETIME,
	CONSTRAINT FK_THAMDUDAIHOI_DOANVIEN FOREIGN KEY(MASODV) REFERENCES DOANVIEN(MASODV),
	CONSTRAINT FK_THAMDUDAIHOI_DAIHOI FOREIGN KEY(MASODH) REFERENCES DAIHOI(MASODH)
)

