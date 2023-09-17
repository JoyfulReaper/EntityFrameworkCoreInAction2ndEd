namespace ServiceLayer.BookServices;

public class DropdownTuple
{
    public required string Value { get; set; }
    public required string Text { get; set; }

    public override string ToString()
    {
        return $"{nameof(Value)}: {Value}, {nameof(Text)}: {Text}";
    }
}
