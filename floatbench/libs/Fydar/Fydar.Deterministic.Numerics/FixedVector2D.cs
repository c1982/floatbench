using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Fydar.Deterministic.Numerics;

/// <summary>
/// Represents a vector with two fixed-point values.
/// </summary>
/// <seealso cref="FixedVector3D"/>
[DebuggerDisplay("{ToString(),nq}")]
public readonly struct FixedVector2D :
    IEquatable<FixedVector2D>,
    IFormattable
{
    /// <summary>
    /// <para>Represents a vector whose two components are equal to zero.</para>
    /// </summary>
    /// <value><c>(0, 0)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D Zero { get; } = new(0, 0);

    /// <summary>
    /// <para>Represents a vector whose two components are equal to one.</para>
    /// </summary>
    /// <value><c>(1, 1)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D One { get; } = new(1, 1);

    /// <summary>
    /// <para>Represents a vector whose X component is equal to one and Y component is equal to zero.</para>
    /// </summary>
    /// <value><c>(1, 0)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D Right { get; } = new(1, 0);

    /// <summary>
    /// <para>Represents a vector whose X component is equal to negative one and Y component is equal to zero.</para>
    /// </summary>
    /// <value><c>(1, 0)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D Left { get; } = new(-1, 0);

    /// <summary>
    /// <para>Represents a vector whose X component is equal to zero and Y component is equal to one.</para>
    /// </summary>
    /// <value><c>(0, 1)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D Up { get; } = new(0, 1);

    /// <summary>
    /// <para>Represents a vector whose X component is equal to zero and Y component is equal to negative one.</para>
    /// </summary>
    /// <value><c>(0, -1)</c></value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static FixedVector2D Down { get; } = new(0, -1);

    /// <summary>
    /// <para>The X component of the vector.</para>
    /// </summary>
    public readonly Fixed X { get; }

    /// <summary>
    /// <para>The Y component of the vector.</para>
    /// </summary>
    public readonly Fixed Y { get; }

    /// <summary>
    /// Creates a vector whose elements have the specified values.
    /// </summary>
    /// <param name="x">The value to assign to the <see cref="X"/> property.</param>
    /// <param name="y">The value to assign to the <see cref="Y"/> property.</param>
    public FixedVector2D(in Fixed x, in Fixed y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// <para>Returns a value indicating whether this instance is equal to a specified object.</para>
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is an instance of <see cref="FixedVector2D"> and equals the value of this instance; otherwise, <c>false</c>.</returns>
    public override readonly bool Equals(object? obj)
    {
        return obj is FixedVector2D other && Equals(other);
    }

    /// <summary>
    /// <para>Returns a value indicating whether this instance and a specified <see cref="FixedVector2D"/> object represent the same value.</para>
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is equal to this instance; otherwise, <c>false</c>.</returns>
    public readonly bool Equals(FixedVector2D obj)
    {
        return this == obj;
    }

    /// <summary>
    /// <para>Returns the hash code for this instance.</para>
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override readonly int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation.</para>
    /// </summary>
    /// <returns>The string representation of the value of this instance.</returns>
    public override readonly string ToString()
    {
        string separator = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture).NumberGroupSeparator;
        return $"<{X}{separator} {Y}>";
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</para>
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="provider"/>.</returns>
    public readonly string ToString(IFormatProvider provider)
    {
        string separator = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture).NumberGroupSeparator;
        return $"<{X.ToString(provider)}{separator} {Y.ToString(provider)}>";
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation, using the specified format.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/>.</returns>
    /// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
    public readonly string ToString(string format)
    {
        string separator = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture).NumberGroupSeparator;
        return $"<{X.ToString(format)}{separator} {Y.ToString(format)}>";
    }

    /// <summary>
    /// <para>Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
    /// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
    public readonly string ToString(string format, IFormatProvider provider)
    {
        string separator = NumberFormatInfo.GetInstance(provider).NumberGroupSeparator;
        return $"<{X.ToString(format, provider)}{separator} {Y.ToString(format, provider)}>";
    }

    /// <summary>
    /// <para>Returns a vector whose elements are the maximum of each of the pairs of elements in two specified vectors.</para>
    /// </summary>
    /// <param name="x">The first vector.</param>
    /// <param name="y">The second vector.</param>
    /// <returns>The maximized vector.</returns>
    public static FixedVector2D Max(
        in FixedVector2D x,
        in FixedVector2D y)
    {
        return new FixedVector2D(
            Fixed.Max(x.X, y.X),
            Fixed.Max(x.Y, y.Y));
    }

    /// <summary>
    /// <para>Returns a vector whose elements are the minimum of each of the pairs of elements in two specified vectors.</para>
    /// </summary>
    /// <param name="x">The first vector.</param>
    /// <param name="y">The second vector.</param>
    /// <returns>The minimized vector.</returns>
    public static FixedVector2D Min(
        in FixedVector2D x,
        in FixedVector2D y)
    {
        return new FixedVector2D(
            Fixed.Min(x.X, y.X),
            Fixed.Min(x.Y, y.Y));
    }

    /// <summary>
    /// <para>Compares two values to determine equality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(in FixedVector2D left, in FixedVector2D right)
    {
        return left.X.rawValue == right.X.rawValue
            && left.Y.rawValue == right.Y.rawValue;
    }

    /// <summary>
    /// <para>Compares two values to determine inequality.</para>
    /// </summary>
    /// <param name="left">The value to compare with <paramref name="right"/>.</param>
    /// <param name="right">The value to compare with <paramref name="left"/>.</param>
    /// <returns><c>true</c> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(in FixedVector2D left, in FixedVector2D right)
    {
        return left.X.rawValue != right.X.rawValue
            || left.Y.rawValue != right.Y.rawValue;
    }

    /// <summary>
    /// <para>Computes the unary plus of a value.</para>
    /// </summary>
    /// <param name="value">The value for which to compute the unary plus.</param>
    /// <returns>The unary plus of <paramref name="value"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator +(in FixedVector2D value)
    {
        return value;
    }

    /// <summary>
    /// <para>Computes the unary negation of a value.</para>
    /// </summary>
    /// <param name="value">The value for which to compute the unary negation.</param>
    /// <returns>The unary negation of <paramref name="value"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator -(in FixedVector2D value)
    {
        return new FixedVector2D(-value.X, -value.Y);
    }

    /// <summary>
    /// <para>Adds two values together to compute their sum.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator +(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X + right.X,
            left.Y + right.Y);
    }

    /// <summary>
    /// <para>Subtracts two values to compute their difference.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator -(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X - right.X,
            left.Y - right.Y);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator *(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X * right.X,
            left.Y * right.Y);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator *(in FixedVector2D left, in Fixed right)
    {
        return new FixedVector2D(
            left.X * right,
            left.Y * right);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator *(in Fixed left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left * right.X,
            left * right.Y);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator *(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            left.X * right,
            left.Y * right);
    }

    /// <summary>
    /// <para>Multiplies two values together to compute their product.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator *(in int left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left * right.X,
            left * right.Y);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator /(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X / right.X,
            left.Y / right.Y);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator /(in FixedVector2D left, in Fixed right)
    {
        return new FixedVector2D(
            left.X / right,
            left.Y / right);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator /(in Fixed left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left / right.X,
            left / right.Y);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator /(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            left.X / right,
            left.Y / right);
    }

    /// <summary>
    /// <para>Divides one value by another to compute their quotient.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator /(in int left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left / right.X,
            left / right.Y);
    }

    /// <summary>
    /// <para>Adds two values together together to compute their sum with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value to which <paramref name="right"/> is added.</param>
    /// <param name="right">The value which is added to <paramref name="left"/>.</param>
    /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked +(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left.X + right.X),
            checked(left.Y + right.Y));
    }

    /// <summary>
    /// <para>Subtracts two values together to compute their difference with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value from which <paramref name="right"/> is subtracted.</param>
    /// <param name="right">The value which is subtracted from <paramref name="left"/>.</param>
    /// <returns>The value of <paramref name="right"/> subtracted from <paramref name="left"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked -(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left.X - right.X),
            checked(left.Y - right.Y));
    }

    /// <summary>
    /// <para>Multiplies two values together together to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked *(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left.X * right.X),
            checked(left.Y * right.Y));
    }

    /// <summary>
    /// <para>Multiplies a value by a Fixed value to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked *(in FixedVector2D left, in Fixed right)
    {
        return new FixedVector2D(
            checked(left.X * right),
            checked(left.Y * right));
    }

    /// <summary>
    /// <para>Multiplies a Fixed value by a value to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked *(in Fixed left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left * right.X),
            checked(left * right.Y));
    }

    /// <summary>
    /// <para>Multiplies a value by an int to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked *(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            checked(left.X * right),
            checked(left.Y * right));
    }

    /// <summary>
    /// <para>Multiplies an int by a value to compute their product with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> multiplies.</param>
    /// <param name="right">The value which multiplies <paramref name="left"/>.</param>
    /// <returns>The product of <paramref name="left"/> multiplied by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked *(in int left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left * right.X),
            checked(left * right.Y));
    }

    /// <summary>
    /// <para>Divides one FixedVector2D by another FixedVector2D to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked /(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left.X / right.X),
            checked(left.Y / right.Y));
    }

    /// <summary>
    /// <para>Divides a value by a Fixed value to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked /(in FixedVector2D left, in Fixed right)
    {
        return new FixedVector2D(
            checked(left.X / right),
            checked(left.Y / right));
    }

    /// <summary>
    /// <para>Divides a Fixed value by a value to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked /(in Fixed left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left / right.X),
            checked(left / right.Y));
    }

    /// <summary>
    /// <para>Divides a value by an int to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked /(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            checked(left.X / right),
            checked(left.Y / right));
    }

    /// <summary>
    /// <para>Divides an int by a value to compute their quotient with overflow checking.</para>
    /// </summary>
    /// <param name="left">The value which <paramref name="right"/> divides.</param>
    /// <param name="right">The value which divides <paramref name="left"/>.</param>
    /// <returns>The quotient of <paramref name="left"/> divided by <paramref name="right"/>.</returns>
    /// <exception cref="OverflowException">The arithmetic operation results in an overflow.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator checked /(in int left, in FixedVector2D right)
    {
        return new FixedVector2D(
            checked(left / right.X),
            checked(left / right.Y));
    }

    /// <summary>
    /// <para>Performs a bitwise **AND** operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise AND operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator &(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X.rawValue & right.X.rawValue,
            left.Y.rawValue & right.Y.rawValue);
    }

    /// <summary>
    /// <para>Performs a bitwise **OR** operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise OR operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator |(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X.rawValue | right.X.rawValue,
            left.Y.rawValue | right.Y.rawValue);
    }

    /// <summary>
    /// <para>Performs a bitwise **XOR** (exclusive OR) operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The first <see cref="Fixed"/> value.</param>
    /// <param name="right">The second <see cref="Fixed"/> value.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the bitwise XOR operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator ^(in FixedVector2D left, in FixedVector2D right)
    {
        return new FixedVector2D(
            left.X.rawValue ^ right.X.rawValue,
            left.Y.rawValue ^ right.Y.rawValue);
    }

    /// <summary>
    /// <para>Performs a **left bit shift** operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <remarks>
    /// Shifting a fixed-point number left by 'n' bits is equivalent to multiplying the fixed-point value by 2 raised to the power of 'n'.
    /// For example, a left shift by 1 bit effectively doubles the value.
    /// </remarks>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift left by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the left bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator <<(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            left.X.rawValue << right,
            left.Y.rawValue << right);
    }

    /// <summary>
    /// <para>Performs a **right bit shift** operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift right by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the right bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator >>(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            left.X.rawValue >> right,
            left.Y.rawValue >> right);
    }

    /// <summary>
    /// <para>Performs a **unsigned right bit shift** operation on each component <see cref="Fixed"/> value.</para>
    /// </summary>
    /// <param name="left">The <see cref="Fixed"/> value to shift.</param>
    /// <param name="right">The number of bits to shift right by.</param>
    /// <returns>A new <see cref="Fixed"/> instance representing the result of the unsigned right bit shift.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixedVector2D operator >>>(in FixedVector2D left, in int right)
    {
        return new FixedVector2D(
            left.X.rawValue >>> right,
            left.Y.rawValue >>> right);
    }
}
