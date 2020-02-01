using System;
using System.Linq;

public static class CExtensions
{
  /// <summary>
  /// checks if 'this' equals to any of the given parameters
  /// </summary>
  public static bool IsAnyOf<T>(this T source, params T[] list)
  {
    if (null == source) throw new ArgumentNullException("source");
    return list.Contains(source);
  }

  /// <summary>
  /// checks if 'this' is different from all of the given parameters
  /// </summary>
  public static bool IsNoneOf<T>(this T source, params T[] list)
  {
    if (null == source) throw new ArgumentNullException("source");
    return !list.Contains(source);
  }

  /// <summary>
  /// exchanges the given values from memory locations
  /// </summary>
  public static void Swap<T>(ref T lhs, ref T rhs)
  {
    T temp = lhs;
    lhs = rhs;
    rhs = temp;
  }

  /// <summary>
  /// checks if enum 'this' has any of the given flags
  /// </summary>
  public static bool HasAnyOf<T>(this T source, params T[] list)
    where T : Enum
  {
    return list.Any(x => source.HasFlag(x));
  }
}
