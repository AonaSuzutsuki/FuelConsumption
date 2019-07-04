using System;
using System.Collections.Generic;
using System.Text;
using FuelConsumption2.Extensions;

namespace FuelConsumption2
{
    public static class Constants
    {
        public static string VehiclesSavedPath => "Vehicles.json".ResolveDocumentPath();

        public static string DocumentDirPath => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }
}
