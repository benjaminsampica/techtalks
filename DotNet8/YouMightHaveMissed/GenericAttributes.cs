namespace YouMightHaveMissed;

public class GenericAttribute<T> : Attribute
    where T : class
{
}

[Generic<Program>]
public class MyClass
{

}