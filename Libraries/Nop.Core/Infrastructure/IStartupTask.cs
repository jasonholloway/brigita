﻿namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Interface which should be implemented by tasks run on startup
    /// </summary>
    public interface IStartupTask 
    {
        /// <summary>
        /// Execute task
        /// </summary>
        void Run();

        /// <summary>
        /// Order
        /// </summary>
        int Order { get; }
    }
}
