namespace App.Modules.Demos.Domain.Domains.Examples.Validation
{
    /// <summary>Validates the optional WGS84 spatial capability shared by ExampleA and ExampleB.</summary>
    /// <remarks>
    /// ExampleA/ExampleB DTOs carry caller input, the application services invoke this rule before
    /// mapping to entities, and the repositories receive only valid coordinate pairs. The Demos
    /// domain owns coordinate meaning; the client Presenter owns map projection and camera state.
    /// Keeping this as one rule prevents the parent and child write paths from accepting different
    /// definitions of a usable spatial sidecar.
    /// </remarks>
    public static class ExampleSpatialCapabilityValidation
    {
        /// <summary>Validates an optional latitude/longitude pair using WGS84 degree bounds.</summary>
        /// <param name="latitude">Optional latitude in the inclusive range -90 to 90 degrees.</param>
        /// <param name="longitude">Optional longitude in the inclusive range -180 to 180 degrees.</param>
        public static void Validate(double? latitude, double? longitude)
        {
            if (latitude.HasValue != longitude.HasValue)
            {
                throw new ArgumentException(
                    "Latitude and longitude must either both be absent or both be present.",
                    nameof(longitude));
            }

            if (!latitude.HasValue)
            {
                return;
            }

            if (!double.IsFinite(latitude.Value) || latitude.Value < -90d || latitude.Value > 90d)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(latitude),
                    latitude.Value,
                    "Latitude must be a finite WGS84 degree value between -90 and 90.");
            }

            if (!double.IsFinite(longitude!.Value) || longitude.Value < -180d || longitude.Value > 180d)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(longitude),
                    longitude.Value,
                    "Longitude must be a finite WGS84 degree value between -180 and 180.");
            }
        }
    }
}