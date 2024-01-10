namespace CSharpTwelve;

public class CollectionExpressionsOld
{
    public static readonly string[] vowels = new[] { "a", "e", "i", "o", "u" };
    public static readonly string[] consonants = new[] {
        "b",
        "c",
        "d",
        "f",
        "g",
        "h",
        "j",
        "k",
        "l",
        "m",
        "n",
        "p",
        "q",
        "r",
        "s",
        "t",
        "v",
        "w",
        "x",
        "z" };
}

public class CollectionExpressionsNew
{
    //    A collection expression can be converted to different collection types, including:
    //          System.Span<T> and System.ReadOnlySpan<T>
    //          Any type with a create method whose parameter type is ReadOnlySpan<T> where there's an implicit conversion from the collection expression type to T.
    //          Inline arrays
    //          Arrays
    //          Any type that supports a collection initializer, such as System.Collections.Generic.List<T>. There must be an .Add() method.

    public static readonly string[] vowels = ["a", "e", "i", "o", "u"];
    public static readonly string[] consonants = [
        "b",
        "c",
        "d",
        "f",
        "g",
        "h",
        "j",
        "k",
        "l",
        "m",
        "n",
        "p",
        "q",
        "r",
        "s",
        "t",
        "v",
        "w",
        "x",
        "z"];

    public static readonly string[] Alphabet = [.. vowels, .. consonants, "y"];
    public static readonly string[] Alphabet2 = [.. vowels, .. consonants, "y"];
}