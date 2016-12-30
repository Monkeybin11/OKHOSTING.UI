using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using Native = global::System.Windows.Controls;
using System.Collections;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	/// <summary>
	/// Represents a list of controls in Xamarin:Forms
	/// <para xml:lang="es">
	/// Representa una lista de controles en Xamarin:Forms
	/// </para>
	/// </summary>
	public class ControlList : IList<IControl>
	{
		/// <summary>
		/// Initializes a new instance of the ControlList class.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia de la clse ControlList.
		/// </para>
		/// </summary>
		/// <param name="innerList">Inner List</param>
		public ControlList(Native.UIElementCollection innerList)
		{
			if (innerList == null)
			{
				throw new ArgumentNullException("innerList");
			}

			InnerList = innerList;
		}

		/// <summary>
		/// The inner list.
		/// <para xml:lang="es">La lista interna.</para>
		/// </summary>
		protected readonly Native.UIElementCollection InnerList;

		/// <summary>
		/// Gets or sets the ControlList at the specified index.
		/// <para xml:lang="es">
		/// Obtiene o establece el ControlList en el indice especificado.
		/// </para>
		/// </summary>
		/// <param name="index">Indice
		/// <para xml:lang="es">El indice especificado.</para>
		/// </param>
		/// <returns>The control.
		/// <para xml:lang="es">El control.</para>
		/// </returns>
		public IControl this[int index]
		{
			get
			{
				return (IControl) InnerList[index];
			}
			set
			{
				InnerList[index] = (System.Windows.FrameworkElement) value;
			}
		}

		/// <summary>
		/// Gets the count.
		/// <para xml:lang="es">
		/// Obtiene el conteo de los controles.
		/// </para>
		/// </summary>
		public int Count
		{
			get
			{
				return InnerList.Count;
			}
		}

		/// <summary>
		/// Gets the is read only.
		/// <para xml:lang="es">
		/// Determina si es de solo lectura.
		/// </para>
		/// </summary>
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Add the specified item.
		/// <para xml:lang="es">
		/// Agrega el elemento especificado.
		/// </para>
		/// </summary>
		/// <param name="item">The item specific
		/// <para xml:lang="es">El elemento especificado.</para>
		/// </param>
		public void Add(IControl item)
		{
			InnerList.Add((System.Windows.FrameworkElement) item);
		}

		/// <summary>
		/// Clear this instance.
		/// <para xml:lang="es">
		/// Limpia esta instancia.
		/// </para>
		/// </summary>
		public void Clear()
		{
			InnerList.Clear();
		}

		/// <summary>
		/// Contains the specified item.
		/// <para xml:lang="es">
		/// Determina si la lista contiene el elemento especificado.
		/// </para>
		/// </summary>
		/// <param name="item">Item
		/// <paraxml:lang="es">El elemento especificado</lang>
		/// </param>
		/// <returns>
		/// True if the specified control exists, otherwise false.
		/// <para xml:lang="es">
		/// Verdadero si existe el control especificado, de lo contrario es falso.
		/// </para>
		/// </returns>
		public bool Contains(IControl item)
		{
			return InnerList.Contains((System.Windows.FrameworkElement) item);
		}

		/// <summary>
		/// Copies to.
		/// <para xml:lang="es">
		/// Copia el control especificado al indice especificado del arreglo.
		/// </para>
		/// </summary>
		/// <param name="array">Array
		/// <para xml:lang="es">El arreglo</para>
		/// </param>
		/// <param name="arrayIndex">Array index
		/// <para xml:lang="es">El indice del arreglo.</para>
		/// </param>
		public void CopyTo(IControl[] array, int arrayIndex)
		{
			InnerList.CopyTo((System.Windows.FrameworkElement[]) array, arrayIndex);
		}

		/// <summary>
		/// Gets the enumerator.
		/// <para xml:lang="es">
		/// Obtiene la lista de controles.
		/// </para>
		/// </summary>
		/// <returns>The enumerator</returns>
		public IEnumerator<IControl> GetEnumerator()
		{
			foreach (System.Windows.FrameworkElement view in InnerList)
			{
				yield return (IControl) view;
			}
		}

		/// <summary>
		/// Indexs the of.
		/// <para xml:lang="es">
		/// Devuelve el indice del elemento especificado.
		/// </para>
		/// </summary>
		/// <param name="item">Item.
		/// <para xml:lang="es">El elemento.</para>
		/// </param>
		/// <returns>The of.
		/// <para xml:lang="es">El indice</para>
		/// </returns>
		public int IndexOf(IControl item)
		{
			return InnerList.IndexOf((System.Windows.FrameworkElement) item);
		}

		/// <summary>
		/// Insert the specified index and item.
		/// <para xml:lang="es">
		/// Inserta el elemento en el indice especificado.
		/// </para>
		/// </summary>
		/// <param name="index">Index
		/// <para xml:lang="es">El indice</para>
		/// </param>
		/// <param name="item">Item.
		/// <para xml:lang="es">El elemento.</para>
		/// </param>
		public void Insert(int index, IControl item)
		{
			InnerList.Insert(index, (System.Windows.FrameworkElement) item);
		}

		/// <summary>
		/// Remove the specified item.
		/// <para xml:lang="es">
		/// Elimina el elemento especificado.
		/// </para>
		/// </summary>
		/// <param name="item">Item
		/// <para xml:lang="es">El elemento.</para>
		/// </param>
		/// <returns>True.</returns>
		public bool Remove(IControl item)
		{
			InnerList.Remove((System.Windows.FrameworkElement) item);

			return true;
		}

		/// <summary>
		/// Removes at index.
		/// <para xml:lang="es">
		/// Elimina el elemento que se encuentra en el indice especificado.
		/// </para>
		/// </summary>
		/// <param name="index">Index
		/// <para xml:lang="es">El indice.</para>
		/// </param>
		public void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

		/// <summary>
		/// The collections IEnumerable. get enumerator.
		/// <para xml:lang="es">
		/// Devuelve la coleccion que jay en la enumeracion.
		/// </para>
		/// </summary>
		/// <returns>The collections IEnumerable get enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}