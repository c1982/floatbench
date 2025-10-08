using System.Runtime.InteropServices;

namespace Fydar.Deterministic.Numerics.Internal;

internal static class MathEngine
{
    internal static readonly ushort[] sin;
    internal static readonly Fixed[] tan;
    internal static readonly int[] asin;
    internal static readonly ushort[] sqrt;

    static MathEngine()
    {
        sin = LoadUShorts("Fydar.Deterministic.Numerics.LUT.Sin.bin");
        asin = LoadIntegers("Fydar.Deterministic.Numerics.LUT.Asin.bin");
        tan = Load("Fydar.Deterministic.Numerics.LUT.Tan.bin");
        sqrt = LoadUShorts("Fydar.Deterministic.Numerics.LUT.Sqrt.bin");
    }
    
    private static byte[] ReadAllBytes(string resourceName)
    {
        return File.ReadAllBytes(resourceName);
    }

    private static ushort[] LoadUShorts(string resourceName)
    {
        var ddd = ReadAllBytes("../../../libs/Fydar/LUT/Sin.bin");
        return MemoryMarshal.Cast<byte, ushort>(ddd).ToArray();
    }

    private static int[] LoadIntegers(string resourceName)
    {
        var ddd = ReadAllBytes("../../../libs/Fydar/LUT/Asin.bin");
        return MemoryMarshal.Cast<byte, int>(ddd).ToArray();
    }

    private static Fixed[] Load(string resourceName)
    {
        var ddd = ReadAllBytes("../../../libs/Fydar/LUT/Tan.bin");
        return MemoryMarshal.Cast<byte, Fixed>(ddd).ToArray();
    }
}
