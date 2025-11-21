using System.Linq;

namespace exercise_4.Exercises;

public static class MenuApp
{
    public static void Run()
    {
        List<object> dsMon = new();

        while (true)
        {
            MenuHelper.HienThiMenuChucNang();
            Console.Write("Chọn chức năng: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int selected))
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ.\n");
                continue;
            }

            Console.WriteLine();

            switch (selected)
            {
                case 1:
                    MenuHelper.ThemMonAn(ref dsMon);
                    break;
                case 2:
                    MenuHelper.HienThiMenu(dsMon);
                    break;
                case 3:
                    MenuHelper.XoaMonAn(ref dsMon);
                    break;
                case 4:
                    MenuHelper.CapNhatMonAn(ref dsMon);
                    break;
                case 5:
                    MenuHelper.SapXepTheoTen(dsMon);
                    break;
                case 6:
                    MenuHelper.SapXepTheoGia(dsMon);
                    break;
                case 7:
                    Console.WriteLine("Tạm biệt!");
                    return;
                default:
                    Console.WriteLine("Không có chức năng này, vui lòng chọn lại.\n");
                    break;
            }
        }
    }
}

internal static class MenuHelper
{
    public static void HienThiMenuChucNang()
    {
        Console.WriteLine("------------- Ứng dụng quản lý MENU -------------");
        Console.WriteLine("1. Thêm món ăn");
        Console.WriteLine("2. Hiển thị menu");
        Console.WriteLine("3. Xóa món ăn (theo chỉ số)");
        Console.WriteLine("4. Cập nhật món ăn (đổi tên/giá theo mã)");
        Console.WriteLine("5. Sắp xếp & hiển thị theo tên (tăng dần)");
        Console.WriteLine("6. Sắp xếp & hiển thị theo giá (tăng dần)");
        Console.WriteLine("7. Thoát");
        Console.WriteLine("-----------------------*-*------------------------");
    }

    public static void ThemMonAn(ref List<object> dsMon)
    {
        if (!TryNhapMa("Nhập Mã: ", dsMon, out int ma))
        {
            return;
        }

        Console.Write("Nhập Tên Món: ");
        string tenMon = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrEmpty(tenMon))
        {
            Console.WriteLine("Tên món không được để trống.\n");
            return;
        }

        if (KiemTraTenTrung(dsMon, tenMon))
        {
            Console.WriteLine("Tên món đã tồn tại.\n");
            return;
        }

        if (!TryNhapGia("Nhập Gía: ", out int gia))
        {
            return;
        }

        dsMon.Add(new { ma, tenMon, gia });
        Console.WriteLine("=> Thêm thành công\n");
    }

    public static void HienThiMenu(List<object> dsMon)
    {
        if (!dsMon.Any())
        {
            Console.WriteLine("Menu đang trống.\n");
            return;
        }

        for (int i = 0; i < dsMon.Count; i++)
        {
            dynamic mon = dsMon[i];
            Console.WriteLine($"{i + 1}/ [{mon.ma}] {mon.tenMon} - {mon.gia}");
        }
        Console.WriteLine();
    }

    public static void XoaMonAn(ref List<object> dsMon)
    {
        if (!dsMon.Any())
        {
            Console.WriteLine("Menu đang trống, không thể xóa.\n");
            return;
        }

        HienThiMenu(dsMon);
        Console.Write("Chọn món cần xóa: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int chiSo))
        {
            Console.WriteLine("Chỉ số phải là số.\n");
            return;
        }

        if (chiSo <= 0 || chiSo > dsMon.Count)
        {
            Console.WriteLine("Chỉ số không hợp lệ.\n");
            return;
        }

        dsMon.RemoveAt(chiSo - 1);
        Console.WriteLine("=> Xóa thành công\n");
    }

    public static void CapNhatMonAn(ref List<object> dsMon)
    {
        if (!dsMon.Any())
        {
            Console.WriteLine("Menu đang trống, không có dữ liệu để cập nhật.\n");
            return;
        }

        Console.Write("Nhập Mã cần cập nhật: ");
        if (!int.TryParse(Console.ReadLine(), out int ma))
        {
            Console.WriteLine("Mã phải là số.\n");
            return;
        }

        int index = dsMon.FindIndex(item => ((dynamic)item).ma == ma);
        if (index == -1)
        {
            Console.WriteLine("Không tìm thấy món ăn tương ứng.\n");
            return;
        }

        dynamic current = dsMon[index];

        Console.Write("Tên mới (bỏ trống nếu giữ nguyên): ");
        string tenMoi = (Console.ReadLine() ?? string.Empty).Trim();

        if (!string.IsNullOrEmpty(tenMoi))
        {
            if (KiemTraTenTrung(dsMon, tenMoi, ma))
            {
                Console.WriteLine("Tên món đã tồn tại.\n");
                return;
            }
        }
        else
        {
            tenMoi = current.tenMon;
        }

        Console.Write("Giá mới (bỏ trống nếu giữ nguyên): ");
        string? giaInput = Console.ReadLine();

        int giaMoi;
        if (string.IsNullOrWhiteSpace(giaInput))
        {
            giaMoi = current.gia;
        }
        else
        {
            if (!int.TryParse(giaInput, out giaMoi) || giaMoi <= 0)
            {
                Console.WriteLine("Giá mới phải là số nguyên dương.\n");
                return;
            }
        }

        dsMon[index] = new { ma = current.ma, tenMon = tenMoi, gia = giaMoi };
        Console.WriteLine("=> Cập nhật thành công\n");
    }

    public static void SapXepTheoTen(List<object> dsMon)
    {
        if (!dsMon.Any())
        {
            Console.WriteLine("Menu đang trống.\n");
            return;
        }

        var dsSapXep = dsMon
            .Select(item => (dynamic)item)
            .OrderBy(item => item.tenMon.ToString().Trim().ToLowerInvariant())
            .ToList();

        InDanhSach(dsSapXep);
    }

    public static void SapXepTheoGia(List<object> dsMon)
    {
        if (!dsMon.Any())
        {
            Console.WriteLine("Menu đang trống.\n");
            return;
        }

        var dsSapXep = dsMon
            .Select(item => (dynamic)item)
            .OrderBy(item => (int)item.gia)
            .ToList();

        InDanhSach(dsSapXep);
    }

    private static bool TryNhapMa(string prompt, List<object> dsMon, out int ma)
    {
        Console.Write(prompt);
        if (!int.TryParse(Console.ReadLine(), out ma))
        {
            Console.WriteLine("Mã món phải là số.\n");
            return false;
        }

        int maCanKiemTra = ma;
        bool trungMa = dsMon.Any(item => ((dynamic)item).ma == maCanKiemTra);
        if (trungMa)
        {
            Console.WriteLine("Mã món đã tồn tại.\n");
            return false;
        }

        return true;
    }

    private static bool TryNhapGia(string prompt, out int gia)
    {
        Console.Write(prompt);
        if (!int.TryParse(Console.ReadLine(), out gia) || gia <= 0)
        {
            Console.WriteLine("Giá phải là số nguyên dương.\n");
            return false;
        }

        return true;
    }

    private static bool KiemTraTenTrung(List<object> dsMon, string tenMon, int? maDangCapNhat = null)
    {
        string tenChuan = tenMon.Trim().ToLowerInvariant();
        return dsMon.Any(item =>
        {
            dynamic mon = item;
            if (maDangCapNhat.HasValue && mon.ma == maDangCapNhat.Value)
            {
                return false;
            }

            return string.Equals(mon.tenMon.ToString().Trim().ToLowerInvariant(), tenChuan, StringComparison.Ordinal);
        });
    }

    private static void InDanhSach(List<dynamic> ds)
    {
        for (int i = 0; i < ds.Count; i++)
        {
            dynamic mon = ds[i];
            Console.WriteLine($"{i + 1}/ [{mon.ma}] {mon.tenMon} - {mon.gia}");
        }
        Console.WriteLine();
    }
}

