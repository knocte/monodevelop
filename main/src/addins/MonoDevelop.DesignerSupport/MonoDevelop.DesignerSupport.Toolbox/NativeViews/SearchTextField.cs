/* 
 * SearchTextField.cs - Native search field implementing INativeChildView
 * 
 * Author:
 *   Jose Medrano <josmed@microsoft.com>
 *
 * Copyright (C) 2018 Microsoft, Corp
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN
 * NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

#if MAC
using System;
using AppKit;
using Foundation;

namespace MonoDevelop.DesignerSupport.Toolbox.NativeViews
{
	enum SearchTextFieldCommand
	{
		InsertTab,
		InsertBacktab
	}

	class SearchTextField : NSSearchField, INSSearchFieldDelegate
	{
		public event EventHandler Focused;
		public event EventHandler<SearchTextFieldCommand> CommandRaised;

		public SearchTextField ()
		{
			Delegate = this;
		}

		public override bool BecomeFirstResponder ()
		{
			Focused?.Invoke (this, EventArgs.Empty);
			return base.BecomeFirstResponder ();
		}

		[Export ("control:textView:doCommandBySelector:")]
		bool CommandBySelector (NSControl control, NSTextField field, ObjCRuntime.Selector sel)
		{
			switch (sel.Name) {
			case "insertTab:": // down arrow
				CommandRaised?.Invoke (this, SearchTextFieldCommand.InsertTab);
				return true;

			case "insertBacktab:": // up arrow
				CommandRaised?.Invoke (this, SearchTextFieldCommand.InsertBacktab);
				return true;
			}
			return false;
		}
	}
}
#endif