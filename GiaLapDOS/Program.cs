using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaLapDOS
{
    class Program
    {
        static String[] Lenh = { "MD", "CD", "RD", "DEL", "REN", "TYPE" };
        static String duongdanhientai;
        static int TachChuoi(String S, ref String[] M)
        {
            M = S.Split(' ');
            return M.Length;
        }
        static int TimVT_X(String X)
        {
            for (int i = 0; i < Lenh.Length; i++)
                if (X == Lenh[i]) return i;
            return -1;
        }
        static void TaoThuMuc(String DirName)
        {
            try
            {
                Directory.CreateDirectory(DirName);
                Console.WriteLine("TAO DUONG DAN THANH CONG");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //Xây dựng thủ tục chuyển thư mục làm việc tương ứng với lệnh CD
        static void ChuyenThuMuc(String DirName)
        {
            try
            {
                Directory.SetCurrentDirectory(DirName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Xây dựng thủ tục xóa thư mục tương ứng với lệnh RD
        static void XoaThuMuc(String DirName)
        {
            try
            {
                Directory.Delete(duongdanhientai + "\\" + DirName);
                Console.WriteLine("XOA THU MUC THANH CONG");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void XoaTapTin(String DirName)
        {
            try
            {
                File.Delete(duongdanhientai + "\\" + DirName);
                Console.WriteLine("XOA TAP TIN THANH CONG");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DoiTenTapTin(String TenCu, String TenMoi)
        {
            try
            {
                Directory.Move(duongdanhientai + "\\" + TenCu, duongdanhientai + "\\" + TenMoi);
                Console.WriteLine("DOI TEN TAP TIN THANH CONG");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void XemNoiDungTapTin(String DirName)
        {
            try
            {
                StreamReader sr = File.OpenText(duongdanhientai + "\\" + DirName);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Gialap(String[] M)
        {

            int vt = TimVT_X(M[0]);

            switch (vt)
            {
                case 0:
                    TaoThuMuc(M[1]);
                    break;
                case 1:
                    ChuyenThuMuc(M[1]);
                    break;
                case 2:
                    XoaThuMuc(M[1]);
                    break;
                case 3:
                    XoaTapTin(M[1]);
                    break;
                case 4:
                    DoiTenTapTin(M[1], M[2]);
                    break;
                case 5:
                    XemNoiDungTapTin(M[1]);
                    break;
                default:
                    Console.WriteLine("Nham lenh roi!");
                    break;
            }
        }
        static void Main(string[] args)
        {
            String CHuoiLenh;
            String[] MangLenh = { };
            while (true)
            {
                duongdanhientai = Directory.GetCurrentDirectory();
                Console.WriteLine();
                Console.Write(duongdanhientai + ">");
                CHuoiLenh = Console.ReadLine();
                CHuoiLenh = CHuoiLenh.ToUpper();
                int dem = TachChuoi(CHuoiLenh, ref MangLenh);
                if (MangLenh[0] == "EXIT") return;
                Gialap(MangLenh);
            }
        }
    }
}
