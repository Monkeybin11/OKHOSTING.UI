namespace OKHOSTING.UI
{
	/// <summary>
	/// It represents the color for controls.
	/// <para xml:lang="es">Representa el color para los controles</para>
	/// </summary>
	public class Colors
	{
		/// <summary>
		/// Initializes a new instance of the Color class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Color</para>
		/// </summary>
		/// <param name="alpha">Alpha.
		/// <para xml:lang="es">Valor del color alfa</para>
		/// </param>
		/// <param name="red">Red.
		/// <para xml:lang="es">Valor para el color rojo</para>
		/// </param>
		/// <param name="green">Green.
		/// <para xml:lang="es">Valor del color verde</para>
		/// </param>
		/// <param name="blue">Blue.
		/// <para xml:lang="es">Valor del color azul.</para>
		/// </param>
		public Color(int alpha, int red, int green, int blue)
		{
			Alpha = alpha;
			Red = red;
			Green = green;
			Blue = blue;
		}

		/// <summary>
		/// Gets or sets the alpha.
		/// <para xml:lang="es">Obtiene o establece el valor del color alfa.</para>
		/// </summary>
		public int Alpha { get; set; }
		/// <summary>
		/// Gets or sets the red.
		/// <para xml:lang="es">Obtiene o establece el valor del color red.</para>
		/// </summary>
		/// <value>The red.</value>
		public int Red { get; set; }
		/// <summary>
		/// Gets or sets the green.
		/// <para xml:lang="es">Obtiene o establece el valor para el color verde.</para>
		/// </summary>
		/// <value>The green.</value>
		public int Green { get; set; }
		/// <summary>
		/// Gets or sets the blue.
		/// <para xml:lang="es">Obtiene o establece el valor para el color azul.</para>
		/// </summary>
		/// <value>The blue.</value>
		public int Blue { get; set; }
	}
}