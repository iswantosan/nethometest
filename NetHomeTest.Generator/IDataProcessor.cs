using System;
using System.Collections.Generic;

namespace NetHomeTest.Generator
{
    public interface IDataProcessor
    {
        /// <summary>
        /// Generate data
        /// </summary>
        /// <param name="numData">Number of generated data</param>
        /// <param name="location">Location of generated data (for example : file path, database connection string)</param>
        /// <returns>True if success</returns>
        bool Generate(int numData);

        /// <summary>
        /// Populate data based on search criteria
        /// </summary>
        /// <param name="search">The search criteria</param>
        /// <returns></returns>
        List<StringData> Populate(string search);
    }
}
