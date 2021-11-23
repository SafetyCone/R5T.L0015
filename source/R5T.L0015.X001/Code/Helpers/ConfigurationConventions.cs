using System;


namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationConventions
    {
        /// <summary>
        /// Make configuration non-optional by default.
        /// If you have spent the effort to add the configuration, the computer should at least check that the configuration exists!
        /// Make it easy to override the default optionality at the right point.
        /// </summary>
        public const bool DefaultOptionality = false;
    }
}
