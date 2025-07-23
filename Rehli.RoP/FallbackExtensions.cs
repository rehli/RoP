namespace Rehli.RoP;

public static class FallbackExtensions
{
    public static TIn FallbackWith<TIn, TErr>(this Result<TIn, TErr> value, TIn defaultValue)
        where TIn : notnull
        where TErr : notnull
    {
        var result = value.Match(
            ok => ok.Value,
            _ => defaultValue
        );

        return result;
    }

    public static async Task<TIn> FallbackWith<TIn, TErr>(
        this Task<Result<TIn, TErr>> value,
        TIn defaultValue
    )
        where TIn : notnull
        where TErr : notnull
    {
        var valRes = await value;
        var result = valRes.Match(
            ok => ok.Value,
            _ => defaultValue
        );

        return result;
    }
}