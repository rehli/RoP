namespace Rehlert.RoP;

public static class OnSuccessExtensions
{
    public static Result<TRes, TErr> OnSuccess<TIn, TErr, TRes>(this Result<TIn, TErr> value,
        Func<TIn, Result<TRes, TErr>> func)
    {
        var result = value.Match(
            ok => func(ok.Value),
            err => err.Value
        );

        return result;
    }

    public static async Task<Result<TRes, TErr>> OnSuccess<TIn, TErr, TRes>(
        this Result<TIn, TErr> value,
        Func<TIn, Task<Result<TRes, TErr>>> func
    )
    {
        var result = await value.Match(
            ok => func(ok.Value),
            err => Task.FromResult<Result<TRes, TErr>>(err.Value)
        );

        return result;
    }

    public static async Task<Result<TRes, TErr>> OnSuccess<TIn, TErr, TRes>(
        this Task<Result<TIn, TErr>> value,
        Func<TIn, Task<Result<TRes, TErr>>> func
    )
    {
        var valRes = await value;
        var result = await valRes.Match(
            ok => func(ok.Value),
            err => Task.FromResult<Result<TRes, TErr>>(err.Value)
        );

        return result;
    }

    public static async Task<Result<TRes, TErr>> OnSuccess<TIn, TErr, TRes>(
        this Task<Result<TIn, TErr>> value,
        Func<TIn, Result<TRes, TErr>> func
    )
    {
        var valRes = await value;
        var result = valRes.Match(
            ok => func(ok.Value),
            err => err.Value
        );

        return result;
    }

    public static async Task OnSuccess<TIn, TErr>(
        this Task<Result<TIn, TErr>> value,
        Func<TIn, Task> func
    )
    {
        var valRes = await value;
        await valRes.Match(
            ok => func(ok.Value),
            err => Task.CompletedTask
        );
    }

    public static async Task OnSuccess<TIn, TErr>(
        this Task<Result<TIn, TErr>> value,
        Action<TIn> action
    )
    {
        var valRes = await value;
        valRes.Match(
            ok => action(ok.Value),
            _ => { }
        );
    }

    public static async Task OnSuccess<TIn, TErr>(
        this Result<TIn, TErr> value,
        Func<TIn, Task> func
    )
    {
        await value.Match(
            ok => func(ok.Value),
            _ => Task.CompletedTask
        );
    }

    public static void OnSuccess<TIn, TErr>(
        this Result<TIn, TErr> value,
        Action<TIn> action
    )
    {
        value.Match(
            ok => action(ok.Value),
            _ => { }
        );
    }

    public static Result<(T1, T2), TErr> Combine<T1, T2, TErr>(this Result<T1, TErr> r1, Result<T2, TErr> r2)
    {
        if (r1 is Result<T1, TErr>.Error err)
            return err.Value;
        if (r2 is Result<T2, TErr>.Error err2)
            return err2.Value;
        return (r1.UnwrapOk().Value, r2.UnwrapOk().Value);
    }

    public static async Task<Result<(T1, T2), TErr>> Combine<T1, T2, TErr>(this Task<Result<T1, TErr>> r1,
        Result<T2, TErr> r2)
    {
        var val = await r1;
        return val.Combine(r2);
    }
}