using Xunit;

namespace Fonlow.ReadifyKnockTests
{
    /// <summary>
    /// This works only for test classes in the same in the same assembly.
    /// http://xunit.github.io/docs/shared-context.html
    /// </summary>
    [CollectionDefinition("IISExpress")]
    public class IisCollection : ICollectionFixture<Fonlow.Testing.IisExpressFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
