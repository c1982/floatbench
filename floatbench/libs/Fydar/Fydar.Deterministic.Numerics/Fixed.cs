using Fydar.Deterministic.Numerics.Internal;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Fydar.Deterministic.Numerics;

/// <summary>
/// <para>Represents a deterministic fixed-point number.</para>
/// </summary>
/// <remarks>
/// <para>The <see cref="Fixed"/> value type represents a 64-bit number with values ranging <b>from</b> <c>-140,737,488,355,328.00000</c> <b>to</b> <c>-140,737,488,355,328.00000</c>.</para>
/// </remarks>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{ToString(),nq}")]
public readonly struct Fixed :
    IEquatable<Fixed>,
    IComparable,
    IComparable<Fixed>,
    IFormattable
{
    /// <summary>
    /// <para>Represents a zero value.</para>
    /// </summary>
    /// <value><c>0</c></value>
    /// <seealso cref="MinValue"/>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed Zero { get; } = new(0L);

    /// <summary>
    /// <para>Represents a one value.</para>
    /// </summary>
    /// <value><c>1</c></value>
    /// <seealso cref="MinValue"/>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed One { get; } = new(65536L);

    /// <summary>
    /// <para>Represents the smallest possible value of <see cref="Fixed"/>.</para>
    /// </summary>
    /// <value><c>-140,737,488,355,328.00000</c></value>
    /// <seealso cref="MaxValue"/>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed MinValue { get; } = new(long.MinValue);

    /// <summary>
    /// <para>Represents the largest possible value of <see cref="Fixed"/>.</para>
    /// </summary>
    /// <value><c>140,737,488,355,328.00000</c></value>
    /// <seealso cref="MinValue"/>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed MaxValue { get; } = new(long.MaxValue);

    /// <summary>
    /// <para>Represents the smallest positive <see cref="Fixed"/> value that is greater than <see cref="Zero"/>.</para>
    /// </summary>
    /// <value><c>0.00099</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed Epsilon { get; } = new(1L);

    /// <summary>
    /// <para>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, &#960;.</para>
    /// </summary>
    /// <value><c>3.14159</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed Pi { get; } = new(205887L);

    /// <summary>
    /// <para>Represents the number of radians in one turn, specified by the constant, &#964;.</para>
    /// </summary>
    /// <value><c>6.28317</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static Fixed Tau { get; } = new(411774L);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal readonly long rawValue;

    internal Fixed(in long rawValue)
    {
        this.rawValue = rawValue;
    }

    /// <summary>
    /// <para>Returns a value indicating whether this instance is equal to a specified object.</para>
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is an instance of <see cref="Fixed"> and equals the value of this instance; otherwise, <c>false</c>.</returns>
    public override readonly bool Equals(object? obj)
    {
        return obj is Fixed other && Equals(other);
    }

    /// <summary>
    /// <para>Returns a value indicating whether this instance and a specified <see cref="Fixed"/> object represent the same value.</para>
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is equal to this instance; otherwise, <c>false</c>.</returns>
    public readonly bool Equals(Fixed obj)
    {
        return rawValue == obj.rawValue;
    }

    /// <summary>
    /// <para>Returns the hash code for this instance.</para>
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override readonly int GetHashCode()
    {
        return 621480157 + rawValue.GetHashCode();
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation.</para>
    /// </summary>
    /// <returns>The string representation of the value of this instance.</returns>
    public override readonly string ToString()
    {
        return $"{(double)this:###,##0.00000}";
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</para>
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="provider"/>.</returns>
    public readonly string ToString(IFormatProvider provider)
    {
        return ((double)this).ToString(provider);
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation, using the specified format.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/>.</returns>
    /// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
    public readonly string ToString(string format)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "###,##0.00000";
        }
        return ((double)this).ToString(format);
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
    /// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
    public readonly string ToString(string format, IFormatProvider provider)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "###,##0.00000";
        }
        return ((double)this).ToString(format, provider);
    }

    /// <summary>
    /// <para>Computes the absolute of a value.</para>
    /// </summary>
    /// <param name="value">The value for which to get its absolute.</param>
    /// <returns>The absolute of  <paramref name="value"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed Abs(in Fixed value)
    {
        long mask = value.rawValue >> 63;
        return new Fixed((value.rawValue + mask) ^ mask);
    }

    /// <summary>
    /// <para></para>
    /// <para>Clamps a value to an inclusive minimum and maximum value.</para>
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The inclusive minimum to which <paramref name="value"/> should clamp.</param>
    /// <param name="max">The inclusive maximum to which <paramref name="value"/> should clamp.</param>
    /// <returns>The result of clamping <paramref name="value"/> to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed Clamp(in Fixed value, in Fixed min, in Fixed max)
    {
        return new Fixed(Math.Clamp(value.rawValue, min.rawValue, max.rawValue));
    }

    /// <summary>
    /// <para>Compares two values to compute which is greater.</para>
    /// </summary>
    /// <param name="x">The value to compare with <paramref name="y"/>.</param>
    /// <param name="y">The value to compare with <paramref name="x"/>.</param>
    /// <returns><paramref name="x"/> if <paramref name="x"/> is greater than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
    public static Fixed Max(in Fixed x, in Fixed y)
    {
        return new Fixed(Math.Max(x.rawValue, y.rawValue));
    }

    /// <summary>
    /// <para>Compares two values to compute which is lesser.</para>
    /// </summary>
    /// <param name="x">The value to compare with <paramref name="y"/>.</param>
    /// <param name="y">The value to compare with <paramref name="x"/>.</param>
    /// <returns><paramref name="x"/> if <paramref name="x"/> is less than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
    public static Fixed Min(in Fixed x, in Fixed y)
    {
        return new Fixed(Math.Min(x.rawValue, y.rawValue));
    }

    /// <summary>
    /// <para>Computes the sine of a value.</para>
    /// </summary>
    /// <param name="x">The value, in radians, whose sine is to be computed.</param>
    /// <returns>The sine of <paramref name="x"/>.</returns>
    public static Fixed Sin(in Fixed x)
    {
        var segmentSize = Pi / 2;
        long segment = (x.rawValue / segmentSize.rawValue) & 0b_11;
        var index = x.rawValue % segmentSize.rawValue;

        return segment switch
        {
            0 => new Fixed(MathEngine.sin[index]),
            1 => new Fixed(MathEngine.sin[segmentSize.rawValue - index]),
            2 => new Fixed(-MathEngine.sin[index]),
            _ => new Fixed(-MathEngine.sin[segmentSize.rawValue - index])
        };
    }

    /// <summary>
    /// <para>Computes the cosine of a value.</para>
    /// </summary>
    /// <param name="x">The value, in radians, whose cosine is to be computed.</param>
    /// <returns>The cosine of <paramref name="x"/>.</returns>
    public static Fixed Cos(in Fixed d)
    {
        var piOverTwo = Pi / 2;
        return Sin(d + piOverTwo);
    }

    /// <summary>
    /// <para>Computes the tangent  of a value.</para>
    /// </summary>
    /// <param name="x">The value, in radians, whose sine is to be computed.</param>
    /// <returns>The tangent  of <paramref name="x"/>.</returns>
    public static Fixed Tan(in Fixed x)
    {
        var segmentSize = Pi / 2;
        long segment = (x.rawValue / segmentSize.rawValue) & 0b_01;
        var index = x.rawValue % segmentSize.rawValue;

        return segment switch
        {
            0 => MathEngine.tan[index],
            _ => -MathEngine.tan[segmentSize.rawValue - index],
        };
    }

    /// <summary>
    /// <para>Computes the arc-sine of a value.</para>
    /// </summary>
    /// <param name="x">The value, in radians, whose arc-sine is to be computed.</param>
    /// <returns>The arc-sine of <paramref name="x"/>.</returns>
    public static Fixed Asin(in Fixed x)
    {
        long segment = (x.rawValue >> 16) & 0b_01;
        var index = x.rawValue & 65535L;

        return segment switch
        {
            0 => new Fixed(MathEngine.asin[index]),
            _ => new Fixed(-MathEngine.asin[65535 - index]),
        };
    }

    /// <summary>
    /// <para>Computes the arc-cosine of a value.</para>
    /// </summary>
    /// <param name="x">The value, in radians, whose arc-cosine is to be computed.</param>
    /// <returns>The arc-cosine of <paramref name="x"/>.</returns>
    public static Fixed Acos(in Fixed x)
    {
        return Asin(-x) + (Pi / 2);
    }

    /// <summary>
    /// <para>Computes the square-root of a value.</para>
    /// </summary>
    /// <param name="x">The value whose square-root is to be computed.</param>
    /// <returns>The square-root of <paramref name="x"/>.</returns>
    public static Fixed Sqrt(in Fixed x)
    {
        if (x == Zero)
        {
            return Zero;
        }

        var abs = Abs(x);
        bool isLessThanOne = abs.rawValue < 65535L;
        long iterationValue = abs.rawValue;
        if (isLessThanOne)
        {
            iterationValue <<= 16;
        }

        int timedReduced = 0;
        while (iterationValue > 262144L)
        {
            timedReduced++;
            iterationValue >>= 2;
        }

        long lutIndex = (iterationValue - 65536L) >> 1;
        if (lutIndex >= 65536L)
        {
            lutIndex = 65535L;
        }
        else if (lutIndex < 0)
        {
            lutIndex = 0L;
        }

        iterationValue = ((long)MathEngine.sqrt[lutIndex] << timedReduced) + 65535L;
        if (isLessThanOne)
        {
            iterationValue >>= 8;
        }
        return new Fixed(iterationValue);
    }

    /// <summary>
    /// <para>Compares this instance to a specified object and returns an indication of their relative values.</para>
    /// </summary>
    /// <param name="other">An <see cref="object"/> to compare, or <c>null</c>.</param>
    /// <returns>A signed number indicating the relative values of this instance and value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object other)
    {
        var otherValue = other switch
        {
            Fixed value => value,
            _ => throw new ArgumentException("Type is not comparable to Fixed.", nameof(other)),
        };

        return rawValue.CompareTo(otherValue.rawValue);
    }

    /// <summary>
    /// <para>Compares this instance to a specified <see cref="Fixed"/> and returns an indication of their relative values.</para>
    /// </summary>
    /// <param name="other">A value to compare.</param>
    /// <returns>A signed number indicating the relative values of this instance and value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Fixed other)
    {
        return rawValue.CompareTo(other.rawValue);
    }

    /// <summary>
    /// <para>Computes the unary plus of a value.</para>
    /// </summary>
    /// <param name="value">The value for which to compute the unary plus.</param>
    /// <returns>The unary plus of <paramref name="value"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator +(in Fixed value)
    {
        return value;
    }

    /// <summary>
    /// <para>Computes the unary negation of a value.</para>
    /// </summary>
    /// <param name="value">The value for which to compute the unary negation.</param>
    /// <returns>The unary negation of <paramref name="value"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator -(in Fixed value)
    {
        return new Fixed(-value.rawValue);
    }

    /// <summary>
    /// <para>Adds two values together to compute their sum.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator +(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue + right.rawValue);
    }

    /// <summary>
    /// <para>Adds two values together to compute their sum.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator +(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue + ((long)right << 16));
    }

    /// <summary>
    /// <para>Adds two values together to compute their sum.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator +(in int left, in Fixed right)
    {
        return new Fixed(((long)left << 16) + right.rawValue);
    }

    /// <summary>
    /// <para>Subtracts two values to compute their difference.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator -(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue - right.rawValue);
    }

    /// <summary>
    /// <para>Subtracts two values to compute their difference.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator -(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue - ((long)right << 16));
    }

    /// <summary>
    /// <para>Subtracts two values to compute their difference.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator -(in int left, in Fixed right)
    {
        return new Fixed(((long)left << 16) - right.rawValue);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator *(in Fixed left, in Fixed right)
    {
        return new Fixed((left.rawValue * right.rawValue) >> 16);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator *(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue * right);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator *(in int left, in Fixed right)
    {
        return new Fixed(left * right.rawValue);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator /(in Fixed left, in Fixed right)
    {
        return new Fixed((left.rawValue << 16) / right.rawValue);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator /(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue / right);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator /(in int left, in Fixed right)
    {
        return new Fixed(((long)left << 32) / right.rawValue);
    }

    /// <summary>
    /// <para>Computes the unary negation of a value with overflow checking.</para>
    /// </summary>
    /// <param name="value">The value for which to compute the unary negation.</param>
    /// <returns>The unary negation of <paramref name="value"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked -(in Fixed value)
    {
        return new Fixed(checked(-value.rawValue));
    }

    /// <summary>
    /// <para>Adds two values together to compute their sum with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked +(in Fixed left, in Fixed right)
    {
        return new Fixed(checked(left.rawValue + right.rawValue));
    }

    /// <summary>
    /// <para>Adds a Fixed value and an int together to compute their sum with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked +(in Fixed left, in int right)
    {
        return new Fixed(checked(left.rawValue + ((long)right << 16)));
    }

    /// <summary>
    /// <para>Adds an int and a Fixed value together to compute their sum with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked +(in int left, in Fixed right)
    {
        return new Fixed(checked(((long)left << 16) + right.rawValue));
    }

    /// <summary>
    /// <para>Subtracts two values to compute their difference with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked -(in Fixed left, in Fixed right)
    {
        return new Fixed(checked(left.rawValue - right.rawValue));
    }

    /// <summary>
    /// <para>Subtracts an int from a Fixed value to compute their difference with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked -(in Fixed left, in int right)
    {
        return new Fixed(checked(left.rawValue - ((long)right << 16)));
    }

    /// <summary>
    /// <para>Subtracts a Fixed value from an int to compute their difference with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked -(in int left, in Fixed right)
    {
        return new Fixed(checked(((long)left << 16) - right.rawValue));
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked *(in Fixed left, in Fixed right)
    {
        return new Fixed(checked((left.rawValue * right.rawValue) >> 16));
    }

    /// <summary>
    /// <para>Multiplies a Fixed value and an int together to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked *(in Fixed left, in int right)
    {
        return new Fixed(checked(left.rawValue * right));
    }

    /// <summary>
    /// <para>Multiplies an int and a Fixed value together to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked *(in int left, in Fixed right)
    {
        return new Fixed(checked(left * right.rawValue));
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked /(in Fixed left, in Fixed right)
    {
        return new Fixed(checked((left.rawValue << 16) / right.rawValue));
    }

    /// <summary>
    /// <para>Divides a Fixed value by an int to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked /(in Fixed left, in int right)
    {
        return new Fixed(checked(left.rawValue / right));
    }

    /// <summary>
    /// <para>Divides an int by a Fixed value to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator checked /(in int left, in Fixed right)
    {
        return new Fixed(checked(((long)left << 32) / right.rawValue));
    }

    /// <summary>
    /// <para>Divides two values together to compute their modulus or remainder.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The modulus or remainder of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator %(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue % right.rawValue);
    }

    /// <summary>
    /// <para>Divides two values together to compute their modulus or remainder.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The modulus or remainder of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator %(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue % ((long)right << 16));
    }

    /// <summary>
    /// <para>Divides two values together to compute their modulus or remainder.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The modulus or remainder of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator %(in int left, in Fixed right)
    {
        return new Fixed(((long)left << 16) % right.rawValue);
    }

    /// <summary>
    /// <para>Performs a bitwise AND operation on two <see cref="Fixed"/> values.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise AND operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator &(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue & right.rawValue);
    }

    /// <summary>
    /// <para>Performs a bitwise OR operation on two <see cref="Fixed"/> values.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise OR operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator |(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue | right.rawValue);
    }

    /// <summary>
    /// <para>Performs a bitwise XOR (exclusive OR) operation on two <see cref="Fixed"/> values.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise XOR operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator ^(in Fixed left, in Fixed right)
    {
        return new Fixed(left.rawValue ^ right.rawValue);
    }

    /// <summary>
    /// <para>Performs a left bit shift operation on a <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <remarks>
    /// Shifting a fixed-point number left by 'n' bits is equivalent to multiplying the fixed-point value by 2 raised to the power of 'n'.
    /// For example, a left shift by 1 bit effectively doubles the value.
    /// </remarks>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift left by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the left bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator <<(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue << right);
    }

    /// <summary>
    /// <para>Performs a right bit shift operation on a <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <remarks>
    /// Shifting a fixed-point number right by 'n' bits is equivalent to
    /// dividing the fixed-point value by 2 raised to the power of 'n'.
    /// For example, a right shift by 1 bit effectively halves the value.
    /// Be aware that right shifts can lead to a loss of precision, as the
    /// least significant bits (which may represent fractional data) are discarded.
    /// </remarks>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift right by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the right bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator >>(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue >> right);
    }

    /// <summary>
    /// <para>Performs an unsigned right bit shift operation on a <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift right by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the unsigned right bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Fixed operator >>>(in Fixed left, in int right)
    {
        return new Fixed(left.rawValue >>> right);
    }

    /// <summary>
    /// <para>Compares two values to determine equality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in Fixed left, in Fixed right)
    {
        return left.rawValue == right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine equality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in Fixed left, in int right)
    {
        return left.rawValue == (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine equality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in int left, in Fixed right)
    {
        return (long)left << 16 == right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine inequality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in Fixed left, in Fixed right)
    {
        return left.rawValue != right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine inequality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in Fixed left, in int right)
    {
        return left.rawValue != (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine inequality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in int left, in Fixed right)
    {
        return (long)left << 16 != right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(in Fixed left, in Fixed right)
    {
        return left.rawValue < right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(in Fixed left, in int right)
    {
        return left.rawValue < (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(in int left, in Fixed right)
    {
        return (long)left << 16 < right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(in Fixed left, in Fixed right)
    {
        return left.rawValue <= right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(in Fixed left, in int right)
    {
        return left.rawValue <= (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine which is less or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(in int left, in Fixed right)
    {
        return (long)left << 16 <= right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(in Fixed left, in Fixed right)
    {
        return left.rawValue > right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(in Fixed left, in int right)
    {
        return left.rawValue > (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(in int left, in Fixed right)
    {
        return (long)left << 16 > right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(in Fixed left, in Fixed right)
    {
        return left.rawValue >= right.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(in Fixed left, in int right)
    {
        return left.rawValue >= (long)right << 16;
    }

    /// <summary>
    /// <para>Compares two values to determine which is greater or equal.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(in int left, in Fixed right)
    {
        return (long)left << 16 >= right.rawValue;
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="float"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Fixed(in float value)
    {
        return new Fixed((long)(value * 65536.0f));
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="double"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Fixed(in double value)
    {
        return new Fixed((long)(value * 65536.0));
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="decimal"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Fixed(in decimal value)
    {
        return new Fixed((long)(value * 65536.0m));
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="byte"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in byte value)
    {
        return new Fixed((long)value << 16);
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="sbyte"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in sbyte value)
    {
        return new Fixed((long)value << 16);
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="int"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in int value)
    {
        return new Fixed((long)value << 16);
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="uint"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in uint value)
    {
        return new Fixed((long)value << 16);
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="long"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in long value)
    {
        return new Fixed(value << 16);
    }

    /// <summary>
    /// <para>Implicitly converts <see cref="ulong"/> values to <see cref="Fixed"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to implicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Fixed(in ulong value)
    {
        return new Fixed((long)value << 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="byte"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator byte(in Fixed value)
    {
        return (byte)(value.rawValue >> 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="sbyte"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator sbyte(in Fixed value)
    {
        return (sbyte)(value.rawValue >> 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="int"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(in Fixed value)
    {
        return (int)(value.rawValue >> 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="uint"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(in Fixed value)
    {
        return (uint)(value.rawValue >> 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="long"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(in Fixed value)
    {
        return value.rawValue >> 16;
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="ulong"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ulong(in Fixed value)
    {
        return (ulong)(value.rawValue >> 16);
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="float"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator float(in Fixed value)
    {
        return value.rawValue / 65536.0f;
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="double"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator double(in Fixed value)
    {
        return value.rawValue / 65536.0;
    }

    /// <summary>
    /// <para>Explicitly converts <see cref="Fixed"/> values to <see cref="decimal"/> numerics.</para>
    /// </summary>
    /// <param name="value">The value to explicitly convert.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator decimal(in Fixed value)
    {
        return value.rawValue / 65536.0m;
    }
}
