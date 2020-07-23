namespace OKHOSTING.UI.Controls.Maps
{
	/// <summary>
	/// A struct that has a latitude and longitude, stored as doubles.
	/// </summary>
	public struct Position
	{
		public Position(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		/// <summary>
		/// Gets the latitude of this position in decimal degrees.
		/// </summary>
		/// <value>
		/// The latitude of this position in degrees, as a double. The returned value will be between -90.0 and 90.0 degrees, inclusive.
		/// </value>
		public double Latitude { get; }

		/// <summary>
		/// Gets the longitude of this position in decimal degrees.
		/// </summary>
		/// <value>
		/// The longitude of this position in degrees, as a double. The returned value will be between -180.0 and 180.0 degrees, inclusive.
		/// </value>
		public double Longitude { get; }
	}
}