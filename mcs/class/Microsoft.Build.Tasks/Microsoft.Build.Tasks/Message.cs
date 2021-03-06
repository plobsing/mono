//
// Message.cs: Represents a message.
//
// Author:
//   Marek Sieradzki (marek.sieradzki@gmail.com)
//
// (C) 2005 Marek Sieradzki
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#if NET_2_0

using Microsoft.Build.Framework; 
using Microsoft.Build.Tasks;

namespace Microsoft.Build.Tasks {
	public sealed class Message : TaskExtension {
	
		string			importance;
		string			text;
	
		public Message ()
		{
		}

		public override bool Execute ()
		{
			if (text == null)
				return true;

			MessageImportance	messageImportance;
			
			if (importance == null)
				messageImportance = MessageImportance.Normal;
			else if (importance.ToLower () == "low")
				messageImportance = MessageImportance.Low;
			else if (importance.ToLower () == "normal")
				messageImportance = MessageImportance.Normal;
			else if (importance.ToLower () == "high")
				messageImportance = MessageImportance.High;
			else {
				return false;
			}
			
			Log.LogMessage (messageImportance, text, null);

			return true;
		}
		
		public string Importance {
			get { return importance; }
			set { importance = value; }
		}

		public string Text {
			get { return text; }
			set { text = value; }
		}
	}
}

#endif
