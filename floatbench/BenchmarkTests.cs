using BenchmarkDotNet.Attributes;
using FixPointCSFixed64 = FixPointCS.Fixed64;
using FixedMathSharpFixed64 = FixedMathSharp.Fixed64;
using SoftFloat;
using FixMathNETFix64 = FixMath.NET.Fix64;
using LockstepMatchLFloat = Lockstep.Math.LFloat;
using Fmathffloat = ffloat;
using FydarFixed =  Fydar.Deterministic.Numerics.Fixed;
using DMathFixedPoint = DGPE.Math.FixedPoint.Fixed;
using DMathFixedTrig = DGPE.Math.FixedPoint.FixedTrig;

namespace floatbench.Tests;

[MemoryDiagnoser]
public class BenchmarkTests
{
    private sfloat sfloat_A;
    private sfloat sfloat_B;

    private FixedMathSharpFixed64 Fixed64_A;
    private FixedMathSharpFixed64 Fixed64_B;

    private long FixPointCS_A;
    private long FixPointCS_B;
    
    private FixMathNETFix64 FixMathNET_A;
    private FixMathNETFix64 FixMathNET_B;

    private LockstepMatchLFloat LFloat_A;
    private LockstepMatchLFloat LFloat_B;
    
    private Fmathffloat fmathf_A;
    private Fmathffloat fmathf_B;
    
    private FydarFixed Fydar_A;
    private FydarFixed Fydar_B;
    
    private DMathFixedPoint DMathFixed_A;
    private DMathFixedPoint DMathFixed_B;
    
    [GlobalSetup]
    public void Setup()
    {
        sfloat_A = (sfloat)10.5f;
        sfloat_B = (sfloat)5.25f;

        Fixed64_A = new FixedMathSharpFixed64(10.5);
        Fixed64_B = new FixedMathSharpFixed64(5.25);
        
        FixPointCS_A = FixPointCSFixed64.FromDouble(10.5);
        FixPointCS_B = FixPointCSFixed64.FromDouble(5.25);
        
        FixMathNET_A = (FixMathNETFix64)10.5f;
        FixMathNET_B = (FixMathNETFix64)5.25f;
        
        LFloat_A = (LockstepMatchLFloat)10.5f;
        LFloat_B = (LockstepMatchLFloat)5.25f;
        
        fmathf_A = (Fmathffloat)10.5f;
        fmathf_B = (Fmathffloat)5.25f;
        
        Fydar_A = (FydarFixed)10.5;
        Fydar_B = (FydarFixed)5.25;
        
        DMathFixed_A = (DMathFixedPoint)10.5;
        DMathFixed_B = (DMathFixedPoint)5.25;
    }
    
    #region Addition
    [Benchmark(Baseline = true)] 
    public sfloat sfloat_Addition()
    {
        return sfloat_A + sfloat_B;
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Addition()
    {
        return Fixed64_A + Fixed64_B;
    }
    
    [Benchmark]
    public long FixPointCS_Addition()
    {
        return FixPointCSFixed64.Add(FixPointCS_A, FixPointCS_B);
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_Addition()
    {
        return FixMathNET_A + FixMathNET_B;
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Addition()
    {
        return LFloat_A + LFloat_B;
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Addition()
    {
        return fmathf_A + fmathf_B;
    }
    
    [Benchmark]
    public FydarFixed Fydar_Addition()
    {
        return Fydar_A + Fydar_B;
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Addition()
    {
        return DMathFixed_A + DMathFixed_B;
    }
    #endregion
    
    #region Subtraction
    [Benchmark]
    public sfloat sfloat_Subtraction()
    {
        return sfloat_A - sfloat_B;
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Subtraction()
    {
        return Fixed64_A - Fixed64_B;
    }
    
    [Benchmark]
    public long FixPointCS_Subtraction()
    {
        return FixPointCSFixed64.Sub(FixPointCS_A, FixPointCS_B);
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_Subtraction()
    {
        return FixMathNET_A - FixMathNET_B;
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Subtraction()
    {
        return LFloat_A - LFloat_B;
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Subtraction()
    {
        return fmathf_A - fmathf_B;
    }
    
    [Benchmark]
    public FydarFixed Fydar_Subtraction()
    {
        return Fydar_A - Fydar_B;
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Subtraction()
    {
        return DMathFixed_A - DMathFixed_B;
    }
    #endregion
    
    #region Division
    [Benchmark]
    public sfloat sfloat_Division()
    {
        return sfloat_A / sfloat_B;
    }
    
    [Benchmark]
    public long FixPointCS_Division()
    {
        return FixPointCSFixed64.Div(FixPointCS_A, FixPointCS_B);
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Division()
    {
        return Fixed64_A / Fixed64_B;
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_Division()
    {
        return FixMathNET_A / FixMathNET_B;
    }
    [Benchmark]
    public LockstepMatchLFloat LFloat_Division()
    {
        return LFloat_A / LFloat_B;
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Division()
    {
        return fmathf_A / fmathf_B;
    }
    
    [Benchmark]
    public FydarFixed Fydar_Division()
    {
        return Fydar_A / Fydar_B;
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Division()
    {
        return DMathFixed_A / DMathFixed_B;
    }
    #endregion
    
    #region Multiplication
    [Benchmark]
    public sfloat sfloat_Multiplication()
    {
        return sfloat_A * sfloat_B;
    }

    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Multiplication()
    {
        return Fixed64_A * Fixed64_B;
    }
    
    [Benchmark]
    public long FixPointCS_Multiplication()
    {
        return FixPointCSFixed64.Mul(FixPointCS_A, FixPointCS_B);
    }

    [Benchmark]
    public FixMathNETFix64 FixMathNET_Multiplication()
    {
        return FixMathNET_A * FixMathNET_B;
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Multiplication()
    {
        return LFloat_A * LFloat_B;
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Multiplication()
    {
        return fmathf_A * fmathf_B;
    }
    
    [Benchmark]
    public FydarFixed Fydar_Multiplication()
    {
        return Fydar_A * Fydar_B;
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Multiplication()
    {
        return DMathFixed_A * DMathFixed_B;
    }
    #endregion
    
    #region Sqrt
    [Benchmark]
    public sfloat sfloat_Sqrt()
    {
        return libm.sqrtf(sfloat_A);
    }

    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Sqrt()
    {
        return FixedMathSharp.FixedMath.Sqrt(Fixed64_A);
    }

    [Benchmark]
    public long FixPointCS_Sqrt()
    {
        return FixPointCSFixed64.Sqrt(FixPointCS_A);
    }

    [Benchmark]
    public FixMathNETFix64 FixMathNET_Sqrt()
    {
        return FixMathNETFix64.Sqrt(FixMathNET_A);
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Sqrt()
    {
        return Lockstep.Math.LMath.Sqrt(LFloat_A);
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Sqrt()
    {
        return Fmathffloat.Sqrt(fmathf_A);
    }
    
    [Benchmark]
    public FydarFixed Fydar_Sqrt()
    {
        return FydarFixed.Sqrt(Fydar_A);
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Sqrt()
    {
        return DMathFixedPoint.Sqrt(DMathFixed_A);
    }
    #endregion
    
    #region Sin
    [Benchmark]
    public sfloat sfloat_Sin()
    {
        return libm.sinf(sfloat_A);
    }

    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Sin()
    {
        return FixedMathSharp.FixedMath.Sin(Fixed64_A);
    }

    [Benchmark]
    public long FixPointCS_Sin()
    {
        return FixPointCSFixed64.Sin(FixPointCS_A);
    }

    [Benchmark]
    public FixMathNETFix64 FixMathNET_Sin()
    {
        return FixMathNETFix64.Sin(FixMathNET_A);
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Sin()
    {
        return Lockstep.Math.LMath.Sin(LFloat_A);
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Sin()
    {
        return Fmathffloat.Sin(fmathf_A);
    }
    
    [Benchmark]
    public FydarFixed Fydar_Sin()
    {
        return FydarFixed.Sin(Fydar_A);
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Sin()
    {
        return DMathFixedTrig.Sin((int)DMathFixed_A);
    }
    #endregion
    
    #region Cos
    [Benchmark]
    public sfloat sfloat_Cos()
    {
        return libm.cosf(sfloat_A);
    }

    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Cos()
    {
        return FixedMathSharp.FixedMath.Cos(Fixed64_A);
    }

    [Benchmark]
    public long FixPointCS_Cos()
    { 
        return FixPointCSFixed64.Cos(FixPointCS_A);
    }

    [Benchmark]
    public FixMathNETFix64 FixMathNET_Cos()
    {
        return FixMathNETFix64.Cos(FixMathNET_A);
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Cos()
    {
        return Lockstep.Math.LMath.Cos(LFloat_A);
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Cos()
    {
        return Fmathffloat.Cos(fmathf_A);
    }
    
    [Benchmark]
    public FydarFixed Fydar_Cos()
    {
        return FydarFixed.Cos(Fydar_A);
    }

    [Benchmark]
    public DMathFixedPoint DMathFixed_Cos()
    {
        return DMathFixedTrig.Cos(10);
    }
    #endregion
    
    #region Abs
    [Benchmark]
    public sfloat sfloat_Abs()
    {
        return sfloat.Abs(sfloat_A);
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Abs()
    {
        return FixedMathSharp.FixedMath.Abs(Fixed64_A);
    }
    
    [Benchmark]
    public long FixPointCS_Abs()
    {
        return FixPointCSFixed64.Abs(FixPointCS_A);
    }

    [Benchmark]
    public FixMathNETFix64 FixMathNET_Abs()
    {
        return FixMathNETFix64.Abs(FixMathNET_A);
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Abs()
    {
        return Lockstep.Math.LMath.Abs(LFloat_A);
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Abs()
    {
        return Fmathffloat.Abs(fmathf_A);
    }
    
    [Benchmark]
    public FydarFixed Fydar_Abs()
    {
        return FydarFixed.Abs(Fydar_A);
    }

    [Benchmark]
    public DMathFixedPoint DMathFixed_Abs()
    {
        return DMathFixedPoint.Abs(DMathFixed_A);
    }
    #endregion
    
    #region ceil
    [Benchmark]
    public sfloat sfloat_ceil()
    {
        return libm.ceilf(sfloat_A);
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_ceil()
    {
        return FixedMathSharp.FixedMath.Ceiling(Fixed64_A);
    }
    
    [Benchmark]
    public long FixPointCS_ceil()
    {
        return FixPointCSFixed64.Ceil(FixPointCS_A);
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_ceil()
    {
        return FixMathNETFix64.Ceiling(FixMathNET_A);
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_ceil()
    {
        return Lockstep.Math.LMath.CeilToInt(LFloat_A);
    }
    
    [Benchmark]
    public Fmathffloat fmathf_ceil()
    {
        return Fmathffloat.Ceiling(fmathf_A);
    }

    [Benchmark]
    public FydarFixed Fydar_ceil()
    {
        var truncated = (FydarFixed)(int)Fydar_A;
        return Fydar_A > truncated ? truncated + (FydarFixed)1 : truncated;
    }

    [Benchmark]
    public DMathFixedPoint DMathFixed_ceil()
    {
        var truncated = (DMathFixedPoint)(int)DMathFixed_A;
        return DMathFixed_A > truncated ? truncated + (DMathFixedPoint)1 : truncated;
    }
    #endregion
    
    #region Pow
    [Benchmark]
    public sfloat sfloat_Pow()
    {
        return libm.powf(sfloat_A, sfloat_B);
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Pow()
    {
        return FixedMathSharp.FixedMath.Pow(Fixed64_A, Fixed64_B);
    }
    
    [Benchmark]
    public long FixPointCS_Pow()
    {
        return FixPointCSFixed64.Pow(FixPointCS_A, FixPointCS_B);
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_Pow()
    {
        return FixMathNETFix64.Pow(FixMathNET_A, FixMathNET_B);
    }
    #endregion
    
    #region Max
    [Benchmark]
    public sfloat sfloat_Max()
    {
        return sfloat.Max(sfloat_A, sfloat_B);
    }
    
    [Benchmark]
    public FixedMathSharpFixed64 FixedMathSharp_Max()
    {
        return FixedMathSharp.FixedMath.Max(Fixed64_A, Fixed64_B);
    }
    
    [Benchmark]
    public long FixPointCS_Max()
    {
        return FixPointCSFixed64.Max(FixPointCS_A, FixPointCS_B);
    }
    
    [Benchmark]
    public FixMathNETFix64 FixMathNET_Max()
    {
        return  (FixMathNET_A > FixMathNET_B) ? FixMathNET_A : FixMathNET_B;
    }
    
    [Benchmark]
    public LockstepMatchLFloat LFloat_Max()
    {
        return (LFloat_A > LFloat_B) ? LFloat_A : LFloat_B;
    }
    
    [Benchmark]
    public Fmathffloat fmathf_Max()
    {
        return Fmathffloat.Max( fmathf_A, fmathf_B);
    }
    
    [Benchmark]
    public FydarFixed Fydar_Max()
    {
        return FydarFixed.Max(Fydar_A, Fydar_B);
    }
    
    [Benchmark]
    public DMathFixedPoint DMathFixed_Max()
    {
        return (DMathFixed_A > DMathFixed_B) ? DMathFixed_A : DMathFixed_B;
    }
    #endregion
}