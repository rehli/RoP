using Dunet;

namespace Rehli.RoP;

[Union]
public partial record Result<TOk, TError>
    where TOk : notnull
    where TError : notnull
{
    public partial record Ok(TOk Value);

    public partial record Error(TError Value);
}