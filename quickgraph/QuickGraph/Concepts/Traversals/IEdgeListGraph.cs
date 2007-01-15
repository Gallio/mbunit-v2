// QuickGraph Library 
// 
// Copyright (c) 2004 Jonathan de Halleux
//
// This software is provided 'as-is', without any express or implied warranty. 
// 
// In no event will the authors be held liable for any damages arising from 
// the use of this software.
// Permission is granted to anyone to use this software for any purpose, 
// including commercial applications, and to alter it and redistribute it 
// freely, subject to the following restrictions:
//
//		1. The origin of this software must not be misrepresented; 
//		you must not claim that you wrote the original software. 
//		If you use this software in a product, an acknowledgment in the product 
//		documentation would be appreciated but is not required.
//
//		2. Altered source versions must be plainly marked as such, and must 
//		not be misrepresented as being the original software.
//
//		3. This notice may not be removed or altered from any source 
//		distribution.
//		
//		QuickGraph Library HomePage: http://mbunit.tigris.org
//		Author: Jonathan de Halleux


namespace QuickGraph.Concepts.Traversals
{
	using System;
	using QuickGraph.Concepts.Collections;

	/// <summary>
	/// The EdgeListGraph concept refines the Graph concept, 
	/// and adds the requirement for efficient access to all the edges in the 
	/// graph. 
	/// </summary>
	/// <remarks>
	/// <seealso cref="IGraph"/>
	/// </remarks>
	public interface IEdgeListGraph : IGraph
	{
		/// <summary>
		/// Gets a value indicating if the vertex set is empty
		/// </summary>
		/// <remarks>
		/// <para>
		/// Usually faster that calling <see cref="EdgesCount"/>.
		/// </para>
		/// </remarks>
		/// <value>
		/// true if the vertex set is empty, false otherwise.
		/// </value>
		bool EdgesEmpty {get;}

		/// <summary>
		/// Returns the number of edges in the graph.
		/// </summary>
		int EdgesCount {get;}

		/// <summary>
		/// Returns an enumerator providing access to all the edges in the graph.
		/// </summary>
		IEdgeEnumerable Edges {get;}

		/// <summary>
		/// Gets a value indicating if the edge <paramref name="e"/> is part
		/// of the list.
		/// </summary>
		/// <param name="e">edge to test</param>
		/// <returns>true if part of the list, false otherwize</returns>
		/// <exception cref="ArgumentNullException">e is a null reference</exception>
		/// <remarks>
		/// This method checks wheter a particular edge is part of the set.
		/// <para>
		/// Complexity: O(E).
		/// </para>
		/// </remarks>
		bool ContainsEdge(IEdge e);
	}
}
