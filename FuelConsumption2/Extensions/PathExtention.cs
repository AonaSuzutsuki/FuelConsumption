using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FuelConsumption2.Extensions
{
    public static class PathExtension
    {
        public static string ResolveDocumentPath(this string path) => Path.Combine(Constants.DocumentDirPath, path);
    }
}
