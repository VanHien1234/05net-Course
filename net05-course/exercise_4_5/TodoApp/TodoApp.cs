using System.Linq;
using System.Text.Json;

namespace exercise_4.Exercises;

public static class TodoApp
{
    public static void Run()
    {
        List<object> lstCongViec = new()
        {
            new { maCongViec = 1, tenCongViec = "Ăn sáng", trangThai = false },
            new { maCongViec = 2, tenCongViec = "Ăn trưa", trangThai = false }
        };

        while (true)
        {
            Method.HienThiMenuChucNang();
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
                    Method.ThemCongViecVaoDanhSach(ref lstCongViec);
                    break;
                case 2:
                    Method.HienThiCongViec(lstCongViec);
                    break;
                case 3:
                    Method.CapNhatThongTin(ref lstCongViec);
                    break;
                case 4:
                    Method.XoaCongViec(ref lstCongViec);
                    break;
                case 5:
                    Method.TimKiemCongViecTheoTen(lstCongViec);
                    break;
                case 6:
                    Method.TickHoanThanhCongViec(ref lstCongViec);
                    break;
                case 7:
                    Method.SapXepChuaHoanThanh(lstCongViec);
                    break;
                case 8:
                    Console.WriteLine(JsonSerializer.Serialize(lstCongViec));
                    Console.WriteLine("=> In nhanh danh sách JSON\n");
                    break;
                case 9:
                    Console.WriteLine("Thoát!");
                    return;
                default:
                    Console.WriteLine("Không có chức năng này, vui lòng chọn lại.\n");
                    break;
            }
        }
    }
}

public static class Method
{
    public static void HienThiMenuChucNang()
    {
        Console.WriteLine("------------- Hãy chọn 1 trong những chức năng sau của TodoApp -------------");
        Console.WriteLine("1. Thêm công việc vào danh sách");
        Console.WriteLine("2. Hiển thị danh sách công việc");
        Console.WriteLine("3. Cập nhật thông tin công việc");
        Console.WriteLine("4. Xóa công việc theo mã");
        Console.WriteLine("5. Tìm kiếm công việc theo tên");
        Console.WriteLine("6. Đánh dấu hoàn thành công việc");
        Console.WriteLine("7. Sắp xếp và hiển thị công việc chưa hoàn thành");
        Console.WriteLine("8. In danh sách JSON (tùy chọn)");
        Console.WriteLine("9. Thoát");
        Console.WriteLine("-----------------------*-*------------------------");
    }

    public static void ThemCongViecVaoDanhSach(ref List<object> lstCongViec)
    {
        Console.Write("Nhập mã công việc: ");
        string? maInput = Console.ReadLine();
        if (!int.TryParse(maInput, out int maCongViec))
        {
            Console.WriteLine("Mã công việc phải là số.\n");
            return;
        }

        bool existed = lstCongViec.Any(item => ((dynamic)item).maCongViec == maCongViec);
        if (existed)
        {
            Console.WriteLine("Mã công việc đã tồn tại.\n");
            return;
        }

        Console.Write("Nhập tên công việc: ");
        string tenCongViec = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(tenCongViec))
        {
            Console.WriteLine("Tên công việc không được để trống.\n");
            return;
        }

        var congViec = new { maCongViec, tenCongViec, trangThai = false };
        lstCongViec.Add(congViec);
        Console.WriteLine("=> Thêm thành công\n");
    }

    public static void HienThiCongViec(List<object> lstCongViec)
    {
        if (!lstCongViec.Any())
        {
            Console.WriteLine("Danh sách công việc trống.\n");
            return;
        }

        foreach (dynamic item in lstCongViec)
        {
            Console.WriteLine($"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
        }
        Console.WriteLine();
    }

    public static void CapNhatThongTin(ref List<object> lstCongViec)
    {
        Console.Write("Nhập mã công việc cần cập nhật: ");
        if (!int.TryParse(Console.ReadLine(), out int ma))
        {
            Console.WriteLine("Mã công việc phải là số.\n");
            return;
        }

        int index = lstCongViec.FindIndex(item => ((dynamic)item).maCongViec == ma);
        if (index == -1)
        {
            Console.WriteLine("Không tìm thấy công việc.\n");
            return;
        }

        dynamic current = lstCongViec[index];
        Console.Write("Nhập tên công việc mới: ");
        string tenMoi = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(tenMoi))
        {
            Console.WriteLine("Tên công việc mới không hợp lệ.\n");
            return;
        }

        lstCongViec[index] = new { maCongViec = current.maCongViec, tenCongViec = tenMoi, trangThai = current.trangThai };
        Console.WriteLine("=> Cập nhật thành công\n");
    }

    public static void XoaCongViec(ref List<object> lstCongViec)
    {
        Console.Write("Nhập mã công việc cần xóa: ");
        if (!int.TryParse(Console.ReadLine(), out int ma))
        {
            Console.WriteLine("Mã công việc phải là số.\n");
            return;
        }

        int index = lstCongViec.FindIndex(item => ((dynamic)item).maCongViec == ma);
        if (index == -1)
        {
            Console.WriteLine("Không tìm thấy công việc.\n");
            return;
        }

        lstCongViec.RemoveAt(index);
        Console.WriteLine("=> Xóa thành công\n");
    }

    public static void TimKiemCongViecTheoTen(List<object> lstCongViec)
    {
        Console.Write("Nhập từ khóa tìm kiếm: ");
        string keyword = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

        if (string.IsNullOrEmpty(keyword))
        {
            Console.WriteLine("Từ khóa không được để trống.\n");
            return;
        }

        var ketQua = lstCongViec
            .Select(item => (dynamic)item)
            .Where(item => item.tenCongViec.ToString().ToLowerInvariant().Contains(keyword))
            .ToList();

        if (!ketQua.Any())
        {
            Console.WriteLine("Không tìm thấy công việc nào chứa từ khóa.\n");
            return;
        }

        foreach (var item in ketQua)
        {
            Console.WriteLine($"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
        }
        Console.WriteLine();
    }

    public static void TickHoanThanhCongViec(ref List<object> lstCongViec)
    {
        Console.Write("Nhập mã công việc cần đánh dấu hoàn thành: ");
        if (!int.TryParse(Console.ReadLine(), out int ma))
        {
            Console.WriteLine("Mã công việc phải là số.\n");
            return;
        }

        int index = lstCongViec.FindIndex(item => ((dynamic)item).maCongViec == ma);
        if (index == -1)
        {
            Console.WriteLine("Không tìm thấy công việc.\n");
            return;
        }

        dynamic current = lstCongViec[index];
        lstCongViec[index] = new { maCongViec = current.maCongViec, tenCongViec = current.tenCongViec, trangThai = true };
        Console.WriteLine("=> Đánh dấu thành công\n");
    }

    public static void SapXepChuaHoanThanh(List<object> lstCongViec)
    {
        var chuaHoanThanh = lstCongViec
            .Select(item => (dynamic)item)
            .Where(item => item.trangThai == false)
            .ToList();

        if (!chuaHoanThanh.Any())
        {
            Console.WriteLine("Không còn công việc chưa hoàn thành.\n");
            return;
        }

        Console.Write("Chọn tiêu chí sắp xếp (a: tên, b: mã): ");
        string luaChon = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

        IEnumerable<dynamic> result = luaChon switch
        {
            "a" => chuaHoanThanh.OrderBy(item => item.tenCongViec),
            "b" => chuaHoanThanh.OrderBy(item => item.maCongViec),
            _ => Enumerable.Empty<dynamic>()
        };

        var resultList = result.ToList();

        if (!resultList.Any())
        {
            Console.WriteLine("Tiêu chí sắp xếp không hợp lệ.\n");
            return;
        }

        foreach (var item in resultList)
        {
            Console.WriteLine($"{item.maCongViec} - {item.tenCongViec} - {item.trangThai}");
        }
        Console.WriteLine();
    }
}

