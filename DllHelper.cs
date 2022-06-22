using System.Runtime.InteropServices;

class DllHelper {

    [DllImport("MyDll.dll", EntryPoint="?FormatDoubleValue@@YAPEADNH@Z")]
    static extern IntPtr FormatDoubleValue(double a, int Fixed);

    public static string GetFormattedPrice(double p) {
        // 保留两位小数
        IntPtr _ptr = FormatDoubleValue(p, 2);
        string s = Marshal.PtrToStringAnsi(_ptr);

        return s;
    }
}