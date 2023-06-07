
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides an interface for adding observers to a tick event, called each update, once per frame. </summary>
	public interface ITicker
	{
		/// <summary> Adds an observer event handler to the tick event, invoked once per frame. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		void StartTick(InputAction<FrameOfTime> handler);

		/// <summary> Adds an observer event handler to the tick event, invoked once per frame. </summary>
		/// <param name="handler"> The event handler to add. </param>
		/// <param name="priority"> The order in which the event handler will be called. </param>
		void StartTick(InputAction<FrameOfTime> handler, int priority);

		/// <summary> Removes an observer event handler from the tick event. </summary>
		/// <param name="handler"> The event handler to be removed. </param>
		void StopTick(InputAction<FrameOfTime> handler);
	}
}
