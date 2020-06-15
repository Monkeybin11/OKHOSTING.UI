namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a top, bottom, left right value. Can be used for margins, paddings, borders, etc.
	/// <para xml:lang="es">
	/// Representa un valor de superior, inferior, izquierda y derecha. Puede ser utilizado para los margenes, los paddings, los bordes, etc.
	/// </para>
	/// </summary>
	public class Thickness
	{
		/// <summary>
		/// Initializes a new instance of the Thickness class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Thickness</para>
		/// </summary>
		public Thickness()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Thickness class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Thickness</para>
		/// </summary>
		/// <param name="uniformLength">Uniform length.
		/// <para xml:lang="es">Longitud uniforme</para>
		/// </param>
		public Thickness(double uniformLength)
		{
			Left = Right = Top = Bottom = uniformLength;
		}



		/// <summary>
		/// Initializes a new instance of the Thickness class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Thickness.</para>
		/// </summary>
		/// <param name="left">Left.
		/// <para xml:lang="es">Valor de izquierda</para>
		/// </param>
		/// <param name="top">Top.
		/// <para xml:lang="es">Valor superior.</para>
		/// </param>
		/// <param name="right">Right.
		/// <para xml:lang="es">Valor de derecha</para>
		/// </param>
		/// <param name="bottom">Bottom.
		/// <para xml:lang="es">Valor inferior.</para>
		/// </param>
		public Thickness(double left, double top, double right, double bottom)
		{
			Left = left;
			Right = right;
			Top = top;
			Bottom = bottom;
		}

		/// <summary>
		/// Gets or sets the bottom.
		/// <para xml:lang="es">Obtiene o establece el valor inferior</para>
		/// </summary>
		public double Bottom { get; set; }
		/// <summary>
		/// Gets or sets the left.
		/// <para xml:lang="es">Obtiene o establece el valor de izquierda.</para>
		/// </summary>
		public double Left { get; set; }
		/// <summary>
		/// Gets or sets the right.
		/// <para xml:lang="es">Obtiene o establece el valor para la derecha.</para>
		/// </summary>
		public double Right { get; set; }
		/// <summary>
		/// Gets or sets the top.
		/// <para xml:lang="es">Obtiene o establece el valor inferior.</para>
		/// </summary>
		public double Top { get; set; }
	}
}