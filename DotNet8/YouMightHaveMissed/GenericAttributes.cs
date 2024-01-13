namespace YouMightHaveMissed;

[GenericAttribute<Program>()]
public class GenericAttribute<T> : Attribute
    where T : class
{
}
