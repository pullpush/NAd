namespace NAd.Common
{
    /// <summary>
    /// Base class for all business rules in the application. Each component can have its own rule class that
    /// derives from <see cref="Rule"/>.
    /// </summary>
    public class Rule : Descriptor<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rule"/> class with the supplied <paramref name="code"/>.
        /// </summary>
        /// <param name="code">Identifies the <see cref="Rule"/></param>
        public Rule(string code)
            : base(code)
        {
        }
    }
}