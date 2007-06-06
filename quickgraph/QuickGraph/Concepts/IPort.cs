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


using System;

namespace QuickGraph.Concepts
{
	/// <summary>
	/// A port represents an anchor between an edge and a vertex
	/// </summary>
	public interface IPort
	{
		/// <summary>
		/// Port identification number
		/// </summary>
		int ID {get;set;}

		/// <summary>
		/// The name of the port
		/// </summary>
		String name {get;set;}

		/// <summary>
		/// Gets or sets the parent vertex
		/// </summary>
		/// <value>
		/// The parent <see cref="IVertex"/> instance
		/// </value>
		IVertex Parent {get;set;}
	}
}
