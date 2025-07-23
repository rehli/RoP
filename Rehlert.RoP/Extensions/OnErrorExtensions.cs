namespace Rehlert.RoP.Extensions;

public static class OnErrorExtensions
{
    public static Result<TIn, TErr> OnError<TIn, TErr>(this Result<TIn, TErr> value, Action<TErr> action)
    {
        value.Match(
            _ => { },
            err => action(err.Value)
        );

        return value;
    }

    public static async Task<Result<TIn, TErr>> OnError<TIn, TErr>(
        this Result<TIn, TErr> value,
        Func<TErr, Task> func
    )
    {
        await value.Match(
            _ => Task.CompletedTask,
            err => func(err.Value)
        );

        return value;
    }

    public static async Task<Result<TIn, TErr>> OnError<TIn, TErr>(
        this Task<Result<TIn, TErr>> value,
        Func<TErr, Task> func
    )
    {
        var valRes = await value;
        await valRes.Match(
            _ => Task.CompletedTask,
            err => func(err.Value)
        );

        return valRes;
    }

    public static async Task<Result<TIn, TErr>> OnError<TIn, TErr>(
        this Task<Result<TIn, TErr>> value,
        Action<TErr> action
    )
    {
        var valRes = await value;
        valRes.Match(
            _ => { },
            err => action(err.Value)
        );

        return valRes;
    }
}