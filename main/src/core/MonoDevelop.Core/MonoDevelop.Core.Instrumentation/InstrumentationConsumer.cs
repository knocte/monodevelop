// 
// IInstrumentationConsumer.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#nullable enable

using System;

namespace MonoDevelop.Core.Instrumentation
{
	/// <summary>
	/// An instrumentation consumer can consume values generated by counters
	/// </summary>
	[Mono.Addins.TypeExtensionPoint]
	public abstract class InstrumentationConsumer
	{
		/// <summary>
		/// Returns true if this consumer can handle the provided counter
		/// </summary>
		/// <returns><c>true</c>, if the counter is supported, <c>false</c> otherwise.</returns>
		/// <param name="counter">The counter</param>
		public abstract bool SupportsCounter (Counter counter);

		/// <summary>
		/// Invoked when a new value is registered for a counter. It won't be invoked for timers.
		/// </summary>
		/// <param name="counter">The counter</param>
		/// <param name="value">The value</param>
		public virtual void ConsumeValue (Counter counter, CounterValue value)
		{
		}

		/// <summary>
		/// Invoked when a new timer is started.
		/// </summary>
		/// <returns>An IDisposable object that is disposed when the timing operation ends.</returns>
		/// <param name="counter">The timer counter</param>
		/// <param name="value">The value</param>
		public virtual IDisposable? BeginTimer (TimerCounter counter, CounterValue value)
		{
			return null;
		}
	}
}

