namespace CSharpTwelve;

// Csharp <=11
public class PrimaryConstructorsOld
{
    public PrimaryConstructorsOld(string text)
    {
        _text = text;
    }

    private readonly string _text;

    public string GetText()
    {
        return _text;
    }
}

// Csharp 12
//public class PrimaryConstructorsNew(string text)
//{
//    public string GetText()
//    {
//        return text;
//    }
//}