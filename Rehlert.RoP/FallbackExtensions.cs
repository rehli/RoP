namespace Rehlert.RoP;

public static class FallbackExtensions
{
    public static TIn FallbackWith<TIn, TErr>(this Result<TIn, TErr> value, TIn defaultValue)
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
    {
        var valRes = await value;
        var result = valRes.Match(
            ok => ok.Value,
            _ => defaultValue
        );

        return result;
    }
}