namespace CSharpTwelve;

public class DefaultLambdaParametersOld
{
    public static void IncrementNumbers()
    {
        var IncrementBy = (int source, int? increment) => source + increment ?? 1;
    }
}


public class DefaultLambdaParametersNew
{
    public static void IncrementNumbers()
    {
        var IncrementBy = (int source, int increment = 1) => source + increment;
    }
}