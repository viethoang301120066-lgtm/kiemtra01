using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bai02
{
    public abstract class PhuongTien
    {
        private string _maPT;
        private string _tenHang;
        private int _namSanXuat;
        private decimal _giaGoc;

        public string MaPT
        {
            get => _maPT;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _maPT = "PT000";
                else
                    _maPT = value.Trim();
            }
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");
                _tenHang = value.Trim();
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");
                _namSanXuat = value;
            }
        }

        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                _giaGoc = value;
            }
        }

        public PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        public abstract decimal TinhGiaLanBanh();

        public virtual string GetInfo()
        {
            return $"Mã: {MaPT} | Hãng: {TenHang} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }

    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                _dungTichDongCo = value;
            }
        }

        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
                return GiaGoc + (GiaGoc * 0.12m) + (GiaGoc * 0.30m);

            return GiaGoc + (GiaGoc * 0.10m);
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} | Số chỗ: {SoChoNgoi} | Động cơ: {DungTichDongCo}L";
        }
    }

    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xylanh phải lớn hơn 0!");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
                return GiaGoc + (GiaGoc * 0.02m);

            return GiaGoc + (GiaGoc * 0.05m);
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} | Dung tích: {DungTichXylanh}cc";
        }
    }

    public class QuanLyPhuongTien
    {
        private List<PhuongTien> _danhSach = new List<PhuongTien>();

        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt != null)
                _danhSach.Add(pt);
        }

        public void DisplayAll()
        {
            foreach (var pt in _danhSach)
            {
                Console.WriteLine($"{pt.GetInfo()} => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        public PhuongTien FindMaxGiaLanBanh()
        {
            if (_danhSach.Count == 0) return null;

            PhuongTien maxPT = _danhSach[0];
            foreach (var pt in _danhSach)
            {
                if (pt.TinhGiaLanBanh() > maxPT.TinhGiaLanBanh())
                    maxPT = pt;
            }
            return maxPT;
        }

        public List<PhuongTien> SearchByName(string keyword)
        {
            return _danhSach.Where(p => p.TenHang.ToLower().Contains(keyword.ToLower())).ToList();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLyPhuongTien ql = new QuanLyPhuongTien();

            Console.WriteLine("=== TC01: KIỂM TRA VALIDATION NĂM SẢN XUẤT ===");
            try
            {
                OTo otoLoi = new OTo("PT01", "Toyota", 1850, 500000000m, 4, 1.5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Bắt ngoại lệ thành công: {ex.Message}");
            }

            Console.WriteLine("\n=== TC02: TÍNH GIÁ LĂN BÁNH Ô TÔ (5 CHỖ) ===");
            OTo oto5Cho = new OTo("OTO01", "Toyota", 2022, 1000000000m, 5, 2.0);
            Console.WriteLine($"Xe: {oto5Cho.TenHang} - Giá gốc: {oto5Cho.GiaGoc:N0} VNĐ");
            Console.WriteLine($"Giá lăn bánh thực tế: {oto5Cho.TinhGiaLanBanh():N0} VNĐ");

            Console.WriteLine("\n=== TC03: TÍNH GIÁ LĂN BÁNH XE MÁY (150CC) ===");
            XeMay xeMay150 = new XeMay("XM01", "Honda", 2023, 50000000m, 150);
            Console.WriteLine($"Xe: {xeMay150.TenHang} - Giá gốc: {xeMay150.GiaGoc:N0} VNĐ");
            Console.WriteLine($"Giá lăn bánh thực tế: {xeMay150.TinhGiaLanBanh():N0} VNĐ");

            Console.WriteLine("\n=== TC04: KIỂM TRA ĐA HÌNH VỚI LIST<PHUONGTIEN> ===");
            ql.AddPhuongTien(oto5Cho);
            ql.AddPhuongTien(xeMay150);
            ql.AddPhuongTien(new OTo("OTO02", "Ford", 2021, 800000000m, 16, 2.2));
            ql.AddPhuongTien(new XeMay("XM02", "Yamaha", 2022, 80000000m, 300));
            ql.DisplayAll();

            Console.WriteLine("\n=== TC05: TÌM PHƯƠNG TIỆN CÓ GIÁ LĂN BÁNH CAO NHẤT ===");
            var ptMax = ql.FindMaxGiaLanBanh();
            if (ptMax != null)
            {
                Console.WriteLine($"Phương tiện giá lăn bánh cao nhất: {ptMax.TenHang} ({ptMax.MaPT})");
                Console.WriteLine($"Giá: {ptMax.TinhGiaLanBanh():N0} VNĐ");
            }

            Console.WriteLine("\n=== TÌM KIẾM THEO HÃNG 'HONDA' ===");
            var ketQuaTim = ql.SearchByName("Honda");
            foreach (var item in ketQuaTim)
            {
                Console.WriteLine(item.GetInfo());
            }

            Console.ReadLine();
        }
    }
}